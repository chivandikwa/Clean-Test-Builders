namespace CleanTestBuilder.Tests.Builders
{
    using System;

    public record TradePosition(
        Guid Identifier,
        TradeValue FixedLegNotional,
        TradeValue FloatLegNotional);

}