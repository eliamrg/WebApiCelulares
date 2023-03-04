using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApiCelulares.Entidades;

namespace WebApiCelulares.Controllers
{
    [ApiController]
    [Route("celular")]
    public class CelularController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CelularController(ApplicationDbContext context) 
        {
            this.dbContext = context;    
        }


        [HttpGet("lista")]
        public async Task<ActionResult<List<Celular>>> GetAll()
        {
            return await dbContext.Celular.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Celular>> GetById(int id)
        {
            return await dbContext.Celular.FirstOrDefaultAsync(x => x.ID == id);
        }

        

        [HttpPost]
        public async Task<ActionResult> Post(Celular celular)
        {
            var existeMarca = await dbContext.Marca.AnyAsync(x => x.Id == celular.MarcaID);
            if (!existeMarca) {
                return BadRequest("No existe la marca");
            }
            
            dbContext.Add(celular);

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Celular celular, int id)
        {
            if (celular.ID != id)
            {
                return BadRequest("El Id del celular no coincide con el establecido en la URL.");
            }

            var existeMarca = await dbContext.Marca.AnyAsync(x => x.Id == celular.MarcaID);
            if (!existeMarca)
            {
                return BadRequest("No existe la marca");
            }

            dbContext.Update(celular);
            await dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task <ActionResult> Delete(int id)
        {
            var exist= await dbContext.Celular.AnyAsync(x =>x.ID== id);
            if (!exist)
            {
                return NotFound("No se encontro el celular en la base de datos");
            }
            dbContext.Remove(new Celular()
                { ID = id, }
            );
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
