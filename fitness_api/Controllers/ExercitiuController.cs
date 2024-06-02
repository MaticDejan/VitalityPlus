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

    public class ExercitiuController : ControllerBase
    {
        private readonly BDContext _authContext;
        private IConfiguration _config;

        public ExercitiuController(BDContext context, IConfiguration config)
        {
            _authContext = context;
            _config = config;
        }

        [HttpGet]
        [Route("GetExercitii")]
        public JsonResult GetExercitii()
        {
            string querry = "select * from dbo.Exercitiu";
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
        [Route("GetBicept")]
        public JsonResult GetBicept()
        {
            string categorie = "Biceps";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetTriceps")]
        public JsonResult GetTriceps()
        {
            string categorie = "Triceps";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetAbdomen")]
        public JsonResult GetAbdomen()
        {
            string categorie = "Abdomen";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetPiept")]
        public JsonResult GetPiept()
        {
            string categorie = "Piept";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetSpate")]
        public JsonResult GetSpate()
        {
            string categorie = "Spate";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetGambe")]
        public JsonResult GetGambe()
        {
            string categorie = "Gambe";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetCoapse")]
        public JsonResult GetCoapse()
        {
            string categorie = "Coapse";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetAntebrat")]
        public JsonResult GetAntebrat()
        {
            string categorie = "Antebrat";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetCardio")]
        public JsonResult GetCardio()
        {
            string categorie = "Cardio";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetUmeri")]
        public JsonResult GetUmeri()
        {
            string categorie = "Umeri";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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
        [Route("GetSporturi")]
        public JsonResult GetSporturi()
        {
            string categorie = "Sporturi";
            string querry = "select * from dbo.Exercitiu where Categorie ='" + categorie + "'";
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

        [HttpPost]
        [Route("AdaugaExercitiu")]
        public async Task<IActionResult> AdaugaExercitiu([FromBody] Exercitiu ExercitiuObj)
        {
            if (ExercitiuObj == null) { return BadRequest(); }
            await _authContext.Exercitiu.AddAsync(ExercitiuObj);
            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteExercitiu")]
        public async Task<IActionResult> DeleteExercitiu(int Id)
        {
            var exercitiu = await _authContext.Exercitiu.FindAsync(Id);

            if (exercitiu == null)
            {
                return NotFound();
            }
            _authContext.Exercitiu.Remove(exercitiu);
            await _authContext.SaveChangesAsync();

            return Ok();
        }


    }
}