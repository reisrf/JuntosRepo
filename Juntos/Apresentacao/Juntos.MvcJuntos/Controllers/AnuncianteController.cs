using System;
using System.Web.Security;
using Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Juntos.Service;
using Juntos.Model;
using Juntos.IService;
using Juntos.Model.Enums;



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
        public ActionResult Edit(long id)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(id);
            return View(anunciante);
        }

        [HttpPost]
        public ActionResult Edit(long id, FormCollection collection)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            List<Anunciante> anunciantees = anuncianteService.RetornarTodos();

            Anunciante anunciante = anunciantees.Where(c => c.Id == id).FirstOrDefault();

            if (anunciante != null)
            {
                TryUpdateModel<Anunciante>(anunciante);
                anuncianteService.Atualizar(anunciante);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.PessoaDTO pessoa)
        {
            Anunciante anunciante = new Anunciante();
            anunciante.Nome = pessoa.Nome;
            anunciante.Email = pessoa.Email;
            anunciante.Senha = pessoa.Senha;
            anunciante.Inscricao = pessoa.Inscricao;
            anunciante.Tipo = EnumTipoPessoa.Juridica;
            Endereco endereco = new Endereco(anunciante);
            endereco.Logradouro = pessoa.Logradouro;
            endereco.Numero = pessoa.LogradouroNumero;
            endereco.Complemento = pessoa.Complemento;
            endereco.Bairro = pessoa.Bairro;
            endereco.Cidade = pessoa.Cidade;
            endereco.Estado = pessoa.Estado;
            endereco.Pais = pessoa.Pais;
            endereco.Cep = pessoa.Cep;

            Telefone telefone = new Telefone(anunciante);
            telefone.DDI = pessoa.DDI;
            telefone.DDD = pessoa.DDD;
            telefone.Numero = pessoa.NumeroTelefone;
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            anuncianteService.Adicionar(anunciante);
            System.Web.HttpContext.Current.Session["anuncianteId"] = anunciante.Id.ToString();
            return RedirectToAction(@"../Oferta");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Models.PessoaDTO pessoa)
        {
            Anunciante anunciante = new Anunciante();
            anunciante.Nome = pessoa.Nome;
            anunciante.Email = pessoa.Email;
            anunciante.Senha = pessoa.Senha;
            anunciante.Inscricao = pessoa.Inscricao;
            anunciante.Tipo = EnumTipoPessoa.Juridica;
            Endereco endereco = new Endereco(anunciante);
            endereco.Logradouro = pessoa.Logradouro;
            endereco.Numero = pessoa.LogradouroNumero;
            endereco.Complemento = pessoa.Complemento;
            endereco.Bairro = pessoa.Bairro;
            endereco.Cidade = pessoa.Cidade;
            endereco.Estado = pessoa.Estado;
            endereco.Pais = pessoa.Pais;
            endereco.Cep = pessoa.Cep;

            Telefone telefone = new Telefone(anunciante);
            telefone.DDI = pessoa.DDI;
            telefone.DDD = pessoa.DDD;
            telefone.Numero = pessoa.NumeroTelefone;
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            anuncianteService.Adicionar(anunciante);

            System.Web.HttpContext.Current.Session["anuncianteId"] = anunciante.Id.ToString();

            return RedirectToAction(@"../Oferta/ListaDeOfertasAnunciante");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.PessoaDTO pessoa)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.ConsultarPeloEmaileSenha(pessoa.Email, pessoa.Senha);



            if (anunciante != null)
            {
                System.Web.HttpContext.Current.Session["anuncianteId"] = anunciante.Id.ToString();
                System.Web.HttpContext.Current.Session["consumidorId"] = string.Empty;
                return RedirectToAction(@"../Oferta/ListaDeOfertasAnunciante");
            }
            else
            {
                //Add message
               ModelState.AddModelError("", "Email ou senha incorretos. Por favor, tente novamente.");
                return View();
            }

        }
    }
}
