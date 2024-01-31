using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest
{
    public class FlightFilterClass
    {
        private static bool isCreated = false;
        private static FlightFilterClass myObject;
        
        private FlightFilterClass() 
        {
            if (isCreated == false)
            {
                isCreated = true;
                
            }
        }


        public List<Flight> FlightFilter(IList<Flight> flightsList, rulesNames ruleName)
        {
            
            switch (ruleName)
            {
                case rulesNames.first:
                    return flightsList.Where(flight => !DepartureBeforeDateTimeNow(flight)).ToList();                
                case rulesNames.second:
                    return flightsList.Where(flight => !HasSegmentsWithArrivalBeforeDeparture(flight)).ToList();
                case rulesNames.third:
                    return flightsList.Where(flight => !LandingTimeExceedes2Hours(flight)).ToList();
                default:
                    throw new ArgumentException();
            }    
            
            

             
        }
        public void FlightConsoleWriter(List<Flight> filteredFlights)
        {
            foreach (var flight in filteredFlights)
            {
                Console.WriteLine("Перелет:");
                for (int i = 0; i < flight.Segments.Count; i++)
                {
                    Console.WriteLine($"Отправка: {flight.Segments[i].DepartureDate} Прилет:{flight.Segments[i].ArrivalDate}");
                }

            }
        }
        private bool DepartureBeforeDateTimeNow(Flight flight)
        {
            bool rule1;
            rule1 = flight.Segments[0].DepartureDate < DateTime.Now;
            return rule1;
        }
        private bool HasSegmentsWithArrivalBeforeDeparture(Flight flight) 
        {
            bool rule2 = false;
            for (int i = 0; i < flight.Segments.Count; i++)
            {
                rule2 = flight.Segments[i].DepartureDate > flight.Segments[i].ArrivalDate;
                if (rule2) { return rule2; }
            }

            return rule2;
        }
        private bool LandingTimeExceedes2Hours(Flight flight) 
        {
            bool rule3 = false;
            int timeBeingLanded = 0;
            if (flight.Segments.Count == 1)
            {
                return rule3;
            }
            for (int i = 0;i < flight.Segments.Count; i++) 
            {
                if (flight.Segments.Count-1 != i)
                {

                    timeBeingLanded += Convert.ToInt32((flight.Segments[i + 1].DepartureDate - flight.Segments[i].ArrivalDate).Hours);
                }
                if (timeBeingLanded > 2)
                {
                    rule3 = true; 
                    return rule3;
                }
            }
            return rule3;
        }
        public enum rulesNames
        {
            first,
            second,
            third
            
        }
        public static FlightFilterClass GetFlightFilter()
        {
             if (isCreated == false)
            {
                return new FlightFilterClass();
            }
             return myObject;


            
        }
    }
}
