using System.ComponentModel;

namespace Applicanty.Core.Enums
{
    public enum StatusType
    {
        [Description("active")]
        Active,
        [Description("archived")]
        Archived,
        [Description("deleted")]
        Deleted
    }
}