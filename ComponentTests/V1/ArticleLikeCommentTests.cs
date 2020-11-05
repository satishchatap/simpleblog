namespace ComponentTests.V1
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class ArticleLikeCommentTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        public ArticleLikeCommentTests(CustomWebApplicationFactory factory) => this._factory = factory;

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

        private async Task<Tuple<Guid, string>> GetArticle(string articleId)
        {
            HttpClient client = this._factory.CreateClient();
            string actualResponseString = await client
                .GetStringAsync($"/api/v1/Articles/{articleId}")
                .ConfigureAwait(false);

            using StringReader stringReader = new StringReader(actualResponseString);
            using JsonTextReader reader = new JsonTextReader(stringReader) {DateParseHandling = DateParseHandling.None};

            JObject jsonResponse = await JObject.LoadAsync(reader)
                .ConfigureAwait(false);

            Guid.TryParse(jsonResponse["article"]!["articleId"]!.Value<string>(), out Guid getArticleId);
            var title=jsonResponse["article"]!["title"]!.Value<string>() ;

            return new Tuple<Guid, string>(getArticleId, title);
        }

        private async Task Comment(string article, string comment)
        {
            HttpClient client = this._factory.CreateClient();
            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("description",comment)
            });

            HttpResponseMessage response = await client.PatchAsync($"api/v1/Comments/{article}/Comment", content)
                .ConfigureAwait(false);

            await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        private async Task Like(string article)
        {
            HttpClient client = this._factory.CreateClient();

            HttpResponseMessage response = await client.PatchAsync($"api/v1/Likes/{article}/Like", null)
                .ConfigureAwait(false);

            await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        private async Task Delete(string article)
        {
            HttpClient client = this._factory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync($"api/v1/Articles/{article}")
                .ConfigureAwait(false);

            await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetArticle_Like_Comment_Like_Like_Delete()
        {
            Tuple<Guid, string> article = await this.GetArticles()
                .ConfigureAwait(false);
            await this.GetArticle(article.Item1.ToString())
                .ConfigureAwait(false);
            await this.Like(article.Item1.ToString())
                .ConfigureAwait(false);
            await this.Comment(article.Item1.ToString(), "Comment 1")
                .ConfigureAwait(false);
            await this.Comment(article.Item1.ToString(), "Comment 2")
                .ConfigureAwait(false);
            await this.Like(article.Item1.ToString())
                .ConfigureAwait(false);
            await this.Like(article.Item1.ToString())
                .ConfigureAwait(false);
            article = await this.GetArticles()
                .ConfigureAwait(false);

            await this.Delete(article.Item1.ToString())
                .ConfigureAwait(false);
        }
    }
}
