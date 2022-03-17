using _02_DataAccess_Dapper.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _02_DataAccess_Dapper.Controllers
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



        #region CREATE/POST/INSERT

        [HttpPost]
        public void Create(CreateCategoryModel model)
        {
            using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString("LocalSql")))
            {
                conn.Execute("INSERT INTO Categories VALUES (@CategoryName)", model);
            }
        }


        #endregion


        #region READ/GET/SELECT

        [HttpGet]
        public IEnumerable<CategoryModel> Read()
        {
            var items = new List<CategoryModel>();

            using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString("LocalSql")))
            {
                items = conn.Query<CategoryModel>("SELECT * FROM Categories").ToList();
            }

            return items;
        }

        [HttpGet("{id}")]
        public CategoryModel Read(int id)
        {
            var item = new CategoryModel();

            using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString("LocalSql")))
            {
                item = conn.QueryFirstOrDefault<CategoryModel>("SELECT * FROM Categories WHERE Id = @Id", new { Id = id });
            }

            return item;
        }


        #endregion


    }
}
