using MultipleApiQueriesTest.Clients;
using MultipleApiQueriesTest.Clients.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleApiQueriesTest.DomainLogic
{
    public class OffersService : IOffersService
    {
        private readonly IApi1Client _api1Client;
        private readonly IApi2Client _api2Client;
        private readonly IApi3Client _api3Client;
        public OffersService(IApi1Client api1Client, IApi2Client api2Client, IApi3Client api3Client)
        {
            _api1Client = api1Client ?? throw new ArgumentNullException(nameof(api1Client));
            _api2Client = api2Client ?? throw new ArgumentNullException(nameof(api2Client));
            _api3Client = api3Client ?? throw new ArgumentNullException(nameof(api3Client));
        }
        public async Task<decimal> GetBestDealAsync(string sourceAddress, string destinationAddress, int[] cartonDimension, CancellationToken cancellationToken = default)
        {
            Task<Api1Response> task1 =  _api1Client.ProcessOffers(new Clients.Requests.Api1Request 
                { 
                    ContactAddress = sourceAddress,
                    WarehouseAddress = destinationAddress,
                    Dimensions = cartonDimension
                });

            Task<Api2Response> task2 = _api2Client.ProcessOffers(new Clients.Requests.Api2Request
            {
                Consignee = sourceAddress,
                Consignor = destinationAddress,
                Cartons = cartonDimension
            });

            Task<Api3Response> task3 = _api3Client.ProcessOffers(new Clients.Requests.Api3Request
            {
                Source = sourceAddress,
                Destination = destinationAddress,
                Packages = cartonDimension
            });

            await Task.WhenAll(task1, task2, task3);

            var amountResponses = new List<decimal>();
            amountResponses.Add((await task1).Total);
            amountResponses.Add((await task2).Amount);
            amountResponses.Add((await task3).Quote);

            return amountResponses.Min();
        }
    }
}
