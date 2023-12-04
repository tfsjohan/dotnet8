namespace Frontend
{
    public class WeatherApiClient(HttpClient httpClient)
    {
        public async Task<WeatherForecast[]?> GetWeatherForecastAsync()
        {
            return await httpClient.GetFromJsonAsync<WeatherForecast[]>("weatherforecast");
        }
    }
}
