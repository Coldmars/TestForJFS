using Newtonsoft.Json;

namespace JFS.DataAccessLayer.Entities
{
    public class Balance
    {
        [JsonProperty("balance")]
        public ICollection<Entry> Entries { get; set; }
    }
}
