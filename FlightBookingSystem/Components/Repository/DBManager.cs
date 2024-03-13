using FlightBookingSystem.Components.Exceptions;
using FlightBookingSystem.Components.Model;
using FlightBookingSystem.Components.ViewModel;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FlightBookingSystem.Components.Repository
{
    internal class DBManager
    {
        private static string AirportFile = "airports.csv";
        private static string FlightFile = "flights.csv";
        private static string ReservationFile = "reservations.csv";
        private FlightManager flightManager;

        public static DBManager INSTANCE { get; private set; } = new DBManager();

        private DBManager()
        {
            flightManager = FlightManager.INSTANCE;
        }

        public async Task InitializeAsync()
        {
            await LoadAirports();
            await LoadFlights();
        }

        public void RefreshFlights()
        {
            LoadFlights().Wait();
        }

        public void RefreshAirports()
        {
            LoadAirports().Wait();
        }

        private async Task LoadAirports()
        {
            try
            {
                using (var stream = new StreamReader(AirportFile))
                {
                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        string[] parts = line.Split(",");
                        flightManager.AddAirport(parts[0], parts[1]);
                    }
                }
            }
            catch (FileNotFoundException)
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error loading airports: {ex.Message}");
            }
        }

        private async Task LoadFlights()
        {
            try
            {
                using (var stream = new StreamReader(FlightFile))
                {
                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        string[] parts = line.Split(',');
                        flightManager.AddFlight(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], int.Parse(parts[6]), decimal.Parse(parts[7]));
                    }
                }
            }
            catch (FileNotFoundException)
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error loading flights: {ex.Message}");
            }
        }
    }
}
