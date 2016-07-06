using System;
using System.Collections.Generic;
using EventView.Data;
using EventView.Dtos;
using System.Data.Entity;
using System.Linq;
using EventView.Models;

namespace EventView.Services
{
    public class SessionService : ISessionService
    {
        public SessionService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this.repository = uow.Sessions;
            this.cache = cacheProvider.GetCache();
        }

        public SessionAddOrUpdateResponseDto AddOrUpdate(SessionAddOrUpdateRequestDto request)
        {
            var entity = repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) repository.Add(entity = new Session());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new SessionAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<SessionDto> Get()
        {
            ICollection<SessionDto> response = new HashSet<SessionDto>();
            var entities = repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new SessionDto(entity)); }    
            return response;
        }


        public SessionDto GetById(int id)
        {
            return new SessionDto(repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow uow;
        protected readonly IRepository<Session> repository;
        protected readonly ICache cache;
    }
}
