using FilmesAPI.Data;
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
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult adicionaFilme([FromBody]Filme filme) 
        {
            _context.Filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmePorId),new {Id=filme.Id },filme);
        }

        [HttpGet]
        public IActionResult recuperaFilme()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id) 
        {
            Filme filme=_context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme!=null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

    }
}
