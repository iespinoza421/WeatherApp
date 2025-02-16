using Newtonsoft.Json.Linq;


namespace WeatherApp.Services
{
    public class WeatherServices
    {
        //API Key
        private readonly string apiKey = "411602552d479b666b9af8432eaaf972";
        //HTTP Client for requests
        private readonly HttpClient _httpClient;

        public WeatherServices(HttpClient httpClient)
        {
            _httpClient = httpClient; //Injecting the HTTP Client
        }

        public async Task<Object> GetWeatherAsync(double lat, double lon)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            return JObject.Parse(response);
        }

        public async Task<Object> GetForecastAsync(double lat, double lon)
        {
            string url = $"http://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            return JObject.Parse(response);
        }
    }
}
