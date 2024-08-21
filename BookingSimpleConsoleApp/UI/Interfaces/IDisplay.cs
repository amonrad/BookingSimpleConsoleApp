namespace BookingSimpleConsoleApp
{
    public interface IDisplay
    {
        void DisplayMeetingCalendar(IDictionary<string, List<IMeeting>> calendar);
    }
}