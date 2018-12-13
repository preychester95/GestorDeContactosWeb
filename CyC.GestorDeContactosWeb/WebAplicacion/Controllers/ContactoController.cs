using CyC.GestorDeContactos.AccesoDatos.DAL;
using CyC.GestorDeContactos.AccesoDatos.DTO;
using System;
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
        public ActionResult AddOrEdit(string idContacto)
        {
            if (String.IsNullOrEmpty(idContacto))
            {
                return View(new Contacto());
            }
            else
            {
                return View(ContactoDAL.getContactoByGuid(Guid.Parse(idContacto)));
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Contacto nuevoContacto)
        {
            if (nuevoContacto.UIDContacto == null)
            {
                nuevoContacto.UIDContacto = Guid.NewGuid();
                nuevoContacto.UIDDireccion = Guid.Parse("849B3C32-BFEA-4FC2-AA2A-068AD170F429");
                ContactoDAL.createContacto(nuevoContacto);
            }
            else
            {
                ContactoDAL.updateContacto(nuevoContacto);
            }

            return GetData();
        }
    }
}