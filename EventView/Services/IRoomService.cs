using EventView.Dtos;
using System.Collections.Generic;

namespace EventView.Services
{
    public interface IRoomService
    {
        RoomAddOrUpdateResponseDto AddOrUpdate(RoomAddOrUpdateRequestDto request);
        ICollection<RoomDto> Get();
        RoomDto GetById(int id);
        dynamic Remove(int id);
    }
}
