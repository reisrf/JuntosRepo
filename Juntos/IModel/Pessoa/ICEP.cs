namespace Juntos.IModel.Pessoa
{
    /// <summary>
    /// Interface para a classe de CEP.
    /// </summary>
    public interface ICEP
    {
        /// <summary>
        /// Retorna ou atribui o bairro vinculado ao CEP.
        /// </summary>
        IBairro Bairro { get; set; }
    }
}