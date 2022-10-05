using Newtonsoft.Json;

namespace JFS.DataAccessLayer.Entities
{
    public class Entry
    {
        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("in_balance")]
        public double InBalance { get; set; }

        [JsonProperty("calculation")]
        public double Calculation { get; set; }
    }
}
