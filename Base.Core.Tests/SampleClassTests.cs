namespace Base.Core.Tests
{
    using FluentAssertions;
    using FluentAssertions.Events;
    using Xunit;

    public class SampleClassTests
    {
        [Fact]
        public void FodyPropertyChangedShouldWorkCorrectly()
        {
            // Arrange
            SampleClass testee = new SampleClass();

            using (IMonitor<SampleClass> eventMonitor = testee.Monitor())
            {
                // Act
                testee.SampleProperty = 1;

                // Assert
                eventMonitor.Should().RaisePropertyChangeFor(t => t.SampleProperty);
            }
        }
    }
}