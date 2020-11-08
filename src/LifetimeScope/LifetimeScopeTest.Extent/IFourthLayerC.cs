namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface IFourthLayerC : IBaseContract
  {

    IThirdLayer ThirdLayer { get; }

    IThirdLayerA ThirdLayerA { get; }

    IThirdLayerB ThirdLayerB { get; }
  }
}
