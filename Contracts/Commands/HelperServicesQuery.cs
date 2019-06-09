using Contracts.Models;
using Contracts.Services;

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
         Results = repository.Get();
      }
   }
}
