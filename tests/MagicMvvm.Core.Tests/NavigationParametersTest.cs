using MagicMvvm.Common;
using Xunit;

namespace MagicMvvm.Core.Tests
{
    public class NavigationParametersTest : IClassFixture<NavigationParametersFixture>
    {
        private readonly IParameters _parameters;

        public NavigationParametersTest(NavigationParametersFixture navigationParametersFixture)
        {
            _parameters = navigationParametersFixture.Parameters;
        }
        
        [Fact]
        public void AddNewValue()
        {
            _parameters.Add("TestKey", "TestValue");
            Assert.Equal(6, _parameters.Count);
            Assert.Equal("TestValue",_parameters["TestKey"]);
        }

        [Fact]
        public void GetValue()
        {
            Assert.Equal("Value1", _parameters.GetValue<string>("Key1"));
        }
    }
}