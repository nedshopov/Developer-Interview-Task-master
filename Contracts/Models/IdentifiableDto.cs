using System;

namespace Contracts.Models
{
   /// <summary>
   /// Base object for data transfer objects.
   /// </summary>
   public abstract class IdentifiableDto : IIdentifiableDto
   {
      public Guid Id { get; set; }
   }
}
