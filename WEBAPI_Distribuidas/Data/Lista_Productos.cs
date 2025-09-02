using WEBAPI_Distribuidas.Models;

namespace WEBAPI_Distribuidas.Data
{
    public class Lista_Productos
    {
        private static List<Producto> _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Producto 1", Precio = 19.99m, Disponible = true },
            new Producto { Id = 2, Nombre = "Producto 2", Precio = 29.99m, Disponible = true },
            new Producto { Id = 3, Nombre = "Producto 3", Precio = 39.99m, Disponible = false }
        };
    }
}
