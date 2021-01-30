namespace CleanTestBuilder.Tests.Builders
{
    public class TradeValueBuilder : Builder<TradeValue>
    {

        public TradeValueBuilder WithCurrencyIsoCode(string currencyIsoCode)
        {
            Set(x => x.CurrencyIsoCode, currencyIsoCode);
            return this;
        }

        public TradeValueBuilder  WithValue(double value)
        {
            Set(x => x.Value, value);
            return this;
        }

        public TradeValueBuilder ThatIsValid()
        {
            Set(x => x.CurrencyIsoCode, "EUR");
            Set(x => x.Value, 1_500_000);
            return this;
        }

        protected override TradeValue Build() => new(Get(x => x.Value), Get(x => x.CurrencyIsoCode));
    }
}