using System.Text.Json;
using MediatR;
using TechTest.Models;
using TechTest.Queries;

namespace TechTest.Handlers
{
    public class GetContributorsHandler : IRequestHandler<GetContributorsQuery, IEnumerable<Commit>?>
    {
        private const int ConfiguredResultAmount = 30;
        private readonly IHttpClientFactory _httpClientFactory;

        public GetContributorsHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Commit>?> Handle(GetContributorsQuery request, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient("githubClient");
            client.DefaultRequestHeaders.Add("User-Agent", "TechTest");
            var response = 
                await client.GetAsync($"/repos/{request.Owner}/{request.Repository}/commits", cancellationToken)
                    .ConfigureAwait(false);

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            if(response.IsSuccessStatusCode)
                return null;

            var commits = await response.Content.ReadFromJsonAsync<List<Commit>>(options, cancellationToken: cancellationToken);

            return commits?.Take(ConfiguredResultAmount);
        }
    }
}

