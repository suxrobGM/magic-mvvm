using MagicMvvm.Common;
using Xunit;

namespace MagicMvvm.Core.Tests
{
    public class DialogParametersTest : IClassFixture<DialogParametersFixture>
    {
        private readonly IParameters _parameters;

        public DialogParametersTest(DialogParametersFixture dialogParametersFixture)
        {
            _parameters = dialogParametersFixture.Parameters;
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
