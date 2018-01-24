using System.ComponentModel;

namespace Applicanty.Core.Enums
{
    public enum VacancyStage
    {
        [Description("cv")]
        CV,
        [Description("interview")]
        Interview,
        [Description("customer interview")]
        CustomerInterview,
        [Description("technical interview")]
        TechnicalInterview,
        [Description("offer")]
        Offer,
        [Description("hired")]
        Hired
    }
}
