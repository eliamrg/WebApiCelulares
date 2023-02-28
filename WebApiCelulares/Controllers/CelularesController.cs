using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApiCelulares.Entidades;

namespace WebApiCelulares.Controllers
{
    [ApiController]
    [Route("api/celulares")]
    public class CelularesController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Celular>> get()
        {
            return new List<Celular>()
            {
                new Celular() { ID = 1, Modelo = "Iphone 11"},
                new Celular() { ID = 2, Modelo = "Iphone 12"}
            };
        } 
    }
}
