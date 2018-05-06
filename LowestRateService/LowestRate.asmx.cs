using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using MCAP.Nova.LowestRate.Model;
using MCAP.Nova.LowestRate.TestData;

namespace MCAP.Nova.LowestRate.Services
{
    /// <summary>
    /// Summary description for LowestRate
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LowestRate : System.Web.Services.WebService
    {
        private IinMemoryData m_inMemoryTestDataService = new inMemoryData();

        public IinMemoryData InMemoryTestDataService
        {
            get
            {
                return m_inMemoryTestDataService;
            }
            set
            {
                m_inMemoryTestDataService = value;
            }
        }

        [WebMethod]
        public string calculateLowestRate(DateTime dtStartDate, DateTime dtEndDate)
        {
            try
            {
                var productList = InMemoryTestDataService.getProductData().ToList();
                List<underwriterProduct> productRates = new List<underwriterProduct>();

                #region verify input parameter
                var dtMinDate = (from item in productList
                                 select item.PeriodStart).Min();
                var dtMaxDate = (from item in productList
                                 select item.PeriodEnd).Max();
                if (dtMinDate > dtStartDate || dtEndDate > dtMaxDate || dtStartDate > dtEndDate)
                {
                    return "wrong date range";
                }
                #endregion
                #region classify product
                var iMinDay = dtStartDate.DayOfYear;
                var iMaxDay = dtEndDate.DayOfYear;
                var classificationResults = (from item in productList
                                      group item by new { item.Product, item.Program } into productGroup
                                      orderby productGroup.Key.Product
                                      select new
                                      {
                                          productName = productGroup.Key.Product + " " + productGroup.Key.Program,
                                          productGroup = productGroup,
                                      }).ToList();
                #endregion

                #region calculate rate for every product
                foreach (var classificationItem in classificationResults)
                {
                    underwriterProduct tempProduct = new underwriterProduct();
                    double dblRate = 0;
                    foreach (var item in classificationItem.productGroup)
                    {
                        DateTime dtTempStartDate;
                        DateTime dtTempEndDate;
                        if (item.PeriodEnd < dtStartDate)
                        {
                            continue;
                        }

                        if (dtEndDate < item.PeriodStart)
                        {
                            break;
                        }

                        dtTempStartDate = item.PeriodStart > dtStartDate ? item.PeriodStart : dtStartDate;
                        dtTempEndDate = item.PeriodEnd < dtEndDate ? item.PeriodEnd : dtEndDate;
                        var dblItemRate = (item.ProductRate + item.ProgramRateAdjustment) * (dtTempEndDate.DayOfYear - dtTempStartDate.DayOfYear + 1);
                        dblRate = dblRate + dblItemRate;
                    }
                    tempProduct.ProductName = classificationItem.productName;
                    tempProduct.Rate = dblRate / (iMaxDay - iMinDay + 1);
                    productRates.Add(tempProduct);
                }
                #endregion

                #region get lowest rate and it's related product name
                var dblMinRate = (from item in productRates
                                  select item.Rate).Min();
                var szResult = (from item in productRates
                                where item.Rate == dblMinRate
                                select item.ProductName).SingleOrDefault();
                #endregion
                return "The lowest rate is: " + Math.Round(dblMinRate, 2) + ", and the product is: " + szResult + ".";
            }
            catch(Exception e)
            {
                return "Internal exception: " + e.Message + " - " + e.StackTrace + " - " + e.Source;
            }
        }
    }
}
