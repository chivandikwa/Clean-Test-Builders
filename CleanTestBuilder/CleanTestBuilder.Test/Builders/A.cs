namespace CleanTestBuilder.Tests.Builders
{
    public class A
    {
        public static PositionBuilder Position => new PositionBuilder();
    }

    public class Some
    {
        public static MoneyBuilder Money => new MoneyBuilder();
    }
}