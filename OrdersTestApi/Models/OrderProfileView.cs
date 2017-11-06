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
    public class OrderProfileView
    {
        public string SELECT { get; set; }
        public string REORDER { get; set; }
        public string STATUS { get; set; }
        public string DESCRIPTION { get; set; }
        public string QTY { get; set; }
        public string DATE_OF_SERVICE { get; set; }
        public string HCPC { get; set; }
        public string TRACKING { get; set; }
    }
}
