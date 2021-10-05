using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace CapaPresentacion.Controllers
{
    public class ProveedorController : Controller
    {
        ProveedorLogica log = new ProveedorLogica();
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
        public ActionResult Formulario(Proveedor clt)
        {
            log.SetProveedor(clt);
            return RedirectToAction("MostrarDAtos");
        }
        //----------Mostramos los datos
        public ActionResult MostrarDAtos()
        {
            var data = log.GetProveedor();
            return View(data);
        }


        //-------Editamos los datos
        public ActionResult Actualizar(int id)
        {
            var mod = log.SearchProveedor(id);
            return View(mod);
        }
        [HttpPost]
        public ActionResult Actualizar(Proveedor clt)
        {
            log.UpdateProveedor(clt);
            return RedirectToAction("MostrarDAtos");
        }


        //-------Borramos los datos
        public ActionResult Borrar(int id)
        {
            var mod = log.SearchProveedor(id);
            return View(mod);
        }

        [HttpPost, ActionName("Borrar")]
        public ActionResult Borrar2(int id)
        {
            log.EliminarProveedor(id);
            return RedirectToAction("MostrarDAtos");
        }

        //--------------Creando el Buscador
        public ActionResult Buscador(string nombre)
        {
            var mode = log.BuscadorProveedor(nombre);

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