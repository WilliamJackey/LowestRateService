using System;

namespace MCAP.Nova.LowestRate.Model
{
    public class UnderwriterInformation
    {
        public DateTime PeriodEnd { get; set; }
        public DateTime PeriodStart { get; set; }
        public string Product { get; set; }
        public double ProductRate { get; set; }
        public string Program { get; set; }
        public double ProgramRateAdjustment { get; set; }
    }
}
