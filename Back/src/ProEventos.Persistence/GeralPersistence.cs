using ProEventos.Persistence.Contratos;
using System.Threading.Tasks;

namespace ProEventos.Persistence

{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly ProEventosContext proEventosContext;

        public GeralPersistence(ProEventosContext proEventosContext)
        {
            this.proEventosContext = proEventosContext;
        }
        public void Add<T>(T entity) where T : class
        {
            proEventosContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            proEventosContext.Remove(entity);
        }

        public void DeleteRange<T>(T entityArray) where T : class
        {
            proEventosContext.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await proEventosContext.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
           proEventosContext.Update(entity);
        }
            

    } 
}
