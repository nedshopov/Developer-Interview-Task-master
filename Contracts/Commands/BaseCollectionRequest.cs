using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Commands
{
   /// <summary>
   /// Base class for collection requests.
   /// </summary>
   /// <typeparam name="T">Type of result dto.</typeparam>
   public abstract class BaseCollectionRequest<T> : IBaseCollectionRequest<T> where T : IdentifiableDto
   {
      /// <summary>
      /// Collection results.
      /// </summary>
      public IEnumerable<T> Results { get; set; }
   }
}
