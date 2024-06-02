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

    public class ProdusController : ControllerBase
    {
        private readonly BDContext _authContext;
        private IConfiguration _config;

        public ProdusController(BDContext context, IConfiguration config)
        {
            _authContext = context;
            _config = config;
        }

        [HttpGet]
        [Route("GetProduse")]
        public JsonResult GetProduse()
        {
            string querry = "select * from dbo.Produse";
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
        [Route("GetCarne")]
        public JsonResult GetCarne()
        {
            string categorie = "carne";
            string querry = "select * from dbo.Produse where Categorie ='"+categorie+"'";
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
        [Route("GetDulciuri")]
        public JsonResult GetDulciuri()
        {
            string categorie = "Dulciuri";
            string querry = "select * from dbo.Produse where Categorie ='" + categorie + "'";
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
        [Route("GetFructe")]
        public JsonResult GetFructe()
        {
            string categorie = "Fructe";
            string querry = "select * from dbo.Produse where Categorie ='" + categorie + "'";
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
        [Route("GetLegume")]
        public JsonResult GetLegume()
        {
            string categorie = "Legume";
            string querry = "select * from dbo.Produse where Categorie ='" + categorie + "'";
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
        [Route("GetLactate")]
        public JsonResult GetLactate()
        {
            string categorie = "Lactate";
            string querry = "select * from dbo.Produse where Categorie ='" + categorie + "'";
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
        [Route("GetSeminte")]
        public JsonResult GetSeminte()
        {
            string categorie = "Seminte";
            string querry = "select * from dbo.Produse where Categorie ='" + categorie + "'";
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
        [Route("GetDiverse")]
        public JsonResult GetDiverse()
        {
            string categorie = "Diverse";
            string querry = "select * from dbo.Produse where Categorie ='" + categorie + "'";
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
        [Route("AdaugaProdus")]
        public async Task<IActionResult> AdaugaProdus([FromBody] Produs ProdusObj)
        {
            if (ProdusObj == null) { return BadRequest(); }
            await _authContext.Produse.AddAsync(ProdusObj);
            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteProdus")]
        public async Task<IActionResult> DeleteProdus(int Id)
        {
            var produs = await _authContext.Produse.FindAsync(Id);

            if (produs == null)
            {
                return NotFound();
            }
            _authContext.Produse.Remove(produs);
            await _authContext.SaveChangesAsync();

            return Ok();
        }


        [HttpPost]
        [Route("UpdateProdusData")]
        public async Task<IActionResult> UpdateProdusData([FromBody] Produs produsObj)
        {
            var produs = _authContext.Produse.FirstOrDefault(produs => produs.Id == produsObj.Id);
            if (produs == null) { return BadRequest(); }

            produs.Nume=produsObj.Nume;
            produs.Categorie= produsObj.Categorie;
            produs.prajit = 0;
            produs.fiert = 0;
            if(produsObj.prajit == 1)
            {
                produs.proteinePrajit = produsObj.proteinePrajit;
                produs.carbohidratiPrajit = produsObj.carbohidratiPrajit;
                produs.grasimiPrajit= produsObj.grasimiPrajit;
                produs.zaharPrajit = produsObj.zaharPrajit;
                produs.kcalPrajit=produsObj.kcalPrajit;
            }
            else
            {
                if(produsObj.fiert == 1)
                {
                    produs.proteineFiert = produsObj.proteineFiert;
                    produs.carbohidratiFiert = produsObj.carbohidratiFiert;
                    produs.grasimiFiert = produsObj.grasimiFiert;
                    produs.zaharFiert = produsObj.zaharFiert;
                    produs.kcalFiert= produsObj.kcalFiert;
                }
                else
                {
                    produs.proteine = produsObj.proteine;
                    produs.carbohidrati = produsObj.carbohidrati;
                    produs.grasimi = produsObj.grasimi;
                    produs.zahar = produsObj.zahar;
                    produs.kcal= produsObj.kcal;
                }
            }

            await _authContext.SaveChangesAsync();
            return Ok();
        }


    }
}
