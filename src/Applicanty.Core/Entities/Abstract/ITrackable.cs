using System;

namespace Applicanty.Core.Entities.Abstract
{
    public interface ITrackable
    {
        DateTime ModifiedAt { get; set; }
        DateTime CreatedAt { get; set; }
        int ModifiedBy { get; set; }
        int CreatedBy { get; set; }
    }
}
