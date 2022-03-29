using _01_EntityFrameworkCore_CodeFirst.Models;
using _01_EntityFrameworkCore_CodeFirst.Models.Forms;
using _01_EntityFrameworkCore_CodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_EntityFrameworkCore_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public CustomersController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerForm form)
        {
            try
            {
                await _customerManager.CreateAsync(new Customer
                {
                    CustomerName = form.CustomerName,
                    ContactPerson = new ContactPerson
                    {
                        FirstName = form.ContactPerson.FirstName,
                        LastName = form.ContactPerson.LastName,
                        Email = form.ContactPerson.Email
                    }
                });

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
