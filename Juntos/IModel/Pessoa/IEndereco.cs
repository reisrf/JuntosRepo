namespace Juntos.IModel.Pessoa
{
    /// <summary>
    /// Interface para classe de endereço.
    /// </summary>
    public interface IEndereco
    {
        /// <summary>
        /// Retorna ou atribui o logradouro ao endereço.
        /// </summary>
        string Logradouro { get; set; }

        /// <summary>
        /// Retorna ou atribui o número ao endereço.
        /// </summary>
        int Numero { get; set; }

        /// <summary>
        /// Retorna ou atribui o complemento ao endereço.
        /// </summary>
        string Complemento { get; set; }

        /// <summary>
        /// Retorna ou atribui o CEP ao endereço.
        /// </summary>
        ICEP CEP { get; set; }
    }
}