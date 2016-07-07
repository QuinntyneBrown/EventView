using EventView.Data;
using EventView.Dtos;
using EventView.Services;
using EventView.UploadHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.OutputCache.V2;
using static System.Drawing.Image;

namespace EventView.Controllers
{
    [Authorize]
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        public ImageController(IImageService imageService, IUow uow, ICacheProvider cacheProvider)
        {
            _imageService = imageService;
            _cache = cacheProvider.GetCache();
            _repository = uow.Images;
            _uow = uow;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ImageAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ImageAddOrUpdateRequestDto dto) { return Ok(_imageService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ImageAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ImageAddOrUpdateRequestDto dto) { return Ok(_imageService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ImageDto>))]
        public IHttpActionResult Get() { return Ok(_imageService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ImageDto))]
        public IHttpActionResult GetById(int id) { return Ok(_imageService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_imageService.Remove(id)); }

        [AllowAnonymous]
        [Route("upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> Upload(HttpRequestMessage request)
        {

            var entities = new List<Models.Image>();
            try
            {
                if (!Request.Content.IsMimeMultipartContent("form-data"))
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

                NameValueCollection formData = provider.FormData;
                IList<HttpContent> files = provider.Files;

                foreach (var file in files)
                {
                    var filename = new FileInfo(file.Headers.ContentDisposition.FileName.Trim(new char[] { '"' })
                        .Replace("&", "and")).Name;
                    Stream stream = await file.ReadAsStreamAsync();
                    var bytes = StreamHelper.ReadToEnd(stream);
                    var entity = new Models.Image();
                    entity.FileName = filename;
                    entity.Bytes = bytes;
                    entity.ContentType = System.Convert.ToString(file.Headers.ContentType);
                    _repository.Add(entity);
                    entities.Add(entity);
                }

                _uow.SaveChanges();
            }
            catch (Exception exception)
            {
                var e = exception;
            }

            return Request.CreateResponse(HttpStatusCode.OK, new ImageUploadResponseDto(entities));
        }

        [Route("serve")]
        [HttpGet]
        [AllowAnonymous]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Serve([FromUri]Guid uniqueId, int? height = null)
        {
            Models.Image entity = _cache.FromCacheOrService(() => _repository.GetAll().FirstOrDefault(x => x.UniqueId == uniqueId), uniqueId.ToString());
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            if (entity == null)
                return result;
            var memoryStream = new System.IO.MemoryStream(entity.Bytes);
            System.Drawing.Image fullsizeImage = FromStream(memoryStream);
            height = height.HasValue ? height : fullsizeImage.Height;
            var ratio = (float)height.Value / (float)fullsizeImage.Height;
            var width = fullsizeImage.Width * ratio;
            System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage((int)width, height.Value, null, IntPtr.Zero);
            var myResult = new System.IO.MemoryStream();
            newImage.Save(myResult, fullsizeImage.RawFormat);
            result.Content = new ByteArrayContent(myResult.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(entity.ContentType);
            return result;
        }

        protected readonly IImageService _imageService;
        protected readonly ICache _cache;
        protected readonly IRepository<Models.Image> _repository;
        protected readonly IUow _uow;


    }
}
