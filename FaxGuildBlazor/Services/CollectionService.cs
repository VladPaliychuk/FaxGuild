using EFCollections.BLL.DTO.Responses;

namespace FaxGuildBlazor.Services
{
    public class CollectionService
    {
        public HttpClient HttpClient { get; set; }

        public CollectionService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        /*public async Task<IEnumerable<CollectionResponse>> GetAllAsync()
        {
            var url = HttpClient.BaseAddress;
        }*/
    }
}
