﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMart.BuyerService.Models;
using EMart.BuyerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMart.BuyerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerRepository _ibuyrepo;

        public BuyerController(IBuyerRepository repo)
        {
            _ibuyrepo = repo;
        }
        [HttpGet]
        [Route("SearchItem/{name}")]

        public IActionResult SearchItems(string name)
        {
            try
            {
                return Ok(_ibuyrepo.SearchItems(name));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("BuyItem")]
        public IActionResult BuyItem(TransactionHistory item)
        {
            try
            {
                _ibuyrepo.BuyItem(item);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }


        [HttpPut]
        [Route("EditProfile")]
        public IActionResult EditProfile(Buyer obj)
        {
            try
            {

                _ibuyrepo.EditProfile(obj);
                return Ok();

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }



        [HttpGet]
        [Route("ViewProfile/{id}")]
        public IActionResult GetProfile(string id)
        {
            try
            {

                return Ok(_ibuyrepo.GetProfile(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }



        [HttpGet]
        [Route("TransactionHistory/{bid}")]

        public IActionResult TransactionHistory(string bid)
        {
            try
            {
                return Ok(_ibuyrepo.TransactionHistory(bid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }




        [HttpGet]
        [Route("GetCategory")]

        public IActionResult GetCategory()
        {
            try
            {
                return Ok(_ibuyrepo.GetCategory());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("GetSubCategory/{catid}")]

        public IActionResult GetSubCategory(string catid)
        {
            try
            {
                return Ok(_ibuyrepo.SubCategory(catid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetAllItems")]
        public IActionResult GetAllItems()
        {
            try
            {
                return Ok(_ibuyrepo.GetAllItems());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddtoCart")]
        public IActionResult AddtoCart(Cart cart)
        {
            try
            {
                _ibuyrepo.AddtoCart(cart);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetCartItems")]
        public IActionResult GetCartItems()
        {
            try
            {
                return Ok(_ibuyrepo.GetCartItems());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteCartItems/{Id}")]
        public IActionResult DeleteCartItems(string Id)
        {
            try
            {
                _ibuyrepo.DeleteCartItems(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}