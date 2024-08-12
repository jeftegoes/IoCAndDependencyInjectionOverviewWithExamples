using ExampleAddScopedVsAddTransient;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();
collection.AddScoped<ScopedClass>();
collection.AddTransient<TransientClass>();

var builder = collection.BuildServiceProvider();

Console.Clear();

Parallel.For(1, 10, i =>
{
    Console.WriteLine($"Scoped ID = { builder.GetService<ScopedClass>().GetHashCode().ToString()}");
    Console.WriteLine($"Transient ID = { builder.GetService<TransientClass>().GetHashCode().ToString()}");
});