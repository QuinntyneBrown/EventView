using System;
using System.Collections.Generic;
using EventView.Dtos;
using EventView.Data;
using System.Linq;
using EventView.Models;
using System.Data.Entity;

namespace EventView.Services
{
    public class RoomService : IRoomService
    {
        public RoomService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Rooms;
            _cache = cacheProvider.GetCache();
        }

        public RoomAddOrUpdateResponseDto AddOrUpdate(RoomAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.Room());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new RoomAddOrUpdateResponseDto(entity);
        }

        public ICollection<RoomDto> Get()
        {
            ICollection<RoomDto> response = new HashSet<RoomDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new RoomDto(entity)); }
            return response;
        }

        public RoomDto GetById(int id)
        {
            return new RoomDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        private IQueryable<Room> GetAll() => _repository.GetAll()
            .Include(x => x.Sessions);

        protected readonly IUow _uow;
        protected readonly IRepository<Models.Room> _repository;
        protected readonly ICache _cache;
    }
}
