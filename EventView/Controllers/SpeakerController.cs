using EventView.Dtos;
using EventView.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace EventView.Controllers
{
    [Authorize]
    [RoutePrefix("api/speaker")]
    public class SpeakerController : ApiController
    {
        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(SpeakerAddOrUpdateResponseDto))]
        public IHttpActionResult Add(SpeakerAddOrUpdateRequestDto dto) { return Ok(_speakerService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(SpeakerAddOrUpdateResponseDto))]
        public IHttpActionResult Update(SpeakerAddOrUpdateRequestDto dto) { return Ok(_speakerService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<SpeakerDto>))]
        public IHttpActionResult Get() { return Ok(_speakerService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(SpeakerDto))]
        public IHttpActionResult GetById(int id) { return Ok(_speakerService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_speakerService.Remove(id)); }

        protected readonly ISpeakerService _speakerService;        
    }
}
