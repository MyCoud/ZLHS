using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class Purchase

    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Purchase_BuyingId { get; set; }
        public int Purchase_SupplierId { get; set; }
        public string Purchase_SupplierName { get; set; }
        public bool Purchase_HaveTax { get; set; }
        public string Purchase_Tax { get; set; }
        public string Purchase_Site { get; set; }
        public string Purchase_Compile { get; set; }
        public string Purchase_Department { get; set; }
    }
}


