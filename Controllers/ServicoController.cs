using API_ORDEM_SERVICO.Data;
using API_ORDEM_SERVICO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ORDEM_SERVICO.Controllers
{
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ServicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(template: "v1/servico")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lista = await _context.Servicos
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(lista);

            }
            catch (Exception ex) { return BadRequest("Erro" + ex); }
        }

        [HttpGet(template: "v1/servico/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            try
            {
                var selecionado = await _context.Servicos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                return Ok(selecionado);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro " + ex);
            }
        }

        [HttpPost(template: "v1/servico")]
        public async Task<IActionResult> Post([FromBody] Servico model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("ERRO NA VALIDAÇÂO DE MODELO");

                var RegistroNovo = new Servico
                {
                    Atividade = model.Atividade
                };

                await _context.AddAsync(RegistroNovo);

                await _context.SaveChangesAsync();
                return Created($"v1/servico/{RegistroNovo.Id}", "ok");
            }
            catch (Exception ex) { return BadRequest("Erro" + ex); }
        }
        [HttpPut(template: "v1/servico/{id}")]
        public async Task<IActionResult> Update([FromBody] Servico model, [FromRoute] int id)
        {
            try
            {
                var Registro = await _context
                        .Servicos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

                Registro.Atividade = model.Atividade;

                _context.Servicos.Update(Registro);

                await _context.SaveChangesAsync();

                return Ok(Registro);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(template: "v1/servico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var registro = await _context.Servicos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                _context.Servicos.Remove(registro);
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
