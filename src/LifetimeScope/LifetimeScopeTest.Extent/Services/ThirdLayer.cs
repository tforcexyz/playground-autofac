using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class ThirdLayer : BaseService, IThirdLayer
  {

    private readonly ISecondLayer _secondLayer;

    public ThirdLayer(ISecondLayer secondLayer)
    {
      _secondLayer = secondLayer;
    }

    public List<string> AllInstanceNames
    {
      get
      {
        List<string> results = new List<string>();
        results.AddRange(_secondLayer.AllInstanceNames);
        results.Add(InstanceName);
        return results;
      }
    }
  }
}
