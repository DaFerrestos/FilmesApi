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
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme) {

            filme.Id = id++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id}, filme);//indica local(location) de criação
        }

        [HttpGet]
        public IActionResult RecuperaFilmes() {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id) {

            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme != null) {
                return Ok(filme);
            }
            return NotFound();//devolve mensagem mais clara para o usuário
        }
    }
}
