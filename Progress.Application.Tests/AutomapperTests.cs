using AutoMapper;

namespace Progress.Application.Tests
{
    public class AutoMapperProfileTests
    {
        [Fact]
        public void Configuration_ShouldBeValid_WhenProfileIsAdded()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}