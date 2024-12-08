using SQLite;
namespace crudfototut.Views;


public partial class AssignmentsPage : ContentPage
{
    private readonly LocalDbTut _localDbTut;
    private int _editAssignmentId;
    public AssignmentsPage(LocalDbTut localDbTut)
	{
		InitializeComponent();
        _localDbTut = localDbTut;

        Task.Run(async () =>
        {
            var themes = await _localDbTut.GetThemesAsync();
            if (themes.Count == 0)
            {
                var initialThemes = new List<Models.Theme>
                {
                    new Models.Theme { Name = "Nature" },
                    new Models.Theme { Name = "You" },
                    new Models.Theme { Name = "other" },
                    //Update themes for final app

                };
                await _localDbTut.InsertThemeAsync(initialThemes);

            }
            ThemePicker.ItemsSource = await _localDbTut.GetThemesAsync();
        });


            Task.Run(async () => ListviewAssignments.ItemsSource = await _localDbTut.GetAssignmentsAsync());
    }
    private async Task LoadAssignmentsAsync()
    {
        //await _localDbTut.GetAssignmentsAsync(); 
        //ListviewAssignments.ItemsSource = await _localDbTut.GetAssignmentsAsync();
        var assignments = await _localDbTut.GetAssignmentsAsync();
        ListviewAssignments.ItemsSource = assignments;
    }

    private async void CreateButton_Clicked(object sender, EventArgs e)
    {
        var selectedTheme = ThemePicker.SelectedItem as Models.Theme;
        if (selectedTheme == null)
        {
            await DisplayAlert("Error", "Please select a theme", "OK");
            return;
        }
        if (_editAssignmentId == 0)
        {
            //add assignment
            await _localDbTut.Create(new Models.Assignment 
            {
                Description = DescriptionEntry.Text, 
                ThemeId = selectedTheme.Id
            }); 
        }
        else
        {                 //update assignment
            await _localDbTut.Update(new Models.Assignment
            { 
                Id = _editAssignmentId, 
                Description = DescriptionEntry.Text,
                ThemeId = selectedTheme.Id

            }); 
            _editAssignmentId = 0;
        }
        DescriptionEntry.Text = string.Empty;
        ThemePicker.SelectedItem = null;
        await LoadAssignmentsAsync();
        

    }

    private async void ListviewAssignment_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var assignment = e.Item as Models.Assignment;
        var action = await DisplayActionSheet("Assignment", "Cancel", null, "Edit", "Delete");
        switch (action)
        {
            case "Edit":
                _editAssignmentId = assignment.Id;
                DescriptionEntry.Text = assignment.Description;
                ThemePicker.SelectedItem = (await _localDbTut.GetThemesAsync()).FirstOrDefault(t => t.Id == assignment.ThemeId);
                break;
            case "Delete":
                await _localDbTut.Delete(assignment);
                ListviewAssignments.ItemsSource = await _localDbTut.GetAssignmentsAsync();
                await LoadAssignmentsAsync();

                break;
        }
        //DescriptionEntry.Text = assignment.Description;
        //_editAssignmentId = assignment.Id;

    }
}