using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingSystem.Components.Model
{
    internal class Flight : IEquatable<Flight>
    {
  
        public string FlightId { get; }
        public string Airline { get; }
        public Airport Source { get; }
        public Airport Destination { get; }
        public string Day { get; }
        public string Time { get; }
        public int TotalSeats { get; }
        public decimal Cost { get; }
        public int BookedSeats { get; private set; }

    
        public Flight(string flightId, string airline, Airport source, Airport destination, string day, string time, int totalSeats, decimal cost)
        {
            FlightId = flightId;
            Airline = airline;
            Source = source;
            Destination = destination;
            Day = day;
            Time = time;
            TotalSeats = totalSeats;
            Cost = cost;
        }

       
        public bool Equals(Flight other)
        {
            if (other == null) return false;
            return FlightId == other.FlightId && Airline == other.Airline && Day == other.Day && Time == other.Time;
        }

        
        public override int GetHashCode()
        {
            return HashCode.Combine(FlightId, Airline, Day, Time);
        }
    }
}

namespace FlightBookingSystem.Components.Model
{
    internal class Airports
    {
        public string Code { get; }
        public string Name { get; }

        public Airports(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}

namespace FlightBookingSystem.Components.Model
{
    internal class Reservation
    {
        public string ReservationCode { get; }
        public string TravelerName { get; }
        public string Citizenship { get; }
        public Flight ReservedFlight { get; }

        public Reservation(string reservationCode, string travelerName, string citizenship, Flight reservedFlight)
        {
            ReservationCode = reservationCode;
            TravelerName = travelerName;
            Citizenship = citizenship;
            ReservedFlight = reservedFlight;
        }
    }
}