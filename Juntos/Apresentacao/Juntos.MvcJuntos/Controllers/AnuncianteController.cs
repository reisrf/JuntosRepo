using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework;
using Juntos.IService;
using Juntos.Model;
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
        public ActionResult Edit(Guid id)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            Anunciante anunciante = anuncianteService.BuscarPorId(id);
            return View(anunciante);
        }
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            IAnuncianteService anuncianteService = typeof(IAnuncianteService).Fabricar();
            List<Anunciante> anunciantes = anuncianteService.RetornarTodos();

            Anunciante anunciante = anunciantes.Where(c => c.Id == id).FirstOrDefault();

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
            anunciante.CpfCnpj = pessoa.CpfCnpj;
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

            return RedirectToAction("Index");
        }

    }
}
