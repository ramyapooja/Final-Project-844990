using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

using EMart.AccountService.Models;
using EMart.AccountService.Repositories;

namespace EMart.Test
{
    [TestFixture]
    public class TestAccountService
    {
        AccountRepository _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new AccountRepository(new EMartDBContext());
        }
        [Test]
        public void RegisterBuyer()
        {
            _repo.BuyerRegister(new Buyer()
            {
                BuyerId = "B0010",
                UserName = "Jay",
                EmailId = "jay@gmail.com",
                Password = "jay123",
                MobileNo = "9898989898",
                CreatedDateTime = DateTime.Now
            }
                );
            var result=_repo.BuyerLogin("Jay", "jay123");
            Assert.NotNull(result);
        }
        [Test]
        public void RegisterSeller()
        {
            _repo.SellerRegister(new Seller()
            {
                SellerId = "S0010",
                UserName = "sravs",
                
                Password = "sravs123",
                CompanyName = "asdf",
                Gstin = "19",
                BriefDetails = "nukjnjnvaf",
                PostalAddress = "Hyderabad",
                Website = "abc.com",
                EmailId = "sravs@gmail.com",
                MobileNo = "8787878787"
            }
                );
            var result = _repo.SellerLogin("sravs", "sravs123");
            Assert.NotNull(result);
        }
        [Test]
        [Description("Test BuyerLogin()")]
        public void BuyerLogin()
        {
            var result=_repo.BuyerLogin("sai", "sai123");
            Assert.NotNull(result);
        }
        [Test]
        [Description("Test SellerLogin()")]
        public void SellerLogin()
        {
            var result = _repo.SellerLogin("hema", "hema123");
            Assert.NotNull(result);
        }


    }
}
