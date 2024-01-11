using System.Text;

using Mango.Web.Models;
using Mango.Web.Service.IService;

using Newtonsoft.Json;

using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage messege = new();
                if (requestDto.ContentType == ContentType.MultipartFormData)
                {
                    messege.Headers.Add("Accept", "*/*");
                }
                else
                {
                    messege.Headers.Add("Accept", "application/json");
                }

                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    messege.Headers.Add("Authorization", $"Bearer {token}");
                }

                messege.RequestUri = new Uri(requestDto.Url);




                if (requestDto.ContentType == ContentType.MultipartFormData)
                {
                    var content = new MultipartFormDataContent();

                    foreach (var prop in requestDto.Data.GetType().GetProperties())
                    {
                        var value = prop.GetValue(requestDto.Data);
                        if (value is FormFile)
                        {
                            var file = (FormFile)value;
                            if (file != null)
                            {
                                content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                            }
                        }
                        else
                        {
                            content.Add(new StringContent(value == null ? "" : value.ToString()), prop.Name);
                        }
                    }
                    messege.Content = content;
                }
                else
                {
                    if (requestDto.Data != null)
                    {
                        messege.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                    }
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
