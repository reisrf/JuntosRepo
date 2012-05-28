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
        /// Cria uma nova oferta permitindo escolher o per�odo e quantidade de cupons disponiveis para ela.
        /// </summary>
        /// <param name="dataInicio">Data inicial da oferta.</param>
        /// <param name="dataExpiracao">Data de expira��o da oferta.</param>
        /// <param name="quantidadeCupons">Quantidade de cupons que ser�o disponibilizados pela oferta.</param>
        /// <returns>Retorna uma oferta.</returns>
        IOferta NovaOferta(DateTime dataInicio, DateTime dataExpiracao, int quantidadeCupons);
    }
}