namespace EventView.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string GitHub { get; set; }
        public string Twitter { get; set; }
        public bool IsDeleted { get; set; }
    }
}
