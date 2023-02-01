using API_ORDEM_SERVICO.Data;
using API_ORDEM_SERVICO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ORDEM_SERVICO.Controllers
{
    [ApiController]
    public class FinalizacaoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FinalizacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(template: "v1/finalizacao")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lista = await _context.Finalizacoes
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(lista);

            }
            catch (Exception ex) { return BadRequest("Erro" + ex); }
        }

        [HttpGet(template: "v1/finalizacao/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            try
            {
                var selecionado = await _context.Finalizacoes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                return Ok(selecionado);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro " + ex);
            }
        }

        [HttpPost(template: "v1/finalizacao")]
        public async Task<IActionResult> Post([FromBody] Finalizacao model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("ERRO NA VALIDAÇÂO DE MODELO");

                var RegistroNovo = new Finalizacao
                {
                    valorTotal = model.valorTotal,
                    Data = model.Data,
                    Data_Entrega = model.Data_Entrega
                };

                await _context.AddAsync(RegistroNovo);

                await _context.SaveChangesAsync();
                return Created($"v1/finalizacao/{RegistroNovo.Id}", "ok");
            }
            catch (Exception ex) { return BadRequest("Erro" + ex); }
        }
        [HttpPut(template: "v1/finalizacao/{id}")]
        public async Task<IActionResult> Update([FromBody] Finalizacao model, [FromRoute] int id)
        {
            try
            {
                var Registro = await _context
                        .Finalizacoes
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

                Registro.valorTotal = model.valorTotal;
                Registro.Data = model.Data;
                Registro.Data_Entrega = model.Data_Entrega;

                _context.Finalizacoes.Update(Registro);

                await _context.SaveChangesAsync();

                return Ok(Registro);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(template: "v1/finalizacao/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var registro = await _context.Finalizacoes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                _context.Finalizacoes.Remove(registro);
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
