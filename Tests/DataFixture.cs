using Microsoft.EntityFrameworkCore;
using System;

namespace Wagering.Tests
{
    public class DataFixture : IDisposable
    {
        public ApplicationDbContext Context { get; private set; }

        public DataFixture()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("test_data").Options;
            Context = new ApplicationDbContext(options);
            Context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    Context.Dispose();
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}