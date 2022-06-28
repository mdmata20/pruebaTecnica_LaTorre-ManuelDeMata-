using Microsoft.AspNetCore.Mvc;

using CrudCompleto.Datos;
using CrudCompleto.Models;

namespace CrudCompleto.Controllers
{
    public class MantenedorController : Controller
    {

        ContactoDatos _contactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //La vista mostrara un lista de contactos
            var oLista = _contactoDatos.Listar();


            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Metodo solo devuelve la vista


            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Metodo recibe el objeto para guardarlo en la DB
            var respuesta = _contactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();


        }

        public IActionResult Editar(int idContacto)
        {
            //Metodo solo devuelve la vista

            var ocontacto = _contactoDatos.Obtener(idContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //Metodo solo devuelve la vista

            var respuesta = _contactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
