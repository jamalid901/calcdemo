using Microsoft.Extensions.DependencyInjection;

namespace CalculatorDemo;

public class Program
{
    static void Main(string[] args)
    {
        //on aurait pu initialiser ServiceCollection dans une classe d'initialisation
        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var app = serviceProvider.GetService<Application>();
        if (app == null)
        {
            Console.WriteLine("\nImpossible de démarrer l'application");
            return;
        }
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        
        services.AddScoped<ICalculatorService, CalculatorService>();
        services.AddScoped<IMathParser, MathParser>();
        services.AddSingleton<Application>();
    }
}

