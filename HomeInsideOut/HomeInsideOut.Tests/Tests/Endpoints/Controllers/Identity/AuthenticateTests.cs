using HomeInsideOut.Api;
using HomeInsideOut.Tests.Factories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using HomeInsideOut.DataLayer.Data;
using HomeInsideOut.Tests.Utilities;
using HomeInsideOut.DataLayer.Models;
using HomeInsideOut.Tests.Entities.Responses;
using FluentAssertions;
using HomeInsideOut.Tests.Common;
using HomeInsideOut.Api.Entities.Requests;

namespace HomeInsideOut.Tests.Tests.Endpoints.Controllers.Identity
{
    [Collection("Context collection")]
    public class AuthenticateIntegrationTest : BaseIntegrationTest
    {
        private string endpointUri = "api/Identity/authenticate";
        public AuthenticateIntegrationTest(GenericWebApplicationFactory<Program, HomeInsideOutContext, SeedData> factory)
            : base(factory.CreateClient())
        {

        }

        [Fact]
        public async Task AuthenticateSuccesfully()
        {
            var request = new AuthenticateRequest() { Username = "test1", Password = "test1" };

            var (response, httpResponse) = await requestHelper.sendGet<AuthenticateRequest, AuthenticateResponse>(
                endpointUri, request, string.Empty);
            
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            response?.Entities.Should().NotBeNullOrEmpty();
            response?.Entities.Should().HaveCount(1);
        }
    }
}
