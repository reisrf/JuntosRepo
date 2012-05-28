namespace Juntos.IModel.Pessoa
{
    using Enumerador;

    /// <summary>
    /// Interface da classe contato.
    /// </summary>
    public interface IContato
    {
        /// <summary>
        /// Retorna ou atribui o tipo do contato como um enumerador.
        /// </summary>
        EnumTipoContato Tipo { get; set; }

        /// <summary>
        /// Retorna ou atribui a descri��o do contato.
        /// </summary>
        string Descricao { get; set; }
    }
}