using System;
using System.Collections.Generic;

namespace Compiladores
{
    /// <summary>
    /// Este evento se genera cada que el analizador semántico necesita mostrar los errores 
    /// encontrados en el análisis
    /// </summary>
    public class MostrarErroresEventArgs : EventArgs
    {
        private List<ElementoListaErrores> errores;

        /// <summary>
        /// Obtiene la lista de errores encontrados por el analizador semántico
        /// </summary>
        public List<ElementoListaErrores> Errores
        {
            get { return errores; }
        }

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errores">La lista de errores encontrados por el analizador</param>
        public MostrarErroresEventArgs(List<ElementoListaErrores> errores)
        {
            this.errores = errores;
        }
    }
}
