using System.Collections.ObjectModel;
using System.ComponentModel;
using Weather_Api_With_MVVM.Modules;
using Weather_Api_With_MVVM.ViewModules.Commands;
using Weather_Api_With_MVVM.ViewModules.Helpers;

namespace Weather_Api_With_MVVM.ViewModules
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query!; }
            set 
            { 
                query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set 
            { 
                currentConditions = value; 
                OnPropertyChanged(nameof(CurrentConditions));
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set 
            { 
                selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
            }
        }
        public SearchCommand SearchCommand { get; set; }
        public GetCurrentConditionCommand GetCurrentConditionCommand { get; set; }
        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City()
                {
                    LocalizedName = "New York",
                };
                CurrentConditions = new CurrentConditions()
                {
                    WeatherText = "Partly Cloudy",
                    Temperature = new Temperature()
                    {
                        Metric = new Units()
                        {
                            Value = 21
                        }
                    }
                };
            }
            SearchCommand = new SearchCommand(this);
            GetCurrentConditionCommand = new GetCurrentConditionCommand(this);
            Cities = new ObservableCollection<City>();
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
            Cities.Clear();
            if (cities != null)
            {
                /*foreach (var city in cities)
                {
                    Cities.Add(city);
                }*/
                cities.ForEach(city => Cities.Add(city));
            }
            Query = string.Empty;
        }
        public async void GetWeather()
        {
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged( string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
