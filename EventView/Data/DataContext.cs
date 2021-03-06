using System.Data.Entity;

namespace EventView.Data
{
    public class DataContext: DbContext, IDbContext
    {
        public DataContext()
            : base(nameOrConnectionString: "EventViewDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Models.Room> Rooms { get; set; }
        public DbSet<Models.Speaker> Speakers { get; set; }
        public DbSet<Models.Session> Sessions { get; set; }
        public DbSet<Models.Talk> Talks { get; set; }
        public DbSet<Models.Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        } 
    }
}
