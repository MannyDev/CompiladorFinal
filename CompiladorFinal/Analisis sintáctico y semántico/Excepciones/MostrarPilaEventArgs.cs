using System;
using System.Collections.Generic;

namespace Compiladores
{
    /// <summary>
    /// Este evento se genera cada que el analizador sintáctico necesita mostrar sus datos
    /// </summary>
    public class MostrarPilaEventArgs : EventArgs
    {
        private ElementoPila[] pila;
        private String elementosEnPila;
        private String simbolo;
        private int accion;

        /// <summary>
        /// Obtiene la pila de elementos en el analizador sintáctico
        /// </summary>
        public ElementoPila[] Pila
        {
            get { return pila; }
        }

        /// <summary>
        /// Obtiene todos los elementos de la pila concatenados en una cadena
        /// </summary>
        public String ElementosEnPila
        {
            get { return elementosEnPila; }
        }

        /// <summary>
        /// Obtiene el simbolo actualmente leído en el analizador sintáctico
        /// </summary>
        public String Simbolo
        {
            get { return simbolo; }
        }

        /// <summary>
        /// Obtiene la acción actualmente llevada a cabo por el analizador sintáctico
        /// </summary>
        public int Accion
        {
            get { return accion; }
        }

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pila">La pila de elementos en el analizador sintáctico</param>
        /// <param name="simbolo">El simbolo actualmente leído en el analizador sintáctico</param>
        /// <param name="accion">La acción actualmente llevada a cabo por el analizador sintáctico</param>
        public MostrarPilaEventArgs(Stack<ElementoPila> pila, String simbolo, int accion)
        {
            this.pila = pila.ToArray();

            //Guardamos todos los elementos de la pila concatenados en una sóla cadena
            String elementosEnPila = "";
            for (int i = this.pila.Length - 1; i >= 0; i--)
                elementosEnPila += this.pila[i].Elemento;
            this.elementosEnPila = elementosEnPila;

            this.simbolo = simbolo;
            this.accion = accion;
        }
    }
}
