using _00_Repetition_Dapper.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _00_Repetition_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpPost]
        public void CreateCustomer(Customer model)
        {
            var customerId = 0;
            var addressId = 0;

            using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString("LocalSql")))
            {
                customerId = conn.QueryFirst<int>("IF EXISTS (SELECT Id FROM Customers WHERE Email = @Email) SELECT Id FROM Customers WHERE Email = @Email ELSE INSERT INTO Customers OUTPUT INSERTED.Id VALUES (@FirstName,@LastName,@Email)", model);
                addressId = conn.QueryFirst<int>("IF EXISTS (SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode) SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode ELSE INSERT INTO Addresses OUTPUT INSERTED.Id VALUES (@AddressLine,@PostalCode,@City)", model.Address);
            
                conn.Execute("INSERT INTO CustomerAddresses VALUES (@CustomerId, @AddressId)", new { CustomerId = customerId, AddressId = addressId });
            }
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString("LocalSql")))
            {
                var items = conn.Query("SELECT c.Id,c.FirstName,c.LastName,c.Email,a.AddressLine,a.PostalCode,a.City FROM Customers c JOIN CustomerAddresses ca ON c.Id = ca.CustomerId JOIN Addresses a ON ca.AddressId = a.Id");
                foreach(var item in items)
                {
                    customers.Add(new Customer
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Address = new Address
                        {
                            AddressLine = item.AddressLine,
                            PostalCode = item.PostalCode,
                            City = item.City
                        }
                    });
                }

                return customers;
            
            }
        }
    }
}
