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
                BuyerId = "B0016",
                UserName = "mouni",
                EmailId = "mouni@gmail.com",
                Password = "mouni123",
                MobileNo = "9898989891",
                CreatedDateTime = DateTime.Now
            }
                );
            var result=_repo.BuyerLogin("mouni", "mouni123");
            Assert.NotNull(result);
        }
        [Test]
        public void RegisterSeller()
        {
            _repo.SellerRegister(new Seller()
            {
                SellerId = "S0016",
                UserName = "suji",
                
                Password = "suji123",
                CompanyName = "asdfg",
                Gstin = "20",
                BriefDetails = "",
                PostalAddress = "Bangalore",
                Website = "abcd.com",
                EmailId = "suji@gmail.com",
                MobileNo = "8787878786"
            }
                );
            var result = _repo.SellerLogin("suji", "suji123");
            Assert.NotNull(result);
        }
        [Test]
        [Description("Test BuyerLogin()")]
        public void BuyerLogin()
        {
            var result=_repo.BuyerLogin("suji", "suji123");
            Assert.NotNull(result);
        }
        [Test]
        [Description("Test SellerLogin()")]
        public void SellerLogin()
        {
            var result = _repo.SellerLogin("suji", "suji123");
            Assert.NotNull(result);
        }


    }
}
