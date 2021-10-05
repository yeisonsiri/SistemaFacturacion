using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class ProveedorLogica
    {
        ProcesosProveedor obj = new ProcesosProveedor();
        public void SetProveedor(Proveedor par)
        {
            obj.InsertarProveedor(par);
        }
        public List<Proveedor> GetProveedor()
        {
            return obj.LeerProveedor();
        }
        public Proveedor SearchProveedor(int id)
        {
            return obj.BuscaProveedor(id);

        }

        public void UpdateProveedor(Proveedor par)
        {
            obj.EditarProveedor(par);
        }

        public void EliminarProveedor(int id)
        {
            obj.BorrarProveedor(id);
        }

        public List<Proveedor> BuscadorProveedor(string m)
        {
            return obj.BuscadorProveedor(m);
        }
    }
}
