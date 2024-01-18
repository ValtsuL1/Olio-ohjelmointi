using System;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.XPath;

namespace Tehtava
{
    public class Weather
    {
        public Current current {get;set;}
        public Location location {get;set;}
    }

    public class Current
    {
        public double temp_c {get;set;}
        public double wind_kph {get;set;}
        public double humidity {get;set;}
    }

    public class Location
    {
        public string name {get;set;}
        public string localtime {get;set;}
    }

    class Program
    {
        static async Task Main()
        {
            try
            {
            HttpClientHandler handler = new()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            HttpClient client = new(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");

            var stringTask = client.GetStreamAsync("http://api.weatherapi.com/v1/current.json?key=7ed490fc8d5e4d33a98120233232711&q=Rovaniemi&aqi=no");
            var weather = await JsonSerializer.DeserializeAsync<Weather>(await stringTask);


            var name = weather.location.name;
            var localTime = weather.location.localtime;

            var temperature = weather.current.temp_c;
            var windSpeed = weather.current.wind_kph;
            var humidity = weather.current.humidity;

            Console.WriteLine($"Sijainti: {name} | {localTime}");
            Console.WriteLine($"Lämpötila: {temperature} °C");
            Console.WriteLine($"Tuulennopeus: {windSpeed} m/s");
            Console.WriteLine($"Ilmankosteus: {humidity} %");

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Virhe: {e.Message}");
            }
        }
    }
}