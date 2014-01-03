using System;
using System.Collections.Generic;

namespace Compiladores
{
    #region Tipos de datos y ambitos

    /// <summary>
    /// Tipos de ambitos de variables (local o global)
    /// </summary>
    public enum TipoAmbito
    {
        LOCAL, GLOBAL
    }

    /// <summary>
    /// Tipos de datos (int, float, string, void)
    /// </summary>
    public enum Tipos
    {
        INT, FLOAT, STRING, VOID, BOOL
    }

    #endregion

    //================================================================================

    #region ElementoTabla

    /// <summary>
    /// Representa un elemento de la tabla de simbolos
    /// </summary>
    public class ElementoTabla
    {
        protected String identificador;
        protected Tipos tipo;

        //Este lo usamos para guardar un nombre secundario de variable, en caso 
        //de que el nombre de la variable actual ya este ocupado por algúna otra 
        //variable en la tabla de simbolos
        private String identificadorSecundario;

        /// <summary>
        /// Obtiene o modifica el identificador o nombre de este elemento
        /// </summary>
        public String Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }

        /// <summary>
        /// Obtiene o modifica el tipo de dato (int, float, string o void )de este elemento
        /// </summary>
        public Tipos Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        /// <summary>
        /// Obtiene o modifica el identificador secundario de esta variable, el 
        /// cual es un nombre de identificador que no esta repetido en la tabla 
        /// de simbolos
        /// </summary>
        public String IdentificadorSecundario
        {
            get { return identificadorSecundario; }
            set { identificadorSecundario = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ElementoTabla()
            : this("", Tipos.VOID)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="identificador">El nombre de este elemento</param>
        /// <param name="tipo">El tipo de dato (int, float, string o void) de este elemento</param>
        public ElementoTabla(String identificador, Tipos tipo)
        {
            this.identificador = identificador;
            this.tipo = tipo;
            this.identificadorSecundario = identificador;
        }

        /// <summary>
        /// Indica si este elemento es una variable; regresa true en caso de ser cierto, falso en 
        /// caso contrario
        /// </summary>
        /// <returns></returns>
        public virtual bool EsVariable()
        {
            return false;
        }

        /// <summary>
        /// Indica si este elemento es una variable local; regresa true en caso de ser cierto, 
        /// falso en caso contrario
        /// <returns></returns>
        public virtual bool EsVarLocal()
        {
            return false;
        }

        /// <summary>
        /// Indica si este elemento es un parámetro; regresa true en caso de ser cierto, 
        /// falso en caso contrario
        /// <returns></returns>
        public virtual bool EsParametro()
        {
            return false;
        }

        /// <summary>
        /// Indica si este elemento es una función; regresa true en caso de ser cierto, falso en 
        /// caso contrario
        /// <returns></returns>
        public virtual bool EsFuncion()
        {
            return false;
        }
    }

    #endregion

    //================================================================================

    #region Variable

    /// <summary>
    /// Representa una variable (o parametro) de la tabla de simbolos
    /// </summary>
    public class Variable : ElementoTabla
    {
        private bool local;
        private bool parametro;
        private String funcionPadre;

        /// <summary>
        /// Obtiene el identificador de la funcion en la que se define la variable local
        /// </summary>
        public String FuncionPadre
        {
            get { return funcionPadre; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipo">El tipo de dato de la variable (int, float, string o void)</param>
        /// <param name="identificador">El nombre de la variable</param>
        /// <param name="ambito">El ambito de la variable (local o global)</param>
        public Variable(Tipos tipo, String identificador, TipoAmbito ambito, bool parametro)
            : this(tipo, identificador, ambito, null, parametro)
        {
    	}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipo">El tipo de dato de la variable (int, float, string o void)</param>
        /// <param name="identificador">El nombre de la variable</param>
        /// <param name="ambito">El ambito de la variable (local o global)</param>
        /// <param name="funcionPadre">El identificador de la funcion en la que se define la variable local</param>
        /// <param name="parametro">Indica si es un parámetro o no</param>
        public Variable(Tipos tipo, String identificador, TipoAmbito ambito, String funcionPadre, bool parametro)
        {
            this.tipo = tipo; //int, float, string
            this.identificador = identificador; //identificador
            this.local = ambito == TipoAmbito.LOCAL ? true : false; //Local o global
            this.funcionPadre = funcionPadre;
            this.parametro = parametro;
        }

        /// <summary>
        /// Indica si este elemento es una variable; regresa true en caso de ser cierto, falso en 
        /// caso contrario
        /// </summary>
        /// <returns></returns>
        public override bool EsVariable()
        {
            return true;
        }

        /// <summary>
        /// Indica si este elemento es una variable local; regresa true en caso de ser cierto, 
        /// falso en caso contrario
        /// </summary>
        /// <returns></returns>
        public override bool EsVarLocal()
        {
            return local;
        }

        /// <summary>
        /// Indica si este elemento es un parámetro; regresa true en caso de ser cierto, 
        /// falso en caso contrario
        /// <returns></returns>
        public override bool EsParametro()
        {
            return parametro;
        }
    }

    #endregion

    //================================================================================

    #region Funcion

    /// <summary>
    /// Representa una función de la tabla de simbolos
    /// </summary>
    public class Funcion : ElementoTabla
    {
        private Parametros parametros;

        /// <summary>
        /// Obtiene los parámetros de la función
        /// </summary>
        public Parametros Parametros
        {
            get { return parametros; }
        }

        /// <summary>
        /// Obtiene la representación en forma de string de los parámetros de la función
        /// </summary>
        public String ParametrosString
        {
            get
            {
                String parametrosString = "";
                if (parametros != null)
                {
                    foreach (NodoSemantico parametro in parametros.Hijos)
                    {
                        parametrosString += (parametro.Hijos[0].Texto + " "); //Tipo del parámetro
                        parametrosString += parametro.Hijos[1].Texto + ", "; //Identificador del parámetro
                    }
                    parametrosString = parametrosString.Substring(0, parametrosString.Length - 2);
                }
                return parametrosString;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipo">El tipo de dato que regresa la función (int, float, string o void)</param>
        /// <param name="identificador">El nombre de la función</param>
        /// <param name="parametros">Los parametros de la función</param>
        public Funcion(Tipos tipo, String identificador, Parametros parametros)
        {
            this.identificador = identificador;
            this.tipo = tipo;
            this.parametros = parametros;
        }

        /// <summary>
        /// Indica si este elemento es una función; regresa true en caso de ser cierto, falso en 
        /// caso contrario
        /// </summary>
        /// <returns></returns>
        public override bool EsFuncion()
        {
            return true;
        }
    }

    #endregion

    //================================================================================

    #region ElementoListaErrores

    /// <summary>
    /// Representa un error así como información relacionada a el
    /// </summary>
    public class ElementoListaErrores
    {
        private String error;
        private String funcionPadre;
        private int numeroLinea;

        /// <summary>
        /// El error
        /// </summary>
        public String Error
        {
            get { return error; }
        }

        /// <summary>
        /// La función donde apareció el error
        /// </summary>
        public String FuncionPadre
        {
            get { return funcionPadre; }
        }

        /// <summary>
        /// El número de línea en el que se genero el error
        /// </summary>
        public int NumeroLinea
        {
            get { return numeroLinea; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="error">El error</param>
        /// <param name="funcionPadre">La función donde apareció el error</param>
        /// <param name="numeroLinea">El número de línea en el que se genero el error</param>
        public ElementoListaErrores(String error, String funcionPadre, int numeroLinea)
        {
            this.error = error;
            this.funcionPadre = funcionPadre;
            this.numeroLinea = numeroLinea;
        }
    }

    #endregion

    //================================================================================

    #region TablaSimbolos

    /// <summary>
    /// Tabla de simbolos, utilizada para alamacenar las definiciones necesarias por 
    /// el analizador semántico
    /// </summary>
    public class TablaSimbolos
    {
        private List<ElementoTabla> tabla;
        private List<ElementoListaErrores> listaErrores;

        private Variable varLocal, varGlobal;
        private Funcion _funcion;

        /// <summary>
        /// Obtiene la tabla de elementos usada
        /// </summary>
        public List<ElementoTabla> Tabla
        {
            get { return tabla; }
        }

        /// <summary>
        /// Obtiene la lista de errores usada
        /// </summary>
        public List<ElementoListaErrores> ListaErrores
        {
            get { return listaErrores; }
        }

        public Variable VarLocal
        {
            get { return varLocal; }
        }

        public Variable VarGlobal
        {
            get { return varGlobal; }
        }

        public Funcion funcion
        {
            get { return _funcion; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listaErrores">La lista de errores usada por el analizador</param>
        public TablaSimbolos(List<ElementoListaErrores> listaErrores)
        {
            varLocal = varGlobal = null;
            _funcion = null;

            tabla = new List<ElementoTabla>();
            this.listaErrores = listaErrores;
        }

        /// <summary>
        /// Agrega un nuevo elemento en la tabla de simbolos
        /// </summary>
        /// <param name="elemento">El elemento a añadir</param>
        public void Agrega(ElementoTabla elemento)
        {
            try
            {
                //Buscamos para ver si le damos otro identificador secundario en caso de que 
                //ya haya algun otro elemento en la tabla con el mismo identificador secundario
                elemento.IdentificadorSecundario = ObtieneIdentificadorLibre(elemento.Identificador);
                /*if (elemento.EsFuncion())
                    System.Windows.Forms.MessageBox.Show("funcion \"" + elemento.Identificador + "\" y tiene el nombre de identificador secundario \"" + elemento.IdentificadorSecundario + "\"");
                else if (elemento.EsVarLocal())
                    System.Windows.Forms.MessageBox.Show("variable local \"" + elemento.Identificador + "\" y tiene el nombre de identificador secundario \"" + elemento.IdentificadorSecundario + "\"");
                else
                    System.Windows.Forms.MessageBox.Show("variable global \"" + elemento.Identificador + "\" y tiene el nombre de identificador secundario \"" + elemento.IdentificadorSecundario + "\"");*/
                tabla.Add(elemento);
            }
            catch(Exception)
            {
            }
        }

        /// <summary>
        /// Verifica si la variable global con el identificador dado se encuetra en la tabla 
        /// de simbolos; regresa true en caso de encontrarse, false en caso contrario
        /// </summary>
        /// <param name="identificador">El nombre de la variable a buscar</param>
        /// <returns></returns>
        public bool VariableGlobalDefinida(String identificador)
        {
            varLocal = varGlobal = null;
            _funcion = null;

            //Buscamos el identificador en la tabla
            var identificadoresEncontrados = tabla.FindAll(e => ((e.Identificador == identificador) && e.EsVariable() && !e.EsVarLocal()));

            //Guardamos la variable, si la encontramos
            if (identificadoresEncontrados.Count == 1)
                varGlobal = (Variable)identificadoresEncontrados[0];

            return identificadoresEncontrados.Count != 1 ? false : true;
        }

        /// <summary>
        /// Verifica si la variable local con el identificador dado , en la función especificada, 
        /// se encuentra en la tabla de simbolos; regresa true en caso de encontrarse, false 
        /// en caso contrario
        /// </summary>
        /// <param name="identificador">El nombre de la variable a buscar</param>
        /// <param name="identificadorFuncion">El nombre de la función en la que se encuentra la variable</param>>
        /// <returns></returns>
        public bool VariableLocalDefinida(String identificador, String identificadorFuncion)
        {
            varLocal = varGlobal = null;
            _funcion = null;

            //Buscamos el identificador en la tabla
            var identificadoresEncontrados = tabla.FindAll(e => ((e.Identificador == identificador) && e.EsVariable() && e.EsVarLocal() && ((Variable)e).FuncionPadre == identificadorFuncion));

            //Guardamos la variable, si la encontramos
            if (identificadoresEncontrados.Count == 1)
                varLocal = (Variable)identificadoresEncontrados[0];

            return identificadoresEncontrados.Count != 1 ? false : true;
        }

        /// <summary>
        /// Verifica si la función con el identificador dado se encuetra en la tabla de 
        /// simbolos; regresa true en caso de encontrarse, false en caso contrario
        /// </summary>
        /// <param name="identificador">El nombre de la función a buscar</param>
        /// <returns></returns>
        public bool FuncionDefinida(String identificador)
        {
            varLocal = varGlobal = null;
            _funcion = null;

            //Buscamos el identificador en la tabla
            var identificadoresEncontrados = tabla.FindAll(e => ((e.Identificador == identificador) && e.EsFuncion()));

            //Guardamos la función, si la encontramos
            if (identificadoresEncontrados.Count == 1)
                _funcion = (Funcion)identificadoresEncontrados[0];

            return identificadoresEncontrados.Count != 1 ? false : true;
        }

        /// <summary>
        /// Agrega una definición de variable a la tabla de simbolos
        /// </summary>
        /// <param name="defVar">La definición de variable a agregar</param>
        public void Agrega(DefVar defVar)
        {
            Variable variable = new Variable(defVar.TipoDeDato, defVar.Identificador, NodoSemantico.TipoDeAmbito, NodoSemantico.FuncionActual, defVar.Parametro);

            if (variable.EsVarLocal())
            {
                if (VariableLocalDefinida(variable.Identificador, variable.FuncionPadre))
                    AgregarError("La variable local " + variable.Identificador + " ya fue definida en la función " + variable.FuncionPadre, defVar.NumeroLinea);
                else
                    Agrega(variable);
            }
            else
            {
                if (VariableGlobalDefinida(variable.Identificador))
                    AgregarError("La variable global " + variable.Identificador + " ya fue definida", defVar.NumeroLinea);
                else if (FuncionDefinida(variable.Identificador))
                    AgregarError("La variable global " + variable.Identificador + " no puede ser definida porque ya existe una función con ese nombre", defVar.NumeroLinea);
                else
                    Agrega(variable);
            }
        }

        /// <summary>
        /// Agrega una definición de función a la tabla de simbolos
        /// </summary>
        /// <param name="defFunc">La definición de función a agregar</param>
        public void Agrega(DefFunc defFunc)
        {
            Funcion funcion = new Funcion(defFunc.TipoDeDato, NodoSemantico.FuncionActual, defFunc.ObtieneParametros());

            if (FuncionDefinida(funcion.Identificador))
                AgregarError("La función " + funcion.Identificador + " ya fue definida", defFunc.NumeroLinea);
            else if (VariableGlobalDefinida(funcion.Identificador))
                AgregarError("La función " + funcion.Identificador + " no puede ser definida porque ya existe una variable global con ese nombre", defFunc.NumeroLinea);
            else
                Agrega(funcion);
        }

        /// <summary>
        /// Limpia todos los datos que utiliza la tabla de simbolos
        /// </summary>
        public void Limpiar()
        {
            tabla.Clear();
            listaErrores.Clear();
            varLocal = varGlobal = null;
            _funcion = null;
        }

        /// <summary>
        /// Agrega un error a la lista de errores
        /// </summary>
        /// <param name="error"></param>
        /// <param name="numeroLinea"></param>
        public void AgregarError(String error, int numeroLinea)
        {
            listaErrores.Add(new ElementoListaErrores(error, NodoSemantico.FuncionActual, numeroLinea));
        }

        /// <summary>
        /// Revisa si el nombre del identificador dado ya lo tiene algún simbolo en la 
        /// tabla de simbolos, si esto es cierto entonces genera un nombre disponible (no 
        /// ocupado por ningún otro simbolo en la tabla de simbolos) y lo devuelve
        /// </summary>
        /// <returns></returns>
        private String ObtieneIdentificadorLibre(String identificador)
        {
            String identificadorLibre = identificador;
            //Buscamos si ya esta este identificador en la tabla de simbolos
            if ((tabla.FindAll(elemento => elemento.IdentificadorSecundario == identificador)).Count > 0)
            {
                int numeroLibre = 1;
                //Nos ciclamos buscando un nombre disponible
                do
                {
                    numeroLibre++;
                } while ((tabla.FindAll(elemento => elemento.IdentificadorSecundario == identificador + numeroLibre.ToString())).Count > 0);

                //Cuando hayamos un nombre disponible lo guardamos como el nuevo
                //identificadorSecundario
                identificadorLibre += numeroLibre.ToString();
            }
            return identificadorLibre;
        }

        /// <summary>
        /// Busca y devuelve el identificador secundario de la variable global dada
        /// </summary>
        /// <param name="identificador">El identificador de la variable global a buscar</param>
        /// <returns></returns>
        public String ObtieneIdentificadorSecundarioVariable(String identificador)
        {
            varGlobal = (Variable)tabla.Find(elemento => elemento.EsVariable() && !elemento.EsVarLocal() && elemento.Identificador == identificador);

            return varGlobal.IdentificadorSecundario;
        }

        /// <summary>
        /// Busca y devuelve el identificador secundario de la variable local dada
        /// </summary>
        /// <param name="identificador">El identificador de la variable local a buscar</param>
        /// <param name="funcionPadre">El identificador de la función padre donde se encuentra la variable local a buscar</param>
        /// <returns></returns>
        public String ObtieneIdentificadorSecundarioVariable(String identificador, String funcionPadre)
        {
            varLocal = (Variable)tabla.Find(elemento => elemento.EsVariable() && elemento.EsVarLocal() && (elemento as Variable).FuncionPadre == funcionPadre && elemento.Identificador == identificador);

            return varLocal.IdentificadorSecundario;
        }

        /// <summary>
        /// Busca y devuelve el identificador secundario de la función dada
        /// </summary>
        /// <param name="identificador">El identificador de la función a buscar</param>
        /// <returns></returns>
        public String ObtieneIdentificadorSecundarioFuncion(String identificador)
        {
            _funcion = (Funcion)tabla.Find(elemento => elemento.EsFuncion() && elemento.Identificador == identificador);

            return _funcion.IdentificadorSecundario;
        }
    }

    #endregion

}
