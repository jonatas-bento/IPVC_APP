using IPBVC_App.Models;
using Syncfusion.Maui.Core;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;

namespace IPBVC_App.ViewModel
{
    public class EventsViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Events { get; private set; } = new ObservableCollection<Event>();

        public ICommand LoadEventsCommand { get; }
        public ICommand AddEventCommand { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value, nameof(IsLoading));
        }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; } = DateTime.Now; // Default to current date
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }


        public EventsViewModel()
        {
            // Command to load events
            //LoadEventsCommand = new Command(async () => await LoadEventsAsync());
            AddEventCommand = new Command(AddEvent);

            // Auto-load events when ViewModel is created
            //LoadEventsCommand.Execute(null);
        }

        public async Task LoadEventsAsync(Event? data = null)
        {
            
            try
            {
                if (Events.Count == 0) // Only load if the collection is empty
                {
                    // Simulated delay for backend fetching
                    await Task.Delay(2000); // Simulate backend call delay
                    Events.Add(new Event { EventId = 1, EventName = "Sunday Service", EventDate = DateTime.Now, EventLocation = "Church Hall", EventDescription = "Regular Sunday Service" });
                    Events.Add(new Event { EventId = 2, EventName = "Bible Study", EventDate = DateTime.Now.AddDays(2), EventLocation = "Church Hall", EventDescription = "Regular Bible Study" });
                    Events.Add(new Event { EventId = 3, EventName = "Prayer Meeting", EventDate = DateTime.Now, EventLocation = "Church Hall", EventDescription = "Regular Prayer Meeting" });
                }
            }
            catch (TargetInvocationException ex)
            {
                // Log the error or manage the UI state to show an error messa
                Console.WriteLine($"Failed to load events: {ex.Message}");
                Debug.WriteLine($"Failed to load events: {ex.Message}");
                //throw new Exception(ex.Message);
            }
            
        }

        private async void AddEvent()
        {
            // Create and add a new event based on ViewModel properties
            var newEvent = new Event
            {
                EventName = this.EventName, // Ensure these properties are defined and bound in ViewModel
                EventDate = this.EventDate,
                EventLocation = this.EventLocation,
                EventDescription = this.EventDescription
            };
            if (newEvent != null)
            {
                Events.Add(newEvent);
                ClearFields();

                await Application.Current.MainPage.DisplayAlert("Success", "Event added successfully", "OK");

                await Shell.Current.GoToAsync("..");

            }
        }

        private void ClearFields()
        {
            EventName = string.Empty;
            EventDate = DateTime.Now; // or set to a default date
            EventLocation = string.Empty;
            EventDescription = string.Empty;
            OnPropertyChanged(nameof(EventName));
            OnPropertyChanged(nameof(EventDate));
            OnPropertyChanged(nameof(EventLocation));
            OnPropertyChanged(nameof(EventDescription));
        }

    }
}
