namespace Infrastructure.DataAccess
{
    using Application.Services;
    using System.Threading.Tasks;

    /// <summary>
    /// </summary>
    public sealed class UnitOfWorkFake : IUnitOfWork
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<int> Save() => await Task.FromResult(0)
            .ConfigureAwait(false);
    }
}
