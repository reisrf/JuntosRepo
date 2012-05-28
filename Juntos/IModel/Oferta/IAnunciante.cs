namespace Juntos.IModel.Oferta
{
    using System;
    using System.Collections.Generic;
    using Pessoa;

    /// <summary>
    /// Interface para a classe de anunciante.
    /// </summary>
    public interface IAnunciante : IPessoa
    {
        /// <summary>
        /// Retorna as ofertas do anunciante.
        /// </summary>
        IEnumerable<IOferta> Ofertas { get; }

        /// <summary>
        /// Cria uma nova oferta permitindo escolher o período e quantidade de cupons disponiveis para ela.
        /// </summary>
        /// <param name="dataInicio">Data inicial da oferta.</param>
        /// <param name="dataExpiracao">Data de expiração da oferta.</param>
        /// <param name="quantidadeCupons">Quantidade de cupons que serão disponibilizados pela oferta.</param>
        /// <returns>Retorna uma oferta.</returns>
        IOferta NovaOferta(DateTime dataInicio, DateTime dataExpiracao, int quantidadeCupons);
    }
}