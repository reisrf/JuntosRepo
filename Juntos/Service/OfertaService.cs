using System;
using System.Linq;
using Juntos.IRepository;
using Juntos.IService;
using Juntos.Model;

namespace Juntos.Service
{
    public class OfertaService : BaseService<Oferta>, IOfertaService
    {
        public OfertaService(IOfertaRepository ofertaRepository) : base(ofertaRepository)
        {
        }

        public void Publicar(Guid idOferta)
        {
            var oferta = this.Repository.Consultar(o => o.Id.Equals(idOferta)).FirstOrDefault();

            if (oferta == null)
            {
                throw new Exception("Oferta não localizada.");
            }

            oferta.Publicar();

            this.Repository.Atualizar(oferta);
        }

        public void Finalizar(Guid idOferta)
        {
            var oferta = this.Repository.Consultar(o => o.Id.Equals(idOferta)).FirstOrDefault();

            if (oferta == null)
            {
                throw new Exception("Oferta não localizada.");
            }

            oferta.Finalizar();

            this.Repository.Atualizar(oferta);
        }

        public void UtilizarCupom(Guid idCupom)
        {
            var oferta = this.Repository.Consultar(o => o.CuponsGerados.Any(c => c.Id.Equals(idCupom))).FirstOrDefault();
            
            if (oferta == null)
            {
                throw new Exception(string.Format("Oferta para cupom de Id {0} não encontrada.", idCupom));
            }

            if (oferta.DataValidadeCupons.Date < DateTime.Now.Date)
            {
                throw new Exception(string.Format("Cupom expirou em: {0}", oferta.DataValidadeCupons));
            }

            var cupom = oferta.CuponsGerados.FirstOrDefault(c => c.Id.Equals(idCupom));

            cupom.DataUtilizacao = DateTime.Now;

            this.Repository.Atualizar(oferta);
        }
    }
}