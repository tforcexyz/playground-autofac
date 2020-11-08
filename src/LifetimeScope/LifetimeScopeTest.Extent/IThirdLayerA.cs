namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface IThirdLayerA : IBaseContract
  {

    ISecondLayer SecondLayer { get; }

    ISecondLayerA SecondLayerA { get; }
  }
}
