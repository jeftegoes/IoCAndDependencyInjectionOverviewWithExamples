using ExampleConditionalResolve;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();
collection.AddScoped<BrazilTaxCalculator>();
collection.AddScoped<EuropeTaxCalculator>();

collection.AddScoped<Func<UserLocations, ITaxCalculator>>(
    ServiceProvider => key =>
    {
        switch (key)
        {
            case UserLocations.Brazil: return ServiceProvider.GetService<BrazilTaxCalculator>();
            case UserLocations.Europe: return ServiceProvider.GetService<EuropeTaxCalculator>();
            default: return null;
        }
    }
);

collection.AddSingleton<Purchase>();

var provider = collection.BuildServiceProvider();
var purchcase = provider.GetService<Purchase>();

var totalCharge = purchcase.CheckOut(UserLocations.Brazil);

Console.WriteLine(totalCharge);