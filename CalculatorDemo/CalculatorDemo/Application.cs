namespace CalculatorDemo;

//Décision: pour ne pas que Program.cs soit rempli de code qui gère les inputs, cette classe s'occupe entièrement de la saisie de l'application Console,
//ce qui fait que Program.cs est plus lisible et ne fait que relayer les informations à cette classe
public class Application
{
    private readonly ICalculatorService _service;

    public Application(ICalculatorService service)
    {
        _service = service;
    }

    public void Run()
    {
        string userInput;

        do
        {
            DisplayMenu();

            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":

                    Console.WriteLine("\nSVP entrez une expression mathématique: ");

                    string expression = Console.ReadLine();

                    try
                    {

                        double result = _service.EvaluateExpression(expression);

                        Console.WriteLine($"Le résultat est: {result} ");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("\n");

                    break;

                case "2":
                    Console.WriteLine("\nMerci d'avoir utilisé la calculatrice.\n");
                    break;

                default:
                    Console.WriteLine("\nChoix invalide, veuillez réessayer.\n");
                    break;
            }

        } while (userInput != null && userInput != "2");

        Console.ReadKey();

        void DisplayMenu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("              CALCULATRICE              ");
            Console.WriteLine("========================================\n");
            Console.WriteLine("1. Effectuer un test");
            Console.WriteLine("2. Quitter");
            Console.WriteLine("----------------------------------------\n");
            Console.Write("Faites votre choix : ");
        }
    }
}
