namespace Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Reflection;

    /// <summary>
    /// Classe de métodos de extensão.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Remove todos os itens retornados que atendem a expressão de consulta.
        /// </summary>
        /// <typeparam name="T">Tipo genérico.</typeparam>
        /// <param name="lista">Lista de origem que será modificada.</param>
        /// <param name="consulta">Expressão de consulta.</param>
        /// <returns>Retorna a lista de itens removidos.</returns>
        public static List<T> RemoveAll<T>(this IList<T> lista, Func<T, bool> consulta)
        {
            var retorno = lista.Where(consulta).ToList();
            Parallel.ForEach(retorno, item => lista.Remove(item));
            return retorno;
        }

        /// <summary>
        /// Retorna o construtor de acordo com os parâmetros.
        /// </summary>
        /// <param name="tipo">Tipo do objeto que deseja verificar o construtor.</param>
        /// <param name="parametros">Parâmetros de construção.</param>
        /// <returns>Retorna as informações do construtor.</returns>
        public static ConstructorInfo GetConstructorByParams(this Type tipo, object[] parametros)
        {
            var tiposDosParametros = new Type[parametros.Length];
            
            for (var i = 0; i < parametros.Length; i++)
            {
                tiposDosParametros[i] = parametros[i].GetType();
            }
            
            var construtor = tipo.GetConstructor(tiposDosParametros);
            
            if (construtor == null)
            {
                throw new Exception(
                    string.Format(
                        "Não foi possível identificar o construtor do tipo '{0}', que apresenta a seglonge sequência de tipos de parâmetros: {1}. Verifique!",
                        tipo.Name, tiposDosParametros.Aggregate(string.Empty, (cur, tipoDoParametro) => cur + "'" + tipoDoParametro.Name + "' ")));
            }

            return construtor;
        }

        /// <summary>
        /// Intância um objeto para a interface passada por parâmetro.
        /// </summary>
        /// <param name="tipoInterface">Tipo da interface.</param>
        /// <param name="parametros">Parâmetros de construção.</param>
        /// <returns>Retorna um objeto instânciado.</returns>
        public static dynamic Fabricar(this Type tipoInterface, params object[] parametros)
        {
            return UnityHelper.Instancia.Resolve(tipoInterface, parametros);
        }

        public static T Hidratar<T>(this T objeto, T objetoDeHidracao)
        {
            var propriedades = objeto.GetType().GetProperties();
            foreach (var propriedade in propriedades)
            {
                var valorPropriedade =  propriedade.GetValue(objeto, new object[] {});

                var isEntidade = (valorPropriedade.GetType().GetMethod("IsEntity") != null);
                if (isEntidade)
                {
                    valorPropriedade = valorPropriedade.Hidratar(propriedade.GetValue(objetoDeHidracao, new object[] {}));
                }

                propriedade.SetValue(objeto, valorPropriedade, new object[] { });
            }
            return objeto;
        }
    }
}
