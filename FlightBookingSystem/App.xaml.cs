using FlightBookingSystem.Components.Repository;

namespace FlightBookingSystem
{
    public partial class App : Application
    {
        private MainPage MainPage;

        public App()
        {
            InitializeComponent();

            DBManager.INSTANCE.InitializeAsync();

            MainPage = new MainPage();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }

    public class Application
    {
    }
}
