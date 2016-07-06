using System;
using System.Collections.Generic;
using EventView.Data;
using EventView.Dtos;
using System.Data.Entity;
using System.Linq;
using EventView.Models;

namespace EventView.Services
{
    public class SpeakerService : ISpeakerService
    {
        public SpeakerService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this.repository = uow.Speakers;
            this.cache = cacheProvider.GetCache();
        }

        public SpeakerAddOrUpdateResponseDto AddOrUpdate(SpeakerAddOrUpdateRequestDto request)
        {
            var entity = repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) repository.Add(entity = new Speaker());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new SpeakerAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<SpeakerDto> Get()
        {
            ICollection<SpeakerDto> response = new HashSet<SpeakerDto>();
            var entities = repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new SpeakerDto(entity)); }    
            return response;
        }


        public SpeakerDto GetById(int id)
        {
            return new SpeakerDto(repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow uow;
        protected readonly IRepository<Speaker> repository;
        protected readonly ICache cache;
    }
}
