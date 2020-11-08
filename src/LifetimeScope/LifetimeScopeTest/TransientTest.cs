using Autofac;
using FluentAssertions;
using Xunit;
using Xyz.TForce.Playground.AutofacLifetimeScope.Extent;
using Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services;

namespace Xyz.TForce.Playground.AutofacLifetimeScope
{

  public class TransientTest
  {

    [Fact]
    public void Singleton_Transient_RootScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().SingleInstance();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().InstancePerDependency();
      IContainer container = containerBuilder.Build();
      // Act
      ISecondLayer secondLayer = container.Resolve<ISecondLayer>();
      ISecondLayer secondLayer2 = container.Resolve<ISecondLayer>();
      // Assert
      secondLayer.AllInstanceNames.Should().NotEqual(secondLayer2.AllInstanceNames);
    }

    [Fact]
    public void Transient_Singleton_RootScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().InstancePerDependency();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().SingleInstance();
      containerBuilder.RegisterType<SecondLayerA>().As<ISecondLayerA>().SingleInstance();
      IContainer container = containerBuilder.Build();
      // Act
      ISecondLayer secondLayer = container.Resolve<ISecondLayer>();
      ISecondLayerA secondLayerA = container.Resolve<ISecondLayerA>();
      ISecondLayerA secondLayerA2 = container.Resolve<ISecondLayerA>();
      // Assert
      secondLayer.AllInstanceNames.Should().NotEqual(secondLayerA.AllInstanceNames);
      secondLayerA.AllInstanceNames.Should().Equal(secondLayerA2.AllInstanceNames);
    }

    [Fact]
    public void Transient_Singleton_Singleton_RootScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().InstancePerDependency();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().SingleInstance();
      containerBuilder.RegisterType<SecondLayerA>().As<ISecondLayerA>().SingleInstance();
      containerBuilder.RegisterType<ThirdLayerA>().As<IThirdLayerA>().SingleInstance();
      containerBuilder.RegisterType<ThirdLayerB>().As<IThirdLayerB>().SingleInstance();
      IContainer container = containerBuilder.Build();
      // Act
      IThirdLayerA thirdLayerA = container.Resolve<IThirdLayerA>();
      IThirdLayerB thirdLayerB = container.Resolve<IThirdLayerB>();
      IThirdLayerB thirdLayerB2 = container.Resolve<IThirdLayerB>();
      // Assert
      thirdLayerA.AllInstanceNames.Should().NotEqual(thirdLayerB.AllInstanceNames);
      thirdLayerB.AllInstanceNames.Should().Equal(thirdLayerB2.AllInstanceNames);
    }
  }
}
