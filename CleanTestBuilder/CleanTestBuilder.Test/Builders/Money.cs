namespace CleanTestBuilder.Tests.Builders
{
    public class Money
    {
        public Money(double value, string currencyIsoCode)
        {
            CurrencyIsoCode = currencyIsoCode;
            Value = value;
        }

        public string CurrencyIsoCode { get; }
        public double Value { get; }
    }
}