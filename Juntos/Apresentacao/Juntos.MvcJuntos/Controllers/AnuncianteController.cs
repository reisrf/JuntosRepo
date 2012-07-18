using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework;
using Juntos.IService;
using Juntos.Model;

namespace Juntos.MvcJuntos.Controllers
{
    public class AnuncianteController : Controller
    {
        public ActionResult Index()
        {

            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            List<Anunciante> anunciantes = anuncianteService.RetornarTodos();
            return View(anunciantes);
        }
        public ActionResult Edit(Guid id)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(id);
            return View(anunciante);
        }
        [HttpPost]
        public ActionResult Edit(Anunciante anunciante)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            if (anunciante != null)
            {
                TryUpdateModel<Anunciante>(anunciante);
                anuncianteService.Atualizar(anunciante);

            }
            return RedirectToAction("Index");
        }

    }
}
