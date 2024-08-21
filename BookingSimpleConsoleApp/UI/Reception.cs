namespace BookingSimpleConsoleApp
{
    public class Reception : IReception
    {
        // Fields:

        public IDictionary<string, List<IMeeting>> calendar;

        List<IBookable> clients;
        List<IBookable> locations;
        List<IBookable> employees;

        IHandleBooking handleBooking;
        INewBookingsForm newBookingsForm;
        IDisplay display;

        // Constructor:

        public Reception()
        {
            // Create an overarching meeting calendar for the reception
            calendar = Factory.createDictionaryOfIMeetings();

            // Create a new list of clients
            clients = Factory.createListOfIBookables();

            // Create a list of locations
            locations = Factory.createListOfIBookables();
            locations.Add(Factory.CreateLocation("Havesalen"));
            locations.Add(Factory.CreateLocation("Riddersalen"));
            locations.Add(Factory.CreateLocation("Kælderloungen"));
            // Add more locations if necessary

            // Create a list of employees
            employees = Factory.createListOfIBookables();
            employees.Add(Factory.CreateEmployee("Jacob"));
            employees.Add(Factory.CreateEmployee("Inge"));
            employees.Add(Factory.CreateEmployee("Morten"));
            // Add more employees if necessary

            // Create a display to show the meeting list
            display = Factory.CreateDisplay();

            // Create an object for meeting booking
            handleBooking = Factory.CreateHandleBooking(calendar);

            // Create an object for data collection
            newBookingsForm = Factory.CreateNewBookingsForm(locations, employees, clients, handleBooking);
        }

        // Public methods:

        // EFFECTS: Prints a welcome message to the console

        public void Welcome()
        {
            Console.Clear();
            Console.WriteLine("\n\rWelcome to booking");
            Console.WriteLine("\n\rPress any key to continue.");
            Console.ReadKey();
        }

        // REQUIRES: User input from a set of options to continue.
        //           Specifically, expects input to correspond to a menu item.
        // EFFECTS: Displays a menu and performs actions based on user input

        public void Menu()
        {
            bool validKeyPressed = false;

            while (!validKeyPressed)
            {
                // Print menu
                Console.Clear();
                Console.WriteLine("\n\rTo book a meeting where you enter booking details yourself, press '1',");
                Console.WriteLine("\n\rTo have us make a booking for you, press '2',");
                Console.WriteLine("\n\rTo see an overview of all bookings, press '3'");
                Console.WriteLine("\n\rTo exit the program, press '4'");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                // Check input and perform action based on input
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        newBookingsForm.fillBookingForm();
                        break;

                    case ConsoleKey.D2:
                        newBookingsForm.GenerateRandomBooking();
                        break;

                    case ConsoleKey.D3:
                        display.DisplayMeetingCalendar(calendar);
                        break;

                    case ConsoleKey.D4:
                        validKeyPressed = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nInvalid input, press any key to try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}