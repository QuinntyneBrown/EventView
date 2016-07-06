using EventView.Dtos;
using EventView.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace EventView.Controllers
{
    [Authorize]
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(RoomAddOrUpdateResponseDto))]
        public IHttpActionResult Add(RoomAddOrUpdateRequestDto dto) { return Ok(_roomService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(RoomAddOrUpdateResponseDto))]
        public IHttpActionResult Update(RoomAddOrUpdateRequestDto dto) { return Ok(_roomService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<RoomDto>))]
        public IHttpActionResult Get() { return Ok(_roomService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(RoomDto))]
        public IHttpActionResult GetById(int id) { return Ok(_roomService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_roomService.Remove(id)); }

        protected readonly IRoomService _roomService;


    }
}
