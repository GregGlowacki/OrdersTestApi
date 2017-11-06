using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPM = OrdersTestApi.Models;

namespace OrdersTestApi.Translators
{
    public static class OrderProfileTranslator
    {
        public static OPM.OrderProfileResponseModel EmptyOPModel(string modelMessage)
        {
            return new OPM.OrderProfileResponseModel()
            {
                
            //    singleOrder.customerId = "1234";
            //singleOrder.description = "Maska";
            //singleOrder.dos = "11-5-2017";
            //singleOrder.hcpcs = "A123";
            //singleOrder.carrier10 = "FedEx";
            //singleOrder.tracking35 = "Z13434";
            //singleOrder.next_elig = "12-13-2017";
            //singleOrder.quantity = "3";
            //singleOrder.order_stat = "Shipped";
            //singleOrder.reorder_qt = 2;

        };
        }

        public static OPM.OrderProfileResponseModel OrdersList(OPM.OrderProfileModel resultList)
        {
            return new OPM.OrderProfileResponseModel()
            {

            };
        }

        //public static OPM.OrderProfileModel EmptyOPModel(string modelMessage)
        //{
        //    return new OPM.OrderProfileModel()
        //    {

        //    };
        //}
    }
}
