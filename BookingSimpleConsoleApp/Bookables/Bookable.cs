namespace BookingSimpleConsoleApp
{
    public abstract class Bookable : IBookable
    {
        // Fields:
        private string name;

        private IDictionary<DateTime, IMeeting> calendar;

        // Constructor:

        public Bookable(string name)
        {
            this.name = name;
            calendar = new Dictionary<DateTime, IMeeting>();
        }

        // Getters:

        public string Name { get { return name; } }
        public IDictionary<DateTime, IMeeting> Calendar { get { return calendar; } }

        // Public methods:


        // EFFECTS: Returns true if the requested meeting does not overlap with existing meetings in the calendar. Otherwise, returns false.

        public bool isBookingPossible(IMeeting requestedMeeting)
        {
            bool possible = true;

            // DateTime for validation
            DateTime dateToCheck = requestedMeeting.Start.Date;
            DateTime meetingStart = requestedMeeting.Start;
            DateTime meetingEnd = requestedMeeting.End;

            // Check if date already exists in the calendar
            if (calendar.Keys.Any(existingDate => existingDate.Date == dateToCheck))
            {
                // Check for overlap with existing meetings
                foreach (DateTime existingMeeting in calendar.Keys)
                {
                    DateTime existingMeetingStart = calendar[existingMeeting].Start;
                    DateTime existingMeetingEnd = calendar[existingMeeting].End;

                    if (isDateTimesOverlapping(requestedMeeting.Start, requestedMeeting.End, existingMeetingStart, existingMeetingEnd))
                    {
                        // Return false if the meeting cannot be booked due to overlap in the calendar
                        possible = false;
                    }
                }
            }

            // Return true if the meeting can be booked
            return possible;
        }


        // MODIFIES: this.calendar
        // EFFECTS: Adds the requested meeting to the calendar.

        public void addBookingToCalendar(IMeeting requestedMeeting)
        {
            calendar[requestedMeeting.Start] = requestedMeeting;
        }


        // EFFECTS: Returns true if start and end times overlap between two meetings, otherwise false.

        public bool isDateTimesOverlapping(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            // Check for non-overlapping cases
            if (end1 <= start2 || end2 <= start1)
            {
                return false;
            }

            // If they are not non-overlapping, they must overlap
            return true;
        }


        // EFFECTS: Virtual method overridden in subclasses.

        public virtual string explanation()
        {
            return "";
        }
    }
}