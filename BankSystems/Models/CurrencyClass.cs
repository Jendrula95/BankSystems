using System.ComponentModel;

namespace BankSystem.Models
{
    public class CurrencyClass
    {

        private static IList<CurrencyModel> repository = new List<CurrencyModel>() {
         new CurrencyModel()
         {
             NameExchanges = "EUR",
             Buy = 0.21M,
             Sell = 4.6M
         },
          new CurrencyModel()
         {
             NameExchanges = "USD",
             Buy = 0.23M,
             Sell = 4.32M
         },
           new CurrencyModel()
         {
             NameExchanges = "GBP",
             Buy = 0.19M,
             Sell = 5.28M
         },
            new CurrencyModel()
         {
             NameExchanges = "CHF",
             Buy = 0.21M,
             Sell = 4.67M
         }
        };
        public static IEnumerable<CurrencyModel> Currencies => repository;
        public static void addCurrency(CurrencyModel currency)
        {

            repository.Add(currency);
        }
    }
    public class CurrencyModel
    {
        [DisplayName("Waluta")]
        public string NameExchanges { get; set; }
        [DisplayName("Kupno")]
        public decimal Buy { get; set; }
        [DisplayName("Sprzedaż")]
        public decimal Sell { get; set; }
    }
}
