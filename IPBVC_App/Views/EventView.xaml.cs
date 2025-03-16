using IPBVC_App.ViewModel;
using System.Diagnostics;

namespace IPBVC_App.Views;

public partial class EventView : ContentPage
{
	private readonly EventsViewModel _viewModel;

    public EventView()
	{
        InitializeComponent();
        _viewModel = new EventsViewModel();
        BindingContext = _viewModel;
    }

    public async void OnNewEventClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewEventPage));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            _viewModel.IsLoading = true;
            await _viewModel.LoadEventsAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error loading events: " + ex.Message);
            // Optionally show an error message to the user
        }
        finally
        {
            _viewModel.IsLoading = false;
        }
    }

}