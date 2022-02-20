# Dependency injection in dotnet core & dotnet 5/6 <!-- omit in toc -->

## Contents <!-- omit in toc -->

- [1. Why dependency injection?](#1-why-dependency-injection)
  - [1.1. Highly coupled](#11-highly-coupled)
  - [1.2. Reducing coupling](#12-reducing-coupling)
  - [1.3. Benefits of dependency injection](#13-benefits-of-dependency-injection)
- [2. Three mehtods of inejction in ServiceCollection](#2-three-mehtods-of-inejction-in-servicecollection)
  - [AddSingleton](#addsingleton)
  - [AddScoped](#addscoped)
  - [AddTransient](#addtransient)

## 1. Why dependency injection?

### 1.1. Highly coupled

- The dependency injection mainly comes from an object oriented design principle, concrete classes must not be dependent on each other, this is called low coupling.
- Then we say that they are highly coupled and opposite when they are not depending on each other.

[Example with highly coupled](ExampleObjectCompositionWithoutInterface)

- The problem is that imagine that this `DataAccess` class rights, the data to SQL Server, and you have, for example, 10 lines of code that divides the data to SQL Server. If we want to switch from SQL Server to, for example, MySql or to a NoSql database, either you have to come and change the body of your method, which this is against the open `closed principle`, because what if we want to go back to SQL Server at some point, you have to again come back and put your old code back in here, or how about the tests that you might have lacunae test and integration test.
- You break all your tests so your `Business` class now has dependency on your `DataAccess` class, because if I change the data access, I'm going to break the `Business` class.
- Your new `DataAccess` necessarily won't have the same method store or even if they have the same methods, then the signature might be different.
- Likewise, your `UserInterface` class has dependency on your `Business` class.
- Again, if you want to change the way we validate data, we will have to change the body of the business class and that can again break a lot of parts of your application.

### 1.2. Reducing coupling

- To reduce this type of coupling or dependency, what we can do is that your user interface can work with an `interfaces`.
- So instead of working directly with the `Business` class, which is the concrete class, it can work with an interface because the interface has the method and has the parameters for the method.
- Your `UserInterface` can use the interface.
- It can only talk to the interface because what your `UserInterface` needs is that what methods exist in the `Business` class and what is the signature of that method.
- Likewise, your `DataAccess` doesn't have to be there as long as there is an interface that has the methods and method signatures and possibly the properties that the business class needs in order to talk to the `DataAccess` layer or `DataAccess` class, the `Business` class will be fine so we can replace the `Business` class with an interface that demonstrates the methods, properties and method signatures of the `Business` class.
- Likewise, we can replace the `DataAccess` class with an interface that represents the methods, properties and method signatures of the data access class. So `UserInterface` will work with the `IBusiness` classes interface and `Business` class will work with the `IDataAccess` interface.
- And now every time we want to actually do something in the `Business` class, dependency injection comes into play and creates an instance of the `Business` class and then makes a call to the actual methods inside the `Business` class.
- Likewise, whenever we need an actual `DataAccess`, then dependency injection creates an instance of your `DataAccess` class, which implements the `IDataAccess` interface or `DataAccess` class, and performs the actual writing or storing data in your database.

[Example reducing coupling with interfaces](ExampleObjectCompositionWithInterface)

### 1.3. Benefits of dependency injection

- Clean code
  - Your code is easier to understand
    - So when you use dependency injection, your code will be a lot cleaner and easier to understand, because, for example, if I only use a `Business` class or `IBusiness` interface and not the actual concrete classes, all you need to know is that what is the signature, what are the methods and what are the properties.
- Better reusability
  - Low coupling allows modules to be reused
    - You don't need to know the details of how things work in a `Business` class. So it will be easier to understand a given code and then the modules and classes will be more usable because you know the interfaces of the classes. If the classes implement a given interface, then you can easily reuse them anywhere that interface is known.
- Better unit testing
  - Concrete class can be replace by mocks
    - And also dependency, injection and interfaces make unit testing very easy. In fact, interfaces and dependency injection is crucial for writing good unit tests because in unit tests you only test one module and all the other dependencies should be just fake or mock's, which mean that they shouldn't actually do anything.
- Low coupling
  - Concrete classes can be replaced
    - You can easily replace concrete classes because if you use the interface, you don't really need to know how actual concrete classes work and that will help you with low coupling.

## 2. Three mehtods of inejction in ServiceCollection

### AddSingleton

- Same instance for the entire application

### AddScoped

- Same instance for the whole request

### AddTransient

- Different instance every time object is requested or injected
