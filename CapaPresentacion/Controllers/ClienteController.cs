using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace CapaPresentacion.Controllers
{
    public class ClienteController : Controller
    {
        ClienteLogica log = new ClienteLogica();
        // GET: Cliente
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
        public ActionResult Formulario(Cliente clt)
        {
            log.SetCliente(clt);
            return RedirectToAction("MostrarDAtos");
        }
        //----------Mostramos los datos
        public ActionResult MostrarDAtos()
        {
            var data = log.GetClientes();
            return View(data);
        }

        //public ActionResult Buscar(int id)
        //{

        //}


        //-------Editamos los datos
        public ActionResult Actualizar(int id)
        {
            var mod = log.SearchCliente(id);
            return View(mod);
        }
        [HttpPost]
        public ActionResult Actualizar(Cliente clt)
        {
            log.UpdateCliente(clt);
            return RedirectToAction("MostrarDAtos");
        }


        //-------Borramos los datos
        public ActionResult Borrar(int id)
        {
            var mod = log.SearchCliente(id);
            return View(mod);
        }

        [HttpPost, ActionName("Borrar")]
        public ActionResult Borrar2(int id)
        {
            log.EliminarCliente(id);
            return RedirectToAction("MostrarDAtos");
        }

        //--------------Creando el Buscador
        public ActionResult Buscador(string nombre)
        {
            var mode = log.BuscadorCliente(nombre);
            

            if (mode.Count == 0)
            {
                return RedirectToAction("MostrarDAtos");
            }
            else
            {
                return View(mode);
            }
        }   

        public ActionResult Buscador1(string categoria)
        {
            var mod = log.BuscadorCliente2(categoria);

            if (mod.Count == 0)
            {
                return RedirectToAction("MostrarDAtos");
            }
            else
            {
                return View(mod);
            }
        }
    }
}