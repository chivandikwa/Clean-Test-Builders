namespace CleanTestBuilder.Tests.Builders
{
    using System;

    public class TradePositionBuilder : Builder<TradePosition>
    {
        public TradePositionBuilder WithIdentifier(Guid identifier)
        {
            Set(x => x.Identifier, identifier);
            return this;
        }

        public TradePositionBuilder WithFloatLegNotional(TradeValue tradeValue)
        {
            Set(x => x.FloatLegNotional, tradeValue);
            return this;
        }

        public TradePositionBuilder WithFixedLegNotional(TradeValue tradeValue)
        {
            Set(x => x.FixedLegNotional, tradeValue);
            return this;
        }

        public TradePositionBuilder ThatIsValid()
        {
            Set(x => x.Identifier, Guid.NewGuid());
            Set(x => x.FixedLegNotional, Some.TradeValue.ThatIsValid());
            Set(x => x.FloatLegNotional, Some.TradeValue.ThatIsValid());
            return this;
        }

        protected override TradePosition Build() => new(
            Get(x => x.Identifier),
            Get(x => x.FixedLegNotional),
            Get(x => x.FixedLegNotional));
    }
}