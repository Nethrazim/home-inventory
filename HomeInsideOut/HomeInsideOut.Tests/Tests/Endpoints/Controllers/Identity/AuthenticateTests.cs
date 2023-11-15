using FluentAssertions;
using HomeInsideOut.Api;
using HomeInsideOut.Api.Entities.Requests;
using HomeInsideOut.Tests.Common;
using HomeInsideOut.Tests.Entities.Responses;
using HomeInsideOut.Tests.Factories;
using HomeInsideOut.Tests.Utilities;
using Shared.DataLayer.Data;
using System.Net;

namespace HomeInsideOut.Tests.Tests.Endpoints.Controllers.Identity
{
    [Collection("API collection")]
    public class AuthenticateIntegrationTest : BaseIntegrationTest
    {
        private string endpointUri = "api/Identity/authenticate";
        public AuthenticateIntegrationTest(GenericWebApplicationFactory<Program, HomeInsideOutContext, SeedData> factory)
            : base(factory.CreateClient())
        { }

        [Fact]
        public async Task AuthenticateSuccesfully()
        {
            var request = new AuthenticateRequest() { Username = "User1", Password = "asd" };

            var (response, httpResponse) = await requestHelper.sendGet<AuthenticateRequest, AuthenticateResponse>(
                endpointUri, request, string.Empty);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            response?.Entity.Should().NotBeNullOrEmpty();
        }
    }
}
