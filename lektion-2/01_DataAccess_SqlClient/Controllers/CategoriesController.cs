using _01_DataAccess_SqlClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace _01_DataAccess_SqlClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CategoriesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /*   
            
            CORS  =     Cross Origin Resource Sharing
                        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            DTO   =     Data Transfer Object   =   Model 


            GET   =     QueryString (parametrar i urlen)                        ex. https://domain.com/api/categories/{id}
            POST  =     Body (värden paketeras in i request meddelandet)        ex. https://domain.com/api/categories
                                                                                DATA/BODY: { "name": "Möbler" }


            ExecuteNonQuery    =       INSERT och inte vill ha något svar/resultat tillbaka
                                            INSERT INTO Categories VALUES ('TV')

            ExecuteScalar      =       INSERT,SELECT och vill vill ha ett svar tilbaka, bara en kolumn
                                            INSERT INTO Categories OUTPUT INSERTED.Id VALUES ('TV')
                                            SELECT Name FROM Categories WHERE Id = 2

            ExecuteReader      =       SELECT och vill få tillbaka flera värden/kolumner
                                            SELECT * FROM Categories
               
        */



        #region CREATE/POST/INSERT

        [HttpPost]
        public void Create(CreateCategoryModel model)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Azure")))
            {
                using (var cmd = new SqlCommand("INSERT INTO Categories VALUES (@CategoryName)", conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", model.CategoryName);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }


        #endregion


        #region READ/GET/SELECT


        // https://domain.com/api/categories
        [HttpGet]
        public IEnumerable<CategoryModel> Read()
        {
            var items = new List<CategoryModel>();

            using (var conn = new SqlConnection(_configuration.GetConnectionString("Azure")))
            {
                using (var cmd = new SqlCommand("SELECT * FROM Categories", conn))
                {
                    conn.Open();
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        items.Add(new CategoryModel
                        {
                            Id = (int)result.GetValue(0),
                            Name = (string)result.GetValue(1)
                        });
                    }
                }
            }

            return items;
        }

        // https://domain.com/api/categories/1
        [HttpGet("{id}")]
        public CategoryModel Read(int id)
        {
            var item = new CategoryModel();

            using (var conn = new SqlConnection(_configuration.GetConnectionString("Azure")))
            {
                using (var cmd = new SqlCommand("SELECT * FROM Categories WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    var result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        item.Id = (int)result.GetValue(0);
                        item.Name = (string)result.GetValue(1);
                    }
                }
            }

            return item;
        }


        #endregion



    }
}
