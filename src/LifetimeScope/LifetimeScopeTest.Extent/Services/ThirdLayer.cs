using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class ThirdLayer : BaseService, IThirdLayer
  {

    public ThirdLayer(ISecondLayer secondLayer)
    {
      SecondLayer = secondLayer;
    }

    public ISecondLayer SecondLayer { get; }

    public List<string> AllInstanceNames
    {
      get
      {
        List<string> results = new List<string>();
        results.AddRange(SecondLayer.AllInstanceNames);
        results.Add(InstanceName);
        return results;
      }
    }
  }
}
