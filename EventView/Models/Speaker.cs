using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventView.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [ForeignKey("Image")]
        public int? ImageId { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string GitHub { get; set; }
        public string Twitter { get; set; }
        public Image Image { get; set; }
        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
        public bool IsDeleted { get; set; }
    }
}
