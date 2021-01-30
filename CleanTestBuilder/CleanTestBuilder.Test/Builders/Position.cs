namespace CleanTestBuilder.Tests.Builders
{
    using System;

    public record Position(Guid Identifier, Money FixedLegNotional, Money FloatLegNotional);

}