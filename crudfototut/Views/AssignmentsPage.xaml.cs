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
                };
                await _localDbTut.InsertThemeAsync(initialThemes);

            }
            ThemePicker.ItemsSource = await _localDbTut.GetThemesAsync();
        });


            Task.Run(async () => ListviewAssignments.ItemsSource = await _localDbTut.GetAssignmentsAsync());
    }

    private async void CreateButton_Clicked(object sender, EventArgs e)
    {
        if (_editAssignmentId == 0)
        {
            //add assignment
            await _localDbTut.Create(new Models.Assignment
            { Description = DescriptionEntry.Text, Theme = ThemeEntry.Text });
        }
        else
        {                 //update assignment
            await _localDbTut.Update(new Models.Assignment
            { Id = _editAssignmentId, Description = DescriptionEntry.Text, Theme = ThemeEntry.Text });
            _editAssignmentId = 0;
        }
        DescriptionEntry.Text = string.Empty;
        ThemeEntry.Text = string.Empty;
        ListviewAssignments.ItemsSource = await _localDbTut.GetAssignmentsAsync();

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
                ThemeEntry.Text = assignment.Theme;
                break;
            case "Delete":
                await _localDbTut.Delete(assignment);
                ListviewAssignments.ItemsSource = await _localDbTut.GetAssignmentsAsync();

                break;
        }
        DescriptionEntry.Text = assignment.Description;
        ThemeEntry.Text = assignment.Theme;
        _editAssignmentId = assignment.Id;

    }
}