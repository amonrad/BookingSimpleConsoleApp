namespace BookingSimpleConsoleApp
{
	public static class Factory
	{

        // gathers all dependencies in one place in the application:

        public static IMeeting CreateMeeting(IBookable client, DateTime dateTime, int duration, IBookable employee, IBookable location)
		{
			return new Meeting(client, dateTime, duration, employee, location);
		}

		public static IBookable CreateLocation(string name)
		{
			return new Location(name);
		}

		public static IBookable CreateEmployee(string name)
		{
			return new Employee(name);
		}

        public static IBookable CreateClient(string name)
        {
            return new Client(name);
        }

		public static IDataCollectionForm CreateDateCollectionForm()
		{
			return new DataCollectionForm();
		}

		public static IDisplay CreateDisplay()
		{
			return new Display();
		}

		public static IHandleBooking CreateHandleBooking(IDictionary<string, List<IMeeting>> calendar)
		{
			return new HandleBooking(calendar);
		}

        public static INewBookingsForm CreateNewBookingsForm(List<IBookable> locations, List<IBookable> employees, List<IBookable> clients, IHandleBooking handleBooking)
        {
            return new NewBookingsForm(locations, employees, clients, handleBooking);
        }

        public static IReception CreateReception()
        {
            return new Reception();
        }

		public static IDictionary<string, List<IMeeting>> createDictionaryOfIMeetings()
		{
			return new Dictionary<string, List<IMeeting>>();
        }

		public static List<IBookable> createListOfIBookables()
		{
			return new List<IBookable>();
        }

		public static List<IMeeting> createListOfIMeeting()
		{
			return new List<IMeeting>();
		}

		public static TimeSpan createNewTimeSpan(int hours, int minutes, int seconds)
		{
			return new TimeSpan(hours, minutes, seconds);
        }

		public static Random createNewRandom()
		{
			return new Random();
		}

		public static DateTime createNewDateTime(int year, int month, int day, int hour, int minute, int second)
		{
			return new DateTime(year, month, day, hour, minute, second);
        }

    }
}

