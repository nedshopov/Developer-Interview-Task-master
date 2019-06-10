using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JuniorInterviewTask.Models
{
   public class CollectionResult : RequestResultModel
   {
      /// <summary>
      /// Result models.
      /// </summary>
      public IList<HelperServiceModel> Results { get; set; }
   }
}