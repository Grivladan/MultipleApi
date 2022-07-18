using Moq;
using MultipleApiQueriesTest.Clients;
using MultipleApiQueriesTest.Clients.Requests;
using MultipleApiQueriesTest.DomainLogic;
using System.Threading;
using Xunit;

namespace MultipleApiQueriesTest.Tests
{
    public class OffersServiceTests
    {
        public Mock<IApi1Client> api1ClientMock = new Mock<IApi1Client>();
        public Mock<IApi2Client> api2ClientMock = new Mock<IApi2Client>();
        public Mock<IApi3Client> api3ClientMock = new Mock<IApi3Client>();

        [Fact]
        public async void GetEmployeebyId()
        {
            decimal amount1 = 10M;
            decimal amount2 = 20M;
            decimal amount3 = 12M;

            api1ClientMock.Setup(p => p.ProcessOffers(It.IsAny<Api1Request>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Clients.Responses.Api1Response { Total = amount1});
            api2ClientMock.Setup(p => p.ProcessOffers(It.IsAny<Api2Request>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Clients.Responses.Api2Response { Amount = amount2 });
            api3ClientMock.Setup(p => p.ProcessOffers(It.IsAny<Api3Request>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Clients.Responses.Api3Response { Quote = amount3 });
            OffersService service = new OffersService(api1ClientMock.Object, api2ClientMock.Object, api3ClientMock.Object);
            decimal result = await service.GetBestDealAsync("sourceAddress", "destinationAddress", new[] { 1,2,3});
            Assert.Equal(amount1, result);
        }
    }
}
