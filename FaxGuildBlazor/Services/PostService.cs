using EFCollections.BLL.DTO.Responses;
using Newtonsoft.Json;

namespace FaxGuildBlazor.Services
{
    public class PostService
    {
        public HttpClient HttpClient { get; set; }
        public PostService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<PostResponse>> GetAllAsync()
        {
            var url = HttpClient.BaseAddress;

            var response = await HttpClient.GetAsync($"{url}/Post/GetAsync");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<PostResponse>>(json);
        }

        public async Task<PostResponse> GetByIdAsync(int id)
        {
            var url = HttpClient.BaseAddress;
            var response = await HttpClient.GetAsync($"{url}/Post/GetByIdAsync?id={id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PostResponse>(json);
        }

        public async Task UpdateLikesAsync(int id)
        {
            var url = HttpClient.BaseAddress;
            var response = await HttpClient.PutAsync($"{url}/Post/UpdateLikesAsync?id={id}", null);
            response.EnsureSuccessStatusCode();
        }
    }
}
