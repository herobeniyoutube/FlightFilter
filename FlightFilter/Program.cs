
using Gridnine.FlightCodingTest;

class Program
{
    public static void Main(string[] args)
    {
        var Flight = FlightFilterClass.GetFlightFilter();
        var FlightBuilder = new FlightBuilder();


      


       
        
        Flight.FlightConsoleWriter(Flight.FlightFilter(FlightBuilder.GetFlights(), FlightFilterClass.rulesNames.first));
        Console.WriteLine("_____________________________________");

        Flight.FlightConsoleWriter(Flight.FlightFilter(FlightBuilder.GetFlights(), FlightFilterClass.rulesNames.second));
        Console.WriteLine("_____________________________________");
        Flight.FlightConsoleWriter(Flight.FlightFilter(FlightBuilder.GetFlights(), FlightFilterClass.rulesNames.third));

    }
}