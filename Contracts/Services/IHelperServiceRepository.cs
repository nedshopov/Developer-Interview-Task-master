using System;
using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.Services
{
    interface IHelperServiceRepository
    {
        IEnumerable<HelperServiceDto> Get();
        HelperServiceDto Get(Guid id);
    }
}
