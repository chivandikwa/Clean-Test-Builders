namespace CleanTestBuilder.Tests
{
    using System;
    using Builders;
    using Xunit;

    public class Sample
    {
        [Fact]
        public void Examples()
        {
            // caters for the common scenario, you just need a valid positioni

            TradePosition position1 = A.TradePosition
                .ThatIsValid();

            // caters for scenario were you need to be in control of all properties
            TradePosition position2 = A.TradePosition
                .WithIdentifier(Guid.NewGuid())
                .WithFixedLegNotional(
                    // notice the chained builder here, very powerful!
                    Some.TradeValue
                        .WithValue(1_500_00)
                        .WithCurrencyIsoCode("EUR"))
                .WithFloatLegNotional(
                    Some.TradeValue
                        .WithValue(2_480_00)
                        .WithCurrencyIsoCode("EUR"));

            // caters for scenario where you care for single property in your test but rest should be valid
            TradePosition position3 = A.TradePosition
                .WithIdentifier(Guid.NewGuid());
        }
    }
}
