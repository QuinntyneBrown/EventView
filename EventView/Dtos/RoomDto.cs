namespace EventView.Dtos
{
    public class RoomDto
    {
        public RoomDto()
        {

        }

        public RoomDto(Models.Room entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
