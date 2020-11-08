namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface ISecondLayerA : IBaseContract
  {

    IFirstLayer FirstLayer { get; }
  }
}
