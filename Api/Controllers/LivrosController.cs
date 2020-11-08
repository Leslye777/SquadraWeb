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
    public class LivrosController : ControllerBase
    {
        private readonly SquadraWEBContext _context;

        public LivrosController(SquadraWEBContext context)
        {
            _context = context;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivro()
        {
            return await _context.Livro.ToListAsync();
        }

        // GET: api/Livros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(string id)
        {
            var livro = await _context.Livro.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        // PUT: api/Livros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(string id, LivroDTO livro)
        {
            Livro aux = new Livro();

            aux.Autor = livro.Autor;
            aux.Editora = livro.Editora;
            aux.Isbn = livro.Isbn;
            aux.Preco = livro.Preco;
            aux.Quantidade = livro.Quantidade;
            aux.Titulo = livro.Titulo;

            if (id != aux.Isbn)
            {
                return BadRequest();
            }

            _context.Entry(aux).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
                {
                    return NotFound("Não Encontrado");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Livros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(LivroDTO livro)
        {
            Livro aux = new Livro();
            
            aux.Autor = livro.Autor;
            aux.Editora = livro.Editora;
            aux.Isbn = livro.Isbn;
            aux.Preco = livro.Preco;
            aux.Quantidade = livro.Quantidade;
            aux.Titulo = livro.Titulo;
          
            
            _context.Livro.Add(aux);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LivroExists(aux.Isbn))
                {
                    return Conflict("Livro Já Cadastrado");
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLivro", new { id = aux.Isbn }, aux);
        }

        // DELETE: api/Livros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Livro>> DeleteLivro(string id)
        {
            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound("Não encontrado");
            }

            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();

            return livro;
        }

        private bool LivroExists(string id)
        {
            return _context.Livro.Any(e => e.Isbn == id);
        }

    }
}
