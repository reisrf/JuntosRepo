using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class EnderecoDAO : IEnderecoDAO
    {
        public void Adicionar(Endereco endereco)
        {
            JuntosContext.Instance.Enderecos.Add(endereco);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Endereco endereco)
        {
            var enderecoPersistido = this.BuscarPorId(endereco.Id);
            if (enderecoPersistido != null)
            {
                this.Remover(enderecoPersistido);
            }
            this.Adicionar(endereco);
        }

        public void Remover(Endereco endereco)
        {
            JuntosContext.Instance.Enderecos.Remove(endereco);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Endereco> Consultar(Func<Endereco, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Enderecos.Where(expressaoDeConsulta);
        }
        public List<Endereco> RetornarTodos()
        {
            return JuntosContext.Instance.Enderecos.ToList();
        }
        public Endereco BuscarPorId(long id)
        {
            return JuntosContext.Instance.Enderecos.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
