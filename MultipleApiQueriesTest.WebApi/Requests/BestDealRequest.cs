namespace MultipleApiQueriesTest.WebApi.Requests
{
    public class BestDealRequest
    {
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public int[] CartonDimensions { get; set; }
    }
}
