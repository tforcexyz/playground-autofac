namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface IThirdLayerB : IBaseContract
  {

    ISecondLayer SecondLayer { get; }

    ISecondLayerA SecondLayerA { get; }
  }
}
