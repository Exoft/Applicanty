using Applicanty.Core.Enums;

namespace Applicanty.Core.Entities.Abstract
{
    public interface IStateable
    {
        StatusType StatusId { get; set; }
    }
}