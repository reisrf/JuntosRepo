using System;
using Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juntos.Service;
using Juntos.Model;
using Juntos.IService;


namespace Juntos.MvcJuntos.Controllers
{
    public class ConsumidorController : Controller
    {
        public ActionResult Index()
        {
            
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            List<Consumidor> consumidores = consumidorService.RetornarTodos();
            return View(consumidores);
        }
        public ActionResult Edit(Guid id)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            Consumidor consumidor = consumidorService.BuscarPorId(id);
            return View(consumidor);
        }
        [HttpPost]
        public ActionResult Edit(Consumidor consumidor)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            if (consumidor != null)
            {
                TryUpdateModel<Consumidor>(consumidor);
                consumidorService.Atualizar(consumidor);

            }
            return RedirectToAction("Index");
        }
         
    }
}
