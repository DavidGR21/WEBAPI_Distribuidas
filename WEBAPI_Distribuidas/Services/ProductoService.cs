using WEBAPI_Distribuidas.Data;
using WEBAPI_Distribuidas.Models;

namespace WEBAPI_Distribuidas.Services
{
    public class ProductoService
    {
        public IEnumerable<Producto> GetAll()
        {
            return Lista_Productos._productos;
        }

        public Producto? GetById(int id)
        {
            return Lista_Productos._productos.FirstOrDefault(p => p.Id == id);
        }

        public Producto Add(Producto producto)
        {
            producto.Id = Lista_Productos._productos.Any() ? Lista_Productos._productos.Max(p => p.Id) + 1 : 1;
            Lista_Productos._productos.Add(producto);
            return producto;
        }

        public bool Update(int id, Producto producto)
        {
            var existente = Lista_Productos._productos.FirstOrDefault(p => p.Id == id);
            if (existente == null) return false;

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Disponible = producto.Disponible;
            return true;
        }
    }
}
