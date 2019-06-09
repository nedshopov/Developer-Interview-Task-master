using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contracts.Services
{
    public class HelperServiceRepository : IHelperServiceRepository
    {
        /// <summary>
        /// Returns all HelperService data, form the back-office CRM system.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HelperServiceDto> Get()
        {
            return HelperServiceFactory.Create();
        }

        /// <summary>
        /// Returns a single HelperService from the back-office CRM system.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public HelperServiceDto Get(Guid id)
        {
            return HelperServiceFactory.Create().FirstOrDefault(g => g.Id == id);
        }
    }
}