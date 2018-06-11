using System.ComponentModel;

namespace Applicanty.Core.Enums
{
    public enum VacancyStage
    {
        [Description("cv")]
        CV,
        [Description("interview")]
        Interview,
        [Description("customerInterview")]
        CustomerInterview,
        [Description("technicalInterview")]
        TechnicalInterview,
        [Description("offer")]
        Offer,
        [Description("hired")]
        Hired,
        [Description("rejected")]
        Rejected,
        [Description("didNotCome")]
        DidNotCome,
        [Description("failedInterview")]
        FailedInterview
    }
}
