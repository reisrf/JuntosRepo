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
    public class CompraController : Controller
    {
        public ActionResult Index()
        {

            ICompraService compraService = typeof(ICompraService).Fabricar();
            List<Compra> compras = compraService.RetornarTodos();
            return View(compras);
        }
        public ActionResult Edit(long id)
        {
            ICompraService compraService = typeof(ICompraService).Fabricar();
            Compra compra = compraService.BuscarPorId(id);
            return View(compra);
        }
        [HttpPost]
        public ActionResult Edit(Compra compra)
        {
            ICompraService compraService = typeof(ICompraService).Fabricar();
            if (compra != null)
            {
                TryUpdateModel<Compra>(compra);
                compraService.Atualizar(compra);

            }
            return RedirectToAction("Index");
        }

    }
}
