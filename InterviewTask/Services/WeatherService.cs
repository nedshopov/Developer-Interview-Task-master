using JuniorInterviewTask.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Contracts.Services
{
   public class WeatherService
   {
      public const string APIID = "1893b9543119118aa0ae6adb3feb56c0";

      public async Task<SingleResult> GetWeatherData(string city)
      {
         SingleResult result = new SingleResult();
         using(var client = new HttpClient())
         {
            try
            {
               client.BaseAddress = new Uri("http://api.openweathermap.org");
               var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={APIID}&units=metric");
               response.EnsureSuccessStatusCode();
               var stringResult = await response.Content.ReadAsStringAsync();
               WeatherInfo weather = JsonConvert.DeserializeObject<WeatherInfo>(stringResult);
               result.Result = weather;
               result.IsSuccessful = true;
               SimpleLogger.LogInfo("Weather information on " + city +" received.");
            }
            catch(HttpRequestException httpRequestException)
            {
               result.IsSuccessful = false;
               result.Message = "We can't get information for this place at the moment.";
               SimpleLogger.LogError(httpRequestException.Message);
            }
         }
         return result;
      }
   }
}
