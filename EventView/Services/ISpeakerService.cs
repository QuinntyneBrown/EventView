using EventView.Dtos;
using System.Collections.Generic;

namespace EventView.Services
{
    public interface ISpeakerService
    {
        SpeakerAddOrUpdateResponseDto AddOrUpdate(SpeakerAddOrUpdateRequestDto request);
        ICollection<SpeakerDto> Get();
        SpeakerDto GetById(int id);
        dynamic Remove(int id);
    }
}
