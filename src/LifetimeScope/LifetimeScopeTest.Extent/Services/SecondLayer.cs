using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class SecondLayer : BaseService, ISecondLayer
  {

    public SecondLayer(IFirstLayer firstLayer)
    {
      FirstLayer = firstLayer;
    }

    public IFirstLayer FirstLayer { get; }

    public List<string> AllInstanceNames
    {
      get
      {
        List<string> results = new List<string>();
        results.AddRange(FirstLayer.AllInstanceNames);
        results.Add(InstanceName);
        return results;
      }
    }
  }
}
