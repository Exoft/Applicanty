using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Core.Services
{
    public interface ICommentService : IService<Comment>
    {
        VacancyWithCommentsDto GetByVacancy(VacancyUpdateDto model);
    }
}
