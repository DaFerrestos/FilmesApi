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
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public void AdicionaFilme([FromBody]Filme filme) {

            filme.Id = id++;
            filmes.Add(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmesSalvos() {
            return filmes;
        }


    }
}
