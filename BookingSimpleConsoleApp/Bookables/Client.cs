namespace BookingSimpleConsoleApp
{
    public class Client : Bookable
    {
        // Constructor:

        public Client(string name) : base(name)
        {
        }

        // Public methods:


        // EFFECTS: Override method that returns a specific explanation for customer objects.

        public override string explanation()
        {
            return "\n- you already have an existing booking at this time.";
        }
    }
}

