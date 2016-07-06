namespace EventView.Dtos
{
    public class SpeakerDto
    {
        public SpeakerDto(EventView.Models.Speaker entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public SpeakerDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
