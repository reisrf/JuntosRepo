namespace Juntos.IModel.Pessoa
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface para a classe de cidade.
    /// </summary>
    public interface ICidade
    {
        /// <summary>
        /// Retorna os bairros cadastrados vinculados a cidade.
        /// </summary>
        IEnumerable<IBairro> Bairros { get; }

        /// <summary>
        /// Retorna ou atribui o nome da cidade.
        /// </summary>
        string Nome { get; set; }

        /// <summary>
        /// Retorna ou atribui a UF vinculada a cidade.
        /// </summary>
        IUF UF { get; set; }

        /// <summary>
        /// Retorna ou atribui o código de IBGE a cidade.
        /// </summary>
        int CodigoIBGE { get; set; }

        /// <summary>
        /// Vincula um bairro a cidade.
        /// </summary>
        /// <param name="bairro">Bairro a ser vinculado.</param>
        void VincularBairro(IBairro bairro);

        /// <summary>
        /// Desvincula um bairro da cidade.
        /// </summary>
        /// <param name="bairro">Bairro a ser desvinculado.</param>
        void DesvincularBairro(IBairro bairro);

        /// <summary>
        /// Retorna uma lista de bairros que contemplem o filtro informado através de uma expressão LINQ.
        /// </summary>
        /// <param name="consulta">Expressão LINQ.</param>
        /// <returns>Retorna uma lista de bairros.</returns>
        IEnumerable<IBairro> ConsultarBairros(Func<IBairro, bool> consulta);
    }
}