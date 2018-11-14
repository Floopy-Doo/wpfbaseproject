namespace Base.Core.Tests
{
    using FluentAssertions;
    using FluentAssertions.Events;
    using Xbehave;
    using Xunit;

    public class SampleUnitTests
    {
        [Fact]
        public void SampleFact()
        {
            // Arrange
            int summandOne = 1;
            int summandTwo = 2;
            int expectedResult = 3;

            // Act
            int result = summandOne + summandTwo;

            // Assert
            result.Should().Be(expectedResult);
        }

        [Scenario]
        public void SampleScenario()
        {
            int? result = null;
            int? summandOne = null;
            int? summandTwo = null;

            "Given i have two numbers 1 and 2".x(
                () =>
                {
                    summandOne = 1;
                    summandTwo = 2;
                });

            "When I calculate the sum of those numbers".x(
                () => { result = summandOne + summandTwo; });

            "Then I get the result of 3".x(
                () => { result.Should().Be(expected: 3); });
        }
    }
}