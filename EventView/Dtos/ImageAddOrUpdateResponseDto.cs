namespace EventView.Dtos
{
    public class ImageAddOrUpdateResponseDto: ImageDto
    {
        public ImageAddOrUpdateResponseDto(EventView.Models.Image entity)
            :base(entity)
        {

        }
    }
}
