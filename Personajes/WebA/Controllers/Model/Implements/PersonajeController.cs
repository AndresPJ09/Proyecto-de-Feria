using Microsoft.AspNetCore.Mvc;
using Entity.Model.Implements;
using WebA.Controllers.Model.Interface;
using Servicio.Model.Interfaces;
using Entity.Model.Dto;

namespace WebA.Controllers.Model.Implements
{
    [Route("api/Personajes")]
    [ApiController]
    public class PersonajeController : ControllerBase, IPersonajeController
    {
        protected readonly IPersonajeService servicess;

        public PersonajeController(IPersonajeService servicess)
        {
            this.servicess = servicess;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await servicess.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personajes>> Get(int id)
        {
            var result = await servicess.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personajes>>> GetAll()
        {
            var result = await servicess.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonajeDto personajeDto)
        {
            // Convertir la imagen de Base64 a byte[]
            byte[] imagenBytes = null;
            if (!string.IsNullOrEmpty(personajeDto.ImagenBase64))
            {
                imagenBytes = Convert.FromBase64String(personajeDto.ImagenBase64);
            }

            var personaje = new Personajes
            {
                Nombre = personajeDto.Nombre,
                Clase = personajeDto.Clase,
                Nivel = personajeDto.Nivel,
                Habilidades = personajeDto.Habilidades,
                Imagen = imagenBytes,
                CreatedAt = DateTime.Now,
                DeletedAt = null,
                UpdatedAt = null
            };

            var result = await servicess.Save(personaje);
            return CreatedAtAction(nameof(Get), new { id = personaje.Id }, result);
        }



        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Personajes personajes)
        {
            if (personajes == null)
            {
                return BadRequest();
            }
            await servicess.Update(personajes);
            return NoContent();
        }
    }
}
