using System.ComponentModel.DataAnnotations.Schema;

namespace EventView.Models
{
    public class Session
    {
        public int Id { get; set; }
        [ForeignKey("Talk")]
        public int? TalkId  { get; set; }
        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        [ForeignKey("Speaker")]
        public int? SpeakerId { get; set; }
        public string Name { get; set; }        
        public bool IsDeleted { get; set; }        
        public Talk Talk { get; set; }
        public Room Room { get; set; }
        public Speaker Speaker { get; set; }
    }
}
