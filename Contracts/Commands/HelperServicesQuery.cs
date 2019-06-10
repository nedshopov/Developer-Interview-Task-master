using Contracts.Models;
using Contracts.Services;
using System.Collections.Generic;
using System.Linq;

namespace Contracts.Commands
{
   /// <summary>
   /// Basic query for helper services. Ideally, it's handler should be in a separate class.
   /// </summary>
   public class HelperServicesQuery : BaseCollectionRequest<HelperServiceDto>
   {
      /// <summary>
      /// Repository of helper services.
      /// </summary>
      IHelperServiceRepository repository;

      /// <summary>
      /// Constructor.
      /// </summary>
      public HelperServicesQuery()
      {
         repository = new HelperServiceRepository();
      }

      /// <summary>
      /// Set the result entities.
      /// </summary>
      public void Handle()
      {
         IEnumerable<HelperServiceDto> results = repository.Get();
         IsSuccessful = results.ToList().Where(x => x.MondayOpeningHours == null).Count() == 0;
         if(IsSuccessful)
         {
            SimpleLogger.LogInfo("Request for helper service information successful.");
         }
         else
         {
            SimpleLogger.LogError("Request for helper service information contians errors.");
         }
         Results = results;
      }
   }
}
