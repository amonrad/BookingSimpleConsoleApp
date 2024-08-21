namespace BookingSimpleConsoleApp
{
    public interface IHandleBooking
    {
        void AddMeetingToCalendar(IMeeting requestedMeeting);
        bool isRequestedBookingPossible(IMeeting requestedMeeting);
    }
}