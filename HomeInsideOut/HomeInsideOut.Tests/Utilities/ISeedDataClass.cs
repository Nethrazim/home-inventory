using HomeInsideOut.DataLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeInsideOut.Tests.Utilities
{
    public interface ISeedDataClass<TContext> where TContext : DbContext
    {
        public void Seed(TContext dbContext);
    }
}