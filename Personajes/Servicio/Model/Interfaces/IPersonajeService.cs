using Entity.Model.Implements;

namespace Servicio.Model.Interfaces
{
    public interface IPersonajeService
    {
        Task Delete(int id);
        Task<Personajes> GetById(int id);
        Task<Personajes> Save(Personajes entity);
        Task Update(Personajes entity);
        Task<IEnumerable<Personajes>> GetAll();
    }
}
