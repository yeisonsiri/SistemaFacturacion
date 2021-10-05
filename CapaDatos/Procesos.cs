using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.Entity;

namespace CapaDatos
{
    public class Procesos
    {
        ProyectoFinalEntities bd = new ProyectoFinalEntities();
        public void InsertarCliente(Cliente mod)
        {
            bd.Cliente.Add(mod);
            bd.SaveChanges();
        }

        public List<Cliente> LeerCliente()
        {
            return bd.Cliente.ToList();
        }


        public Cliente BuscaCliente(int id)
        {
            return bd.Cliente.Find(id);
        }

        //--------Editar o actualizar e Cliente
        public void EditarCliente(Cliente clt)
        {
            var data = bd.Cliente.Find(clt.Clienteid);
            data.Cedula = clt.Cedula;
            data.Nombre = clt.Nombre;
            data.Telefono = clt.Telefono;
            data.Email = clt.Email;
            data.Categoria = clt.Categoria;
            bd.Entry(data).State = EntityState.Modified;
            bd.SaveChanges();
        }

        //---------Borrar Cliente
        public void BorrarCliente(int id)
        {
            var data = bd.Cliente.Find(id);
            bd.Cliente.Remove(data);
            bd.SaveChanges();
        }

        public List<Cliente> BuscadorCliente(string nom)
        {
            return bd.Cliente.Where(a => a.Nombre == nom).ToList(); ;
        }
        public List<Cliente> BuscadorCategoria(string cat)
        {
            return bd.Cliente.Where(a => a.Categoria == cat).ToList(); ;
        }
        public List<Cliente> BuscadorCliente1( string cat)
        {
            return bd.Cliente.Where(a => a.Nombre == cat).ToList(); ;
        }


    }
}
