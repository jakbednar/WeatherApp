using System.Text.Json;

namespace WeatherAPI
{
    public class Program
    {
        static async Task Main()
        {
            string apiKey = "API_KEY";

            Console.Write("Zadej název města: ");

            string city = Console.ReadLine();
            string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                WeatherResponse data = JsonSerializer.Deserialize<WeatherResponse>(json, options);

                Console.WriteLine($"\n{data.location.name}, {data.location.region}, {data.location.country}");
                string rawTime = data.current.last_updated;
                DateTime parsedTime = DateTime.Parse(rawTime);
                string formatted = parsedTime.ToString("dd.MM.yyyy - HH:mm");
                Console.WriteLine($"Čas: {formatted}");
                Console.WriteLine($"Teplota: {data.current.temp_c}°C");
                Console.WriteLine($"Pocitová teplota: {data.current.feelslike_c}°C");
                Console.WriteLine($"Vítr: {data.current.wind_kph} km/h");
                Console.WriteLine($"Počasí: {data.current.condition.text}");
                Console.WriteLine($"UV index: {data.current.uv}");
            }
            else
            {
                Console.WriteLine("Nepodařilo se načíst data.");
            }
        }
    }

    public class WeatherResponse
    {
        public Location location { get; set; }
        public Current current { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string tz_id { get; set; }
        public long localtime_epoch { get; set; }
        public string localtime { get; set; }
    }

    public class Current
    {
        public string last_updated { get; set; }
        public double temp_c { get; set; }
        public Condition condition { get; set; }
        public double wind_kph { get; set; }
        public double feelslike_c { get; set; }
        public double uv { get; set; }
    }

    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }
    }

}
