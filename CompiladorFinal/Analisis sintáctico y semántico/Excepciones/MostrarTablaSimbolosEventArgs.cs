using System;
using System.Collections.Generic;

namespace Compiladores
{
    /// <summary>
    /// Este evento se genera cada que el analizador semántico necesita mostrar la tabla 
    /// de simbolos
    /// </summary>
    public class MostrarTablaSimbolosEventArgs : EventArgs
    {
        private List<ElementoTabla> elementos;
        private int cantFunciones, cantVariables;

        /// <summary>
        /// Obtiene la lista de elementos en la tabla semántica
        /// </summary>
        public List<ElementoTabla> Elementos
        {
            get { return elementos; }
        }

        /// <summary>
        /// Obtiene la cantidad de elementos funcion, en la tabla
        /// </summary>
        public int CantFunciones
        {
            get { return cantFunciones; }
        }

        /// <summary>
        /// Obtiene la cantidad de elementos variable, en la tabla
        /// </summary>
        public int CantVariables
        {
            get { return cantVariables; }
        }

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="elementos">La lista de elementos de la tabla</param>
        public MostrarTablaSimbolosEventArgs(List<ElementoTabla> elementos)
        {
            this.elementos = elementos;
            cantVariables = cantFunciones = 0;
            foreach (ElementoTabla elemento in elementos)
            {
                if (elemento.EsVariable())
                    cantVariables++;
                else
                    cantFunciones++;
            }
        }
    }
}
