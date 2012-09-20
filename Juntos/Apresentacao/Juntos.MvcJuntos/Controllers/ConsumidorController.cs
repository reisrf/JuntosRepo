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
    public class ConsumidorController : Controller
    {
        public ActionResult Index()
        {
            
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            List<Consumidor> consumidores = consumidorService.RetornarTodos();
            return View(consumidores);
        }
        public ActionResult Edit(long id)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            Consumidor consumidor = consumidorService.BuscarPorId(id);
            return View(consumidor);
        }

        [HttpPost]
        public ActionResult Edit(long id, FormCollection collection)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            List<Consumidor> consumidores = consumidorService.RetornarTodos(); 

            Consumidor consumidor = consumidores.Where(c => c.Id == id).FirstOrDefault();

            if (consumidor != null)
            {
                TryUpdateModel<Consumidor>(consumidor);
                consumidorService.Atualizar(consumidor);
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
            Consumidor consumidor = new Consumidor();
            consumidor.Nome = pessoa.Nome;
            consumidor.Email = pessoa.Email;
            consumidor.Senha = pessoa.Senha;
            consumidor.Inscricao = pessoa.Inscricao;
            consumidor.Tipo = EnumTipoPessoa.Fisica;
            Endereco endereco = new Endereco(consumidor);
            endereco.Logradouro = pessoa.Logradouro;
            endereco.Numero = pessoa.LogradouroNumero;
            endereco.Complemento = pessoa.Complemento;
            endereco.Bairro = pessoa.Bairro;
            endereco.Cidade  =pessoa.Cidade;
            endereco.Estado = pessoa.Estado;
            endereco.Pais = pessoa.Pais;
            endereco.Cep = pessoa.Cep;

            Telefone telefone = new Telefone(consumidor);
            telefone.DDI = pessoa.DDI;
            telefone.DDD = pessoa.DDD;
            telefone.Numero = pessoa.NumeroTelefone;
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            consumidorService.Adicionar(consumidor);

            System.Web.HttpContext.Current.Session["consumidorId"] = consumidor.Id.ToString();
            return RedirectToAction(@"../Oferta");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Models.PessoaDTO pessoa)
        {
            Consumidor consumidor = new Consumidor();
            consumidor.Nome = pessoa.Nome;
            consumidor.Email = pessoa.Email;
            consumidor.Senha = pessoa.Senha;
            consumidor.Inscricao = pessoa.Inscricao;
            consumidor.Tipo = EnumTipoPessoa.Fisica;
            Endereco endereco = new Endereco(consumidor);
            endereco.Logradouro = pessoa.Logradouro;
            endereco.Numero = pessoa.LogradouroNumero;
            endereco.Complemento = pessoa.Complemento;
            endereco.Bairro = pessoa.Bairro;
            endereco.Cidade = pessoa.Cidade;
            endereco.Estado = pessoa.Estado;
            endereco.Pais = pessoa.Pais;
            endereco.Cep = pessoa.Cep;

            Telefone telefone = new Telefone(consumidor);
            telefone.DDI = pessoa.DDI;
            telefone.DDD = pessoa.DDD;
            telefone.Numero = pessoa.NumeroTelefone;
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            consumidorService.Adicionar(consumidor);

            System.Web.HttpContext.Current.Session["consumidorId"] = consumidor.Id.ToString();
            return RedirectToAction(@"../Oferta");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.PessoaDTO pessoa)
        {
            IConsumidorService consumidorService = typeof(IConsumidorService).Fabricar();
            Consumidor consumidor = consumidorService.ConsultarPeloEmaileSenha(pessoa.Email, pessoa.Senha);

            

            if (consumidor != null)
            {
                FormsAuthentication.SetAuthCookie(consumidor.Email, true);
                return RedirectToAction(@"../Oferta");
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
