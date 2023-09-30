using System.Text;

using Mango.Web.Models;
using Mango.Web.Service.IService;

using Newtonsoft.Json;


namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage messege = new();
                messege.Headers.Add("Accept", "application/json");
                //token

                messege.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    messege.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case Utility.SD.ApiType.GET:
                        messege.Method = HttpMethod.Get;
                        break;
                    case Utility.SD.ApiType.POST:
                        messege.Method = HttpMethod.Post;
                        break;
                    case Utility.SD.ApiType.PUT:
                        messege.Method = HttpMethod.Put;
                        break;
                    case Utility.SD.ApiType.DELETE:
                        messege.Method = HttpMethod.Delete;
                        break;

                }


                apiResponse = await client.SendAsync(messege);

                switch (apiResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not found" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal server error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }
        }

    }
}
