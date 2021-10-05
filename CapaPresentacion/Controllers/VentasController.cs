using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace CapaPresentacion.Controllers
{
    public class VentasController : Controller
    {
        VentasLogica log = new VentasLogica();
        // GET: Proveedor
        public ActionResult Index()
        {
            return View();
        }


        //-------Formularios creacion del formulario
        //-------atraves de entity Framework
        public ActionResult Formulario()
        {
            return View();
        }
        //----------Formularioscon que recibio los datos
        [HttpPost]
        public ActionResult Formulario(Ventas clt)
        {
            //log.SetVentas(clt);
            log.FacturacionVentas(clt);
            return RedirectToAction("MostrarDAtos");
        }
        //----------Mostramos los datos
        public ActionResult MostrarDAtos()
        {
            var data = log.GetVentas();
            return View(data);
        }


        //-------Editamos los datos
        public ActionResult Actualizar(int id)
        {
            var mod = log.SearchVentas(id);
            return View(mod);
        }
        [HttpPost]
        public ActionResult Actualizar(Ventas clt)
        {
            log.UpdateVentas(clt);
            return RedirectToAction("MostrarDAtos");
        }


        //-------Borramos los datos
        public ActionResult Borrar(int id)
        {
            var mod = log.SearchVentas(id);
            return View(mod);
        }

        [HttpPost, ActionName("Borrar")]
        public ActionResult Borrar2(int id)
        {
            log.EliminarVentas(id);
            return RedirectToAction("MostrarDAtos");
        }

        //--------------Creando el Buscador
        public ActionResult Buscador(string nombre)
        {
            var mode = log.BuscadorVentas(nombre);

            if (mode.Count == 0)
            {
                return RedirectToAction("MostrarDAtos");
            }
            else
            {
                return View(mode);
            }
        }
    }
}