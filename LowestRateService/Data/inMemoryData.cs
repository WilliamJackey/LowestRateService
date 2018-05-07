using System;
using System.Collections.Generic;
using System.Linq;
using MCAP.Nova.LowestRate.Model;


namespace MCAP.Nova.LowestRate.TestData
{
    /// <summary>
    /// Summary description for inMemoryData
    /// </summary>
    public class InMemoryData : IInMemoryData
    {
        public IQueryable<UnderwriterInformation> getProductData()
        {
            return new List<UnderwriterInformation>
            {
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 9, 14, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 9, 1, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.7,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.05
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 9, 14, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 9, 1, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.7,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.1
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 9, 14, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 9, 1, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.04,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.05
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 9, 14, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 9, 1, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.04,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.1
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 9, 30, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 9, 15, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.8,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.15
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 9, 30, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 9, 15, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.8,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.22
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 9, 30, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 9, 15, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.04,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.15
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 9, 30, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 9, 15, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.04,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.22
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 10, 2, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 10, 1, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.8,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.15
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 10, 2, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 10, 1, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.8,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.2
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 10, 2, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 10, 1, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.02,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.15
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 10, 2, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 10, 1, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.02,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.2
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 10, 31, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 10, 3, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.75,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.15
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 10, 31, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 10, 3, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.75,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.15
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 10, 31, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 10, 3, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.02,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.15
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 10, 31, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 10, 3, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.02,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.15
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 12, 31, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 11, 1, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.75,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.05
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 12, 31, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 11, 1, 0, 0, 0),
                    Product = "3 Year Closed",
                    ProductRate = 2.75,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.1
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 12, 31, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 11, 1, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.02,
                    Program = "Standard",
                    ProgramRateAdjustment = -0.05
                },
                new UnderwriterInformation
                {
                    PeriodEnd = new DateTime(2016, 12, 31, 23, 59, 59),
                    PeriodStart = new DateTime(2016, 11, 1, 0, 0, 0),
                    Product = "5 Year Closed",
                    ProductRate = 3.02,
                    Program = "Quick Close",
                    ProgramRateAdjustment = -0.1
                }
            }.AsQueryable();
        }
    }
}