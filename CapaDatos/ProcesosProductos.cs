using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.Entity;

namespace CapaDatos
{
    public class ProcesosProductos
    {
        ProyectoFinalEntities bd = new ProyectoFinalEntities();
        public void InsertarProucto(Producto mod)
        {
            bd.Producto.Add(mod);
            bd.SaveChanges();
        }

        public List<Producto> LeerProducto()
        {
            return bd.Producto.ToList();
        }


        public Producto BuscaProducto(int id)
        {
            return bd.Producto.Find(id);
        }

        //--------Editar o actualizar e Producto
        public void EditarProducto(Producto clt)
        {
            var data = bd.Producto.Find(clt.Productoid);
            data.Nombre = clt.Nombre;
            data.Precio = clt.Precio;
            data.Cantidad = clt.Cantidad;
            bd.Entry(data).State = EntityState.Modified;
            bd.SaveChanges();
        }

        //---------Borrar Producto
        public void BorrarProducto(int id)
        {
            var data = bd.Producto.Find(id);
            bd.Producto.Remove(data);
            bd.SaveChanges();
        }

        public List<Producto> BuscadorProducto(string nom)
        {
            return bd.Producto.Where(a => a.Nombre == nom).ToList(); ;
        }
    }
}
