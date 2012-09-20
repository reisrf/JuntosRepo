using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Framework;
using Juntos.IService;
using Juntos.Model;
using Juntos.Model.Enums;

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
        public ActionResult Edit(long id)
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


        public ActionResult ListaDeOfertasAtivas()
        {

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            List<Oferta> ofertas = ofertaService.BuscarPorStatus(EnumStatusOferta.Publicada);

            return View(ofertas);
        }


        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Models.OfertaDTO oferta)
        {
            Oferta newOferta = new Oferta();
            long anuncianteId = long.Parse(System.Web.HttpContext.Current.Session["anuncianteId"].ToString());
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(anuncianteId);
            newOferta.Anunciante = anunciante;
            newOferta.Status = EnumStatusOferta.Criada;
            newOferta.DataValidadeCupons = oferta.DataValidadeCupons;
            newOferta.DataExpiracao = oferta.DataExpiracao;
            newOferta.DataInicioValidade = oferta.DataInicioValidade;

            newOferta.ValorCupons = oferta.ValorCupons;
            newOferta.Descricao = oferta.Descricao;
            newOferta.Condicoes = oferta.Condicoes;
            newOferta.Endereco = oferta.Endereco;
            newOferta.Telefone = oferta.Telefone;

            newOferta.NumeroMaximoCupons = oferta.NumeroMaximoCupons;

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            ofertaService.Adicionar(newOferta);


            return RedirectToAction(@"../Oferta/ListaDeOfertasAnuncianteAPublicar");
        }

        public ActionResult ListaDeOfertasAnunciante()
        {
            long anuncianteId = long.Parse(System.Web.HttpContext.Current.Session["anuncianteId"].ToString());
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(anuncianteId);

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            List<Oferta> ofertas = ofertaService.BuscarPorAnunciante(anunciante);

            

            return View(ofertas);
        }

        public ActionResult ListaDeOfertasAnuncianteAPublicar()
        {
            long anuncianteId = long.Parse(System.Web.HttpContext.Current.Session["anuncianteId"].ToString());
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(anuncianteId);

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            List<Oferta> ofertas = ofertaService.BuscarPorAnuncianteEStatus(anunciante, EnumStatusOferta.Criada);
            return View(ofertas);
        }

        public ActionResult ListaDeOfertasAnunciantePublicadas()
        {
            long anuncianteId = long.Parse(System.Web.HttpContext.Current.Session["anuncianteId"].ToString());
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(anuncianteId);

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            List<Oferta> ofertas = ofertaService.BuscarPorAnuncianteEStatus(anunciante, EnumStatusOferta.Publicada);
            return View(ofertas);
        }

        public ActionResult ListaDeOfertasAnuncianteFinalizadas()
        {
            long anuncianteId = long.Parse(System.Web.HttpContext.Current.Session["anuncianteId"].ToString());
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(anuncianteId);

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            List<Oferta> ofertas = ofertaService.BuscarPorAnuncianteEStatus(anunciante, EnumStatusOferta.Finalizada);
            return View(ofertas);
        }

        public ActionResult Publicar(long id)
        {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();

            Oferta oferta = ofertaService.BuscarPorId(id);
            
            return View(oferta);

        }

        [HttpPost, ActionName("Publicar")]
        public ActionResult PublicarConfirmado(long id)
        {
            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();
            ofertaService.Publicar(id);
            return RedirectToAction(@"../Oferta/ListaDeOfertasAnuncianteAPublicar");
            
        }

        public ActionResult Detalhes(long id)
        {

            IOfertaService ofertaService = typeof(IOfertaService).Fabricar();

            Oferta oferta = ofertaService.BuscarPorId(id);

            return View(oferta);

        }

    }
}
