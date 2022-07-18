using System.Threading;
using System.Threading.Tasks;

namespace MultipleApiQueriesTest.DomainLogic
{
    public interface IOffersService
    {
        public Task<decimal> GetBestDealAsync(string sourceAddress, string destinationAddress, int[] cartonDimensions, CancellationToken cancellationToken = default);
    }
}
