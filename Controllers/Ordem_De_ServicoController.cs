using API_ORDEM_SERVICO.Data;
using API_ORDEM_SERVICO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ORDEM_SERVICO.Controllers
{
    [ApiController]
    public class Ordem_De_ServicoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public Ordem_De_ServicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(template: "v1/ordem")]
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

        [HttpGet(template: "v1/ordem/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            try
            {
                var selecionado = await _context.Ordems_De_servico
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                return Ok(selecionado);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro " + ex);
            }
        }

        [HttpPost(template: "v1/ordem")]
        public async Task<IActionResult> Post([FromBody] Ordem_De_Servico model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("ERRO NA VALIDAÇÂO DE MODELO");

                var RegistroNovo = new Ordem_De_Servico
                {
                    Data= model.Data,
                    DescProblema = model.DescProblema,
                    Equipamento = model.Equipamento,
                    ClienteId = model.ClienteId,
                    TecnicoId = model.TecnicoId,
                    FinalizacaoId = model.FinalizacaoId
                    
                };

                await _context.AddAsync(RegistroNovo);

                await _context.SaveChangesAsync();
                return Created($"v1/ordem/{RegistroNovo.Id}", "ok");
            }
            catch (Exception ex) { return BadRequest("Erro" + ex); }
        }
        [HttpPut(template: "v1/ordem/{id}")]
        public async Task<IActionResult> Update([FromBody] Ordem_De_Servico model, [FromRoute] int id)
        {
            try
            {
                var Registro = await _context
                        .Ordems_De_servico
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

                Registro = new Ordem_De_Servico
                {
                    Data = model.Data,
                    DescProblema = model.DescProblema,
                    Equipamento = model.Equipamento,
                    ClienteId = model.ClienteId,
                    TecnicoId = model.TecnicoId,
                    FinalizacaoId = model.FinalizacaoId

                };

                _context.Ordems_De_servico.Update(Registro);

                await _context.SaveChangesAsync();

                return Ok(Registro);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(template: "v1/ordem/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var registro = await _context.Ordems_De_servico
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                _context.Ordems_De_servico.Remove(registro);
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
