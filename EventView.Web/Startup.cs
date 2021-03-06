using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;
using EventView.Configuration;
using Microsoft.Practices.Unity;
using System;
using EventView.Trace;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using SerilogWeb.Classic.Enrichers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;

[assembly: OwinStartup(typeof(EventView.Web.Startup))]

namespace EventView.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(config =>
            {
                var container = UnityConfiguration.GetContainer();
                InitLogging(container);
                config.DependencyResolver = new UnityDependencyResolver(container);
                EventView.ApiConfiguration.Install(config, app);
            });
        }

        public static void InitLogging(IUnityContainer container)
        {
            var settings = container.Resolve<Lazy<ITraceConfiguration>>();
            var traceService = new TraceService();

            traceService.Performance = CreateLogger(settings.Value, "performance-{Date}.txt", "Performance", new Collection<DataColumn>
            {
                new DataColumn {DataType = typeof(string), ColumnName = "OperationName" },
                new DataColumn {DataType = typeof(int), ColumnName = "TimeTakenMsec" },
                new DataColumn {DataType = typeof(string), ColumnName = "OperationResult" },
                new DataColumn {DataType = typeof(DateTime), ColumnName = "StartedTime" }
            });

            container.RegisterInstance<ITraceService>(traceService);
        }

        public static Serilog.ILogger CreateLogger(ITraceConfiguration settings, string fileName = null, string tableName = null, ICollection<DataColumn> additionalColumns = null, bool? logToFile = null, bool? logToSql = null)
        {
            var logsPath = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME"))
                ? Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                : Path.Combine(Environment.GetEnvironmentVariable("HOME"), "LogFiles");

            var logger = new LoggerConfiguration()
                .Enrich.With<HttpRequestIdEnricher>()
                .Enrich.With<UserNameEnricher>()
                .Enrich.With<EventIdEnricher>();

            if (logToFile ?? settings.LogToFile && !string.IsNullOrEmpty(fileName))
            {
                logger = logger.WriteTo.RollingFile(Path.Combine(logsPath, fileName), fileSizeLimitBytes: null);
            }

            if (logToSql ?? Convert.ToBoolean(settings.LogToSql) &&
                !string.IsNullOrEmpty(settings.LoggingSqlServerConnectionString) &&
                !string.IsNullOrEmpty(tableName))
            {
                var columnOptions = new ColumnOptions
                {
                    AdditionalDataColumns = new Collection<DataColumn>
                    {
                        new DataColumn {DataType = typeof(string), ColumnName = "UserName"},
                        new DataColumn {DataType = typeof(string), ColumnName = "HttpRequestId"},
                        new DataColumn {DataType = typeof(int), ColumnName = "EventId"}
                    }
                    .Union(additionalColumns ?? Enumerable.Empty<DataColumn>())
                    .ToList()
                };
                logger = logger.WriteTo
                    .MSSqlServer(settings.LoggingSqlServerConnectionString, tableName, columnOptions: columnOptions);
            }
            return logger.CreateLogger();
        }
    }
}
