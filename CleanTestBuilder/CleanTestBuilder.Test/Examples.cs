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

            Position position1 = A.Position
                .ThatIsValid();

            // caters for scenario were you need to be in control of all properties
            Position position2 = A.Position
                .WithIdentifier(Guid.NewGuid())
                .WithFixedLegNotional(
                    // notice the chained builder here, very powerful!
                    Some.Money
                        .WithValue(1_500_00)
                        .WithCurrencyIsoCode("EUR"))
                .WithFloatLegNotional(
                    Some.Money
                        .WithValue(2_480_00)
                        .WithCurrencyIsoCode("EUR"));

            // caters for scenario where you care for single property in your test but rest should be valid
            Position position3 = A.Position
                .WithIdentifier(Guid.NewGuid());
        }
    }
}
