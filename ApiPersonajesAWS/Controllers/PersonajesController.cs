using ApiPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonajes()
        {
            var personajes = await this.repo.GetPersonajesAsync();
            return Ok(personajes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonaje(int id)
        {
            var personaje = await this.repo.GetPersonajeAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }
            return Ok(personaje);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonaje(string nombre, string imagen)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(imagen))
            {
                return BadRequest("El nombre y la imagen son obligatorios.");
            }
            await this.repo.CreatePersonajeAsync(nombre, imagen);
            return CreatedAtAction(nameof(GetPersonajes), new { nombre, imagen });
        }
    }
}
