using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JuniorInterviewTask.Models
{
   public class WeatherInfo
   {
      public string Name { get; set; }

      public IEnumerable<WeatherDescription> Weather { get; set; }
   }
}