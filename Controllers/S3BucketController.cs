using System.Threading.Tasks;
using apiMercantil.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiMercantil.Controllers
{
    [Route("api/[controller]")]
    public class S3BucketController : ControllerBase
    {
        private readonly IS3Service _service;

        public S3BucketController(IS3Service service)
        {
            _service = service;
        }

        [HttpPost("{bucketName}")]
          public async Task<IActionResult> CreateBucket([FromRoute] string bucketName){

              var response = await _service.CreateBucketAsync(bucketName);

              return Ok();
          }
    }
}