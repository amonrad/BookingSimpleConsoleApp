namespace BookingSimpleConsoleApp
{
    public class NewBookingsForm : INewBookingsForm
    {
        // Fields:

        List<IBookable> locations;
        List<IBookable> employees;
        List<IBookable> clients;

        private IHandleBooking handleBooking;
        private IDataCollectionForm dataCollectionForm;

        // Constructor:

        public NewBookingsForm(List<IBookable> locations, List<IBookable> employees, List<IBookable> clients, IHandleBooking handleBooking)
        {
            this.locations = locations;
            this.employees = employees;
            this.clients = clients;
            this.handleBooking = handleBooking;

            // Create an object for data collection
            dataCollectionForm = Factory.CreateDateCollectionForm();
        }

        // Public methods:

        // REQUIRES: User input for selecting client, date, duration, employee, and location.
        // MODIFIES: Potentially adds a meeting to the calendar.
        // EFFECTS: Creates a meeting, validates it, and then adds it to the calendar or rejects it. Also prints a confirmation or rejection message to the console.

        public void fillBookingForm()
        {
            // Obtain data about client, date, duration, employee, and location via user input
            IBookable selectedClient = dataCollectionForm.GetClientInput(clients);
            DateTime selectedDateTime = dataCollectionForm.getDateInput();
            int selectedDuration = dataCollectionForm.getDurationInput();
            IBookable selectedEmployee = dataCollectionForm.getEmployeeInput(employees);
            IBookable selectedLocation = dataCollectionForm.getLocationInput(locations);

            // Create a meeting for validation
            IMeeting requestedMeeting = Factory.CreateMeeting(selectedClient, selectedDateTime, selectedDuration, selectedEmployee, selectedLocation);

            // Add the meeting to the calendar if validated
            if (handleBooking.isRequestedBookingPossible(requestedMeeting))
            {
                handleBooking.AddMeetingToCalendar(requestedMeeting);
                // Print confirmation to console
                printResponse(requestedMeeting.meetingConfirmation());
            }
            else
            {
                // Print rejection to console
                printResponse(requestedMeeting.meetingRejection());
            }
        }

        // REQUIRES: User input for selecting client.
        // MODIFIES: Adds a meeting to the calendar.
        // EFFECTS: Generates and validates a random booking, adds the meeting to the calendar, and prints a confirmation message to the console.

        public void GenerateRandomBooking()
        {
            // Add client to the new meeting
            IBookable selectedClient = dataCollectionForm.GetClientInput(clients);

            // Generate fields and validate random booking

            IMeeting requestedMeeting = null;

            while (requestedMeeting == null)
            {
                DateTime randomDateTime = dataCollectionForm.GetRandomDateTime();
                int randomDuration = dataCollectionForm.GetRandomDuration();
                IBookable randomEmployee = dataCollectionForm.GetRandomElement(employees);
                IBookable randomLocation = dataCollectionForm.GetRandomElement(locations);

                // Create a meeting for validation
                requestedMeeting = Factory.CreateMeeting(selectedClient, randomDateTime, randomDuration, randomEmployee, randomLocation);

                if (!handleBooking.isRequestedBookingPossible(requestedMeeting))
                {
                    // If the meeting is not possible, set requestedMeeting to null and try again
                    requestedMeeting = null;
                }
            }

            // Now that 'requestedMeeting' is validated, it can be added to the calendar
            handleBooking.AddMeetingToCalendar(requestedMeeting);

            // Print confirmation to console
            printResponse(requestedMeeting.meetingConfirmation());
        }


        // Private methods:

        // EFFECTS: Clears console, prints string, and awaits user input.

        private static void printResponse(string response)
        {
            Console.Clear();
            Console.WriteLine(response);
            Console.ReadKey();
        }
    }
}