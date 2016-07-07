using EventView.Dtos;
using System.Collections.Generic;

namespace EventView.Services
{
    public interface IImageService
    {
        ImageAddOrUpdateResponseDto AddOrUpdate(ImageAddOrUpdateRequestDto request);
        ICollection<ImageDto> Get();
        ImageDto GetById(int id);
        dynamic Remove(int id);
    }
}
