using System.Collections.Generic;

namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services
{

  public class FourthLayerC : BaseService, IFourthLayerC
  {

    public FourthLayerC(IThirdLayer thirdLayer, IThirdLayerA thirdLayerA, IThirdLayerB thirdLayerB)
    {
      ThirdLayer = thirdLayer;
      ThirdLayerA = thirdLayerA;
      ThirdLayerB = thirdLayerB;
    }

    public IThirdLayer ThirdLayer { get; }

    public IThirdLayerA ThirdLayerA { get; }

    public IThirdLayerB ThirdLayerB { get; }

    public List<string> AllInstanceNames
    {
      get
      {
        List<string> results = new List<string>();
        results.AddRange(ThirdLayer.AllInstanceNames);
        results.AddRange(ThirdLayerA.AllInstanceNames);
        results.AddRange(ThirdLayerB.AllInstanceNames);
        results.Add(InstanceName);
        return results;
      }
    }
  }
}
