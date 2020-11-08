namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface IFourthLayerA : IBaseContract
  {

    IThirdLayer ThirdLayer { get; }

    IThirdLayerA ThirdLayerA { get; }
  }
}
