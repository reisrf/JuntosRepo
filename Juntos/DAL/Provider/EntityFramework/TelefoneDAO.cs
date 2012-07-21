using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class TelefoneDAO : ITelefoneDAO
    {
        public void Adicionar(Telefone telefone)
        {
            JuntosContext.Instance.Telefones.Add(telefone);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Telefone telefone)
        {
            var telefonePersistido = this.BuscarPorId(telefone.Id);
            if (telefonePersistido != null)
            {
                this.Remover(telefonePersistido);
            }
            this.Adicionar(telefone);
        }

        public void Remover(Telefone telefone)
        {
            JuntosContext.Instance.Telefones.Remove(telefone);
            JuntosContext.Instance.SaveChanges();
        }

        public IEnumerable<Telefone> Consultar(Func<Telefone, bool> expressaoDeConsulta)
        {
            return JuntosContext.Instance.Telefones.Where(expressaoDeConsulta);
        }

        public List<Telefone> RetornarTodos()
        {
            return JuntosContext.Instance.Telefones.ToList();
        }

        public Telefone BuscarPorId(long id)
        {
            return JuntosContext.Instance.Telefones.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
