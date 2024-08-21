namespace BookingSimpleConsoleApp
{
    public class HandleBooking : IHandleBooking
    {
        // Fields:

        private IDictionary<string, List<IMeeting>> calendar;
        List<IMeeting> meetings;
        private string rejectionCause = "";

        // Constructor:

        public HandleBooking(IDictionary<string, List<IMeeting>> calendar)
        {
            this.calendar = calendar;
        }

        // Public methods:

        // REQUIRES: A valid meeting.
        // EFFECTS: Indicates whether the booking is possible or not.

        public bool isRequestedBookingPossible(IMeeting requestedMeeting)
        {
            if (requestedMeeting == null || requestedMeeting.Location == null || requestedMeeting.Employee == null || requestedMeeting.Client == null)
            {
                // Handle if requestedMeeting is null
                throw new ArgumentNullException("requestedMeeting", "The meeting or its properties cannot be null.");
            }

            bool isBookingPossible = true;

            // Create a list of bookables
            List<IBookable> bookables = Factory.createListOfIBookables();
            bookables.Add(requestedMeeting.Location);
            bookables.Add(requestedMeeting.Employee);
            bookables.Add(requestedMeeting.Client);

            foreach (Bookable bookable in bookables)
            {
                // Check if bookables do NOT have availability in their calendar for the requested meeting
                if (!bookable.isBookingPossible(requestedMeeting))
                {
                    isBookingPossible = false;
                    // Add an explanation to the rejection of the meeting
                    requestedMeeting.addRejectionCause(bookable.explanation());
                }
            }
            // Add validation to the meeting object
            requestedMeeting.isPossible = isBookingPossible;

            return isBookingPossible;
        }

        // REQUIRES: A valid meeting.
        // MODIFIES: Modifies the calendar for each Bookable instance and the meeting calendar.
        // EFFECTS: Adds the meeting to the calendar, throws exception if the meeting is not validated.

        public void AddMeetingToCalendar(IMeeting requestedMeeting)
        {
            if (requestedMeeting == null || requestedMeeting.Location == null || requestedMeeting.Employee == null || requestedMeeting.Client == null)
            {
                // Handle if requestedMeeting is null
                throw new ArgumentNullException("requestedMeeting", "The meeting or its properties cannot be null.");
            }

            List<IBookable> bookables = Factory.createListOfIBookables();

            // Add instances of subclasses and add them to the list

            bookables.Add(requestedMeeting.Location);
            bookables.Add(requestedMeeting.Employee);
            bookables.Add(requestedMeeting.Client);

            // Check that the meeting is validated before adding it to the calendar
            if (requestedMeeting.isPossible)
            {
                foreach (Bookable bookable in bookables)
                {
                    // Add the meeting to the bookables' calendars
                    bookable.addBookingToCalendar(requestedMeeting);
                }

                // Create a key string (convert DateTime to string and append the client name)
                string formattedKeyString = requestedMeeting.Start.ToString("yyyyMMdd") + requestedMeeting.Client.Name;

                // Book the meeting in the calendar dictionary!!
                addMeetingToDictionary(formattedKeyString, requestedMeeting);
            }
            else
            {
                // Handle the case where the meeting is not possible (validation failed)
                throw new InvalidOperationException("The meeting cannot be added to the calendar because it is not validated.");
            }
        }


        // Private methods:

        // MODIFIES: Modifies the calendar.
        // EFFECTS: Checks and initializes the meeting list on the specified date in the calendar and adds the meeting to this list.

        private void addMeetingToDictionary(string date, IMeeting meeting)
        {
            // Check if the key does not yet exist in the dictionary
            if (!calendar.ContainsKey(date))
            {
                // If not, initialize the meeting list on the specified date
                calendar[date] = Factory.createListOfIMeeting();
            }

            // Add the meeting to the meeting list on the specified date
            calendar[date].Add(meeting);
        }
    }
}