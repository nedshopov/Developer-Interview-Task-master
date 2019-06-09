using System;
using System.Collections.Generic;
using JuniorInterviewTask.Models;

namespace JuniorInterviewTask.Services
{
    interface IHelperServiceRepository
    {
        IEnumerable<HelperServiceModel> Get();
        HelperServiceModel Get(Guid id);
    }
}
