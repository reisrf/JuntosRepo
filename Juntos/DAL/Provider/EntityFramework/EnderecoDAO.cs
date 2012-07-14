using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class EnderecoDAO : IEnderecoDAO
    {
        public void Adicionar(Endereco modelo)
        {
            JuntosContext.Instance.Enderecos.Add(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Endereco modelo)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Endereco modelo)
        {
            JuntosContext.Instance.Enderecos.Remove(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Endereco> Consultar(Func<Endereco, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Enderecos.Where(expressaoDeConsulta);
        }
    }
}
