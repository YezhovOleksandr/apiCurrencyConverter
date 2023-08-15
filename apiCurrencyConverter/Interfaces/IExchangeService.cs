namespace apiCurrencyConverter.Interfaces
{
    public interface IExchangeService
    {
        string Exchange(string fromCurrency, string toCurrency, double sum);
    }
}
