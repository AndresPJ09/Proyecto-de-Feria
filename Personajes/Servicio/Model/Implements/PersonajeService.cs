using Data.Model.Interfaces;
using Entity.Model.Implements;
using Servicio.Model.Interfaces;


namespace Servicio.Model.Implements
{
    public class PersonajeService : IPersonajeService
    {
        protected readonly IPersonajeData data;

        public PersonajeService(IPersonajeData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<Personajes>> GetAll()
        {
            IEnumerable<Personajes> personajes = await data.GetAll();
            {
                return await data.GetAll();
            }
        }

            public Task<Personajes> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Personajes> Save(Personajes entity)
        {
            // Validaciones adicionales o lógica de negocio
            entity.CreatedAt = DateTime.Now;
            entity.DeletedAt = null;
            entity.UpdatedAt = null;

            // Pasar la entidad a la capa de Data para guardarla
            return await data.Save(entity);
        }


        public async Task Update(Personajes entity)
        {
            Personajes personajes = await data.GetById(entity.Id);
            if (personajes == null)
            {
                throw new Exception("Registro no encontrado");
            }
            personajes.UpdatedAt = DateTime.Now;

            await data.Update(personajes);
        }
    }
}
