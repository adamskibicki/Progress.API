using Progress.Application.Persistence;

namespace Progress.Application.Tests
{
    public class SeededGuidGeneratorTests
    {
        [Fact]
        public void GeneratesSameGuidesForSameSeeds()
        {
            var gen = new SeededGuidGenerator(1501381288);

            var guid = gen.GetNext().ToString();

            Assert.Equal("d3cad15f-3531-d853-ac13-22e7a0dd4f58", guid);
        }
    }
}