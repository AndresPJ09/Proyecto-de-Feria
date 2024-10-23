using Entity.Model.Implements;

namespace Data.Model.Interfaces
{
    public interface IPersonajeData
    {
        Task Delete(int id);
        Task<Personajes> GetById(int id);
        Task<Personajes> Save(Personajes entity);
        Task Update(Personajes entity);
        Task<IEnumerable<Personajes>> GetAll();
    }
}
