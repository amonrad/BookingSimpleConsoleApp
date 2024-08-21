namespace BookingSimpleConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // Field:
        IReception reception = Factory.CreateReception();

        // Print welcome message in console
        reception.Welcome();

        // Program flow is controlled by reception.Menu()
        reception.Menu();
    }
}