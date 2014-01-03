using System;
using ArbolGrafico;

namespace Compiladores
{
    /// <summary>
    /// Clase base para los elementos de la pila
    /// </summary>
    public class ElementoPila
    {
        protected int id;
        protected String elemento;
        protected NodoSemantico nodo;

        public virtual int Id
        {
            get { return id; }
        }
        public virtual String Elemento
        {
            get { return elemento; }
        }
        public virtual NodoSemantico Nodo
        {
            get { return nodo; }
            set { nodo = value; }
        }

        public virtual bool EsEstado()
        {
            return false;
        }

        public virtual bool EsTerminal()
        {
            return false;
        }

        public virtual bool EsNoTerminal()
        {
            return false;
        }
    }

    //================================================================================

    /// <summary>
    /// Un terminal (simbolo)
    /// </summary>
    class Terminal : ElementoPila
    {
        /// <summary>
        /// Obtiene el valor númerico que representa el terminal
        /// </summary>
        override public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Obtiene el terminal
        /// </summary>
        override public String Elemento
        {
            get { return elemento; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">El valor númerico que representa el terminal</param>
        public Terminal(int id)
        {
            this.id = id;
            elemento = "";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">El valor númerico que representa el terminal</param>
        /// <param name="elemento">El terminal</param>
        public Terminal(int id, String elemento)
        {
            this.id = id;
            this.elemento = elemento;
        }

        /// <summary>
        /// Determina si el objeto es un terminal, regresa true en caso de ser cierto
        /// </summary>
        /// <returns></returns>
        override public bool EsTerminal()
        {
            return true;
        }
    }

    //================================================================================

    /// <summary>
    /// Un no terminal (la E o regla)
    /// </summary>
    class NoTerminal : ElementoPila
    {
        /// <summary>
        /// Obtiene el valor númerico que representa el no terminal
        /// </summary>
        override public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Obtiene la regla que representa el no terminal
        /// </summary>
        override public String Elemento
        {
            get { return elemento; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">El valor númerico que representa el no terminal</param>
        /// <param name="elemento">La regla que representa el no terminal</param>
        public NoTerminal(int id, String elemento)
        {
            this.id = id;
            this.elemento = elemento;
        }

        /// <summary>
        /// Determina si el objeto es un terminal, regresa true en caso de ser cierto
        /// </summary>
        /// <returns></returns>
        override public bool EsNoTerminal()
        {
            return true;
        }
    }

    //================================================================================

    /// <summary>
    /// Un estado (el número)
    /// </summary>
    class Estado : ElementoPila
    {
        /// <summary>
        /// Obtiene el valor númerico del estado
        /// </summary>
        override public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Obtiene el estado en forma de cadena
        /// </summary>
        override public String Elemento
        {
            get { return id.ToString(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">El valor númerico del estado</param>
        public Estado(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Determina si el objeto es un terminal, regresa true en caso de ser cierto
        /// </summary>
        /// <returns></returns>
        override public bool EsEstado()
        {
            return true;
        }
    }
}
