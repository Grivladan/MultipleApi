using MultipleApiQueriesTest.Clients.Requests;
using MultipleApiQueriesTest.Clients.Responses;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleApiQueriesTest.Clients
{
    public interface IApi3Client
    {
        [Post("/api/v1/process_offers")]
        Task<Api3Response> ProcessOffers(Api3Request request, CancellationToken cancellationToken = default);
    }
}
