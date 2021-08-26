using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Properties
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController:ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id_filme=1;

        [HttpPost]
        public IActionResult adicionaFilme([FromBody]Filme filme) 
        {
            filme.Id = id_filme++;
            filmes.Add(filme);
            
            return CreatedAtAction(nameof(RecuperaFilmePorId),new {Id=filme.Id },filme);
        }

        [HttpGet]
        public IActionResult recuperaFilme()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id) 
        {
            Filme filme=filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme!=null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

    }
}
