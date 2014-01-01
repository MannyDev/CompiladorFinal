using System;
using ArbolGrafico;

namespace Compiladores
{
    /// <summary>
    /// Este evento se genera cuando termina el analisis sintáctico
    /// </summary>
    public class MostrarArbolEventArgs : EventArgs
    {
        private Nodo raizArbolSintactico;

        /// <summary>
        /// Obtiene la raíz del árbol sintáctico contruido por el analizador sintáctico
        /// </summary>
        public Nodo RaizArbolSintactico
        {
            get { return raizArbolSintactico; }
        }

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="raizArbolSintactico">La raíz del árbol sintáctico contruido por el analizador sintáctico</param>
        public MostrarArbolEventArgs(Nodo raizArbolSintactico)
        {
            this.raizArbolSintactico = raizArbolSintactico;
        }
    }
}