using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class SecondLayer : BaseService, ISecondLayer
  {

    private readonly IFirstLayer _firstLayer;

    public SecondLayer(IFirstLayer firstLayer)
    {
      _firstLayer = firstLayer;
    }

    public List<string> AllInstanceNames
    {
      get
      {
        List<string> results = new List<string>();
        results.AddRange(_firstLayer.AllInstanceNames);
        results.Add(InstanceName);
        return results;
      }
    }
  }
}
