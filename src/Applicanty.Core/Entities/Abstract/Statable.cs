namespace Applicanty.Core.Entities.Abstract
{
    public abstract class Statable : IStateable
    {
        public bool IsArchived { get; set; }
    }
}