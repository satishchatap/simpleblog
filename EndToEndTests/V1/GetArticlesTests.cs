namespace EndToEndTests.V1
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("WebApi Collection")]
    public sealed class GetArticlesTests
    {
        private readonly CustomWebApplicationFactoryFixture _fixture;
        public GetArticlesTests(CustomWebApplicationFactoryFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task GetArticlesReturnsList()
        {
            HttpClient client = this._fixture
                .CustomWebApplicationFactory
                .CreateClient();

            HttpResponseMessage actualResponse = await client
                .GetAsync("/api/v1/Articles/")
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
        }
    }
}
