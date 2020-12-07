namespace CleanTestBuilder.Tests.Builders
{
    using System;

    public class PositionBuilder : Builder<Position>
    {
        public PositionBuilder WithIdentifier(Guid identifier)
        {
            Set(x => x.Identifier, identifier);
            return this;
        }

        public PositionBuilder WithFloatLegNotional(Money money)
        {
            Set(x => x.FloatLegNotional, money);
            return this;
        }

        public PositionBuilder WithFixedLegNotional(Money money)
        {
            Set(x => x.FixedLegNotional, money);
            return this;
        }

        public PositionBuilder ThatIsValid()
        {
            Set(x => x.Identifier, Guid.NewGuid());
            Set(x => x.FixedLegNotional, Some.Money.ThatIsValid());
            Set(x => x.FloatLegNotional, Some.Money.ThatIsValid());
            return this;
        }

        protected override Position Build() => new Position(
            Get(x => x.Identifier),
            Get(x => x.FixedLegNotional),
            Get(x => x.FixedLegNotional));
    }
}