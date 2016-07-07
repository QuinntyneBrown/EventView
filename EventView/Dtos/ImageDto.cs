namespace EventView.Dtos
{
    public class ImageDto
    {
        public ImageDto(EventView.Models.Image entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public ImageDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
