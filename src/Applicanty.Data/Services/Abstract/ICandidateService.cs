using Applicanty.Data.Entity;
using System.Collections.Generic;

namespace Applicanty.Data.Services
{
   public interface ICandidateService : IEntityService<Candidate>
    {
        ICollection<Candidate> GetAll();
        Candidate GetOne(long Id);
        void Archive(long id);
        void Archive(ICollection<Candidate> list);
        void UnArchive(long id);
        void UnArchive(ICollection<Candidate> list);
    }
}
