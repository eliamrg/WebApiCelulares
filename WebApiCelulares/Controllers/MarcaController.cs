using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCelulares.Entidades;

namespace WebApiCelulares.Controllers
{
    [ApiController]
    [Route("marca")]
    public class MarcaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public MarcaController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<Marca>>> GetAll()
        {
            return await dbContext.Marca.Include(x=> x.celulares).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Marca>> GetById(int id)
        {
            return await dbContext.Marca.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Marca marca)
        {
            dbContext.Add(marca);

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Marca marca, int id)
        {
            if (marca.Id != id)
            {
                return BadRequest("El Id de la marca no coincide con el establecido en la URL.");
            }

            dbContext.Update(marca);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Marca.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No se encontro la marca en la base de datos");
            }
            dbContext.Remove(new Marca()
            { Id = id, }
            );
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        
    }
}
