using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class FourthLayer : BaseService, IFourthLayer
  {

    private readonly IThirdLayer _thirdLayer;

    public FourthLayer(IThirdLayer thirdLayer)
    {
      _thirdLayer = thirdLayer;
    }

    public List<string> AllInstanceNames
    {
      get
      {
        List<string> results = new List<string>();
        results.AddRange(_thirdLayer.AllInstanceNames);
        results.Add(InstanceName);
        return results;
      }
    }
  }
}
