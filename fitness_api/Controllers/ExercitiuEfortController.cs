using Fitness_Application.Context;
using Fitness_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Fitness_Application.Controllers;
using Fitness_Application.CommonMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fitness_Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ExercitiuEfortController : ControllerBase
    {
        private readonly BDContext _authContext;
        private IConfiguration _config;

        public ExercitiuEfortController(BDContext context, IConfiguration config)
        {
            _authContext = context;
            _config = config;
        }



        [HttpPost]
        [Route("AdaugaExercitiuEfort")]
        public async Task<IActionResult> AdaugaExercitiuEfort(int idExercitiu,int idAntrenament,int timp,int serii, int repetari,int greutati,int anduranta)
        {

            ExercitiuEfort exercitiuEfort = new ExercitiuEfort();

            exercitiuEfort.idExercitiu = idExercitiu;
            exercitiuEfort.idAntrenament = idAntrenament;

            if (greutati != 0)
            {
                exercitiuEfort.greutati = greutati;
                exercitiuEfort.anduranta = 0;
                exercitiuEfort.timp = 0;
                exercitiuEfort.serii = serii;
                exercitiuEfort.repetari = repetari;
            }
            else if(anduranta != 0)
            {
                exercitiuEfort.greutati = 0;
                exercitiuEfort.anduranta = anduranta;
                exercitiuEfort.timp = timp;
                exercitiuEfort.serii = 0;
                exercitiuEfort.repetari = 0;
            }

            if (exercitiuEfort == null) { return BadRequest(); }
            await _authContext.ExercitiuEfort.AddAsync(exercitiuEfort);
            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("GetExercitiuEfort")]
        public JsonResult GetExercitiuEfort()
        {
            string querry = "select * from dbo.ExercitiuEfort";
            DataTable table = new DataTable();
            string sqlDataSource = _config.GetConnectionString("Fitness_Application");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(querry, myCon))
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







