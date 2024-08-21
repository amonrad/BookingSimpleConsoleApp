namespace BookingSimpleConsoleApp
{
    public interface IMeeting
    {
        IBookable Client { get; }
        DateTime Start { get; }
        DateTime End { get; }
        IBookable Employee { get; }
        IBookable Location { get; }
        string TimeSlot { get; }
        string Date { get; }
        bool isPossible { get; set; }

        void addRejectionCause(string cause);
        string meetingConfirmation();
        string meetingRejection();
    }
}