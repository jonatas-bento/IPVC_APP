namespace IPBVC_App.Views;

public partial class HomeScreen : ContentPage
{
	public HomeScreen()
	{
		InitializeComponent();
	}

	private async void OnEventsClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(EventView));
	}

	private async void OnWhoWeAreClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(WhoWeArePage));
	}

	private async void OnBirthdayClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(BirthdayPage));
	}
}