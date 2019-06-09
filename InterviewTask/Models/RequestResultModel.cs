using System.Collections.Generic;

namespace JuniorInterviewTask.Models
{
   public class RequestResultModel
   {
      /// <summary>
      /// Result models.
      /// </summary>
      public IList<HelperServiceModel> Results { get; set; }

      /// <summary>
      /// Whether the model is missing data.
      /// </summary>
      public bool RequestFail { get; set; }
   }
}