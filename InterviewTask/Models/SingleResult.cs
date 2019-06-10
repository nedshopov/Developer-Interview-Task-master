using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JuniorInterviewTask.Models
{
   public class SingleResult : RequestResultModel
   {
      public WeatherInfo Result { get; set; }

      public string Message { get; set; }
   }
}