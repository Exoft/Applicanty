using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public abstract class Statable : IStateable
    {
        public bool IsArchived { get; set; }
    }
}