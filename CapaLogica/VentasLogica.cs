using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class VentasLogica
    {
        ProcesosVentas obj = new ProcesosVentas();
        public void SetVentas(Ventas par)
        {
            obj.InsertarVentas(par);
        }
        public List<Ventas> GetVentas()
        {
            return obj.LeerVentas();
        }
        public Ventas SearchVentas(int id)
        {
            return obj.BuscaVentas(id);

        }

        public void UpdateVentas(Ventas par)
        {
            obj.EditarVentas(par);
        }

        public void EliminarVentas(int id)
        {
            obj.BorrarVentas(id);
        }

        public List<Ventas> BuscadorVentas(string m)
        {
            return obj.BuscadorVentas(m);
        }

        public void FacturacionVentas(Ventas v)
        {
            obj.FacturacionVenta(v);
        }
    }
}
