namespace CleanTestBuilder.Tests.Builders
{
    using System;

    public class Position
    {
        public Position(Guid identifier,
            Money fixedLegNotional,
            Money floatLegNotional)
        {
            Identifier = identifier;
            FixedLegNotional = fixedLegNotional;
            FloatLegNotional = floatLegNotional;
        }

        public Guid Identifier { get; }
        public Money FloatLegNotional { get; }
        public Money FixedLegNotional { get; }
    }
}