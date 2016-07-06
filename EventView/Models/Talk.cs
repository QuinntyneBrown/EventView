namespace EventView.Models
{
    public class Talk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public Level Level { get; set; }
    }
}
