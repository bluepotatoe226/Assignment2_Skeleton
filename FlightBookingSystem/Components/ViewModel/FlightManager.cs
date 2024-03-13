using FlightBookingSystem.Components.Model;
using FlightBookingSystem.Components.Repository;
using System;
using System.Collections.Generic;

namespace FlightBookingSystem.Components.ViewModel
{
    internal class FlightManager
    {
        public static FlightManager INSTANCE = new FlightManager();

        private List<Airport> AirportList = new List<Airport>();
        private List<Flight> FlightList = new List<Flight>();

        private FlightManager()
        {
        }

        public void AddAirport(string code, string name)
        {
            Airport newAirport = new Airport(code, name);

            if (!AirportList.Contains(newAirport))
                AirportList.Add(newAirport);
        }

        public void AddFlight(string flightId, string airline, string sourceCode, string destinationCode, string day, string time, int totalSeats, decimal cost)
        {
            Airport source = GetAirportByCode(sourceCode);
            Airport destination = GetAirportByCode(destinationCode);

            if (source == null || destination == null)
            {
                throw new ArgumentException("Invalid source or destination airport code.");
            }

            Flight newFlight = new Flight(flightId, airline, source, destination, day, time, totalSeats, cost);
            FlightList.Add(newFlight);
        }

        public Airport GetAirportByCode(string code)
        {
            return AirportList.Find(airport => airport.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
        }

        public List<Flight> FindFlights(string src, string dest, string day)
        {
            List<Flight> matchingFlights = FlightList.FindAll(flight =>
                flight.Source.Name.Equals(src, StringComparison.OrdinalIgnoreCase) &&
                flight.Destination.Name.Equals(dest, StringComparison.OrdinalIgnoreCase) &&
                (flight.Day.Equals(day, StringComparison.OrdinalIgnoreCase) || day.Equals("Any", StringComparison.OrdinalIgnoreCase)));

            return matchingFlights;
        }
    }
}
