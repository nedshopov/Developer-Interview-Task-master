using System;

namespace Contracts.Models
{
   /// <summary>
   /// Base interface for data transfer objects.
   /// </summary>
   public interface IIdentifiableDto
   {
      Guid Id { get; set; }
   }
}
