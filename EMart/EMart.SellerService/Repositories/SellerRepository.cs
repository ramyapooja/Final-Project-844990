using EMart.SellerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMart.SellerService.Repositories
{
    public class SellerRepository:ISellerRepository
    {
        private readonly EMartDBContext _context;
        public SellerRepository(EMartDBContext context)
        {
            _context = context;

        }
        public void EditProfile(Seller obj)
        {
            _context.Seller.Update(obj);
            _context.SaveChanges();
        }

        public Seller GetProfile(string sid)
        {

            return _context.Seller.Find(sid);
        }
    }
}
