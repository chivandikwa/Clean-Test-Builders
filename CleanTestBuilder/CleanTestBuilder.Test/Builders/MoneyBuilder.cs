namespace CleanTestBuilder.Tests.Builders
{
    public class MoneyBuilder : Builder<Money>
    {

        public MoneyBuilder WithCurrencyIsoCode(string currencyIsoCode)
        {
            Set(x => x.CurrencyIsoCode, currencyIsoCode);
            return this;
        }

        public MoneyBuilder  WithValue(double value)
        {
            Set(x => x.Value, value);
            return this;
        }

        public MoneyBuilder ThatIsValid()
        {
            Set(x => x.CurrencyIsoCode, "EUR");
            Set(x => x.Value, 1_500_000);
            return this;
        }

        protected override Money Build() => new(Get(x => x.Value), Get(x => x.CurrencyIsoCode));
    }
}