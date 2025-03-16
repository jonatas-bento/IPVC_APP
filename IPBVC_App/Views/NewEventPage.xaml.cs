using IPBVC_App.Models;
using IPBVC_App.ViewModel;

namespace IPBVC_App.Views;

public partial class NewEventPage : ContentPage
{
    
        private EventsViewModel _viewModel;

        public NewEventPage()
        {
            InitializeComponent();

            BindingContext = new EventsViewModel();

        }
    
}