using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class ClienteLogica
    {
        Procesos obj = new Procesos();
        public void SetCliente(Cliente par)
        {
            obj.InsertarCliente(par);
        }
        public List<Cliente> GetClientes()
        {
            return obj.LeerCliente();
        }
        public Cliente SearchCliente(int id)
        {
            return obj.BuscaCliente(id);

        }

        public void UpdateCliente(Cliente par)
        {
            obj.EditarCliente(par); 
        }

        public void EliminarCliente(int id)
        {
            obj.BorrarCliente(id) ;
        }

        public List<Cliente> BuscadorCliente(string m)
        {
            return obj.BuscadorCliente(m);
        }

        
        public List<Cliente> BuscadorCliente2( string c)
        {
            return obj.BuscadorCategoria(c);
        }

        
    }
}
