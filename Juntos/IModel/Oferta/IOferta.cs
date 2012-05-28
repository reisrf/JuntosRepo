namespace Juntos.IModel.Oferta
{
    using System;
    using System.Collections.Generic;
    using Pessoa;

    /// <summary>
    /// Interface para classe de oferta.
    /// </summary>
    public interface IOferta
    {
        /// <summary>
        /// Retorna ou atribui uma descrição a oferta.
        /// </summary>
        string Descricao { get; set; }

        /// <summary>
        /// Retorna os cupons vinculados a essa oferta.
        /// </summary>
        IEnumerable<ICupom> CuponsDisponiveis { get; }

        /// <summary>
        /// Retorna ou atribui uma data para o início da oferta.
        /// </summary>
        DateTime DataInicio { get; set; }

        /// <summary>
        /// Retorna ou atribui uma data de expiração para a oferta.
        /// </summary>
        DateTime DataExpiracao { get; set; }

        /// <summary>
        /// Retorna o anunciante que criou a oferta.
        /// </summary>
        IAnunciante Anunciante { get; }

        /// <summary>
        /// Retorna uma quantidade definida de cupons, retirando-os dos disponíveis.
        /// </summary>
        /// <param name="pessoa">Pessoa que solicitou os cupons.</param>
        /// <param name="quantidade">Quantidade cupons solicitados.</param>
        /// <returns>Retorna uma lista com a quantidade de cupons.</returns>
        IEnumerable<ICupom> SolicitarCupons(IPessoa pessoa, int quantidade);

        /// <summary>
        /// Cancela a solicitação de cupons, devolvendo-os.
        /// </summary>
        /// <param name="cupons">Cupons a serem devolvidos.</param>
        void DevolverCupons(IEnumerable<ICupom> cupons);
    }
}
