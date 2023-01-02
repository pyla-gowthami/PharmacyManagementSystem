using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystemWEBMVC.Models
{
    public class DrugViewModel
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
    }
}