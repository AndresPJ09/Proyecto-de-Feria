
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entity.Model.Implements;
using Data.Model.Interfaces;

namespace Data.Model.Implements
{
    public class PersonajeData : IPersonajeData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public PersonajeData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Personajes.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Personajes> GetById(int id)
        {
            var sql = @"SELECT * FROM Personajes WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Personajes>(sql, new { Id = id });
        }

        public async Task<Personajes> Save(Personajes entity)
        {
            // Guardar el personaje en la base de datos
            context.Personajes.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        private bool IsValidImage(byte[] image)
        {
            // Puedes implementar una validación más robusta si lo deseas.
            return image.Length > 0 && (image[0] == 0x89 || (image[0] == 0xFF && image[1] == 0xD8));
        }

        public async Task Update(Personajes entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Personajes>> GetAll()
        {
            var sql = @"SELECT * FROM Personajes Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Personajes>(sql);
        }
    }
}
