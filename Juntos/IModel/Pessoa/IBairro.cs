namespace Juntos.IModel.Pessoa
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface para a classe de bairro.
    /// </summary>
    public interface IBairro
    {
        /// <summary>
        /// Retorna ou atribui um nome ao bairro.
        /// </summary>
        string Nome { get; set; }

        /// <summary>
        /// Retorna os CEPs vinculados ao bairro.
        /// </summary>
        IEnumerable<ICEP> CEPs { get; }

        /// <summary>
        /// Retorna ou atribui a cidade vinculado a cidade.
        /// </summary>
        ICidade Cidade { get; set; }

        /// <summary>
        /// Vincula uma CEP a bairro.
        /// </summary>
        /// <param name="cep">CEP a ser vinculada.</param>
        void VincularCEP(ICEP cep);

        /// <summary>
        /// Desvincula um CEP do bairro.
        /// </summary>
        /// <param name="cep">CEP a ser desvinculado.</param>
        void DesvincularCEP(ICEP cep);

        /// <summary>
        /// Retorna uma lista de CEPs que contemplem o filtro informado através de uma expressão LINQ.
        /// </summary>
        /// <param name="consulta">Expressão LINQ.</param>
        /// <returns>Retorna uma lista de CEPs.</returns>
        IEnumerable<ICEP> ConsultarCEPs(Func<ICEP, bool> consulta);
    }
}