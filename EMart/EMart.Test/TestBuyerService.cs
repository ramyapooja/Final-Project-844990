using EMart.BuyerService.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EMart.BuyerService.Models;

namespace EMart.Test
{
    class TestBuyerService
    {
        BuyerRepository _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new BuyerRepository(new EMartDBContext());
        }
        [Test]
        [Description("GetProfile()")]
        public void TestGetProfile()
        {
            var result = _repo.GetProfile("1");
            Assert.NotNull(result);
        }
        [Test]
        [Description("EditProfile()")]
        public void TestEditProfile()
        {
            Buyer buyer = _repo.GetProfile("1");
            buyer.MobileNo = "9898989898";
            _repo.EditProfile(buyer);
            Buyer buyer1 = _repo.GetProfile("1");
            Assert.AreSame(buyer, buyer1);
        }
        [Test]
        [Description("GetAllItems()")]
        public void TestGetItems()
        {
            var result = _repo.GetAllItems();
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("GetCartItems()")]
        public void TestGetCartItems()
        {
            var result = _repo.GetCartItems();
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("SearchItem(ItemName)")]
        public void TestSearchItemByName()
        {
            var result = _repo.SearchItems("AC");
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("BuyItem()")]
        public void TestBuyItem()
        {
            _repo.BuyItem(new TransactionHistory()
            {
                Id = "T001",
                BuyerId = "B0010",
                SellerId = "S0010",
                TransactionId = "T001",
                ItemId = "I443",
                NumberOfItems = "5",
                DateTime=DateTime.Now,
                Remarks="",
                TransactionType="debit"
            }
                );
            var result=_repo.TransactionHistory("B0010");
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("TransactionHistory()")]
        public void TestTransactionHistory()
        {
            var result = _repo.TransactionHistory("B0010");
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("AddtoCart()")]
        public void TestAddtoCart()
        {
            _repo.AddtoCart(new Cart()
            {
                Id="C001",
                CategoryId="C165",
                SubcategoryId="SC14",
                SellerId="1",
                ItemId="I443",
                ItemName="AC",
                Price="80000",
                Description="",
                StockNumber="5",
                Img="ac.jpg"
            }
                );
            
        }
    }
}
