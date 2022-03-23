using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController] //identifica tipo da classe: Controller
    [Route("[controller]")] //Explicita rota
    public class FilmeController : ControllerBase {

        private FilmeContext _context;

        public FilmeController(FilmeContext context) {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme) {

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);//indica local(location) de criação
        }

        [HttpGet]
        public IActionResult RecuperaFilmes() {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id) {

            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null) {
                return Ok(filme);
            }
            return NotFound();//devolve mensagem mais clara para o usuário
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] Filme filmeNovo) {

           Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme == null) {
                return NotFound();
            }
            filme.Titulo = filmeNovo.Titulo;
            filme.Genero = filmeNovo.Genero;
            filme.Duracao = filmeNovo.Duracao;
            filme.Diretor = filmeNovo.Diretor;

            _context.SaveChanges();
            return NoContent();
        }
    }
}
