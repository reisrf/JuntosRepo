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
    public class OfertaController : Controller
    {
        public ActionResult Index()
        {

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            List<Oferta> ofertas = ofertaService.RetornarTodos();
            return View(ofertas);
        }
        public ActionResult Edit(Guid id)
        {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            Oferta oferta = ofertaService.BuscarPorId(id);
            return View(oferta);
        }
        [HttpPost]
        public ActionResult Edit(Oferta oferta)
        {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            if (oferta != null)
            {
                TryUpdateModel<Oferta>(oferta);
                ofertaService.Atualizar(oferta);

            }
            return RedirectToAction("Index");
        }

    }
}
