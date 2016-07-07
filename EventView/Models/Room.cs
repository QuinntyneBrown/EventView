using System.Collections.Generic;

namespace EventView.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
        public bool IsDeleted { get; set; }        
    }
}
