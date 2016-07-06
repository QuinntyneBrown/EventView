using System.ComponentModel.DataAnnotations.Schema;

namespace EventView.Models
{
    public class Session
    {
        public int Id { get; set; }
        [ForeignKey("Talk")]
        public int? TalkId  { get; set; }
        public string Name { get; set; }        
        public bool IsDeleted { get; set; }        
        public Talk Talk { get; set; }
    }
}
