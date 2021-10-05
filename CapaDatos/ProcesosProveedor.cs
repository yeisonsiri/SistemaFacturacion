using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.Entity;

namespace CapaDatos
{
    public class ProcesosProveedor
    {
        ProyectoFinalEntities bd = new ProyectoFinalEntities();
        public void InsertarProveedor(Proveedor mod)
        {
            bd.Proveedor.Add(mod);
            bd.SaveChanges();
        }

        public List<Proveedor> LeerProveedor()
        {
            return bd.Proveedor.ToList();
        }


        public Proveedor BuscaProveedor(int id)
        {
            return bd.Proveedor.Find(id);
        }

        //--------Editar o actualizar e Proveedor
        public void EditarProveedor(Proveedor clt)
        {
            var data = bd.Proveedor.Find(clt.Proveedorid);
            data.Cedula = clt.Cedula;
            data.Nombre = clt.Nombre;
            data.Telefono = clt.Telefono;
            data.Email = clt.Email;
            bd.Entry(data).State = EntityState.Modified;
            bd.SaveChanges();
        }

        //---------Borrar Proveedor
        public void BorrarProveedor(int id)
        {
            var data = bd.Proveedor.Find(id);
            bd.Proveedor.Remove(data);
            bd.SaveChanges();
        }

        public List<Proveedor> BuscadorProveedor(string nom)
        {
            return bd.Proveedor.Where(a => a.Nombre == nom).ToList(); ;
        }
    }
}
