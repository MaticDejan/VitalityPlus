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

namespace Fitness_Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly BDContext _authContext;
        private IConfiguration _config;

        public UserController(BDContext context, IConfiguration config)
        {
            _authContext = context;
            _config = config;
        }
        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Userlogin([FromBody] User userObj)
        {
            
            if (userObj == null) { return BadRequest(); }
            
            userObj.Parola = Security.ConvertToEncrypt(userObj.Parola);
            
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Email == userObj.Email && x.Parola == userObj.Parola);
            
            if (user == null) { return NotFound("User not found"); }
            user.Activ = true;
            await _authContext.SaveChangesAsync();
            return Ok();

        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> UserRegister([FromBody] User userObj)
        {
            if(userObj == null) { return BadRequest(); }
            userObj.Parola = Security.ConvertToEncrypt(userObj.Parola);
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok( );
        }

        [HttpPost]
        [Route("stergeRolAntrenor")]
        public async Task<IActionResult> stergeRolAntrenor([FromBody] User userObj)
        {
            var user = _authContext.Users.FirstOrDefault(user => user.Id == userObj.Id);
            if(user == null) { return BadRequest(); }

            user.Antrenor = 0;
            await _authContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        [Route("adaugaRolAntrenor")]
        public async Task<IActionResult> adaugaRolAntrenor([FromBody] User userObj)
        {
            var user = _authContext.Users.FirstOrDefault(user => user.Id == userObj.Id);
            if (user == null) { return BadRequest(); }

            user.Antrenor = 1;
            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("adaugaRolAdmin")]
        public async Task<IActionResult> adaugaRolAdmin([FromBody] User userObj)
        {
            var user = _authContext.Users.FirstOrDefault(user => user.Id == userObj.Id);
            if (user == null) { return BadRequest(); }

            user.Admin = true;
            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("stergeRolAdmin")]
        public async Task<IActionResult> stergeRolAdmin([FromBody] User userObj)
        {
            var user = _authContext.Users.FirstOrDefault(user => user.Id == userObj.Id);
            if (user == null) { return BadRequest(); }

            user.Admin = false;
            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("utilizatorActiv")]
        public bool utilizatorActiv([FromBody] User userObj)
        {
            var user = _authContext.Users.FirstOrDefault(user => user.Email == userObj.Email);
            if (user == null) { return false; }

            user.Activ = true;
             _authContext.SaveChangesAsync();
            return true;
        }   

        [HttpPost]
        [Route("utilizatorInactiv")]
        public async Task<IActionResult> utilizatorInactiv([FromBody] User userObj)
        {
            var user = _authContext.Users.FirstOrDefault(user => user.Id == userObj.Id);
            if (user == null) { return BadRequest(); }

            user.Activ = false;
            await _authContext.SaveChangesAsync();
            return Ok();
        }



        [HttpGet]
        [Route("GetUsers")]
        public JsonResult GetUser()
        {
            string querry = "select * from dbo.Users";
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
        [Route("GetAdmin")]
        public JsonResult GetAdmin()
        {
            string querry = "select * from dbo.Users WHERE Admin = 1";
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
        [Route("GetAntrenor")]
        public JsonResult GetAntrenor()
        {
            string querry = "select * from dbo.Users WHERE Antrenor = 1";
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
        [Route("GetUtilizator")]
        public JsonResult GetUtilizator()
        {
            string querry = "select * from dbo.Users WHERE Antrenor = 0 AND Admin = 0";
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
        [Route("GetUserById")]
        public JsonResult GetUserById(int id)
        {
            string querry = "select * from dbo.Users where Id = @Id";
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
        [Route("GetClienti")]
        public JsonResult GetClienti(int id)
        {
            string querry = "select * from dbo.Users where idAntrenor = @Id";
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
        [Route("GetUserByEmail")]
        public JsonResult GetUserByEmail(string Email)
        {
            string querry = "select * from dbo.Users where Email = @Email";
            DataTable table = new DataTable();
            string sqlDataSource = _config.GetConnectionString("Fitness_Application");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(querry, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Email", Email);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }

            }

            return new JsonResult(table);
        }


        [HttpDelete]
        [Route("DeleteUserContext")]
        public async Task<IActionResult> DeleteUserContext(int Id)
        {
            var user = await _authContext.Users.FindAsync(Id);

            if(user == null)
            {
                return NotFound();
            }
            _authContext.Users.Remove(user);
            await _authContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser")]

    public async Task<IActionResult>DeleteUser(int Id)
        {
            string querry = "delete from dbo.Users where Id = @Id";
            string sqlDataSource = _config.GetConnectionString("Fitness_Application");
            int deletedUser = 0;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                await myCon.OpenAsync();
                using (SqlCommand myCommand = new SqlCommand(querry, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", Id);

                    deletedUser = await myCommand.ExecuteNonQueryAsync();
                    
                    myCon.Close();
                }

            }
            if(deletedUser == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        [Route("UpdateUserData")]
        public async Task<IActionResult> UpdateUserData([FromBody] User userObj)
        {
            var user = _authContext.Users.FirstOrDefault(user => user.Id == userObj.Id);
            if (user == null) { return BadRequest(); }

            user.Nume = userObj.Nume;
            user.Prenume = userObj.Prenume;
            user.Greutate = userObj.Greutate;
            user.Inaltime = userObj.Inaltime;

            user.gat = userObj.gat;
            user.talie = userObj.talie;
            user.antebrat = userObj.antebrat;
            user.coapsa = userObj.coapsa;

            user.Varsta = userObj.Varsta;
            user.sex = userObj.sex;
            user.Activitate = userObj.Activitate;
            user.Email = userObj.Email;
            user.imagine = userObj.imagine;

            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("adaugaAntrenor")]
        public async Task<IActionResult> adaugaAntrenor(User UserObj, int IdAntrenor)
        {
            var user = _authContext.Users.FirstOrDefault(user => user.Id == UserObj.Id);
            if (user == null) { return BadRequest(); }

            user.idAntrenor = IdAntrenor;

            await _authContext.SaveChangesAsync();
            return Ok();
        }

            [HttpPatch]
            [Route("stergeAntrenor")]
            public async Task<IActionResult> stergeAntrenor([FromBody] User UserObj)
            {
                var user = _authContext.Users.FirstOrDefault(user => user.Id == UserObj.Id);
                if (user == null) { return BadRequest(); }

                user.idAntrenor = 0;

                await _authContext.SaveChangesAsync();
                return Ok();
            }


        [HttpPatch]
        [Route("calculIMC")]
        public async Task<IActionResult> calculIMC([FromBody] User UserObj)
        {
            float imc;
            float inaltime;
            float inaltime2;
            float greutate;
            var user = _authContext.Users.FirstOrDefault(user => user.Id == UserObj.Id);
            if (user == null) { return BadRequest(); }
            if(UserObj.Inaltime == 0 || UserObj.Greutate == 0) { return StatusCode(466);  }
            else
            {
                greutate = (float)UserObj.Greutate;
                inaltime = (float)UserObj.Inaltime;
                inaltime=inaltime/100f;//conversie din cm in m
                inaltime2 = inaltime * inaltime;
                imc = greutate / inaltime2;
                user.indiceMasaCorporala = imc;
            }

            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("calculGreutateIdeala")]
        public async Task<IActionResult> calculGreutateIdeala([FromBody] User UserObj)
        {
            float greutateIdeala;
            float inaltime;
            float inaltimesex;

            var user = _authContext.Users.FirstOrDefault(user => user.Id == UserObj.Id);
            if (user == null) { return BadRequest(); }
            if ((UserObj.sex != "Barbat" && UserObj.sex != "Femeie")|| UserObj.Inaltime <100) { return StatusCode(466); }
            else
            {

                inaltime = (float)UserObj.Inaltime;
                inaltime = inaltime - 100;
                inaltimesex=(float)UserObj.Inaltime;
                inaltimesex = inaltimesex - 150;
                if (UserObj.sex == "Barbat") { inaltimesex = inaltimesex / 4; }
                else if (UserObj.sex == "Femeie") { inaltimesex = (float)(inaltimesex / 2.5); }
                greutateIdeala = inaltime - inaltimesex;
                
            }
            user.greutateIdeala = greutateIdeala;

            await _authContext.SaveChangesAsync();
            return Ok();
        }


        [HttpPatch]
        [Route("necesarCaloric")]
        public async Task<IActionResult> necesarCaloric([FromBody] User UserObj)
        {
            float greutate;
            float inaltime;
            float indiceInitial;
            float ani;
            float necesarCaloric=1;
            float necesarCaloricBazal;
            float coeficientMiscare=(float)1.2;

            var user = _authContext.Users.FirstOrDefault(user => user.Id == UserObj.Id);
            if (user == null) { return BadRequest(); }
            if ((UserObj.sex != "Barbat" && UserObj.sex != "Femeie") || UserObj.Inaltime < 100 || UserObj.Greutate < 10 || UserObj.Varsta == null) { return StatusCode(466); }
            else
            {
                if (UserObj.Activitate == "Sedentar") { coeficientMiscare = (float)1.2; }
                else if (UserObj.Activitate == "Miscare usoara") { coeficientMiscare = (float)1.375; }
                else if (UserObj.Activitate == "Moderat") { coeficientMiscare = (float)1.55; }
                else if (UserObj.Activitate == "Activ") { coeficientMiscare = (float)1.725; }
                else if (UserObj.Activitate == "Sport de performanta") { coeficientMiscare = (float)1.9; }

                if (UserObj.sex == "Barbat") {
                    indiceInitial = (float)66.47;
                    greutate = (float)UserObj.Greutate;
                    greutate = greutate * (float)13.75;
                    inaltime = (float)UserObj.Inaltime;
                    inaltime = inaltime * (float)5.003;
                    ani = (float)UserObj.Varsta;
                    ani = ani * (float)6.775;
                    necesarCaloricBazal = indiceInitial+greutate+inaltime-ani;
                    necesarCaloric = necesarCaloricBazal;
                    necesarCaloric = necesarCaloric * coeficientMiscare;

                }
                else if(UserObj.sex == "Femeie") {
                    indiceInitial = (float)655.1;
                    greutate = (float)UserObj.Greutate;
                    greutate = greutate * (float)9.563;
                    inaltime = (float)UserObj.Inaltime;
                    inaltime = inaltime * (float)1.850;
                    ani = (float)UserObj.Varsta;
                    ani = ani * (float)4.676;
                    necesarCaloricBazal = indiceInitial + greutate + inaltime - ani;
                    necesarCaloric = necesarCaloricBazal;
                    necesarCaloric = necesarCaloric * coeficientMiscare;

                }

            }

            user.necesarCaloric = necesarCaloric;
            

            await _authContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("procentGrasime")]
        public async Task<IActionResult> procentGrasime([FromBody] User UserObj)
        {
            float greutate;
            float factor1;
            float factor2;
            float factor3;
            float factor4;
            float factor5;
            float leanBodyMass;
            float greutateGrasime;
            float procentGrasime=10;

            var user = _authContext.Users.FirstOrDefault(user => user.Id == UserObj.Id);
            if (user == null) { return BadRequest(); }
            if (UserObj.sex != "Barbat" && UserObj.sex != "Femeie") { return StatusCode(466); }
            else if(UserObj.sex == "Femeie")
            {
                if(UserObj.Greutate <=0 || UserObj.talie <=0 || UserObj.antebrat <=0 || UserObj.coapsa <= 0)
                {
                    return StatusCode(467);
                }
                else
                {
                    greutate = (float)UserObj.Greutate;
                    factor1 = greutate;
                    factor1 = factor1 * (float)0.732;
                    factor1 = factor1 + (float)8.987;

                    factor2 = (float)UserObj.antebrat;
                    factor2 = factor2 * (float)0.73;

                    factor2 = factor2 / (float)3.140;

                    factor3 = (float)UserObj.talie;
                    factor3 = factor3 * (float)0.157;

                    factor4 = (float)UserObj.coapsa;
                    factor4 = factor4 * (float)0.249;

                    factor5 = (float)UserObj.antebrat;
                    factor5 = factor5 * (float)0.434;

                    leanBodyMass = factor1;
                    leanBodyMass = leanBodyMass + factor2;
                    leanBodyMass = leanBodyMass - factor3;
                    leanBodyMass = leanBodyMass - factor4;
                    leanBodyMass=leanBodyMass + factor5;

                    greutateGrasime = greutate;
                    greutateGrasime=greutateGrasime - leanBodyMass;

                    procentGrasime = greutateGrasime;
                    procentGrasime = procentGrasime * 100;
                    procentGrasime = procentGrasime / greutate;
                }
            }
            else if(UserObj.sex == "Barbat")
            {
                if(UserObj.Greutate <=0 || UserObj.talie <= 0)
                {
                    return StatusCode(467);
                }
                else
                {
                    greutate = (float)UserObj.Greutate;
                    factor1 = greutate;
                    factor1 = factor1 * (float)1.082;
                    factor1 = factor1 + (float)94.42;
                    factor2 = (float)UserObj.talie;
                    factor2 = factor2 * (float)4.15;
                    leanBodyMass = factor1;
                    leanBodyMass = leanBodyMass - factor2;
                    greutateGrasime = greutate;
                    greutateGrasime = greutateGrasime - leanBodyMass;
                    procentGrasime = greutateGrasime;
                    procentGrasime = procentGrasime * 100;
                    procentGrasime = procentGrasime / greutate;
                }
            }

            user.procentDeGrasime = procentGrasime;

            await _authContext.SaveChangesAsync();
            return Ok();
        }


    }


}