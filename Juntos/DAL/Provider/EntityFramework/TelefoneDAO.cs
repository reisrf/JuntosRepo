﻿using System;
using System.Collections.Generic;
using System.Linq;
using Juntos.IDAL;
using Juntos.Model;

namespace Juntos.DAL.Provider.EntityFramework
{
    public class TelefoneDAO : ITelefoneDAO
    {
        public void Adicionar(Telefone modelo)
        {
            JuntosContext.Instance.Telefones.Add(modelo);
            JuntosContext.Instance.SaveChanges();
        }

        public void Atualizar(Telefone modelo)
        {
            JuntosContext.Instance.SaveChanges();
        }

        public void Remover(Telefone modelo)
        {
            JuntosContext.Instance.Telefones.Remove(modelo);
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

        public Telefone BuscarPorId(Guid id)
        {
            return JuntosContext.Instance.Telefones.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
