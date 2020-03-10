using EMart.BuyerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMart.BuyerService.Repositories
{
    public interface IBuyerRepository
    {
        List<Items> SearchItems(string name);

        void BuyItem(TransactionHistory item);

        void EditProfile(Buyer obj);
        

        Buyer GetProfile(string bid);

        List<TransactionHistory> TransactionHistory(string bid);


        List<Category> GetCategory();
        List<SubCategory> SubCategory(string catid);
        List<Items> GetAllItems();
        void AddtoCart(Cart cart);
        List<Cart> GetCartItems();
        void DeleteCartItems(string Id);
        bool ViewCart(string bid, string itemid);
        List<Cart> GetCartItems(string bid);
        Cart GetCartItem(string cartid);
        int GetCount(string bid);

    }
}
