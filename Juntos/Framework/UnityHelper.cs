namespace Framework
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    /// <summary>
    /// Classe de auxílio para o uso do Unity.
    /// </summary>
    internal class UnityHelper
    {
        /// <summary>
        /// Constante para configuração do nome da seção.
        /// </summary>
        private const string SECTION = "unity";

        /// <summary>
        /// Constante para configuração do nome do container.
        /// </summary>
        private const string CONTAINER = "container";

        /// <summary>
        /// Definição do container.
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Definição da seção.
        /// </summary>
        private readonly UnityConfigurationSection _section;

        /// <summary>
        /// Instância para singleton.
        /// </summary>
        private static UnityHelper _instancia;

        /// <summary>
        /// Construtor do UnityHelper.
        /// </summary>
        private UnityHelper()
        {
            this._container = new UnityContainer();
            this._section = (UnityConfigurationSection)ConfigurationManager.GetSection(SECTION);
            this._section.Configure(this._container, CONTAINER);
        }

        /// <summary>
        /// Retorna a instância criada do UnityHelper.
        /// </summary>
        public static UnityHelper Instancia
        {
            get
            {
                _instancia = _instancia ?? new UnityHelper();
                return _instancia;
            }
        }

        /// <summary>
        /// Cria uma instância do objeto concreto mapeado para a interface fornecida no parâmetro.
        /// </summary>
        /// <param name="tipoInterface">Tipo da interface.</param>
        /// <param name="parametros">Parâmetros de construção do objeto.</param>
        /// <returns>Retorna um objeto instânciado que implemente a interface definida.</returns>
        public object Resolve(Type tipoInterface, params object[] parametros)
        {
            if (parametros.Length == 0)
            {
                return this._container.Resolve(tipoInterface);
            }

            var tipo = this.RetornarTipoMapeado(tipoInterface);
            var construtor = tipo.GetConstructorByParams(parametros);
            var parameterOverrides = this.RetornaMapeamentoDeParametros(construtor, parametros);
            this._container.RegisterType(tipoInterface, tipo, new InjectionConstructor(parametros));
            return Convert.ChangeType(this._container.Resolve(tipo, parameterOverrides), tipoInterface);
        }

        /// <summary>
        /// Identifica e mapeia os parâmetros do construtor.
        /// </summary>
        /// <param name="construtor">Construtor do objeto.</param>
        /// <param name="parametros">Parâmetros de construção.</param>
        /// <returns>Retorna o mapeamento dos parâmetros do construtor.</returns>
        private ParameterOverrides RetornaMapeamentoDeParametros(ConstructorInfo construtor, IList<object> parametros)
        {
            var parametrosOverrides = new ParameterOverrides();

            var informacoesDosParametros = construtor.GetParameters();
            for (var i = 0; i < informacoesDosParametros.Length; i++)
            {
                parametrosOverrides.Add(informacoesDosParametros[i].Name, parametros[i]);
            }

            return parametrosOverrides;
        }

        /// <summary>
        /// Retorna o tipo mapeado para a interface.
        /// </summary>
        /// <param name="tipoInterface">Tipo da interface.</param>
        /// <returns>Retorna o tipo concreto para aquela interface.</returns>
        private Type RetornarTipoMapeado(Type tipoInterface)
        {
            var registro = this._container.Registrations.FirstOrDefault(r => r.RegisteredType == tipoInterface);

            if (registro == null)
            {
                throw new Exception(
                    string.Format("Interface '{0}' não foi mapeada no arquivo de configuração do Unity, verifique!",
                                  tipoInterface.Name));
            }

            return registro.MappedToType;
        }
    }
}
