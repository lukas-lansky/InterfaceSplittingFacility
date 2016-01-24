# InterfaceSplittingFacility

![Current build status](https://ci.appveyor.com/api/projects/status/9ul39kmyrv3ibatg?svg=true)

## Reasoning

Let's say you have to maintain a large interface with lots of rather unrelated methods. What an unfortunate situation to be in! You would love to adhere to SOLID design principles, but as your monstrous implementation dependency list grows, you start considering to stop using IoC framework to managing them.

In an ideal world, you would be able to break the big interface into many small ones, but if this is not an option, you may want to split the big externally visible interface to more internal ones you can manage. The problem this library solves is how to reroute calls to the big interface without creating any kind of big implementation that would force you to manage dependencies manually.

## Usage

If you control the interface definition, you are able to rewrite hypothetical IBig from this:

    public interface IBig { ... big list of methods ... }

into this:

    public interface IBig : ISmall1, ISmall2, ISmall3 { }
    public interface ISmall1 { ... smaller list of methods ... }
    public interface ISmall2 { ... smaller list of methods ... }
    public interface ISmall3 { ... smaller list of methods ... }
    
Then you add this library as a reference and use it like this:

    var container = new WindsorContainer()
      .AddFacility<InterfaceSplittingFacility>();

    container.Register(
      Component.For<ISmall1>().ImplementedBy<DefaultSmall1>().LifestyleTransient(),
      Component.For<ISmall2>().ImplementedBy<DefaultSmall2>().LifestyleTransient(),
      Component.For<ISmall3>().ImplementedBy<DefaultSmall3>().LifestyleTransient(),
      Component.For<IBig>().ImplementedAsSplittedInterface()
      );

    var instance = container.Resolve<IBig>();

Now, you have instance of merged implementations DefaultSmall1, DefaultSmall2 and DefaultSmall3. Please note that you can now control lifestyle of each particular implementation separately. Every implementation has, of course, its own dependencies.

If you don't control the IBig definition, you can leave it like this:

    public interface IBig { ... big list of methods ... }
    public interface ISmall1 { ... smaller list of methods ... }
    public interface ISmall2 { ... smaller list of methods ... }
    public interface ISmall3 { ... smaller list of methods ... }
    
... and name smaller interfaces in your composition root:

    Component.For<IBig>().ImplementedAsSplittedInterfaceBy<IBig, ISmall1, ISmall2, ISmall3>()
    
This solution has an obvious problem: if you add a new method into IBig, it won't be aparent that it's not managed by any splitted interface. When you call a method that is not a part of any splitted interface, NotImplementedException is thrown.

## Thanks

The implementation is based on [Patrick Quirk](http://stackoverflow.com/users/1698557/patrick-quirk)'s [answer](http://stackoverflow.com/a/33896456/577067) to [my question](http://stackoverflow.com/questions/33895711/can-castle-windsor-help-me-to-split-implementation-of-a-big-interface) at Stack Overflow.
