namespace Applicanty.Core.Abstract
{
    public abstract class Statable : IStateable
    {
        public bool IsArchived { get; set; }
    }
}