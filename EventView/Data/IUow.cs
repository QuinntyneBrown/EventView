namespace EventView.Data
{
    public interface IUow
    {
        IRepository<Models.Room> Rooms { get; }
        IRepository<Models.Speaker> Speakers { get; }
        IRepository<Models.Session> Sessions { get; }
        IRepository<Models.Talk> Talks { get; }
        IRepository<Models.Image> Images { get; }

        void SaveChanges();
    }
}
