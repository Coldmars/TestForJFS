using JFS.DataAccessLayer.Entities;
using Newtonsoft.Json;

namespace JFS.DataAccessLayer.Context
{
    public class FilesContext : IFilesContext
    {
        public FilesContext()
        {
            Balance = DeserializeBalanceJson();
            Payments = DeserializePaymentJson();
        }

        public Balance Balance { get; set; }

        public IEnumerable<Payment> Payments { get; set; }

        private Balance DeserializeBalanceJson()
        {
            using StreamReader file = File.OpenText(@"./Data/balance_202105270825.json");
            JsonSerializer serializer = new();
            return (Balance)serializer.Deserialize(file, typeof(Balance));
        }

        private IEnumerable<Payment> DeserializePaymentJson()
        {
            using StreamReader file = File.OpenText(@"./Data/payment_202105270827.json");
            JsonSerializer serializer = new();
            
           return (IEnumerable<Payment>)serializer.Deserialize(file, typeof(IEnumerable<Payment>));
        }
    }
}
