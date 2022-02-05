using BookRentalApp.Models;
using BookRentalApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //Data fields
        private readonly ICustomer _customer;

        //Constructor Injection
        public CustomersController(ICustomer customer)
        {
            _customer = customer;
        }

        //GET ALL CUSTOMERS
        #region GET ALL CUSTOMERS
        [HttpGet] // /api/customers
        public async Task<ActionResult<IEnumerable<Customers>>> GetAllCustomers()
        {
            return await _customer.GetAllCustomers();
        }
        #endregion

        //ADD CUSTOMERS
        #region ADD CUSTOMERS
        [HttpPost] // /api/customers
        public async Task<IActionResult> AddCustomer([FromBody] Customers cust)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var cId = await _customer.AddCustomer(cust);
                    if (cId > 0)
                    {
                        return Ok(cId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //DELETE CUSTOMER
        #region DELETE CUSTOMERS
        [HttpDelete("{id}")] // /api/customers/{id}
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _customer.DeleteCustomer(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //UPDATE CUSTOMER
        #region UPDATE CUSTOMER
        [HttpPut]  // /api/customers
        public async Task<IActionResult> UpdateCustomer([FromBody] Customers cust)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _customer.UpdateCustomer(cust);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //GET CUSTOMER BY ID
        #region GET CUSTOMER BY ID
        [HttpGet("{id}")] // /api/customers/{id}
        public async Task<ActionResult<Customers>> GetBookId(int id)
        {
            try
            {
                var cust = await _customer.GetCustomer(id);
                if (cust == null)
                {
                    return NotFound();
                }
                return cust;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
