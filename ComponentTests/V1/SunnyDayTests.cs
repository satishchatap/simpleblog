namespace ComponentTests.V2
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;
    /// <summary>
    /// Happy Path
    /// </summary>
    public sealed class SunnyDayTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        public SunnyDayTests(CustomWebApplicationFactory factory) => this._factory = factory;

        private async Task<Tuple<Guid, string>> GetArticles()
        {
            HttpClient client = this._factory.CreateClient();
            HttpResponseMessage actualResponse = await client
                .GetAsync("/api/v1/Articles/")
                .ConfigureAwait(false);

            string actualResponseString = await actualResponse.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            using StringReader stringReader = new StringReader(actualResponseString);
            using JsonTextReader reader = new JsonTextReader(stringReader) {DateParseHandling = DateParseHandling.None};

            JObject jsonResponse = await JObject.LoadAsync(reader)
                .ConfigureAwait(false);

            Guid.TryParse(jsonResponse["articles"]![0]!["articleId"]!.Value<string>(), out Guid articleId);
            var title = jsonResponse["articles"]![0]!["title"]!.Value<string>();

            return new Tuple<Guid, string>(articleId, title);
        }

        private async Task GetArticle(string articleId)
        {
            HttpClient client = this._factory.CreateClient();
            await client.GetAsync($"/api/v2/Articles/{articleId}")
                .ConfigureAwait(false);
        }

        [Fact]
        public async Task GetArticles_GetArticle()
        {
            Tuple<Guid, string> article = await this.GetArticles()
                .ConfigureAwait(false);
            await this.GetArticle(article.Item1.ToString())
                .ConfigureAwait(false);
        }
    }
}
