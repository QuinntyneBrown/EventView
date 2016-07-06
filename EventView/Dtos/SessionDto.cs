namespace EventView.Dtos
{
    public class SessionDto
    {
        public SessionDto(EventView.Models.Session entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public SessionDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
