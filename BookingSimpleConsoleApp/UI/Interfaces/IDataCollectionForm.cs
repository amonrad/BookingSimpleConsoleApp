namespace BookingSimpleConsoleApp
{
    public interface IDataCollectionForm
    {
        IBookable GetClientInput(List<IBookable> existingClients);
        DateTime getDateInput();
        int getDurationInput();
        IBookable getEmployeeInput(List<IBookable> employees);
        IBookable getLocationInput(List<IBookable> locations);
        DateTime GetRandomDateTime();
        int GetRandomDuration();
        T GetRandomElement<T>(List<T> list);
    }
}