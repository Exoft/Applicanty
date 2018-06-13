using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using Applicanty.Services.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Applicanty.Services.Services
{
    public class CommentService : BaseService<Comment, ICommentRepository>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        { }

        public VacancyWithCommentsDto GetByVacancy(VacancyUpdateDto model)
        {
            var comments = Repository.GetWithInclude(include => include.User)
                .Where(item => item.VacancyId == model.Id).ToArray();

            var modelWithComments = Mapper.Map<VacancyUpdateDto, VacancyWithCommentsDto>(model);

            if (comments == null || comments.Length < 1)
                return modelWithComments;

            modelWithComments.CommentText = new string[comments.Length];
            modelWithComments.CommentCreatedAt = new DateTime[comments.Length];
            modelWithComments.CommentCreatedBy = new string[comments.Length];

            for (int i = 0; i < comments.Length; i++)
            {
                modelWithComments.CommentText[i] = comments[i].CommentText;
                modelWithComments.CommentCreatedAt[i] = comments[i].CreatedAt;
                modelWithComments.CommentCreatedBy[i] = comments[i].User.Email;
            }
            
            return modelWithComments;
        }

        public override TDto Create<TDto>(TDto dto)
        {
            var vacancyDto = dto as VacancyUpdateDto;
            if(vacancyDto == null)
                throw new System.ArgumentNullException(nameof(vacancyDto));

            var entity = Mapper.Map<TDto, Comment>(dto);

            if (String.IsNullOrEmpty(entity.CommentText))
                return dto;

            var createdEntity = Repository.Create(entity);
            UnitOfWork.Commit();

            var returnEntity = Repository.GetWithInclude(include => include.User)
                .FirstOrDefault(item => item.Id == createdEntity.Id);
            return Mapper.Map<Comment, TDto>(returnEntity);
        }

        protected override ICommentRepository InitRepository() => UnitOfWork.CommentRepository;

    }
}
