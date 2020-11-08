namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface IFourthLayerB : IBaseContract
  {

    IThirdLayer ThirdLayer { get; }

    IThirdLayerA ThirdLayerA { get; }

    IThirdLayerB ThirdLayerB { get; }
  }
}
