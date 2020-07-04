using System.Threading.Tasks;
using apiMercantil.models;

namespace apiMercantil.Services
{
    public interface IS3Service
    {
         Task<S3Response> CreateBucketAsync(string bucketName);
    }
}