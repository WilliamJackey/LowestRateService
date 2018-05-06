using System;
using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using Xunit;
using MCAP.Nova.LowestRate.Model;
using MCAP.Nova.LowestRate.TestData;

namespace MCAP.Nova.LowestRate.UnitTests
{
    [Collection("UnitTestBaseCollection")]
    [Trait("Category", "UnitTests")]
    public class LowestRateTest
    {
        private readonly Services.LowestRate m_serviceRepository;
        private readonly Mock<IinMemoryData> m_dataRepositoryMock = new Mock<IinMemoryData>();

        public LowestRateTest()
        {
            m_serviceRepository = new Services.LowestRate();
        }

        [Fact]
        public void CalculateLowestRate_WithNullData_ReturnsInternallError()
        {
            DateTime dtTestStartDate = new DateTime(2016, 9, 1, 0, 0, 0);
            DateTime dtTestEndDate = new DateTime(2016, 9, 14, 23, 59, 59);

            m_dataRepositoryMock.Setup(m => m.getProductData()).Returns((IQueryable<underwriterInformation>)null);
            m_serviceRepository.InMemoryTestDataService = m_dataRepositoryMock.Object;

            var szResult = m_serviceRepository.calculateLowestRate(dtTestStartDate, dtTestEndDate);
            szResult.Should().Contain("Internal exception");
        }

        [Fact]
        public void CalculateLowestRate_WithInValidDateRange_ReturnsWrongMessage()
        {
            DateTime dtTestStartDate = new DateTime(2016, 9, 1, 0, 0, 0);
            DateTime dtTestEndDate = new DateTime(2016, 9, 14, 23, 59, 59);

            var testData = Builder<underwriterInformation>
                .CreateListOfSize(2)
                .TheFirst(1)
                .With(item => item.PeriodStart = dtTestStartDate)
                .With(item => item.PeriodEnd = dtTestEndDate)
                .With(item => item.Product = "10 Year")
                .With(item => item.Program = "standard")
                .TheNext(1)
                .With(item => item.PeriodStart = dtTestStartDate)
                .With(item => item.PeriodEnd = dtTestEndDate)
                .With(item => item.Product = "5 Year")
                .With(item => item.Program = "quick Close")
                .Build();
            m_dataRepositoryMock.Setup(m => m.getProductData()).Returns(Queryable.AsQueryable(testData));

            m_serviceRepository.InMemoryTestDataService = m_dataRepositoryMock.Object;
            var szResult1 = m_serviceRepository.calculateLowestRate(dtTestStartDate.AddDays(-9), dtTestEndDate);
            szResult1.Should().Contain("wrong date range");

            var szResult2 = m_serviceRepository.calculateLowestRate(dtTestStartDate, dtTestEndDate.AddDays(9));
            szResult2.Should().Contain("wrong date range");

            var szResult3 = m_serviceRepository.calculateLowestRate(dtTestEndDate, dtTestStartDate);
            szResult3.Should().Contain("wrong date range");
        }

        [Fact]
        public void CalculateLowestRate_WithValidDateRange_ReturnsSuccess()
        {
            DateTime dtTestStartDate = new DateTime(2016, 9, 1, 0, 0, 0);
            DateTime dtTestEndDate = new DateTime(2016, 9, 14, 23, 59, 59);

            var testData = Builder<underwriterInformation>
                .CreateListOfSize(3)
                .TheFirst(1)
                .With(item => item.PeriodStart = dtTestStartDate)
                .With(item => item.PeriodEnd = dtTestEndDate)
                .With(item => item.ProductRate = 2.9)
                .With(item => item.ProgramRateAdjustment = 0)
                .With(item => item.Product = "10 Year")
                .With(item => item.Program = "standard")
                .TheNext(1)
                .With(item => item.PeriodStart = dtTestStartDate)
                .With(item => item.PeriodEnd = dtTestEndDate)
                .With(item => item.ProductRate = 3.9)
                .With(item => item.ProgramRateAdjustment = 0)
                .With(item => item.Product = "5 Year")
                .With(item => item.Program = "quick Close")
                .TheNext(1)
                .With(item => item.PeriodStart = dtTestStartDate)
                .With(item => item.PeriodEnd = dtTestEndDate)
                .With(item => item.ProductRate = 5.9)
                .With(item => item.ProgramRateAdjustment = 0)
                .With(item => item.Product = "6 Year")
                .With(item => item.Program = "standard")
                .Build();
            m_dataRepositoryMock.Setup(m => m.getProductData()).Returns(Queryable.AsQueryable(testData));

            m_serviceRepository.InMemoryTestDataService = m_dataRepositoryMock.Object;
            var szResult = m_serviceRepository.calculateLowestRate(dtTestStartDate, dtTestEndDate);
            szResult.Should().Contain("10 Year");
            szResult.Should().Contain("standard");
            szResult.Should().Contain("2.9");
        }
    }
}
