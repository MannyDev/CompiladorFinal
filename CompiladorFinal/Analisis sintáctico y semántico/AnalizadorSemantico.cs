using System;
using System.Collections.Generic;
using ArbolGrafico;

namespace Compiladores
{
    /// <summary>
    /// Permite generar un análisis semántico sobre un árbol sintáctico dado
    /// </summary>
    public class AnalizadorSemantico
    {
        #region Variables y propiedades

        private TablaSimbolos tablaDeSimbolos;
        private NodoSemantico raizArbolSemantico;
        private List<ElementoListaErrores> listaErrores;

        /// <summary>
        /// Obtiene o modifica el nodo raíz del árbol sintáctico usado en el análisis
        /// </summary>
        public NodoSemantico RaizArbolSintactico
        {
            get { return raizArbolSemantico; }
            set { raizArbolSemantico = value; }
        }

        /// <summary>
        /// Obtiene un valor que indica si el análisis fue correcto, o si hay errores
        /// </summary>
        public bool Correcto
        {
            get { return tablaDeSimbolos.ListaErrores.Count == 0 ? true : false; }
        }

        #endregion

        #region Eventos

        //Delegado usado para guardar el evento para mostrar la tabla de simbolos
        public delegate void MuestraTablaSimbolosEventArgs(object sender, MostrarTablaSimbolosEventArgs e);

        /// <summary>
        /// Este evento se dispara cuando el analizador necesita mostrar los datos de la 
        /// tabla de simbolos
        /// </summary>
        public event MuestraTablaSimbolosEventArgs MostrarTablaSimbolos;

        //Delegado usado para guardar el evento para mostrar la lista de errores
        public delegate void MuestraErroresEventArgs(object sender, MostrarErroresEventArgs e);
        
        /// <summary>
        /// Este evento se dispara cuando el analizador necesita mostrar la lista de errores
        /// </summary>
        public event MuestraErroresEventArgs MostrarErrores;

        #endregion

        //================================================================================

        #region Constructores

        /// <summary>
        /// Constructor
        /// </summary>
        public AnalizadorSemantico()
            : this(null)
        {
        }

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="raizArbolSintactico">El nodo raíz del árbol sintáctico sobre el 
        /// cual aplicar el análisis semántico</param>
        public AnalizadorSemantico(NodoSemantico raizArbolSintactico)
        {
            listaErrores = new List<ElementoListaErrores>();
            raizArbolSemantico = raizArbolSintactico;
            NodoSemantico.TablaDeSimbolos = tablaDeSimbolos = new TablaSimbolos(listaErrores);
        }

        #endregion

        //================================================================================

        /// <summary>
        /// Realiza todo el análisis semántico
        /// </summary>
        public void Analiza()
        {
            if (raizArbolSemantico == null)
                return;

            raizArbolSemantico.ValidaTiposDatos();
            MuestraTablaSimbolos();
            MuestraErrores();
        }

        //================================================================================

        #region Despliegue de datos

        /// <summary>
        /// Dispara el evento para mostrar la tabla de simbolos
        /// </summary>
        private void MuestraTablaSimbolos()
        {
            //Disparamos el evento para mostrar la tabla de simbolos, sólo si ya se suscribierón a el
            if (MostrarTablaSimbolos != null)
            {
                MostrarTablaSimbolosEventArgs datosEvento = new MostrarTablaSimbolosEventArgs(tablaDeSimbolos.Tabla);
                MostrarTablaSimbolos(this, datosEvento);
            }
        }

        //================================================================================

        /// <summary>
        /// Dispara el evento para mostrar la lista de errores
        /// </summary>
        private void MuestraErrores()
        {
            //Disparamos el evento para mostrar la lista de errores, sólo si ya se suscribierón a el
            if (MostrarErrores != null)
            {
                MostrarErroresEventArgs datosEvento = new MostrarErroresEventArgs(listaErrores);
                MostrarErrores(this, datosEvento);
            }
        }

        #endregion

        //================================================================================

        /// <summary>
        /// Limpia todos los elementos que utiliza el analizador semántico
        /// </summary>
        public void Limpiar()
        {
            listaErrores.Clear();
            tablaDeSimbolos.Limpiar();
            raizArbolSemantico = null;
        }
    }
}