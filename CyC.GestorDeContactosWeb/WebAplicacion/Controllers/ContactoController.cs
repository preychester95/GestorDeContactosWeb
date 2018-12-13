using CyC.GestorDeContactos.AccesoDatos.DAL;
using CyC.GestorDeContactos.AccesoDatos.DTO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebAplicacion.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            List<Contacto> listaContactos = ContactoDAL.getAllContactos();
            return Json(new { data = listaContactos }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int i = 0)
        {
            return View(new Contacto());
        }

        [HttpPost]
        public ActionResult AddOrEdit()
        {
            return View();
        }
    }
}