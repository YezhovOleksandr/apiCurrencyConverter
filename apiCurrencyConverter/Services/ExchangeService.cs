using apiCurrencyConverter.Interfaces;
using apiCurrencyConverter.Models.Enumerator;
using Newtonsoft.Json.Linq;

namespace apiCurrencyConverter.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IConfiguration _configuration;

        public ExchangeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string Exchange(string fromCurrency, string toCurrency, double sum)
        {
            if (fromCurrency == Currency.eur || toCurrency == Currency.eur || fromCurrency == Currency.usd || toCurrency == Currency.usd || fromCurrency == Currency.uah || toCurrency == Currency.uah)
            {
                return "Exchanged rate will be : " + getJsonRates(fromCurrency, toCurrency) * sum;
            }

            return "Only available currencies are USD, EUR and UAH";
        }

        private double getJsonRates(string fromCurrency, string toCurrency)
        {

            string json;

            using (var client = new HttpClient())
            {
                json = client.GetStringAsync($"https://v6.exchangerate-api.com/v6/{_configuration.GetSection("API-key").Value!}/latest/{fromCurrency}").Result;
                var data = JObject.Parse(json);

                return double.Parse(data["conversion_rates"]![toCurrency]!.ToString());
            }
        }
    }
}
