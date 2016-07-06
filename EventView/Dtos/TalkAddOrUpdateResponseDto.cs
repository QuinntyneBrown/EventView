namespace EventView.Dtos
{
    public class TalkAddOrUpdateResponseDto: TalkDto
    {
        public TalkAddOrUpdateResponseDto(EventView.Models.Talk entity)
            :base(entity)
        {

        }
    }
}
