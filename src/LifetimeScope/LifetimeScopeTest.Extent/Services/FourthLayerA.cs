using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class FourthLayerA : BaseService, IFourthLayerA
  {

    public FourthLayerA(IThirdLayer thirdLayer, IThirdLayerA thirdLayerA)
    {
      ThirdLayer = thirdLayer;
      ThirdLayerA = thirdLayerA;
    }

    public IThirdLayer ThirdLayer { get; }

    public IThirdLayerA ThirdLayerA { get; }

    public List<string> AllInstanceNames
    {
      get
      {
        List<string> results = new List<string>();
        results.AddRange(ThirdLayer.AllInstanceNames);
        results.AddRange(ThirdLayerA.AllInstanceNames);
        results.Add(InstanceName);
        return results;
      }
    }
  }
}
