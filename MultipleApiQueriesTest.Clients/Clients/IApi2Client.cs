using MultipleApiQueriesTest.Clients.Requests;
using MultipleApiQueriesTest.Clients.Responses;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleApiQueriesTest.Clients
{
    public interface IApi2Client
    {
        [Post("/api/v1/process_offers")]
        Task<Api2Response> ProcessOffers(Api2Request request, CancellationToken cancellationToken = default);
    }
}
