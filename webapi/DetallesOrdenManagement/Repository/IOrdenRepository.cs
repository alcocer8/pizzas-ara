using DetallesOrdenManagement.Models.entities;

namespace DetallesOrdenManagement.Repository{
    public interface IOrdenRepository{
        public IEnumerable<Orden> GetOrdenAll();
    }
}