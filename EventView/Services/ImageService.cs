using System;
using System.Collections.Generic;
using EventView.Data;
using EventView.Dtos;
using System.Data.Entity;
using System.Linq;
using EventView.Models;

namespace EventView.Services
{
    public class ImageService : IImageService
    {
        public ImageService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this.repository = uow.Images;
            this.cache = cacheProvider.GetCache();
        }

        public ImageAddOrUpdateResponseDto AddOrUpdate(ImageAddOrUpdateRequestDto request)
        {
            var entity = repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) repository.Add(entity = new Image());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new ImageAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<ImageDto> Get()
        {
            ICollection<ImageDto> response = new HashSet<ImageDto>();
            var entities = repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ImageDto(entity)); }    
            return response;
        }


        public ImageDto GetById(int id)
        {
            return new ImageDto(repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow uow;
        protected readonly IRepository<Image> repository;
        protected readonly ICache cache;
    }
}
