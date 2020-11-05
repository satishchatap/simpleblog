namespace IntegrationTests.EntityFrameworkTests
{
    using System;
    using Infrastructure.DataAccess;
    using Microsoft.EntityFrameworkCore;

    public sealed class StandardFixture : IDisposable
    {
        public StandardFixture()
        {    
            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "SimpleBlogDatabase")
                .Options;

            this.Context = new DataContext(options);
            this.Context
                .Database
                .EnsureCreated();
        }

        public DataContext Context { get; }

        public void Dispose() => this.Context.Dispose();
    }
}
