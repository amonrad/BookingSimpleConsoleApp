namespace BookingSimpleConsoleApp
{
    public interface IBookable
    {
        string Name { get; }
        IDictionary<DateTime, IMeeting> Calendar { get; }

        void addBookingToCalendar(IMeeting requestedMeeting);
        string explanation();
        bool isBookingPossible(IMeeting requestedMeeting);
    }
}