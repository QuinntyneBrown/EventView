using System;
using System.Collections.Generic;
using EventView.Data;
using EventView.Dtos;
using System.Data.Entity;
using System.Linq;
using EventView.Models;

namespace EventView.Services
{
    public class TalkService : ITalkService
    {
        public TalkService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this.repository = uow.Talks;
            this.cache = cacheProvider.GetCache();
        }

        public TalkAddOrUpdateResponseDto AddOrUpdate(TalkAddOrUpdateRequestDto request)
        {
            var entity = repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) repository.Add(entity = new Talk());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new TalkAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<TalkDto> Get()
        {
            ICollection<TalkDto> response = new HashSet<TalkDto>();
            var entities = repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new TalkDto(entity)); }    
            return response;
        }


        public TalkDto GetById(int id)
        {
            return new TalkDto(repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow uow;
        protected readonly IRepository<Talk> repository;
        protected readonly ICache cache;
    }
}
