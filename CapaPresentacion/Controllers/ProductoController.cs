using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace CapaPresentacion.Controllers
{
    public class ProductoController : Controller
    {
        ProductoLogica log = new ProductoLogica();
        // GET: Producto
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
        public ActionResult Formulario(Producto clt)
        {
            log.SetProducto(clt);
            return RedirectToAction("MostrarDAtos");
        }
        //----------Mostramos los datos
        public ActionResult MostrarDAtos()
        {
            var data = log.GetProducto();
            return View(data);
        }


        //-------Editamos los datos
        public ActionResult Actualizar(int id)
        {
            var mod = log.SearchProducto(id);
            return View(mod);
        }
        [HttpPost]
        public ActionResult Actualizar(Producto clt)
        {
            log.UpdateProducto(clt);
            return RedirectToAction("MostrarDAtos");
        }


        //-------Borramos los datos
        public ActionResult Borrar(int id)
        {
            var mod = log.SearchProducto(id);
            return View(mod);
        }

        [HttpPost, ActionName("Borrar")]
        public ActionResult Borrar2(int id)
        {
            log.EliminarProducto(id);
            return RedirectToAction("MostrarDAtos");
        }

        //--------------Creando el Buscador
        public ActionResult Buscador(string nombre)
        {
            var mode = log.BuscadorProducto(nombre);

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