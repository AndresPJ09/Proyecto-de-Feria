using Entity.Model.Dto;
using Entity.Model.Implements;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Model.Interface
{
    public interface IPersonajeController
    {
        Task<ActionResult<IEnumerable<Personajes>>> GetAll();
        Task<ActionResult<Personajes>> Get(int id);
        Task<ActionResult> Post([FromBody] PersonajeDto personajeDto);
        Task<ActionResult> Put([FromBody] Personajes personajes);
        Task<ActionResult> Delete(int id);
    }
}
