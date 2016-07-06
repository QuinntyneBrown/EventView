using EventView.Dtos;
using System.Collections.Generic;

namespace EventView.Services
{
    public interface ITalkService
    {
        TalkAddOrUpdateResponseDto AddOrUpdate(TalkAddOrUpdateRequestDto request);
        ICollection<TalkDto> Get();
        TalkDto GetById(int id);
        dynamic Remove(int id);
    }
}
