using AutoMapper;

namespace Progress.Application.Tests
{
    public class AutomapperTests
    {
        [Fact]
        public void IsConfigurationValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}