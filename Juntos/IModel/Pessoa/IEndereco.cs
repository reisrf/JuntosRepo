namespace Juntos.IModel.Pessoa
{
    /// <summary>
    /// Interface para classe de endere�o.
    /// </summary>
    public interface IEndereco
    {
        /// <summary>
        /// Retorna ou atribui o logradouro ao endere�o.
        /// </summary>
        string Logradouro { get; set; }

        /// <summary>
        /// Retorna ou atribui o n�mero ao endere�o.
        /// </summary>
        int Numero { get; set; }

        /// <summary>
        /// Retorna ou atribui o complemento ao endere�o.
        /// </summary>
        string Complemento { get; set; }

        /// <summary>
        /// Retorna ou atribui o CEP ao endere�o.
        /// </summary>
        ICEP CEP { get; set; }
    }
}