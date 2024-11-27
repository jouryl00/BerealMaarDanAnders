namespace crudfototut.Views;

public partial class HomePage : ContentPage
{
    private LocalDbTut LocalDbTut;
    public HomePage()
    {
        InitializeComponent();
        LocalDbTut = new LocalDbTut();
    }

    

       private void AssignmentsButton_Clicked(object sender, EventArgs e)
    {

       

    }

    private void FeedButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FeedPage());

    }

    private void ProfileButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());

    }

    private void MakePhotoButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MakePhotoPage());

    }
}