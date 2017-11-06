using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Swashbuckle.Swagger.Annotations;
using OrdersTestApi.Models;
using OrdersTestApi.Translators;


namespace OrdersTestApi.Controllers
{
    [RoutePrefix("api/crmorders")]
    public class OrderController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="externalUrlFlag"></param>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "No value found under specified Id.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error occurred.")]
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> ListAsync(bool externalUrlFlag, string customerNumber)
        {
            List<OrderProfileResponseModel> resultList = new List<OrderProfileResponseModel>();




            List<Models.Data> orderProfileResponse = new List<Models.Data>();
            //        orderProfileResponse = GetOrderProfile(_urlBaseDevOld, bearerKey, customerNumber);

            orderProfileResponse = GetOrderProfileMock();

            var table = orderProfileResponse.ToHtmlTable();

            //******************************************************
            if (orderProfileResponse.Count > 0)
            {
                return Ok(orderProfileResponse);
            }
            else
            {
                // return empty model
                resultList.Add((OrderProfileTranslator.EmptyOPModel("Order not found")));
                return Ok(orderProfileResponse);
            }
        }

        private List<Models.Data> GetOrderProfileMock()
        {
            Models.Data singleOrder = new Data();
            List<Models.Data> orderProfileResponse = new List<Models.Data>();

            singleOrder.customerId = "1234";
            singleOrder.description = "Maska";
            singleOrder.dos = "11-3-2017";
            singleOrder.hcpcs = "A123";
            singleOrder.carrier10 = "FedEx";
            singleOrder.tracking35 = "Z13434";
            singleOrder.next_elig = "12-13-2017";
            singleOrder.quantity = "3";
            singleOrder.order_stat = "Shipped";
            singleOrder.reorder_qt = 6;

            orderProfileResponse.Add(singleOrder);
            Models.Data singleOrder2 = new Data();

            singleOrder2.customerId = "9876";
            singleOrder2.description = "Inhalator";
            singleOrder2.dos = "11-4-2017";
            singleOrder2.hcpcs = "B123";
            singleOrder2.carrier10 = "UPS";
            singleOrder2.tracking35 = "Z998877";
            singleOrder2.next_elig = "12-13-2017";
            singleOrder2.quantity = "5";
            singleOrder2.order_stat = "Shipped";
            singleOrder2.reorder_qt = 15;

            orderProfileResponse.Add(singleOrder2);

            Models.Data singleOrder3 = new Data();

            singleOrder3.customerId = "1122";
            singleOrder3.description = "Albuterol RX";
            singleOrder3.dos = "11-1-2017";
            singleOrder3.hcpcs = "C123";
            singleOrder3.carrier10 = "Postal Service";
            singleOrder3.tracking35 = "UPS998877";
            singleOrder3.next_elig = "12-14-2017";
            singleOrder3.quantity = "7";
            singleOrder3.order_stat = "Shipped";
            singleOrder3.reorder_qt = 14;

            orderProfileResponse.Add(singleOrder3);

            return orderProfileResponse;
        }

/// <summary>
/// 
/// </summary>
/// <param name="externalUrlFlag"></param>
/// <param name="customerNumber"></param>
/// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "No value found under specified Id.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error occurred.")]
        [Route("table")]
        [HttpGet]
        public string Get(bool externalUrlFlag, string customerNumber)
        {
            string rv = @"<table class='flextable'><tr><th>SELECT</th><th width='7%'><span>REORDER REFILL QTY</span></th></tr><tr><td><input type='radio' /></td><td>row1</td></tr><tr><td><input type='radio'/></td><td>row 2</td></tr><tr><td><input type='radio' ></td><td>row 3</td></tr></table>";


            List<Models.Data> orderProfileResponse = new List<Models.Data>();
            orderProfileResponse = GetOrderProfileMock();

            List<OrderProfileView> orderProfileViewList = new List<OrderProfileView>();
            if (orderProfileResponse.Count > 0)
            {
                foreach(Data item in orderProfileResponse)
                {
                    OrderProfileView row = ConvertToView(item);
                    orderProfileViewList.Add(row);
                }
            }

            //var table = orderProfileResponse.ToHtmlTable();

            var table = orderProfileViewList.ToHtmlTable();

            rv = table.ToString().Trim();

            return rv;
        }

        private OrderProfileView ConvertToView(Data singleOrder)
        {
            OrderProfileView singleView = new OrderProfileView();

            singleView.SELECT = "<input type='radio' />";
            singleView.REORDER = "";
            singleView.STATUS = singleOrder.order_stat;
            singleView.DESCRIPTION = singleOrder.description;
            singleView.QTY = singleOrder.quantity;
            singleView.DATE_OF_SERVICE = singleOrder.dos;
            singleView.HCPC = singleOrder.hcpcs;
            singleView.TRACKING = singleOrder.tracking35;

            return singleView;
        }





    } // end of class
}
