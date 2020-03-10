using EMart.SellerService.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EMart.SellerService.Models;

namespace EMart.Test
{
    [TestFixture]
    class TestSellerService
    {
        SellerRepository _repo;
        ItemRepository _itemrepo;
        [SetUp]
        public void SetUp()
        {
            _repo = new SellerRepository(new EMartDBContext());
            _itemrepo = new ItemRepository(new EMartDBContext());
        }
        [Test]
        [Description("GetProfile()")]
        public void TestGetProfile()
        {
            var result=_repo.GetProfile("1");
            Assert.NotNull(result);
        }
        [Test]
        [Description("EditProfile()")]
        public void TestEditProfile()
        {
            Seller seller = _repo.GetProfile("1");
            seller.Gstin =" 20";
            _repo.EditProfile(seller);
            Seller seller1 = _repo.GetProfile("1");
            Assert.AreSame(seller, seller1);
        }
        [Test]
        [Description("ViewItems()")]
        public void TestViewItems()
        {
            var result=_itemrepo.ViewItems();
            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.Count, 1);
        }
        [Test]
        [Description("GetCategory()")]
        public void TestGetCategory()
        {
            var result = _itemrepo.GetCategory();
            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.Count, 1);
        }
        [Test]
        [Description("GetSubCategory(categoryId)")]
        public void TestGetSubCategory()
        {
            var result = _itemrepo.GetSubCategory("SC2");
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("ViewItems(sellerId)")]
        public void TestSellerItem()
        {
            var result = _itemrepo.ViewItems("S002");
            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.Count, 1);
        }
        [Test]
        [Description("GetItem(itemId)")]
        public void TestGetItem()
        {
            var result = _itemrepo.GetItem("I38");
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("AddItem()")]
        public void TestAddItem()
        {
            _itemrepo.AddItem(new Items()
            {
                SellerId="1",
                ItemId="I389",
                CategoryId="C258",
                SubcategoryId="SC47",
                Price="9000",
                ItemName="Night wear",
                StockNumber="7",
                Img="kidswear.jpg"
            }
                );
            var result=_itemrepo.GetItem("I389");
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("DeleteItem(itemId")]
        public void TestDeleteItem()
        {
            _itemrepo.DeleteItem("I389");
            var result = _itemrepo.GetItem("I389");
            Assert.Null(result);
        }
        [Test]
        [Description("UpdateItem(itemId)")]
        public void TestUpdateItem()
        {
            Items item = _itemrepo.GetItem("I389");
            item.Description = "Below 12 years";
            _itemrepo.UpdateItem(item);
            Items item1 = _itemrepo.GetItem("I389");
            Assert.AreSame(item, item1);
        }
    }

}
