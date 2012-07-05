using System;
using System.Collections.Generic;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class TelefoneDAO : ITelefoneDAO
    {
        public void Adicionar(Telefone modelo)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Telefone modelo)
        {
            throw new NotImplementedException();
        }

        public void Remover(Telefone modelo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Telefone> Consultar(Func<Telefone, bool> expressaoDeConsulta)
        {
            throw new NotImplementedException();
        }
    }
}
