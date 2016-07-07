using System;
using System.Collections.Generic;
using EventView.Data;
using EventView.Dtos;
using System.Data.Entity;
using System.Linq;
using EventView.Models;
using System.Data.Entity;

namespace EventView.Services
{
    public class SpeakerService : ISpeakerService
    {
        public SpeakerService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this._repository = uow.Speakers;
            this.cache = cacheProvider.GetCache();
        }

        public SpeakerAddOrUpdateResponseDto AddOrUpdate(SpeakerAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Speaker());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new SpeakerAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<SpeakerDto> Get()
        {
            ICollection<SpeakerDto> response = new HashSet<SpeakerDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new SpeakerDto(entity)); }    
            return response;
        }


        public SpeakerDto GetById(int id)
        {
            return new SpeakerDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        private IQueryable<Speaker> GetAll() => _repository.GetAll()
            .Include(x => x.Sessions);

        protected readonly IUow uow;
        protected readonly IRepository<Speaker> _repository;
        protected readonly ICache cache;
    }
}
