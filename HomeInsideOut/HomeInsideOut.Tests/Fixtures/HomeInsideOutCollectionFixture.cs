using HomeInsideOut.Api;
using HomeInsideOut.DataLayer.Data;
using HomeInsideOut.Tests.Factories;
using HomeInsideOut.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Tests.Fixtures
{
    [CollectionDefinition("Context collection")]
    public class HomeInsideOutCollectionFixture : ICollectionFixture<GenericWebApplicationFactory<Program, HomeInsideOutContext, SeedData>>
    {

    }
}
