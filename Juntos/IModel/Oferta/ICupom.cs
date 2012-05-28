namespace Juntos.IModel.Oferta
{
    using Pessoa;

    /// <summary>
    /// Interface para a classe de cupom.
    /// </summary>
    public interface ICupom
    {
        /// <summary>
        /// Retorna a oferta que gerou o cupom.
        /// </summary>
        IOferta Oferta { get; }

        /// <summary>
        /// Retorna o pagamento do cupom.
        /// </summary>
        IPagamento Pagamento { get; }

        /// <summary>
        /// Retorna o valor do cupom.
        /// </summary>
        decimal Valor { get; }

        /// <summary>
        /// Retorna a pessoa que solicitou o cupom.
        /// </summary>
        IPessoa Pessoa { get; }

        /// <summary>
        /// Reserva o cupom para uma pessoa.
        /// </summary>
        /// <param name="pessoa">Pessoa para reserva.</param>
        /// <param name="pagamento">Pagamento do cupom.</param>
        void Reservar(IPessoa pessoa, IPagamento pagamento);
    }
}