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

    public class ProdusGramajController : ControllerBase
    {
        private readonly BDContext _authContext;
        private IConfiguration _config;

        public ProdusGramajController(BDContext context, IConfiguration config)
        {
            _authContext = context;
            _config = config;
        }



        [HttpPost]
        [Route("AdaugaProdusGramaj")]
        public async Task<IActionResult> AdaugaProdusGramaj(int idProdus, float gramaj, int idMeniu,int prajit, int fiert, int crud)
        {

            ProdusGramaj produsGramaj=new ProdusGramaj();

            produsGramaj.idProdus = idProdus;
            produsGramaj.gramaj = gramaj;
            produsGramaj.idMeniu = idMeniu;
            produsGramaj.prajit = prajit;
            produsGramaj.fiert = fiert;
            produsGramaj.crud = crud;

            if (produsGramaj == null) { return BadRequest(); }
            await _authContext.ProdusGramaje.AddAsync(produsGramaj);
            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("GetProdusGramaj")]
        public JsonResult GetProdusGramaj()
        {
            string querry = "select * from dbo.ProdusGramaje";
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
