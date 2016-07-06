using EventView.Dtos;
using EventView.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace EventView.Controllers
{
    [Authorize]
    [RoutePrefix("api/session")]
    public class SessionController : ApiController
    {
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(SessionAddOrUpdateResponseDto))]
        public IHttpActionResult Add(SessionAddOrUpdateRequestDto dto) { return Ok(_sessionService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(SessionAddOrUpdateResponseDto))]
        public IHttpActionResult Update(SessionAddOrUpdateRequestDto dto) { return Ok(_sessionService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<SessionDto>))]
        public IHttpActionResult Get() { return Ok(_sessionService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(SessionDto))]
        public IHttpActionResult GetById(int id) { return Ok(_sessionService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_sessionService.Remove(id)); }

        protected readonly ISessionService _sessionService;


    }
}
