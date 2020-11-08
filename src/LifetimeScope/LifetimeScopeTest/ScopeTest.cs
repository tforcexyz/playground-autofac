using Autofac;
using FluentAssertions;
using Xunit;
using Xyz.TForce.Playground.AutofacLifetimeScope.Extent;
using Xyz.TForce.Playground.AutofacLifetimeScope.Extent.Services;

namespace Xyz.TForce.Playground.AutofacLifetimeScope
{

  public class ScopeTest
  {

    [Fact]
    public void SinglePerScope_Singleton_RootScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().InstancePerLifetimeScope();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().SingleInstance();
      containerBuilder.RegisterType<SecondLayerA>().As<ISecondLayerA>().SingleInstance();
      IContainer container = containerBuilder.Build();
      // Act
      ISecondLayer secondLayer = container.Resolve<ISecondLayer>();
      ISecondLayerA secondLayerA = container.Resolve<ISecondLayerA>();
      ISecondLayerA secondLayerA2 = container.Resolve<ISecondLayerA>();
      // Assert
      secondLayer.FirstLayer.InstanceName.Should().Equals(secondLayerA.FirstLayer.InstanceName);
      secondLayerA.AllInstanceNames.Should().Equal(secondLayerA2.AllInstanceNames);
    }

    [Fact]
    public void SinglePerScope_Singleton_OneScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().InstancePerLifetimeScope();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().SingleInstance();
      containerBuilder.RegisterType<SecondLayerA>().As<ISecondLayerA>().SingleInstance();
      IContainer container = containerBuilder.Build();
      // Act
      ILifetimeScope scope1 = container.BeginLifetimeScope();
      ISecondLayer secondLayer = scope1.Resolve<ISecondLayer>();
      ISecondLayerA secondLayerA = scope1.Resolve<ISecondLayerA>();
      ISecondLayerA secondLayerA2 = scope1.Resolve<ISecondLayerA>();
      // Assert
      secondLayer.FirstLayer.InstanceName.Should().Equals(secondLayerA.FirstLayer.InstanceName);
      secondLayerA.AllInstanceNames.Should().Equal(secondLayerA2.AllInstanceNames);
    }

    [Fact]
    public void SinglePerScope_Singleton_TwoScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().InstancePerLifetimeScope();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().SingleInstance();
      IContainer container = containerBuilder.Build();
      // Act
      ILifetimeScope scope1 = container.BeginLifetimeScope();
      ISecondLayer secondLayerScope1 = scope1.Resolve<ISecondLayer>();
      ILifetimeScope scope2 = container.BeginLifetimeScope();
      ISecondLayer secondLayerScope2 = scope2.Resolve<ISecondLayer>();
      // Assert
      secondLayerScope1.AllInstanceNames.Should().BeEquivalentTo(secondLayerScope2.AllInstanceNames);
    }

    [Fact]
    public void SinglePerScope_SinglePerScope_TwoScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().InstancePerLifetimeScope();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().InstancePerLifetimeScope();
      containerBuilder.RegisterType<SecondLayerA>().As<ISecondLayerA>().InstancePerLifetimeScope();
      IContainer container = containerBuilder.Build();
      // Act
      ILifetimeScope scope1 = container.BeginLifetimeScope();
      ISecondLayer secondLayerScope1 = scope1.Resolve<ISecondLayer>();
      ISecondLayerA secondLayerAScope1 = scope1.Resolve<ISecondLayerA>();
      ILifetimeScope scope2 = container.BeginLifetimeScope();
      ISecondLayer secondLayerScope2 = scope2.Resolve<ISecondLayer>();
      ISecondLayerA secondLayerAScope2 = scope2.Resolve<ISecondLayerA>();
      // Assert
      secondLayerScope1.FirstLayer.InstanceName.Should().BeEquivalentTo(secondLayerAScope1.FirstLayer.InstanceName);
      secondLayerScope2.FirstLayer.InstanceName.Should().BeEquivalentTo(secondLayerAScope2.FirstLayer.InstanceName);
      secondLayerScope1.FirstLayer.InstanceName.Should().NotBeEquivalentTo(secondLayerScope2.FirstLayer.InstanceName);
      secondLayerAScope1.FirstLayer.InstanceName.Should().NotBeEquivalentTo(secondLayerAScope2.FirstLayer.InstanceName);
      secondLayerScope1.InstanceName.Should().NotBeEquivalentTo(secondLayerScope2.InstanceName);
    }

    [Fact]
    public void Singleton_SinglePerScope_TwoScope()
    {
      // Arrange
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FirstLayer>().As<IFirstLayer>().SingleInstance();
      containerBuilder.RegisterType<SecondLayer>().As<ISecondLayer>().InstancePerLifetimeScope();
      containerBuilder.RegisterType<SecondLayerA>().As<ISecondLayerA>().InstancePerLifetimeScope();
      IContainer container = containerBuilder.Build();
      // Act
      ILifetimeScope scope1 = container.BeginLifetimeScope();
      ISecondLayer secondLayerScope1 = scope1.Resolve<ISecondLayer>();
      ISecondLayerA secondLayerAScope1 = scope1.Resolve<ISecondLayerA>();
      ILifetimeScope scope2 = container.BeginLifetimeScope();
      ISecondLayer secondLayerScope2 = scope2.Resolve<ISecondLayer>();
      ISecondLayerA secondLayerAScope2 = scope2.Resolve<ISecondLayerA>();
      // Assert
      secondLayerScope1.FirstLayer.InstanceName.Should().BeEquivalentTo(secondLayerAScope1.FirstLayer.InstanceName);
      secondLayerScope2.FirstLayer.InstanceName.Should().BeEquivalentTo(secondLayerAScope2.FirstLayer.InstanceName);
      secondLayerScope1.FirstLayer.InstanceName.Should().BeEquivalentTo(secondLayerScope2.FirstLayer.InstanceName);
      secondLayerAScope1.FirstLayer.InstanceName.Should().BeEquivalentTo(secondLayerAScope2.FirstLayer.InstanceName);
      secondLayerScope1.InstanceName.Should().NotBeEquivalentTo(secondLayerScope2.InstanceName);
    }
  }
}
