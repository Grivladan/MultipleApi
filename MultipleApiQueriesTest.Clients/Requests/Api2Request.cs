namespace MultipleApiQueriesTest.Clients.Requests
{
    public class Api2Request
    {
        public string Consignee { get; set; }
        public string Consignor { get; set; }
        public int[] Cartons { get; set; }
    }
}
