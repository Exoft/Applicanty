using System;
using Applicanty.Data.Entity;
using System.Collections.Generic;
using Applicanty.Data.Services.Abstract;

namespace Applicanty.Data.Services
{
    public interface IVacancyService : IStateableServices<Vacancy, long>
    {
    }
}
