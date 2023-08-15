using apiCurrencyConverter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiCurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ConverterController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpGet]
        [Route("/Convert")]
        public string ExchangeCurrency(string from, double value, string to) => _exchangeService.Exchange(from, to, value);

        [HttpGet]
        [Route("/GetAllAvailableCurrencies")]
        public string getAll()
        {
            return "Available currencies are EUR, USD and UAH";
        }
    }
}
