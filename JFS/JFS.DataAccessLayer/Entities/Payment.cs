using Newtonsoft.Json;

namespace JFS.DataAccessLayer.Entities
{
    public class Payment
    {
        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("sum")]
        public double Sum { get; set; }

        [JsonProperty("payment_guid")]
        public string PaymentGuid { get; set; }
    }
}
