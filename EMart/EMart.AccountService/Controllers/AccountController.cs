using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EMart.AccountService.Models;
using EMart.AccountService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EMart.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _iaccrepo;
        private readonly IConfiguration configuration;

        public AccountController(IAccountRepository iaccrepo,IConfiguration configuration)
        {
            _iaccrepo = iaccrepo;
            this.configuration = configuration;
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role,username)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            //var response = new Token
            //{
            //    username = username,
            //    token = new JwtSecurityTokenHandler().WriteToken(token)
            //};
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet]
        [Route("BuyerLogin/{uname}/{pwd}")]

        public IActionResult BuyerLogin(string uname, string pwd)
        {
            Token token = null;
            try 
            {
                Buyer buyer = _iaccrepo.BuyerLogin(uname, pwd);
                if(buyer!=null)
                {
                    token = new Token()
                    {
                        buyerId = buyer.BuyerId,
                        token = GenerateJwtToken(uname),
                        msg = "Success"
                    };
                }
                else
                {
                    token = new Token()
                    {
                        token = "",
                        msg = "Unsuccess"
                    };
                }
                return Ok(token);
            }

            //try
            //{

            //    return Ok(_iaccrepo.BuyerLogin(uname, pwd));

            //}

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpPost]
        [Route("BuyerRegister")]

        public IActionResult BuyerRegister(Buyer b)
        {
            try
            {
                _iaccrepo.BuyerRegister(b);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }


        [HttpGet]
        [Route("SellerLogin/{uname}/{pwd}")]

        public IActionResult SellerLogin(string uname, string pwd)
        {
            //try
            //{
            //    return Ok(_iaccrepo.SellerLogin(uname, pwd));

            //}
            Token token = null;
            try
            {
                Seller seller = _iaccrepo.SellerLogin(uname, pwd);
                if (seller != null)
                {
                    token = new Token()
                    {
                        sellerId = seller.SellerId,
                        token = GenerateJwtToken(uname),
                        msg = "Success"
                    };
                }
                else
                {
                    token = new Token()
                    {
                        token = "",
                        msg = "Unsuccess"
                    };
                }
                return Ok(token);
            }


            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }


        [HttpPost]
        [Route("SellerRegister")]

        public IActionResult SellerRegister(Seller s)
        {
            try
            {
                _iaccrepo.SellerRegister(s);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }

    }
}