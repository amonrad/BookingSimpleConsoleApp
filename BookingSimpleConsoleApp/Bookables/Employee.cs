namespace BookingSimpleConsoleApp
{
    public class Employee : Bookable
    {
        // Constructor:

        public Employee(string name) : base(name)
        {
        }

        // Public methods:

        // EFFECTS: Override method that returns a specific explanation for employee objects.

        public override string explanation()
        {
            string explanation = "\n- our employee " + Name + " is not available at this time.";
            return explanation;
        }

    }
}
