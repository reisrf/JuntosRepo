using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juntos.MvcJuntos.Controllers
{
    public class ConsumidorController : Controller
    {
        //
        // GET: /Consumidor/

        public ActionResult Index()
        {
            List<Consumidor> consumidores = Juntos.Service.ConsumidorService.BuscarTodosOsConsumidores();
            return View(consumidores);
        }
        public ActionResult Edit(long id)
        {
            List<Consumidor> consumidores = Juntos.Service.ConsumidorService.BuscarTodosOsConsumidores();

            Consumidor consumidor = consumidores.Where(c => c.ID == id).FirstOrDefault();
            return View(consumidor);
        }
        [HttpPost]
        public ActionResult Edit(Consumidor consumidor)
        {
            if (consumidor != null)
            {
                TryUpdateModel<Consumidor>(consumidor);
                Juntos.Service.AtualizarConsumidor(consumidor);

            }
            return RedirectToAction("Index");
        }
    }
}
