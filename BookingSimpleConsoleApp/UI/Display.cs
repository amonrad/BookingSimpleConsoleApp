namespace BookingSimpleConsoleApp
{
    public class Display : IDisplay
    {
        // Constructor:

        public Display()
        {
        }

        // Public Method:

        // REQUIRES: dictionary is not null
        // EFFECTS: Prints the calendar to the console in chronological order

        public void DisplayMeetingCalendar(IDictionary<string, List<IMeeting>> calendar)
        {
            try
            {
                // Check if the calendar is null
                if (calendar == null)
                {
                    throw new ArgumentNullException("Calendar must not be null.");
                }

                // Check if the calendar is empty - if not, print it to the console
                if (calendar.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("The meeting calendar is empty, no meetings are booked.");
                    Console.WriteLine("\nPress any key to return to the menu.");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Meeting Overview: \n");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($" {"Date",-20} {"Time",-20} {"Client",-20} {"Employee",-20} {"Location",-20}");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------\n");

                    // Loop over dictionary sorted by date
                    foreach (var pair in calendar.OrderBy(entry => entry.Key))
                    {
                        // Sort the list of meetings for the current date by start time
                        var sortedMeetings = pair.Value.OrderBy(meeting => meeting.Start).ToList();

                        // Print sorted list for the current date
                        foreach (var meeting in sortedMeetings)
                        {
                            Console.WriteLine($" {meeting.Date,-20} {meeting.TimeSlot,-20} {meeting.Client.Name,-20} {meeting.Employee.Name,-20} {meeting.Location.Name,-20}\n");
                        }
                    }

                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

                    Console.WriteLine("\nPress any key to return to the menu.");
                    Console.ReadKey();
                }
            }
            catch (ArgumentNullException ex)
            {
                // Handle if calendar is null
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}