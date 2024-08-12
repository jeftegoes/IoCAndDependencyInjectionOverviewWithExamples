using Microsoft.Extensions.DependencyInjection;
using ExampleObjectCompositionWithDependencyInjection;

var collection = new ServiceCollection();
collection.AddScoped<IBusiness, Business>();
collection.AddScoped<IDataAccess, DataAccess>();
collection.AddScoped<IUserInterface, UserInterface>();

var provider = collection.BuildServiceProvider();
IDataAccess dataAccess = provider.GetService<IDataAccess>();
IBusiness business = provider.GetService<IBusiness>();
IUserInterface userInterface = provider.GetService<IUserInterface>();