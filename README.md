# InterfaceSplittingFacility

This is work in progress!

## Reasoning

Let's say you have to maintain large interface with lots of rather unrelated methods. What an unfortunate situation to be in! You would love adhere to SOLID design principles, but as your monstrous implementation dependency list grows, you start considering to stop using IoC framework to managing them.

In an ideal world, you would be able to break the big interface to many small ones, but if this is not an option, you may want to split the big, externally visible interface to more, internal ones you can manage. The problem this library solves is how to reroute calls to the big interface without creating any kind of big implementation.

## Usage

If you control the interface definition, you are able to rewrite hypothetical IBig like this:

    public interface IBig : ISmall1, ISmall2, ISmall3 { }
    
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

If you don't control IBig definition, you can leave it like this:

    public interface IBig { ... big list ... }
    
... and name smaller interfaces in your composition root:

    Component.For<IBig>().ImplementedAsSplittedInterface<IBig, ISmall1, ISmall2, ISmall3>()
    
This solution has an obvious problem: if you add a new member into IBig, it won't be aparent that it's not managed by some splitted interface. When you call method that is not part of any splitted interface, runtime exception is thrown.

## Thanks

The implementation is based on Patrick Quirk's answer to [my question](http://stackoverflow.com/questions/33895711/can-castle-windsor-help-me-to-split-implementation-of-a-big-interface) at Stack Overflow.
