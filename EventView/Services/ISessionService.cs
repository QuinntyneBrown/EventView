using EventView.Dtos;
using System.Collections.Generic;

namespace EventView.Services
{
    public interface ISessionService
    {
        SessionAddOrUpdateResponseDto AddOrUpdate(SessionAddOrUpdateRequestDto request);
        ICollection<SessionDto> Get();
        SessionDto GetById(int id);
        dynamic Remove(int id);
    }
}
