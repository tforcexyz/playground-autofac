namespace Xyz.TForce.Playground.AutofacLifetimeScope.Extent
{

  public interface IFourthLayer : IBaseContract
  {

    IThirdLayer ThirdLayer { get; }
  }
}
