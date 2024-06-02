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

    public class MeniuController : ControllerBase
    {
        private readonly BDContext _authContext;
        private IConfiguration _config;

        public MeniuController(BDContext context, IConfiguration config)
        {
            _authContext = context;
            _config = config;
        }


        [HttpPost]
        [Route("AdaugaMeniu")]
        public async Task<IActionResult> AdaugaMeniu(string nume,string descriere,
            int idProduseGramaje,int idUtilizator, int idCreator,
            float kcal, float proteine, float carboohidrati, float zahar, float grasimi)
        {
            Meniu meniu = new Meniu();
            meniu.Nume = nume;
            meniu.descriere = descriere;
            meniu.idProduseGramaje = idProduseGramaje;
            meniu.idUtilizator = idUtilizator;
            meniu.idCreator= idCreator;
            meniu.kcal = kcal;
            meniu.proteine = proteine;
            meniu.carboohidrati = carboohidrati;
            meniu.zahar = zahar;
            meniu.grasimi = grasimi;

            if (meniu == null) { return BadRequest(); }
            await _authContext.Meniuri.AddAsync(meniu);
            await _authContext.SaveChangesAsync();
            return Ok(meniu.Id);
        }

        [HttpGet]
        [Route("GetMeniuri")]
        public JsonResult GetMeniuri()
        {
            string querry = "select * from dbo.Meniuri";
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

        [HttpGet]
        [Route("GetMeniuByIdUtilizator")]
        public JsonResult GetMeniuByIdUtilizator(int id)
        {
            string querry = "select * from dbo.Meniuri where idUtilizator = @Id";
            DataTable table = new DataTable();
            string sqlDataSource = _config.GetConnectionString("Fitness_Application");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(querry, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }

            }

            return new JsonResult(table);
        }


        [HttpGet]
        [Route("GetMeniuById")]
        public JsonResult GetMeniuById(int id)
        {
            string querry = "select * from dbo.Meniuri where Id = @Id";
            DataTable table = new DataTable();
            string sqlDataSource = _config.GetConnectionString("Fitness_Application");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(querry, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }

            }

            return new JsonResult(table);
        }

        [HttpDelete]
        [Route("DeleteMeniu")]
        public async Task<IActionResult> DeleteMeniu(int Id)
        {
            
            var meniu = await _authContext.Meniuri.FindAsync(Id);

            if (meniu == null)
            {
                return NotFound();
            }
            _authContext.Meniuri.Remove(meniu);
            await _authContext.SaveChangesAsync();
            var produsGramaj = _authContext.ProdusGramaje.FirstOrDefault(produs => produs.idMeniu == Id);
            if (produsGramaj != null)
            {
                while(produsGramaj != null)
                {
                    _authContext.ProdusGramaje.Remove(produsGramaj);
                    await _authContext.SaveChangesAsync();
                    produsGramaj = _authContext.ProdusGramaje.FirstOrDefault(produs => produs.idMeniu == Id);
                }
            }


            return Ok();
        }

    }
}
