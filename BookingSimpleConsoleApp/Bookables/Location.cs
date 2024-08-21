namespace BookingSimpleConsoleApp
{
    public class Location : Bookable
    {
        // Constructor:

        public Location(string name) : base(name)
        {
        }

        // Public Methods:

        // EFFECTS: Override method that returns a specific explanation for location objects.

        public override string explanation()
        {
            string explanation = "\n- the room " + Name + " is not available at this time.";
            return explanation;
        }
    }
}