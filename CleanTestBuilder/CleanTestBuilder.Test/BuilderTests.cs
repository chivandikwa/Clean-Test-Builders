namespace CleanTestBuilder.Tests
{
    using System;
    using CleanTestBuilder;
    using FluentAssertions;
    using Xunit;

    public class BuilderTests
    {
        public class TestData
        {
            public TestData(Guid id, string description)
            {
                Id = id;
                Description = description;
            }

            public Guid Id { get; }
            public string Description { get; }
        }

        public class TestDataBuilder : Builder<TestData>
        {
            public TestDataBuilder WithId(Guid id)
            {
                Set(x => x.Id, id);

                return this;
            }

            public TestDataBuilder WithDescription(string description)
            {
                Set(x => x.Description, description);

                return this;
            }

            protected override TestData Build() => new TestData(Get(x => x.Id), Get(x => x.Description));
        }

        public class Some
        {
            // TODO
            // Document care that should be taken to make sure each builder is a new instance
            public static TestDataBuilder TestData => new TestDataBuilder();
        }

        [Fact]
        public void GivenTestBuilder_OnBuild_ThenResultIsAsExpected()
        {
            const string description = nameof(description);
            var id = Guid.NewGuid();

            TestData data = Some.TestData
                .WithDescription(description)
                .WithId(id);

            data.Should().NotBeNull();
            data.Description.Should().Be(description);
            data.Id.Should().Be(id);
        }

        [Fact]
        public void GivenTestBuilder_OnBuildWithDescriptionOnly_ThenResultIsAsExpected()
        {
            const string description = nameof(description);

            TestData data = Some.TestData
                .WithDescription(description);

            data.Should().NotBeNull();
            data.Description.Should().Be(description);
            data.Id.Should().Be(default(Guid));
        }

        [Fact]
        public void GivenTestBuilder_OnBuildWithIdOnly_ThenResultIsAsExpected()
        {
            var id = Guid.NewGuid();

            TestData data = Some.TestData
                .WithId(id);

            data.Should().NotBeNull();
            data.Id.Should().Be(id);

            data.Description.Should().Be(default);
        }
    }
}
