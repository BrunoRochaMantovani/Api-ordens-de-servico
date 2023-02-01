using API_ORDEM_SERVICO.Data;
using API_ORDEM_SERVICO.Models;
using API_ORDEM_SERVICO.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ORDEM_SERVICO.Controllers
{
    [ApiController]
    public class ClienteControlador : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClienteControlador(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(template:"v1/cliente")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lista = await _context.Clientes
                    .AsNoTracking()
                    .ToListAsync(); 
                return Ok(lista);

            }catch(Exception ex) { return BadRequest("Erro" + ex); }
        }

        [HttpGet(template:"v1/cliente/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            try
            {
                var selecionado = await _context.Clientes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.id == id);
                return Ok(selecionado);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro " + ex);
            }
        }

        [HttpPost(template:"v1/cliente")]
        public async Task<IActionResult> Post([FromBody] ClientePostViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("ERRO NA VALIDAÇÂO DE MODELO");

                var RegistroNovo = new Cliente
                {
                    Nome = model.Nome,
                    Empresa = model.Empresa,
                    Telefone = model.Telefone
                };

                await _context.AddAsync(RegistroNovo);

                await _context.SaveChangesAsync();
                return Created($"v1/cliente/{RegistroNovo.id}", "ok");
            }
            catch (Exception ex) { return BadRequest("Erro" + ex); }
        }
        [HttpPut(template:"v1/cliente/{id}")]
        public async Task<IActionResult> Update([FromBody] ClientePostViewModel model, [FromRoute] int id)
        {
            try
            {
                var Registro = await _context
                    .Clientes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x=>x.id == id);

                Registro.Nome = model.Nome;
                Registro.Empresa = model.Empresa;
                Registro.Telefone = model.Telefone;

                _context.Clientes.Update(Registro);

                await _context.SaveChangesAsync();

                return Ok(Registro);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(template:"v1/cliente/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var registro = await _context.Clientes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.id == id);

                _context.Clientes.Remove(registro);
                await _context.SaveChangesAsync();
                return Ok(registro);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
