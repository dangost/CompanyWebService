using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }

        public int LocationId { get; set; }

        public string WarehouseName { get; set; }
    }
}