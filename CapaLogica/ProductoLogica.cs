using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class ProductoLogica
    {
        ProcesosProductos obj = new ProcesosProductos();
        public void SetProducto(Producto par)
        {
            obj.InsertarProucto(par);
        }
        public List<Producto> GetProducto()
        {
            return obj.LeerProducto();
        }
        public Producto SearchProducto(int id)
        {
            return obj.BuscaProducto(id);

        }

        public void UpdateProducto(Producto par)
        {
            obj.EditarProducto(par);
        }

        public void EliminarProducto(int id)
        {
            obj.BorrarProducto(id);
        }

        public List<Producto> BuscadorProducto(string m)
        {
            return obj.BuscadorProducto(m);
        }
    }
}
