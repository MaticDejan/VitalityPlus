
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebAoolication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class Fitness_Application : ControllerBase
    {

        public IConfiguration _configuration;
        public Fitness_Application(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetNotes")]

        public JsonResult GetNotes() 
        {
            string querry = "select * from dbo.sala";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Fitness_Application");
            SqlDataReader myReader;
            using (SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(querry,myCon))
                {
                myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }

            }

            return new JsonResult(table);
        }
    }

}