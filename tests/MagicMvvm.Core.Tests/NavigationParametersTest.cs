using MagicMvvm.Common;
using Xunit;

namespace MagicMvvm.Tests;

public class ParametersTest : IClassFixture<ParametersFixture>
{
    private readonly IParameters _parameters;

    public ParametersTest(ParametersFixture navigationParametersFixture)
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