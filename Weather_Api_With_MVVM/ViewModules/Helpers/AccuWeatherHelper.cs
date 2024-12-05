using Newtonsoft.Json;
using System.Net.Http;
using Weather_Api_With_MVVM.Modules;

namespace Weather_Api_With_MVVM.ViewModules.Helpers
{
    internal class AccuWeatherHelper
    {
        public const string API_KEY = "vCVuJ6TCyxCflpsBOEUX9AJcgxjnbUFA";
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<City>> GetCities(string query)
        {
            string url = string.Format(BASE_URL + AUTOCOMPLETE_ENDPOINT, API_KEY, query);
            //string url = BASE_URL + string.Format( AUTOCOMPLETE_ENDPOINT, API_KEY, query);
            using HttpClient httpClient = new();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var cities = JsonConvert.DeserializeObject<List<City>>(json);
                return cities!;
            }
            return null;
        }
        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            string url = string.Format(BASE_URL + CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);
            //string url = BASE_URL + string.Format( CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);
            using HttpClient httpClient = new();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json);
                return currentConditions!.FirstOrDefault()!;
            }
            return null;
        }
    }
}
