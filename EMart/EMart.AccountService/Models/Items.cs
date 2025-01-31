﻿using System;
using System.Collections.Generic;

namespace EMart.AccountService.Models
{
    public partial class Items
    {
        public Items()
        {
            Cart = new HashSet<Cart>();
            TransactionHistory = new HashSet<TransactionHistory>();
        }

        public string SellerId { get; set; }
        public string ItemId { get; set; }
        public string CategoryId { get; set; }
        public string SubcategoryId { get; set; }
        public string Price { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string StockNumber { get; set; }
        public string Remarks { get; set; }
        public string Img { get; set; }

        public virtual Category Category { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual SubCategory Subcategory { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistory { get; set; }
    }
}
