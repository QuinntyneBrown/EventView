namespace EventView.Dtos
{
    public class SpeakerAddOrUpdateResponseDto: SpeakerDto
    {
        public SpeakerAddOrUpdateResponseDto(EventView.Models.Speaker entity)
            :base(entity)
        {

        }
    }
}
