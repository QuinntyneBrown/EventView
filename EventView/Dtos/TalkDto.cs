namespace EventView.Dtos
{
    public class TalkDto
    {
        public TalkDto(EventView.Models.Talk entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public TalkDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
