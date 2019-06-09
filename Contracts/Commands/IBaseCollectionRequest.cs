using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Commands
{
   /// <summary>
   /// Basic interface for queries for collection of data.
   /// </summary>
   /// <typeparam name="T">Type of the data transfer object.</typeparam>
   public interface IBaseCollectionRequest<T> where T : IdentifiableDto
   {
      /// <summary>
      /// Collection results.
      /// </summary>
      IEnumerable<T> Results { get; set; }
   }
}
