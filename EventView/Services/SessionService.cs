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
    public class SessionService : ISessionService
    {
        public SessionService(IUow uow, ICacheProvider cacheProvider)
        {
            this._uow = uow;
            this._repository = uow.Sessions;
            this._cache = cacheProvider.GetCache();
        }

        public SessionAddOrUpdateResponseDto AddOrUpdate(SessionAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Session());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new SessionAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<SessionDto> Get()
        {
            ICollection<SessionDto> response = new HashSet<SessionDto>();
            var entities = GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new SessionDto(entity)); }    
            return response;
        }
        
        public SessionDto GetById(int id)
        {
            return new SessionDto(GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        private IQueryable<Session> GetAll() => _repository.GetAll()
                .Include(x => x.Speaker)
                .Include(x => x.Room)
                .Include(x => x.Talk);

        protected readonly IUow _uow;
        protected readonly IRepository<Session> _repository;
        protected readonly ICache _cache;
    }
}
