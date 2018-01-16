using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Applicanty.Core.Enums
{
    public enum StatusType
    {
        [Description("Active")]
        Active,
        [Description("Archived")]
        Archived,
        [Description("Deleted")]
        Deleted
    }
}
