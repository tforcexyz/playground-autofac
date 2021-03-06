using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class FourthLayer : BaseService, IFourthLayer
  {

    public FourthLayer(IThirdLayer thirdLayer)
    {
      ThirdLayer = thirdLayer;
    }

    public IThirdLayer ThirdLayer { get; }

    public List<string> AllInstanceNames
    {
      get
      {
        List<string> results = new List<string>();
        results.AddRange(ThirdLayer.AllInstanceNames);
        results.Add(InstanceName);
        return results;
      }
    }
  }
}
