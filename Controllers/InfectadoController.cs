using API.Data.Collections;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB mongoDB;
        IMongoCollection<Infectado> infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            this.mongoDB = mongoDB;
            this.infectadosCollection = this.mongoDB.database.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDTO dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
            infectadosCollection.InsertOne(infectado);
            return StatusCode(201, "Infectado cadastrado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            return Ok(infectados);
        }
    }
}