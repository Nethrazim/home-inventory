using HomeInsideOut.Api;
using HomeInsideOut.Tests.Factories;
using HomeInsideOut.Tests.Utilities;
using Shared.DataLayer.Data;

namespace HomeInsideOut.Tests.Fixtures
{
    [CollectionDefinition("API collection")]
    public class HomeInsideOutCollectionFixture : ICollectionFixture<GenericWebApplicationFactory<Program, HomeInsideOutContext, SeedData>>
    {

    }
}
