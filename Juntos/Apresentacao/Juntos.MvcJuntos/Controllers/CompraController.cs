using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework;
using Juntos.IService;
using Juntos.Model;
using Juntos.MvcJuntos.Models;

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

        public ActionResult Comprar(string id)
        {
            long ofertaId = long.Parse(id);
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            Oferta oferta = ofertaService.BuscarPorId(ofertaId);
            System.Web.HttpContext.Current.Session["ofertaId"] = oferta.Id.ToString();
            long consumidorId = long.Parse(System.Web.HttpContext.Current.Session["consumidorId"].ToString());
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            Consumidor consumidor = consumidorService.BuscarPorId(consumidorId);

            ICompraService compraService = typeof(ICompraService).Fabricar();
            CompraDTO compraDTO = new CompraDTO();
            compraDTO.Consumidor = consumidor;
            compraDTO.Oferta = oferta;
            return View(compraDTO);
            
        }

        [HttpPost]
        public ActionResult Comprar(Models.CompraDTO compra)
        {
            if (ModelState.IsValid)
            {
                Compra newCompra = new Compra();
                long consumidorId = long.Parse(System.Web.HttpContext.Current.Session["consumidorId"].ToString());
                IConsumidorService consumidorService = typeof (IConsumidorService).Fabricar();
                Consumidor consumidor = consumidorService.BuscarPorId(consumidorId);

                long ofertaId = long.Parse(System.Web.HttpContext.Current.Session["ofertaId"].ToString());
                IOfertaService ofertaService = typeof (IOfertaService).Fabricar();
                Oferta oferta = ofertaService.BuscarPorId(ofertaId);

                ICompraService compraService = typeof (ICompraService).Fabricar();
                newCompra = compraService.ComprarOferta(consumidor, oferta, compra.nrcupons);




                return RedirectToAction(@"PagarCompra/" + compra.id.ToString());
            }
            return View(compra);
        }


        public ActionResult PagarCompra(string id)
        {
            long compraId = long.Parse(id);
            ICompraService compraService = typeof(ICompraService).Fabricar();
            Compra compra = compraService.BuscarPorId(compraId);

            long ofertaId = long.Parse(System.Web.HttpContext.Current.Session["ofertaId"].ToString());
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            Oferta oferta = ofertaService.BuscarPorId(ofertaId);

            CompraDTO compraDTO = new CompraDTO();
            compraDTO.Consumidor = compra.Consumidor;
            compraDTO.Oferta = compra.Cupons[0].Oferta;
            compraDTO.ValorTotal = compra.ValorTotal;

            return View(compraDTO);
        }

        [HttpPost]
        public ActionResult PagarCompra(Models.CompraDTO compraDTO)
        {
            if (ModelState.IsValid)
            {
                ICompraService compraService = typeof(ICompraService).Fabricar();

                Compra compra = compraService.BuscarPorId(compraDTO.id);

                compraService.PagarCompra(compra,  compraDTO.FormaPagamento);

                return RedirectToAction(@"../Compra/ListaDeComprasConsumidor");
            }
            return View(compraDTO);
        }
    }
}
