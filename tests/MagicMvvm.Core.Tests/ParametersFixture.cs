using MagicMvvm.Common;

namespace MagicMvvm.Tests;

public class ParametersFixture
{
    public ParametersFixture()
    {
        Parameters = new Parameters();
        Parameters.Add("Key1", "Value1");
        Parameters.Add("Key2", "Value2");
        Parameters.Add("Key3", "Value3");
        Parameters.Add("Key4", "Value4");
        Parameters.Add("Key5", "Value5");
    }
        
    public IParameters Parameters { get; }
}