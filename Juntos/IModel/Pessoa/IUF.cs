namespace Juntos.IModel.Pessoa
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface para a classe de UF.
    /// </summary>
    public interface IUF
    {
        /// <summary>
        /// Retornas as cidades vinculadas ao estado.
        /// </summary>
        IEnumerable<ICidade> Cidades { get; }

        /// <summary>
        /// Retorna ou atribui
        /// </summary>
        string Nome { get; set; }

        /// <summary>
        /// Retorna ou atribui o código de IBGE a UF.
        /// </summary>
        int CodigoIBGE { get; set; }

        /// <summary>
        /// Vincula uma cidade a UF.
        /// </summary>
        /// <param name="cidade">Cidade a ser vinculada.</param>
        void VincularCidade(ICidade cidade);
        
        /// <summary>
        /// Desvincula uma cidade da UF.
        /// </summary>
        /// <param name="cidade">Cidade a ser vinculada.</param>
        void DesvincularCidade(ICidade cidade);

        /// <summary>
        /// Retorna uma lista de cidades que contemplem o filtro informado através de uma expressão LINQ.
        /// </summary>
        /// <param name="consulta">Expressão LINQ.</param>
        /// <returns>Retorna uma lista de cidades.</returns>
        IEnumerable<ICidade> ConsultarCidades(Func<ICidade, bool> consulta);
    }
}