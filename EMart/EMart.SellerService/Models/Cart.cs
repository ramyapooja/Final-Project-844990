﻿using System;
using System.Collections.Generic;

namespace EMart.SellerService.Models
{
    public partial class Cart
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string SubcategoryId { get; set; }
        public string SellerId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string StockNumber { get; set; }
        public string Remarks { get; set; }
        public string Img { get; set; }

        public virtual Category Category { get; set; }
        public virtual Items Item { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual SubCategory Subcategory { get; set; }
    }
}
