using EventView.Dtos;
using EventView.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace EventView.Controllers
{
    [Authorize]
    [RoutePrefix("api/talk")]
    public class TalkController : ApiController
    {
        public TalkController(ITalkService talkService)
        {
            _talkService = talkService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(TalkAddOrUpdateResponseDto))]
        public IHttpActionResult Add(TalkAddOrUpdateRequestDto dto) { return Ok(_talkService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(TalkAddOrUpdateResponseDto))]
        public IHttpActionResult Update(TalkAddOrUpdateRequestDto dto) { return Ok(_talkService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<TalkDto>))]
        public IHttpActionResult Get() { return Ok(_talkService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(TalkDto))]
        public IHttpActionResult GetById(int id) { return Ok(_talkService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_talkService.Remove(id)); }

        protected readonly ITalkService _talkService;        
    }
}
