using Xunit;

namespace MagicMvvm.Core.Tests
{
    public class DialogParametersTest : IClassFixture<DialogParametersFixture>
    {
        private DialogParametersFixture _dialogParametersFixture;

        public DialogParametersTest(DialogParametersFixture dialogParametersFixture)
        {
            _dialogParametersFixture = dialogParametersFixture;
        }
        
        [Fact]
        public void Test1()
        {
        }
    }
}
