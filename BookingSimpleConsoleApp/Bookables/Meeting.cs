namespace BookingSimpleConsoleApp
{
       public class Meeting : IMeeting
    {
        // fields:

        private IBookable client;
        private DateTime start;
        private DateTime end;
        private IBookable employee;
        private IBookable location;
        private string date;
        private string timeSlot;
        private string rejection;
        private bool isMeetingPossible = false;

        // Constructor:

        public Meeting(IBookable client, DateTime dateTime, int duration, IBookable employee, IBookable location)
        {
            this.client = client;
            this.start = dateTime;
            this.employee = employee;
            this.location = location;
            end = dateTime.AddMinutes(duration);

            date = Start.ToString("dd/MM-yyyy");
            timeSlot = Start.ToString("HH:mm") + "-" + Start.AddMinutes(duration).ToString("HH:mm");

            rejection = "Dear " + client.Name + " - Unfortunately, it is not possible to book your requested meeting on " + date + " at " + timeSlot + " because: ";
        }

        // getters & setters:

        public IBookable Client { get { return client; } }
        public DateTime Start { get { return start; } }
        public DateTime End { get { return end; } }
        public IBookable Employee { get { return employee; } }
        public IBookable Location { get { return location; } }
        public string TimeSlot { get { return timeSlot; } }
        public string Date { get { return date; } }
        public bool isPossible { get { return isMeetingPossible; } set { isMeetingPossible = value; } }

        // public methods:


        // EFFECTS: Returns confirmation for booked meeting with client's name, date, time, location, and employee's name.
        public string meetingConfirmation()
        {
            // Composes string based on meeting information.
            string meetingConfirmation = "Dear " + client.Name + " - You have successfully booked a meeting on " + date + " at " + timeSlot + " at " + Location.Name + ". You will be greeted by our friendly employee " + Employee.Name + ".";

            return meetingConfirmation;
        }

        // EFFECTS: Returns reason ('rejection') for rejecting the meeting.
        public string meetingRejection()
        {
            return rejection;
        }

        // MODIFIES: Changes 'rejection'
        // EFFECTS: add specified string to 'rejection'
        public void addRejectionCause(string cause)
        {
            rejection = rejection + cause;
        }
    }
}