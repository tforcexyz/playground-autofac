namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface IThirdLayer : IBaseContract
  {

    ISecondLayer SecondLayer { get; }
  }
}
