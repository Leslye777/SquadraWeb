using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SquadraWeb.Api;
using SquadraWeb.Api.Models;

namespace SquadraWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly SquadraWEBContext _context;

        public VendasController(SquadraWEBContext context)
        {
            _context = context;
        }

        // GET: api/Vendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVenda()
        {
            return await _context.Venda.ToListAsync();
        }

        // GET: api/Vendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _context.Venda.FindAsync(id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }


        // GET: api/Vendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetComprasDeUmCliente()
        {
            return await _context.Venda.ToListAsync();
        }



        //Não sera possivel alterar nem mesmo remover vendas concluidas 


        // POST: api/Vendas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Venda>> PostVenda(VendaDTO venda)
        {

            Venda aux = new Venda();

            if(verificaQuantidade(venda.Quantidade,venda.IdLivro))
            {
                return BadRequest("Quantidade Não Disponivel");
            }

            aux.IdCliente = venda.IdCliente;
            aux.IdLivro = venda.IdLivro; 
            aux.Quantidade = venda.Quantidade;
            aux.Total = CalculoTotal(venda.Quantidade, venda.IdLivro);
            aux.DataCompra = DateTime.Now.ToUniversalTime();
            

            _context.Venda.Add(aux);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenda", new { id = aux.Id }, aux);
        }

       

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.Id == id);
        }

        private bool verificaQuantidade(int quantidadeRequisitada, string isbn)
        {
            if(((_context.Livro.Find(isbn).Quantidade) - quantidadeRequisitada) < 0)
            {
                return true;
            }

            return false;
            
        }

        private decimal CalculoTotal(int quantidade, string isbn)
        {
            return ((_context.Livro.Find(isbn).Preco) * quantidade);
        }

    }
}
