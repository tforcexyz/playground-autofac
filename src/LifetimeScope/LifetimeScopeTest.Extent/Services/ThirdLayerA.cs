using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class ThirdLayerA : BaseService, IThirdLayerA
  {

    public ThirdLayerA(ISecondLayer secondLayer, ISecondLayerA secondLayerA)
    {
      SecondLayer = secondLayer;
      SecondLayerA = secondLayerA;
    }

    public ISecondLayer SecondLayer { get; }

    public ISecondLayerA SecondLayerA { get; }

    public List<string> AllInstanceNames
    {
      get
      {
        List<string> results = new List<string>();
        results.AddRange(SecondLayer.AllInstanceNames);
        results.AddRange(SecondLayerA.AllInstanceNames);
        results.Add(InstanceName);
        return results;
      }
    }
  }
}
