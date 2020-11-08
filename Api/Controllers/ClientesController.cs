using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SquadraWeb.Api;
using SquadraWeb.Api.DTOs;
using SquadraWeb.Api.Models;


namespace SquadraWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly SquadraWEBContext _context;

        public ClientesController(SquadraWEBContext context)
        {
            _context = context;
        }



        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTO cliente)
        {
            Cliente aux = new Cliente();

            aux.Id = id;
            aux.Cpf = cliente.Cpf;
            aux.Endereco = cliente.Endereco;
            aux.Nome = cliente.Nome;
            aux.Telefone = cliente.Telefone;

            if (id != aux.Id)
            {
                return BadRequest("Deu ruim");
            }

            _context.Entry(aux).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound("Cliente não encontrado");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Cliente> PostCliente(ClienteDTO cliente)
        {
            Cliente aux = new Cliente();
            aux.Cpf = cliente.Cpf;
            aux.Endereco = cliente.Endereco;
            aux.Nome = cliente.Nome;
            aux.Telefone = cliente.Telefone;

            _context.Cliente.Add(aux);
            _context.SaveChanges();

            return CreatedAtAction("GetCliente", new { id = aux.Id }, aux);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }

        //Conta quantos registros existem
        [HttpGet]
        [Route("count")]
        public int GetQuantity()
        {
            return _context.Cliente.Count();
        }

        //Busca Registro pelo nome
        [HttpGet]
        [Route("BuscaNome")]
        public ActionResult<Cliente>GetClienteByName(String nome)
        {
            var cliente = _context.Cliente.FirstOrDefault(Cliente => Cliente.Nome == nome);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        //Busca Registro pelo CPF
        [HttpGet]
        [Route("BuscaCPF")]
        public async Task<ActionResult<Cliente>> GetClienteByCPF(String cpf)
        {
            var cliente = _context.Cliente.FirstOrDefault(Cliente => Cliente.Cpf == cpf);
            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }



    }
}
