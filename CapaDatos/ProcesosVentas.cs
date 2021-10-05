using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.Entity;

namespace CapaDatos
{
    public class ProcesosVentas
    {
        ProyectoFinalEntities bd = new ProyectoFinalEntities();
        public void InsertarVentas(Ventas mod)
        {
            bd.Ventas.Add(mod);
            bd.SaveChanges();
        }

        public List<Ventas> LeerVentas()
        {
            return bd.Ventas.ToList();
        }


        public Ventas BuscaVentas(int id)
        {
            return bd.Ventas.Find(id);
        }

        //--------Editar o actualizar Ventas
        public void EditarVentas(Ventas clt)
        {
            var data = bd.Ventas.Find(clt.Ventaid);
            data.Fecha = clt.Fecha;
            data.Producto = clt.Producto;
            data.Cantidad = clt.Cantidad;
            data.NombreCliente = clt.NombreCliente;
            data.Precio = clt.Precio;
            data.Itebis = clt.Itebis;
            bd.Entry(data).State = EntityState.Modified;
            bd.SaveChanges();
        }

        //---------Borrar Ventas
        public void BorrarVentas(int id)
        {
            var data = bd.Ventas.Find(id);
            bd.Ventas.Remove(data);
            bd.SaveChanges();
        }

        public List<Ventas> BuscadorVentas(string nom)
        {
            return bd.Ventas.Where(a => a.NombreCliente == nom).ToList(); ;
        }

        public void FacturacionVenta(Ventas v)
        {
            //v.Total = int.Parse(v.Precio) * int.Parse(v.Cantidad);
            //var total = v.Total;
            //if (v.Cliente.Categoria == "regular")
            //{
            //    v.Itebis = (string)(total * 0.18);
            //}
            
            v.Total = v.Precio * v.Cantidad;
            var total = v.Total;
            var descuento = total * 0.05;
            var itebis = 0;
            var query = (from x in bd.Cliente where x.Clienteid == v.Clienteid select x.Categoria).FirstOrDefault();

            if (query == "regular")
            {
                v.Itebis = (int)(total * 0.18);
                v.Total = total + v.Itebis;
                
            }
            else
            {
                itebis = (int)(v.Total * 0.18);
                v.Itebis = itebis;
                v.Total = (int) (v.Total - descuento) + itebis;
            }


            bd.Ventas.Add(v);
            bd.SaveChanges();



        }
    }
}
