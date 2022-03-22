using _00_Repetition_SqlClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace _00_Repetition_SqlClient.Controllers
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


        // cmd.ExecuteNonQuery()            bara gör men skickar inget tillbaka
        // cmd.ExecuteScalar()              ger tillbaka ett värde
        // cmd.ExecuteReader()              ger tillbaka ett helt objekt

        [HttpPost]
        public void CreateCustomer(Customer model)
        {
            var customerId = 0;
            var addressId = 0;

            using (var conn = new SqlConnection(_configuration.GetConnectionString("LocalSql")))
            {
                conn.Open();
                using (var cmd = new SqlCommand("IF EXISTS (SELECT Id FROM Customers WHERE Email = @Email) SELECT Id FROM Customers WHERE Email = @Email ELSE INSERT INTO Customers OUTPUT INSERTED.Id VALUES (@FirstName,@LastName,@Email)", conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                  
                    customerId = (int)cmd.ExecuteScalar();
                }

                using (var cmd = new SqlCommand("IF EXISTS (SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode) SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND PostalCode = @PostalCode ELSE INSERT INTO Addresses OUTPUT INSERTED.Id VALUES (@AddressLine,@PostalCode,@City)", conn))
                {
                    cmd.Parameters.AddWithValue("@AddressLine", model.Address.AddressLine);
                    cmd.Parameters.AddWithValue("@PostalCode", model.Address.PostalCode);
                    cmd.Parameters.AddWithValue("@City", model.Address.City);
                
                    addressId = (int)cmd.ExecuteScalar();
                }

                using (var cmd = new SqlCommand("INSERT INTO CustomerAddresses VALUES (@CustomerId, @AddressId)", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@AddressId", addressId);
                  
                    cmd.ExecuteNonQuery();
                }
            }
        }


        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            return customers;
        }


    }
}
