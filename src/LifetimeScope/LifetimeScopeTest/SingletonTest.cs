using Autofac;
using FluentAssertions;
using Xunit;
using Xyz.TForce.Playground.AutofacLifetimeScope.Extent;
using Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services;

namespace Xyz.TForce.Playground.AutofacLifetimeScope
{

  public class SingletonTest
  {

    [Fact]
    public void Singleton_Singleton_Singleton_ChildScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().SingleInstance();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().SingleInstance();
      containerBuilder.RegisterType<ThirdLayer>().As<IThirdLayer>().SingleInstance();
      IContainer container = containerBuilder.Build();
      // Act
      ILifetimeScope scope1 = container.BeginLifetimeScope();
      IThirdLayer thirdLayer1 = scope1.Resolve<IThirdLayer>();
      ILifetimeScope scope2 = container.BeginLifetimeScope();
      IThirdLayer thirdLayer2 = scope2.Resolve<IThirdLayer>();
      // Assert
      thirdLayer1.AllInstanceNames.Should().Equal(thirdLayer2.AllInstanceNames);
    }

    [Fact]
    public void Singleton_Singleton_Singleton_RootScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().SingleInstance();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().SingleInstance();
      containerBuilder.RegisterType<ThirdLayer>().As<IThirdLayer>().SingleInstance();
      IContainer container = containerBuilder.Build();
      // Act
      IThirdLayer thirdLayer1 = container.Resolve<IThirdLayer>();
      IThirdLayer thirdLayer2 = container.Resolve<IThirdLayer>();
      // Assert
      thirdLayer1.AllInstanceNames.Should().Equal(thirdLayer2.AllInstanceNames);
    }
  }
}
