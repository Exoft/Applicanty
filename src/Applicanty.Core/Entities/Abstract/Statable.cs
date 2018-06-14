using Applicanty.Core.Enums;

namespace Applicanty.Core.Entities.Abstract
{
    public abstract class Statable : IStateable
    {
        public StatusType StatusId { get; set; }

    }
}