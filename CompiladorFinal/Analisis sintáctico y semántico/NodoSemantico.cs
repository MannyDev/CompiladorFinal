using System;
using ArbolGrafico;

namespace Compiladores
{
    /// <summary>
    /// Representa un nodo que conoce información semántica sobre su contenido
    /// </summary>
    public class NodoSemantico : Nodo
    {
        #region Variables y propiedades

        static private TablaSimbolos tablaDeSimbolos;
        static private TipoAmbito tipoDeAmbito = TipoAmbito.GLOBAL;
        static private String funcionActual = "";
        static private bool definicionVariables = false;

        private Tipos tipoDeDato;
        private int numeroLinea = 1;
        private String codigoEnsamblador;

        /// <summary>
        /// La tabla de simbolos que usan los nodos
        /// </summary>
        static public TablaSimbolos TablaDeSimbolos
        {
            get { return tablaDeSimbolos; }
            set { tablaDeSimbolos = value; }
        }

        /// <summary>
        /// Obtiene o modifica el ambito (local o global) en el que actualmente nos encontramos
        /// </summary>
        static public TipoAmbito TipoDeAmbito
        {
            get { return tipoDeAmbito; }
            set { tipoDeAmbito = value; }
        }

        /// <summary>
        /// Obtiene o modifica la funcion en la que actualmente nos encontramos
        /// </summary>
        static public String FuncionActual
        {
            get { return funcionActual; }
            set { funcionActual = value; }
        }

        /// <summary>
        /// Obtiene o modifica un valor que indica si se estan definiendo variables
        /// </summary>
        static public bool DefinicionVariables
        {
            get { return definicionVariables; }
            set { definicionVariables = value; }
        }

        /// <summary>
        /// Obtiene o modifica el tipo de dato (int, float, string, void) del nodo
        /// </summary>
        public Tipos TipoDeDato
        {
            get { return tipoDeDato; }
            set { tipoDeDato = value; }
        }

        /// <summary>
        /// Obtiene o modifica el número de línea en el cual se instanció este nodo
        /// </summary>
        public int NumeroLinea
        {
            get { return numeroLinea; }
            set { numeroLinea = value; }
        }

        /// <summary>
        /// Obtiene o modifica el código ensamblador de este nodo
        /// </summary>
        public String CodigoEnsamblador
        {
            get { return codigoEnsamblador; }
            set { codigoEnsamblador = value; }
        }

        #endregion

        //================================================================================

        #region Constructores

        /// <summary>
        /// Constructor
        /// </summary>
        public NodoSemantico()
            : this("")
        {
        }

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texto">El texto a mostrar en el nodo</param>
        public NodoSemantico(String texto)
            : base(texto)
        {
            tipoDeDato = Tipos.VOID;
            numeroLinea = AnalizadorLexico.NumeroLineaUltimoSimbolo;
            codigoEnsamblador = "";
        }

        #endregion

        //================================================================================

        /// <summary>
        /// Valida el tipo de dato (int, float, string o void) de este nodo, y de todos sus 
        /// nodos hijos
        /// </summary>
        virtual public void ValidaTiposDatos()
        {
            tipoDeDato = Tipos.VOID;
            foreach (NodoSemantico nodo in hijos)
                nodo.ValidaTiposDatos();
        }

        //================================================================================

        /// <summary>
        /// Genera el código ensamblador de este nodo
        /// </summary>
        /// <returns></returns>
        virtual public void GeneraCodigoEnsamblador()
        {
            codigoEnsamblador = "";
            foreach (NodoSemantico nodo in hijos)
                nodo.GeneraCodigoEnsamblador();
        }
    }
}
