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

    public class CereriController : ControllerBase
    {
        private readonly BDContext _authContext;
        private IConfiguration _config;

        public CereriController(BDContext context, IConfiguration config)
        {
            _authContext = context;
            _config = config;
        }

        [HttpGet]
        [Route("GetCereri")]
        public JsonResult GetCereri()
        {
            string querry = "select * from dbo.Cereri";
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
        [Route("GetSugestii")]
        public JsonResult GetSugestii()
        {
            string categorie = "Sugestii";
            string querry = "select * from dbo.Cereri where Categorie ='" + categorie + "'";
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
        [Route("GetRolAntrenor")]
        public JsonResult GetRolAntrenor()
        {
            string categorie = "Cerere rol de antrenor";
            string querry = "select * from dbo.Cereri where Categorie ='" + categorie + "'";
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
        [Route("GetRolAdmin")]
        public JsonResult GetRolAdmin()
        {
            string categorie = "Cerere rol de admin";
            string querry = "select * from dbo.Cereri where Categorie ='" + categorie + "'";
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
        [Route("GetAlimentNou")]
        public JsonResult GetAlimentNou()
        {
            string categorie = "Aliment nou";
            string querry = "select * from dbo.Cereri where Categorie ='" + categorie + "'";
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
        [Route("GetProbleme")]
        public JsonResult GetProbleme()
        {
            string categorie = "Probleme intampinate";
            string querry = "select * from dbo.Cereri where Categorie ='" + categorie + "'";
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
        [Route("GetExercitiuNou")]
        public JsonResult GetExercitiuNou()
        {
            string categorie = "Exercitiu nou";
            string querry = "select * from dbo.Cereri where Categorie ='" + categorie + "'";
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
        [Route("DeleteCerere")]
        public async Task<IActionResult> DeleteCerere(int Id)
        {
            var cerere = await _authContext.Cereri.FindAsync(Id);

            if (cerere == null)
            {
                return NotFound();
            }
            _authContext.Cereri.Remove(cerere);
            await _authContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch]
        [Route("StatusAcceptat")]
        public async Task<IActionResult> StatusAcceptat(int Id)
        {
            var cerere = await _authContext.Cereri.FindAsync(Id);

            if (cerere == null)
            {
                return NotFound();
            }
            cerere.status = "Acceptat";
            await _authContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch]
        [Route("StatusRespins")]
        public async Task<IActionResult> StatusRespins(int Id)
        {
            var cerere = await _authContext.Cereri.FindAsync(Id);

            if (cerere == null)
            {
                return NotFound();
            }
            cerere.status = "Respins";
            await _authContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch]
        [Route("StatusInAsteptare")]
        public async Task<IActionResult> StatusInAsteptare(int Id)
        {
            var cerere = await _authContext.Cereri.FindAsync(Id);

            if (cerere == null)
            {
                return NotFound();
            }
            cerere.status = "In asteptare";
            await _authContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("CreareCerere")]
        public async Task<IActionResult> CreareCerere([FromBody] Cereri CereriObj)
        {
            if (CereriObj == null) { return BadRequest(); }
            
            await _authContext.Cereri.AddAsync(CereriObj);
            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("RaspunsCerere")]
        public async Task<IActionResult> RaspunsCerere(int Id,string raspuns)
        {
            var cerere = await _authContext.Cereri.FindAsync(Id);

            if (cerere == null)
            {
                return NotFound();
            }
            cerere.raspuns = raspuns;
            await _authContext.SaveChangesAsync();

            return Ok();
        }

    }
}