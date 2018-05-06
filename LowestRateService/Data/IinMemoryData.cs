using MCAP.Nova.LowestRate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCAP.Nova.LowestRate.TestData
{
    public interface IinMemoryData
    {
        IQueryable<underwriterInformation> getProductData();
    }
}