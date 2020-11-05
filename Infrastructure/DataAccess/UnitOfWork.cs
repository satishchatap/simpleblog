namespace Infrastructure.DataAccess
{
    using System;
    using System.Threading.Tasks;
    using Application.Services;

    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private bool _disposed;

        public UnitOfWork(DataContext context) => this._context = context;

        /// <inheritdoc />
        public void Dispose() => this.Dispose(true);

        /// <inheritdoc />
        public async Task<int> Save()
        {
            int affectedRows = await this._context
                .SaveChangesAsync()
                .ConfigureAwait(false);
            return affectedRows;
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                this._context.Dispose();
            }

            this._disposed = true;
        }
    }
}