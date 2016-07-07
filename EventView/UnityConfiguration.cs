using EventView.Configuration;
using EventView.Data;
using EventView.Services;
using EventView.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EventView
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer().AddNewExtension<Interception>();
            container.RegisterType<IDbContext, DataContext>();
            container.RegisterType<IUow, Uow>();
            container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            container.RegisterType<IIdentityService, IdentityService>();
            container.RegisterType<ILoggerFactory, LoggerFactory>();
            container.RegisterType<ICacheProvider, CacheProvider>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IRoomService, RoomService>();
            container.RegisterType<ISpeakerService, ISpeakerService>();
            container.RegisterType<ISessionService, SessionService>();
            container.RegisterType<ITalkService, TalkService>();
            container.RegisterType<IImageService, ImageService>();
            
            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}
