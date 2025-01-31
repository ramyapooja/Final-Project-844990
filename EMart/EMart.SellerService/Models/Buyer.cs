﻿using System;
using System.Collections.Generic;

namespace EMart.SellerService.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            Cart = new HashSet<Cart>();
            TransactionHistory = new HashSet<TransactionHistory>();
        }

        public string BuyerId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistory { get; set; }
    }
}
