using API_ORDEM_SERVICO.Data;
using API_ORDEM_SERVICO.Models;
using API_ORDEM_SERVICO.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ORDEM_SERVICO.Controllers
{
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TecnicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(template: "v1/tecnico")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lista = await _context.Tecnicos
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(lista);

            }
            catch (Exception ex) { return BadRequest("Erro" + ex); }
        }

        [HttpGet(template: "v1/tecnico/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            try
            {
                var selecionado = await _context.Tecnicos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                return Ok(selecionado);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro " + ex);
            }
        }

        [HttpPost(template: "v1/tecnico")]
        public async Task<IActionResult> Post([FromBody] Tecnico model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("ERRO NA VALIDAÇÂO DE MODELO");

                var RegistroNovo = new Tecnico
                {
                    Nome = model.Nome
                };

                await _context.AddAsync(RegistroNovo);

                await _context.SaveChangesAsync();
                return Created($"v1/tecnico/{RegistroNovo.Id}", "ok");
            }
            catch (Exception ex) { return BadRequest("Erro" + ex); }
        }
        [HttpPut(template: "v1/tecnico/{id}")]
        public async Task<IActionResult> Update([FromBody] Tecnico model, [FromRoute] int id)
        {
            try
            {
                var Registro = await _context
                        .Tecnicos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

                Registro.Nome = model.Nome;

                _context.Tecnicos.Update(Registro);

                await _context.SaveChangesAsync();

                return Ok(Registro);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(template: "v1/tecnico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var registro = await _context.Tecnicos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                _context.Tecnicos.Remove(registro);
                await _context.SaveChangesAsync();
                return Ok(registro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
