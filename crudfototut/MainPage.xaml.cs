namespace crudfototut
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbTut _localDbTut;



        public MainPage(LocalDbTut localDbTut)
        {
            InitializeComponent();
            _localDbTut = localDbTut;

        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please enter both username and password", "OK");
                return;
            }

            var user = await _localDbTut.GetUserByNameAsync(username);
            if (user != null && user.Password == password)
            {
                await DisplayAlert("Success", "Login successful", "OK");
                // Navigate to the next page or main application page
                // For example:
                await Navigation.PushAsync(new Views.HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }

        }
    }

}
