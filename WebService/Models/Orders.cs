using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Orders
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int SalesRepId { get; set; }

        public string OrderDate { get; set; }

        public int OrderCode { get; set; }

        public string OrderStatus { get; set; }

        public int OrderTotal { get; set; }

        public string OrderCurrency { get; set; }

        public string PromotionCode { get; set; }
    }
}