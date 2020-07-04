using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using apiMercantil.models;

namespace apiMercantil.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _client;

        public S3Service(IAmazonS3 client)
        {
            _client = client;
        }

        public async Task<S3Response> CreateBucketAsync(string bucketname)
        {
            try
            {
                if (await AmazonS3Util.DoesS3BucketExistV2Async(_client, bucketname))
                {
                    var putBucketResquest = new PutBucketRequest
                    {
                        BucketName = bucketname,
                        UseClientRegion = true
                    };

                    var response = await _client.PutBucketAsync(putBucketResquest);

                    return new S3Response
                    {
                        Message = response.ResponseMetadata.RequestId,
                        Status = response.HttpStatusCode
                    };
                }

            }
            catch (AmazonS3Exception e)
            {
                return new S3Response
                {
                    Status = e.StatusCode,
                    Message = e.Message
                };
            }

            catch (Exception e)
            {
                return new S3Response
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };
            }
            
            return new S3Response
            {
                Status = HttpStatusCode.InternalServerError,
                Message = "deu algum Error"
            };

        }
    }
}