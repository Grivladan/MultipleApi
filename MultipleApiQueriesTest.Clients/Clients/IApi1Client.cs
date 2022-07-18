using MultipleApiQueriesTest.Clients.Requests;
using MultipleApiQueriesTest.Clients.Responses;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleApiQueriesTest.Clients
{
    public interface IApi1Client
    {
        [Post("/api/v1/process_offers")]
        Task<Api1Response> ProcessOffers(Api1Request request, CancellationToken cancellationToken = default);
    }
}