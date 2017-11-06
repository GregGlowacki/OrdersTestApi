using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersTestApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderProfileModel
    {
        public List<Data> data { get; set; }
        public Result result { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Data
    {
        public string customerId { get; set; }
        public string description { get; set; }
        public string dos { get; set; }
        public string hcpcs { get; set; }
        public string carrier10 { get; set; }
        public string tracking35 { get; set; }
        public string next_elig { get; set; }
        public string quantity { get; set; }
        public string order_stat { get; set; }
        public int? reorder_qt { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Result
    {
        public bool success { get; set; }
        public string system { get; set; }
        public int returnValue { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}
