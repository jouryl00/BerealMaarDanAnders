namespace crudfototut
{
    public partial class App : Application
    {
        public App(MainPage mainPage)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.HomePage());
        }
    }
}
