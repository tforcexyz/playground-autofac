namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface ISecondLayer : IBaseContract
  {

    IFirstLayer FirstLayer { get; }
  }
}
