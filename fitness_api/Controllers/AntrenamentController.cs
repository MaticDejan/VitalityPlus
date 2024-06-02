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

    public class AntrenamentController : ControllerBase
    {
        private readonly BDContext _authContext;
        private IConfiguration _config;

        public AntrenamentController(BDContext context, IConfiguration config)
        {
            _authContext = context;
            _config = config;
        }

        [HttpPost]
        [Route("AdaugaAntrenament")]
        public async Task<IActionResult> AdaugaAntrenament(string Nume, string Descriere,
           float calorii,int idUtilizator,int idCreator)
        {

            Antrenament antrenament=new Antrenament();
            antrenament.Nume = Nume;
            antrenament.Descriere = Descriere;
            antrenament.calorii = calorii;
            antrenament.idUtilizator = idUtilizator;
            antrenament.idCreator = idCreator;

            if (antrenament == null) { return BadRequest(); }
            await _authContext.Antrenament.AddAsync(antrenament);
            await _authContext.SaveChangesAsync();
            return Ok(antrenament.Id);
        }

        [HttpGet]
        [Route("GetAntrenamente")]
        public JsonResult GetAntrenamente()
        {
            string querry = "select * from dbo.Antrenament";
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

        [HttpDelete]
        [Route("DeleteAntrenament")]
        public async Task<IActionResult> DeleteAntrenament(int Id)
        {
            
            var antrenament = await _authContext.Antrenament.FindAsync(Id);

            if (antrenament == null)
            {
                return NotFound();
            }
            _authContext.Antrenament.Remove(antrenament);
            await _authContext.SaveChangesAsync();
            var exercitiuEfort = _authContext.ExercitiuEfort.FirstOrDefault(exercitiu => exercitiu.idAntrenament == Id);
            if (exercitiuEfort != null)
            {
                while(exercitiuEfort != null)
                {
                    _authContext.ExercitiuEfort.Remove(exercitiuEfort);
                    await _authContext.SaveChangesAsync();
                    exercitiuEfort = _authContext.ExercitiuEfort.FirstOrDefault(exercitiu => exercitiu.idAntrenament == Id);
                }
            }


            return Ok();
        }

    }
}

        