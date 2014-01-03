using System;
using System.Collections.Generic;

namespace Compiladores
{
    public struct Tipo
    {
        static public Tipos ObtieneTipo(String tipo)
        {
            switch (tipo)
            {
                case "int":
                    return Tipos.INT;
                case "float":
                    return Tipos.FLOAT;
                case "string":
                    return Tipos.STRING;
                case "bool":
                    return Tipos.BOOL;
                default:
                    return Tipos.VOID;
            }
        }
    }

    //================================================================================

    //Todas estas clases son para no retacar el switch del análizador, y son usadas 
    //por el analizador semántico

    #region Nodos simples para variables

    /// <summary>
    /// Clase base para los nodos del árbol que representan variables simples
    /// </summary>
    public class Termino : NodoSemantico
    {
        public Termino(Stack<ElementoPila> pila)
            : base()
        {
            pila.Pop();
            texto = pila.Pop().Elemento;
        }

        public override string ToString()
        {
            return texto;
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa un identificador, usado en la regla 36, 
    /// [Termino] ::= identificador
    /// </summary>
    public class Identificador : Termino
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pila">La pila de la cual toma el identificador que representa</param>
        public Identificador(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            TipoDeDato = Tipos.VOID;
            if (!NodoSemantico.DefinicionVariables)
            {
                //Buscamos si este identificador ya fue definido en la tabla de simbolos
                if (NodoSemantico.TablaDeSimbolos.VariableLocalDefinida(texto, NodoSemantico.FuncionActual) || NodoSemantico.TablaDeSimbolos.VariableGlobalDefinida(texto))
                {
                    TipoDeDato = NodoSemantico.TablaDeSimbolos.VarLocal == null ? NodoSemantico.TablaDeSimbolos.VarGlobal.Tipo : NodoSemantico.TablaDeSimbolos.VarLocal.Tipo;
                }
                else
                    NodoSemantico.TablaDeSimbolos.AgregarError("La variable " + texto + " es usada pero nunca es definida", this.NumeroLinea);
            }
        }

        public override void GeneraCodigoEnsamblador()
        {
            //CodigoEnsamblador = identificadorSecundario;
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa un entero, usado en la regla 37, 
    /// [Termino] ::= entero
    /// </summary>
    public class Entero : Termino
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pila">La pila de la cual toma el entero que representa</param>
        public Entero(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            TipoDeDato = Tipos.INT;
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa un real, usado en la regla 38, 
    /// [Termino] ::= real
    /// </summary>
    public class Real : Termino
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pila">La pila de la cual toma el real que representa</param>
        public Real(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            TipoDeDato = Tipos.FLOAT;
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una cadena, usado en la regla 39, 
    /// [Termino] ::= cadena
    /// </summary>
    public class Cadena : Termino
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pila">La pila de la cual toma la cadena que representa</param>
        public Cadena(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            TipoDeDato = Tipos.STRING;
        }
    }

    #endregion

    //================================================================================

    #region Nodos de definición de variables

    /// <summary>
    /// Nodo del árbol que representa una variable; esta contiene un tipo de dato y un 
    /// identificador
    /// </summary>
    public class DefVar : NodoSemantico
    {
        protected String identificador;
        protected bool parametro;

        /// <summary>
        /// Obtiene o modifica el identificador de la variable
        /// </summary>
        public String Identificador
        {
            get { return identificador; }
        }

        //public String 

        /// <summary>
        /// Indica si es un parámetro o no
        /// </summary>
        public bool Parametro
        {
            get { return parametro; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipo">El tipo de dato de la variable (int, float, string o void)</param>
        /// <param name="identificador">El nombre de la variable</param>
        /// <param name="parametro">Indica si es un parámetro</param>
        public DefVar(String tipo, String identificador, bool parametro)
            : base("<DefVar>")
        {
            TipoDeDato = Tipo.ObtieneTipo(tipo);
            this.identificador = identificador;
            this.parametro = parametro;
            AñadirHijo(new NodoSemantico(tipo));
            AñadirHijo(new NodoSemantico(identificador));
        }

        /// <summary>
        /// Valida el tipo de dato (int, float, string o void) de este nodo, y de todos sus 
        /// nodos hijos
        /// </summary>
        public override void ValidaTiposDatos()
        {
            NodoSemantico.TablaDeSimbolos.Agrega(this);
        }

        /// <summary>
        /// Genera el código ensamblador de este nodo
        /// </summary>
        /// <returns></returns>
        public override void GeneraCodigoEnsamblador()
        {
            base.GeneraCodigoEnsamblador();

            //Si es variable global
            if (NodoSemantico.TipoDeAmbito == TipoAmbito.GLOBAL)
            {
                CodigoEnsamblador = NodoSemantico.TablaDeSimbolos.ObtieneIdentificadorSecundarioVariable(identificador);
                switch(TipoDeDato)
                {
                    case Tipos.INT: case Tipos.FLOAT:
                        CodigoEnsamblador += " dw ?";
                        break;
                    default:
                        CodigoEnsamblador += " db ?";
                        break;
                }
            }
            else
            {
                CodigoEnsamblador = "local " + NodoSemantico.TablaDeSimbolos.ObtieneIdentificadorSecundarioVariable(identificador, NodoSemantico.FuncionActual);
                switch (TipoDeDato)
                {
                    case Tipos.INT: case Tipos.FLOAT:
                        CodigoEnsamblador += ": dw";
                        break;
                    default:
                        CodigoEnsamblador += "[128]: byte";
                        break;
                }
            }
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una lista de definiciones de variables, usado en 
    /// la regla 6, [DefVar] ::= tipo identificador [ListaVar] ;
    /// </summary>
    public class Variables : NodoSemantico
    {
        public Variables(Stack<ElementoPila> pila)
            : base("<ListaVar>")
        {
            pila.Pop();
            pila.Pop();
            pila.Pop();
            List<NodoSemantico> listaVariables = new List<NodoSemantico>();
            NodoSemantico n = pila.Pop().Nodo;
            foreach (NodoSemantico nodo in n.Hijos)
                listaVariables.Add(nodo);
            pila.Pop();
            String identificador = pila.Pop().Elemento;
            pila.Pop();
            String tipo = pila.Pop().Elemento;

            DefVar variable = new DefVar(tipo, identificador, false);
            variable.NumeroLinea = NumeroLinea = n.NumeroLinea;

            AñadirHijo(variable);

            //Añadimos los demás parametros de la lista, y de esta manera nos 
            //convertimos en la nueva lista de definiciones de variables
            for (int i = 0; i < listaVariables.Count; i++)
            {
                DefVar defVar = new DefVar(tipo, ((DefVar)listaVariables[i]).Identificador, false);
                AñadirHijo(defVar);
            }
        }

        public override void ValidaTiposDatos()
        {
            NodoSemantico.DefinicionVariables = true;
            base.ValidaTiposDatos();
            NodoSemantico.DefinicionVariables = false;
        }

        public override void GeneraCodigoEnsamblador()
        {
            CodigoEnsamblador = "";
            foreach (DefVar defVar in hijos)
            {
                defVar.GeneraCodigoEnsamblador();
                CodigoEnsamblador += defVar.CodigoEnsamblador + Environment.NewLine;
            }
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una lista de definiciones de variables, usado en
    /// la regla 8, [ListaVar] ::= , identificador [ListaVar]
    /// </summary>
    public class Variables2 : NodoSemantico
    {
        public Variables2(Stack<ElementoPila> pila)
            : base("<ListaVar>")
        {
            pila.Pop();
            List<NodoSemantico> listaVariables = new List<NodoSemantico>();
            foreach (NodoSemantico nodo in pila.Pop().Nodo.Hijos)
                listaVariables.Add(nodo);
            pila.Pop();
            String identificador = pila.Pop().Elemento;
            pila.Pop();
            pila.Pop();

            DefVar variable = new DefVar("", identificador, false);
            variable.NumeroLinea = NumeroLinea;

            AñadirHijo(variable);

            //Añadimos los demás parametros de la lista, y de esta manera nos 
            //convertimos en la nueva lista de definiciones de variables
            for (int i = listaVariables.Count - 1; i >= 0; i--)
                AñadirHijo(listaVariables[i]);
        }
    }

    #endregion

    //================================================================================

    #region Nodos del tipo Expresion

    public class ExpresionSimple : NodoSemantico
    {
        private NodoSemantico nodo;

        public ExpresionSimple(Stack<ElementoPila> pila)
            : base("<Expresion>")
        {
            pila.Pop();
            nodo = pila.Pop().Nodo;
            AñadirHijo(nodo);

            NumeroLinea = nodo.NumeroLinea;
        }

        public override void ValidaTiposDatos()
        {
            nodo.ValidaTiposDatos();
            TipoDeDato = nodo.TipoDeDato;
        }

        public override string ToString()
        {
            return nodo.ToString();
        }
    }

    /// <summary>
    /// Clase base para los nodos del tipo expresión de operadores binarios
    /// </summary>
    public class ExpresionOperadoresBinarios : NodoSemantico
    {
        protected NodoSemantico expresion;
        protected NodoSemantico expresionDerecha;
        protected NodoSemantico expresionIzquierda;

        public ExpresionOperadoresBinarios(Stack<ElementoPila> pila)
            : base("<Expresion>")
        {
            pila.Pop();
            expresionDerecha = pila.Pop().Nodo;
            pila.Pop();
            String operador = pila.Pop().Elemento;
            pila.Pop();
            expresionIzquierda = pila.Pop().Nodo;

            expresion = new NodoSemantico(operador);
            expresion.AñadirHijo(expresionIzquierda);
            expresion.AñadirHijo(expresionDerecha);

            AñadirHijo(expresion);

            NumeroLinea = expresionIzquierda.NumeroLinea;
        }

        /// <summary>
        /// Valida el tipo de dato (int, float, string o void) de este nodo, y de todos sus 
        /// nodos hijos
        /// </summary>
        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            Tipos tipoIzquierdo = expresionIzquierda.TipoDeDato;
            Tipos tipoDerecho = expresionDerecha.TipoDeDato;
            String operandoIzquierdo = expresionIzquierda.ToString();
            String operandoDerecho = expresionDerecha.ToString();

            if (tipoIzquierdo == tipoDerecho && tipoIzquierdo != Tipos.VOID)
            {
                TipoDeDato = tipoDerecho;
            }
            else
                NodoSemantico.TablaDeSimbolos.AgregarError("No se puede formar la expresión " + ToString() + ", ya que la expresión izquierda " + operandoIzquierdo + " es del tipo " + tipoIzquierdo.ToString().ToLower() + ", y la expresión derecha " + operandoDerecho + " es del tipo " + tipoDerecho.ToString().ToLower(), this.NumeroLinea);
        }

        public override string ToString()
        {
            return expresionIzquierda.ToString() + " " + expresion.Texto + " " + expresionDerecha.ToString() + " ";
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una suma/resta, usado en la regla 47, 
    /// [Expresion] ::= [Expresion] opSuma [Expresion]
    /// </summary>
    public class OperadorAdicion : ExpresionOperadoresBinarios
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pila">La pila de la cual toma los operandos de la operación, así como la operación que representa</param>
        public OperadorAdicion(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            //Los operandos no pueden ser string ni bool (void se evalua en la clase padre)
            if (TipoDeDato == Tipos.STRING || TipoDeDato == Tipos.BOOL)
            {
                NodoSemantico.TablaDeSimbolos.AgregarError("No puede aplicarse el operador de suma " + expresion.Texto + ", en la expresion " + ToString() + ", a operandos del tipo " + TipoDeDato.ToString().ToLower(), NumeroLinea);
                TipoDeDato = Tipos.VOID;
            }
        }

        public override string ToString()
        {
            return expresionIzquierda.ToString() + " " + expresion.Texto + " " + expresionDerecha.ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una multiplicación/división, usado en la regla 46,
    /// [Expresion] ::= [Expresion] opMul [Expresion]
    /// </summary>
    public class OperadorMultiplicacion :  ExpresionOperadoresBinarios
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pila">La pila de la cual toma los operandos de la operación, así como la operación que representa</param>
        public OperadorMultiplicacion(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            //Los operandos no pueden ser string ni bool (void se evalua en la clase padre)
            if (TipoDeDato == Tipos.STRING || TipoDeDato == Tipos.BOOL)
            {
                NodoSemantico.TablaDeSimbolos.AgregarError("No puede aplicarse el operador de multiplicación " + expresion.Texto + ", en la expresion " + ToString() + ", a operandos del tipo " + TipoDeDato.ToString().ToLower(), NumeroLinea);
                TipoDeDato = Tipos.VOID;
            }
        }

        public override string ToString()
        {
            return expresionIzquierda.ToString() + " " + expresion.Texto + " " + expresionDerecha.ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa un operador relacional (<, <=, >, >=), usado en la regla 48, 
    /// [Expresion] ::= [Expresion] opRelac [Expresion]
    /// </summary>
    public class OperadorRelacional : ExpresionOperadoresBinarios
    {
        public OperadorRelacional(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();
            
            //Si la expresión derecha e izquierda tienen el mismo tipo de dato, y no son 
            //ni string ni bool (void se evalua en la clase padre)
            if (TipoDeDato == Tipos.STRING || TipoDeDato == Tipos.BOOL)
            {
                NodoSemantico.TablaDeSimbolos.AgregarError("No puede aplicarse el operador relacional " + expresion.Texto + ", en la expresion " + ToString() + ", a operandos del tipo " + TipoDeDato.ToString().ToLower(), NumeroLinea);
                TipoDeDato = Tipos.VOID;
            }
            else if (TipoDeDato != Tipos.VOID)
                TipoDeDato = Tipos.BOOL;
        }

        public override string ToString()
        {
            return expresionIzquierda.ToString() + " " + expresion.Texto + " " + expresionDerecha.ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa un Or lógico, usado en la regla 51, 
    /// [Expresion] ::= [Expresion] opOr [Expresion]
    /// </summary>
    public class OperadorOr : ExpresionOperadoresBinarios
    {
        public OperadorOr(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            //Si la expresión derecha e izquierda son de tipo lógico (bool) entonces nos 
            //ponemos también de tipo lógico, sino void como error
            if (expresionIzquierda.TipoDeDato == Tipos.BOOL && expresionDerecha.TipoDeDato == Tipos.BOOL)
                TipoDeDato = Tipos.BOOL;
            else if (TipoDeDato != Tipos.VOID)
            {
                NodoSemantico.TablaDeSimbolos.AgregarError("No puede aplicarse el lógico and &&, en la expresion " + ToString() + ", a operandos del tipo " + TipoDeDato.ToString().ToLower(), NumeroLinea);
                TipoDeDato = Tipos.VOID;
            }
        }

        public override string ToString()
        {
            return expresionIzquierda.ToString() + " || " + expresionDerecha.ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa un And lógico, usado en la regla 50, 
    /// [Expresion] ::= [Expresion] opAnd [Expresion]
    /// </summary>
    public class OperadorAnd : ExpresionOperadoresBinarios
    {
        public OperadorAnd(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            //Si la expresión derecha e izquierda son de tipo lógico (bool) entonces nos 
            //ponemos también de tipo lógico, sino void como error
            if (expresionIzquierda.TipoDeDato == Tipos.BOOL && expresionDerecha.TipoDeDato == Tipos.BOOL)
                TipoDeDato = Tipos.BOOL;
            else if (TipoDeDato != Tipos.VOID)
            {
                NodoSemantico.TablaDeSimbolos.AgregarError("No puede aplicarse el lógico and &&, en la expresion " + ToString() + ", a operandos del tipo " + TipoDeDato.ToString().ToLower(), NumeroLinea);
                TipoDeDato = Tipos.VOID;
            }
        }

        public override string ToString()
        {
            return expresionIzquierda.ToString() + " && " + expresionDerecha.ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una igualdad (==, !=), usado en la regla 49, 
    /// [Expresion] ::= [Expresion] opIgualdad [Expresion]
    /// </summary>
    public class OperadorIgualdad : ExpresionOperadoresBinarios
    {
        public OperadorIgualdad(Stack<ElementoPila> pila)
            : base(pila)
        {
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            if (TipoDeDato != Tipos.VOID)
                TipoDeDato = Tipos.BOOL;
        }

        public override string ToString()
        {
            return expresionIzquierda.ToString() + " " + expresion.Texto + " " + expresionDerecha.ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una suma/resta, usado en la regla 44, 
    /// [Expresion] ::= opSuma [Expresion]
    /// </summary>
    public class OperadorAdicion2 : NodoSemantico
    {
        NodoSemantico expresion;
        NodoSemantico operador;

        public OperadorAdicion2(Stack<ElementoPila> pila)
            : base("<Expresion>")
        {
            pila.Pop();
            expresion = pila.Pop().Nodo;
            pila.Pop();
            operador = new NodoSemantico(pila.Pop().Elemento);

            AñadirHijo(operador);
            AñadirHijo(expresion);

            NumeroLinea = expresion.NumeroLinea;
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            //No puede aplicarse a expresiones de tipo bool, string o void
            if (expresion.TipoDeDato == Tipos.BOOL || expresion.TipoDeDato == Tipos.STRING || expresion.TipoDeDato == Tipos.VOID)
            {
                NodoSemantico.TablaDeSimbolos.AgregarError("No se puede formar la expresión " + operador.Texto + " " + expresion.ToString() + ", ya que la expresión derecha " + expresion.ToString() + " es de tipo " + expresion.TipoDeDato.ToString().ToLower(), this.NumeroLinea);
            }
            else
                TipoDeDato = expresion.TipoDeDato;
        }

        public override string ToString()
        {
            return operador.Texto + " " + expresion.ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una negación (!), usado en la regla 45, 
    /// [Expresion] ::= opNot [Expresion]
    /// </summary>
    public class OperadorNot : NodoSemantico
    {
        NodoSemantico expresion;

        public OperadorNot(Stack<ElementoPila> pila)
            : base("<Expresion>")
        {
            pila.Pop();
            expresion = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();

            AñadirHijo(new NodoSemantico("!"));
            AñadirHijo(expresion);

            NumeroLinea = expresion.NumeroLinea;
        }

        public override void ValidaTiposDatos()
        {
            expresion.ValidaTiposDatos();
            if (expresion.TipoDeDato != Tipos.BOOL)
            {
                TipoDeDato = Tipos.VOID;
                NodoSemantico.TablaDeSimbolos.AgregarError("El operador de negación ! no puede ser aplicado a la expresión " + expresion.ToString() + " ya que no es de tipo lógica", this.NumeroLinea);
            }
            else
                TipoDeDato = Tipos.BOOL;
        }

        public override string ToString()
        {
            return "! " + expresion.ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una expresión entre parentesis, usado en la regla 43, 
    /// [Expresion] ::= ( [Expresion] )
    /// </summary>
    public class ExpresionEntreParentesis : NodoSemantico
    {
        NodoSemantico expresion;

        public ExpresionEntreParentesis(Stack<ElementoPila> pila)
            : base("<Expresion>")
        {
            pila.Pop();
            pila.Pop();
            pila.Pop();
            expresion = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();

            AñadirHijo(new NodoSemantico("("));
            AñadirHijo(expresion);
            AñadirHijo(new NodoSemantico(")"));

            NumeroLinea = expresion.NumeroLinea;
        }

        public override void ValidaTiposDatos()
        {
            expresion.ValidaTiposDatos();
            TipoDeDato = expresion.TipoDeDato;
        }

        public override string ToString()
        {
            return "( " + expresion.ToString() + " )";
        }
    }

    #endregion

    //================================================================================

    #region Nodos del tipo Sentencia

    /// <summary>
    /// Nodo del árbol que representa una lista de sentencias, usado en la regla 20, 
    /// [Sentencias] ::= [Sentencia] [Sentencias]
    /// </summary>
    public class Sentencias : NodoSemantico
    {
        public Sentencias(Stack<ElementoPila> pila)
            : base("<Sentencias>")
        {
            pila.Pop();
            NodoSemantico sentencias = pila.Pop().Nodo;
            pila.Pop();
            NodoSemantico sentencia = pila.Pop().Nodo;

            AñadirHijo(sentencia);
            foreach (NodoSemantico hijo in sentencias.Hijos)
                AñadirHijo(hijo);
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una asignación, usado en la regla 21, 
    /// [Sentencia] ::= identificador = [Expresion] ;
    /// </summary>
    public class SentenciaAsignacion : NodoSemantico
    {
        NodoSemantico expresion;
        NodoSemantico identificador;

        public SentenciaAsignacion(Stack<ElementoPila> pila)
            : base("<Sentencia>")
        {
            pila.Pop();
            pila.Pop();
            pila.Pop();
            expresion = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();
            pila.Pop();
            identificador = new NodoSemantico(pila.Pop().Elemento);

            AñadirHijo(identificador);
            AñadirHijo(new NodoSemantico("="));
            AñadirHijo(expresion);

            NumeroLinea = expresion.NumeroLinea;
        }

        public override void ValidaTiposDatos()
        {
            TipoDeDato = Tipos.VOID;

            //Revisamos el identificador
            identificador.TipoDeDato = Tipos.VOID;
            if (NodoSemantico.TablaDeSimbolos.VariableLocalDefinida(identificador.Texto, NodoSemantico.FuncionActual) || NodoSemantico.TablaDeSimbolos.VariableGlobalDefinida(identificador.Texto))
            {
                identificador.TipoDeDato = NodoSemantico.TablaDeSimbolos.VarLocal == null ? NodoSemantico.TablaDeSimbolos.VarGlobal.Tipo : NodoSemantico.TablaDeSimbolos.VarLocal.Tipo;
            }
            else
                NodoSemantico.TablaDeSimbolos.AgregarError("La variable " + identificador.Texto + " es usada pero nunca es definida", this.NumeroLinea);

            //Revisamos la expresion
            expresion.ValidaTiposDatos();

            //El identificador y la expresión deben de ser el mismo tipo, y el identificador no puede ser 
            //void, ni la expresión puede ser void o bool
            if (identificador.TipoDeDato != expresion.TipoDeDato || ((identificador.TipoDeDato == Tipos.VOID) || (expresion.TipoDeDato == Tipos.VOID || expresion.TipoDeDato == Tipos.BOOL)))
                NodoSemantico.TablaDeSimbolos.AgregarError("No puede formarse la asignación " + ToString() + " ya que el identificador " + identificador.Texto + " es del tipo " + identificador.TipoDeDato.ToString().ToLower() + " y la expresión derecha " + expresion.ToString() + " es del tipo " + expresion.TipoDeDato.ToString().ToLower(), this.NumeroLinea);
        }

        public override string ToString()
        {
            return identificador.Texto + " = " + expresion.ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una sentencia de llamada de funcion, usado en la 
    /// regla 25, [Sentencia] ::= [LlamadaFunc] ;
    /// </summary>
    public class SentenciaLlamadaFuncion : NodoSemantico
    {
        public SentenciaLlamadaFuncion(Stack<ElementoPila> pila)
            : base("<Sentencia>")
        {
            pila.Pop();
            pila.Pop();
            pila.Pop();
            AñadirHijo(pila.Pop().Nodo);
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una sentencia de regreso de valor, usado en la 
    /// regla 24, [Sentencia] ::= return [ValorRegresa] ;
    /// </summary>
    public class SentenciaValorRegresa : NodoSemantico
    {
        private NodoSemantico valorRegresa;

        public NodoSemantico ValorRegresa
        {
            get { return valorRegresa; }
        }

        public SentenciaValorRegresa(Stack<ElementoPila> pila)
            : base("<Sentencia>")
        {
            pila.Pop();
            pila.Pop();
            pila.Pop();
            valorRegresa = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();

            AñadirHijo(new NodoSemantico("return"));
            AñadirHijo(valorRegresa);

            NumeroLinea = valorRegresa.NumeroLinea;
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();
            if (valorRegresa.Hijos.Count == 0)
                TipoDeDato = Tipos.VOID;
            else
                TipoDeDato = ((NodoSemantico)valorRegresa.Hijos[0]).TipoDeDato;
        }

        public override string ToString()
        {
            if (valorRegresa.Hijos.Count == 0)
                return "return;";
            else
                return "return " + valorRegresa.Hijos[0].ToString();
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una sentencia if, usado en la regla 22, 
    /// [Sentencia] ::= if ( [Expresion] ) [SentenciaBloque] [Otro]
    /// </summary>
    public class SentenciaIf : NodoSemantico
    {
        NodoSemantico expresion;

        public SentenciaIf(Stack<ElementoPila> pila)
            : base("<Sentencia>")
        {
            pila.Pop();
            NodoSemantico otros = pila.Pop().Nodo;
            pila.Pop();
            NodoSemantico bloque = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();
            pila.Pop();
            expresion = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();
            pila.Pop();
            pila.Pop();

            AñadirHijo(new NodoSemantico("if"));
            AñadirHijo(new NodoSemantico("("));
            AñadirHijo(expresion);
            AñadirHijo(new NodoSemantico(")"));
            AñadirHijo(bloque);
            AñadirHijo(otros);

            NumeroLinea = expresion.NumeroLinea;
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            if (expresion.TipoDeDato != Tipos.BOOL)
                NodoSemantico.TablaDeSimbolos.AgregarError("No puede formarse la instrucción if, porque la condición " + expresion.ToString() + " es de tipo " + expresion.TipoDeDato.ToString().ToLower() + " y se requiere un tipo lógico", this.NumeroLinea);
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una sentencia while, usado en la regla 23, 
    /// [Sentencia] ::= while ( [Expresion] ) [Bloque]
    /// </summary>
    public class SentenciaWhile : NodoSemantico
    {
        NodoSemantico expresion;

        public SentenciaWhile(Stack<ElementoPila> pila)
            : base("<Sentencia>")
        {
            pila.Pop();
            NodoSemantico bloque = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();
            pila.Pop();
            expresion = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();
            pila.Pop();
            pila.Pop();

            AñadirHijo(new NodoSemantico("while"));
            AñadirHijo(new NodoSemantico("("));
            AñadirHijo(expresion);
            AñadirHijo(new NodoSemantico(")"));
            AñadirHijo(bloque);

            NumeroLinea = expresion.NumeroLinea;
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            if (expresion.TipoDeDato != Tipos.BOOL)
                NodoSemantico.TablaDeSimbolos.AgregarError("No puede formarse la instrucción while, porque la condición " + expresion.ToString() + " es de tipo " + expresion.TipoDeDato.ToString().ToLower() + " y se requiere un tipo lógico", this.NumeroLinea);
        }
    }

    #endregion

    //================================================================================

    #region Nodos auxiliares a los de tipo sentencia

    /// <summary>
    /// Nodo del árbol que representa un bloque para alguna palabra reservada de flujo 
    /// de instrucciones, usado en la regla 28, [Bloque] ::= { [Sentencias] }
    /// </summary>
    public class Bloque : NodoSemantico
    {
        public Bloque(Stack<ElementoPila> pila)
            : base("<Bloque>")
        {
            pila.Pop();
            pila.Pop();
            pila.Pop();
            NodoSemantico sentencias = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();

            AñadirHijo(new NodoSemantico("{"));
            AñadirHijo(sentencias);
            AñadirHijo(new NodoSemantico("}"));
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa un bloque else despues de una sentencia if, 
    /// usado en la regla 27, [Otro] ::= else [SentenciaBloque]
    /// </summary>
    public class Otro : NodoSemantico
    {
        public Otro(Stack<ElementoPila> pila)
            : base("<Otro>")
        {
            pila.Pop();
            NodoSemantico bloque = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();

            AñadirHijo(new NodoSemantico("else"));
            AñadirHijo(bloque);
        }
    }

    #endregion

    //================================================================================

    #region Nodos referentes a funciones

    /// <summary>
    /// Nodo del árbol que representa la definición de una función, usado en la regla 9, 
    /// [DefFunc] ::= tipo identificador ( [Parametros] ) [BloqFunc]
    /// </summary>
    public class DefFunc : NodoSemantico
    {
        private NodoSemantico tipo, identificador, bloqueFunc, parametros;

        public DefFunc(Stack<ElementoPila> pila)
            : base("<DefFunc>")
        {
            pila.Pop();
            bloqueFunc = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();
            pila.Pop();
            parametros = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();
            pila.Pop();
            identificador = new NodoSemantico(pila.Pop().Elemento);
            pila.Pop();
            tipo = new NodoSemantico(pila.Pop().Elemento);

            AñadirHijo(tipo);
            AñadirHijo(identificador);
            AñadirHijo(new NodoSemantico("("));
            AñadirHijo(parametros);
            AñadirHijo(new NodoSemantico(")"));
            AñadirHijo(bloqueFunc);

            NumeroLinea = parametros.NumeroLinea;
        }

        /// <summary>
        /// Valida el tipo de dato (int, float, string o void) de este nodo, y de todos sus 
        /// nodos hijos
        /// </summary>
        public override void ValidaTiposDatos()
        {
            NodoSemantico.TipoDeAmbito = TipoAmbito.LOCAL;
            TipoDeDato = Tipo.ObtieneTipo(tipo.Texto); //El tipo de la función
            NodoSemantico.FuncionActual = identificador.Texto; //El identificador de la función

            NodoSemantico.TablaDeSimbolos.Agrega(this);
            foreach (NodoSemantico nodo in hijos)
                nodo.ValidaTiposDatos();

            //Tomamos todos los nodos que son del tipo SentenciaValorRegresa
            List<ArbolGrafico.Nodo> returns = bloqueFunc.Hijos[1].Hijos.FindAll(a => a is SentenciaValorRegresa);

            if (identificador.Texto == "main" && TipoDeDato != Tipos.INT)
            {
                NodoSemantico.TablaDeSimbolos.AgregarError("La función main debe regresar un tipo de dato int", NumeroLinea);
            }
            else if (returns.Count == 0 && TipoDeDato != Tipos.VOID)
            {
                NodoSemantico.TablaDeSimbolos.AgregarError("La función " + NodoSemantico.FuncionActual + " no devuelve ningún valor", this.NumeroLinea);
            }
            else
            {
                foreach (SentenciaValorRegresa nodo in returns)
                {
                    if (nodo.TipoDeDato != TipoDeDato)
                    {
                        NodoSemantico.TablaDeSimbolos.AgregarError("El tipo de dato devuelto por la expresión " + nodo.ToString() + " es de tipo " + nodo.TipoDeDato.ToString().ToLower() + " y la función devuelve un tipo " + TipoDeDato.ToString().ToLower(), nodo.NumeroLinea);
                    }
                }
            }

            NodoSemantico.TipoDeAmbito = TipoAmbito.GLOBAL;
            NodoSemantico.FuncionActual = "";
        }

        /// <summary>
        /// Devuelve todos los parámetros de la función, concatenados en una cadena
        /// </summary>
        /// <returns></returns>
        public Parametros ObtieneParametros()
        {
            return parametros as Parametros;
        }

        /// <summary>
        /// Obtiene un valor que índica si esta función es el main
        /// </summary>
        /// <returns></returns>
        public bool EsMain()
        {
            return TipoDeDato == Tipos.INT && identificador.Texto == "main" ? true : false;
        }

        public override void GeneraCodigoEnsamblador()
        {
            NodoSemantico.TipoDeAmbito = TipoAmbito.LOCAL;
            NodoSemantico.FuncionActual = identificador.Texto;

            base.GeneraCodigoEnsamblador();


            NodoSemantico.TipoDeAmbito = TipoAmbito.GLOBAL;
            NodoSemantico.FuncionActual = "";
        }

        public String ObtienePrototipoFuncion()
        {
            String prototipo = NodoSemantico.TablaDeSimbolos.ObtieneIdentificadorSecundarioFuncion(identificador.Texto) + " ";
            prototipo += "proto ";
            bool entro = false;
            foreach(NodoSemantico parametro in parametros.Hijos)
            {
                entro = true;
                prototipo += (parametro as Parametro).ObtieneParametroPrototipo() + ", ";
            }
            //Le quitamos el último coma y espacio
            if (entro)
                prototipo = prototipo.Substring(0, prototipo.Length - 2);
            else
                prototipo = prototipo.Substring(0, prototipo.Length - 1);
            return prototipo;
        }
    }

    //================================================================================

    public class Parametro : DefVar
    {
        public Parametro(String tipo, String identificador)
            : base(tipo, identificador, true)
        {
            texto = "<Parametro>";
        }

        /// <summary>
        /// Genera el código ensamblador de este nodo
        /// </summary>
        /// <returns></returns>
        public override void GeneraCodigoEnsamblador()
        {
            base.GeneraCodigoEnsamblador();

            //Si es variable global
            if (NodoSemantico.TipoDeAmbito == TipoAmbito.GLOBAL)
            {
                CodigoEnsamblador = NodoSemantico.TablaDeSimbolos.ObtieneIdentificadorSecundarioVariable(identificador);
                switch (TipoDeDato)
                {
                    case Tipos.INT: case Tipos.FLOAT:
                        CodigoEnsamblador += " dw ?";
                        break;
                    default:
                        CodigoEnsamblador += " db ?";
                        break;
                }
            }
            else
            {
                CodigoEnsamblador = "local " + NodoSemantico.TablaDeSimbolos.ObtieneIdentificadorSecundarioVariable(identificador, NodoSemantico.FuncionActual);
                switch (TipoDeDato)
                {
                    case Tipos.INT: case Tipos.FLOAT:
                        CodigoEnsamblador += ": dw";
                        break;
                    default:
                        CodigoEnsamblador += "[128]: byte";
                        break;
                }
            }
        }

        public String ObtieneParametroPrototipo()
        {
            String parametro = "";
            switch(TipoDeDato)
            {
                case Tipos.INT: case Tipos.FLOAT:
                    parametro += ":DWORD";
                    break;
                default:
                    parametro += ":DBYTE";
                    break;
            }
            return parametro;
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa la lista de parámetros de una función, usado en 
    /// la regla 11, [Parametros] ::= tipo identificador [ListaParam]
    /// </summary>
    public class Parametros : NodoSemantico
    {
        public Parametros(Stack<ElementoPila> pila)
            : base("<ListaParam>")
        {
            pila.Pop();
            List<NodoSemantico> listaParametros = new List<NodoSemantico>();
            foreach (NodoSemantico nodo in pila.Pop().Nodo.Hijos)
                listaParametros.Add(nodo);
            pila.Pop();
            String identificador = pila.Pop().Elemento;
            pila.Pop();
            String tipo = pila.Pop().Elemento;

            Parametro parametro = new Parametro(tipo, identificador);

            AñadirHijo(parametro);

            //Añadimos los demás parametros de la lista, y de esta manera nos 
            //convertimos en la nueva lista de parámetros
            foreach (NodoSemantico nodo in listaParametros)
                AñadirHijo(nodo);
        }

        public override void GeneraCodigoEnsamblador()
        {
            base.GeneraCodigoEnsamblador();
            CodigoEnsamblador = "";
            foreach (NodoSemantico parametro in hijos)
            {
                CodigoEnsamblador += parametro.CodigoEnsamblador + Environment.NewLine;
            }
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa la lista de parámetros de una función, usado en 
    /// la regla 13, [ListaParam] ::= , tipo identificador [ListaParam]
    /// </summary>
    public class Parametros2 : NodoSemantico
    {
        public Parametros2(Stack<ElementoPila> pila)
            : base("<ListaParam>")
        {
            pila.Pop();
            List<NodoSemantico> listaParametros = new List<NodoSemantico>();
            foreach (NodoSemantico nodo in pila.Pop().Nodo.Hijos)
                listaParametros.Add(nodo);
            pila.Pop();
            String identificador = pila.Pop().Elemento;
            pila.Pop();
            String tipo = pila.Pop().Elemento;
            pila.Pop();
            pila.Pop();

            Parametro parametro = new Parametro(tipo, identificador);

            AñadirHijo(parametro);

            //Añadimos los demás parametros de la lista, y de esta manera nos 
            //convertimos en la nueva lista de parámetros
            foreach (NodoSemantico nodo in listaParametros)
                AñadirHijo(nodo);
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa el bloque de una función, usado en la regla 8, 
    /// [BloqFunc] ::= { [DefLocales] }
    /// </summary>
    public class BloqueFunc : NodoSemantico
    {
        public BloqueFunc(Stack<ElementoPila> pila)
            : base("<BloqueFunc>")
        {
            pila.Pop();
            pila.Pop();
            pila.Pop();
            NodoSemantico defLocales = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();

            AñadirHijo(new NodoSemantico("{"));
            AñadirHijo(defLocales);
            AñadirHijo(new NodoSemantico("}"));
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una llamada de función, usado en la regla 40, 
    /// [LlamadaFunc] ::= identificador ( [Argumentos] )
    /// </summary>
    public class LlamadaFuncion : NodoSemantico
    {
        private NodoSemantico identificador, argumentos;

        public LlamadaFuncion(Stack<ElementoPila> pila)
            : base("<LlamadaFunc>")
        {
            pila.Pop();
            pila.Pop();
            pila.Pop();
            argumentos = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();
            pila.Pop();
            identificador = new NodoSemantico(pila.Pop().Elemento);

            AñadirHijo(identificador);
            AñadirHijo(new NodoSemantico("("));
            AñadirHijo(argumentos);
            AñadirHijo(new NodoSemantico(")"));

            NumeroLinea = argumentos.NumeroLinea;
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            //Buscamos que se haya definido la función
            if (NodoSemantico.TablaDeSimbolos.FuncionDefinida(identificador.Texto))
            {
                bool correcto = true;
                Parametros parametros = NodoSemantico.TablaDeSimbolos.funcion.Parametros;

                //Tienen que concordar en la cantidad de parámetros de la definición de la función y de 
                //argumentos de la llamada
                int cantidadParametros = parametros == null ? 0 : parametros.Hijos.Count;
                if (cantidadParametros != argumentos.Hijos.Count)
                {
                    correcto = false;
                }
                else
                {
                    //Además uno por uno de los argumentos y parámetros deben de ser del mismo tipo
                    for (int i = 0; i < argumentos.Hijos.Count; i++)
                    {
                        if (((NodoSemantico)argumentos.Hijos[i]).TipoDeDato != ((NodoSemantico)parametros.Hijos[i]).TipoDeDato)
                            correcto = false;
                    }
                }
                if (!correcto)
                    NodoSemantico.TablaDeSimbolos.AgregarError("Los argumentos de la llamada a la función " + identificador.Texto + " no concuerdan con los parámetros de su definición", NumeroLinea);
                else
                    TipoDeDato = NodoSemantico.TablaDeSimbolos.funcion.Tipo;
            }
            else
                NodoSemantico.TablaDeSimbolos.AgregarError("No se encontró la definición de la función " + identificador.Texto, NumeroLinea);
        }

        public override string ToString()
        {
            return identificador.Texto + "( " + (argumentos.Hijos.Count == 0 ? " " : argumentos.ToString()) + ")";
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una lista de argumentos para una llamada a función, 
    /// usado en la regla 32, [Argumentos] ::= [Expresion] [ListaArgumentos]
    /// </summary>
    public class ListaArgumentos : NodoSemantico
    {
        public ListaArgumentos(Stack<ElementoPila> pila)
            : base("<ListaArgumentos>")
        {
            pila.Pop();
            NodoSemantico listaArgumentos = pila.Pop().Nodo;
            pila.Pop();
            NodoSemantico expresion = pila.Pop().Nodo;

            AñadirHijo(expresion);
            foreach (NodoSemantico nodo in listaArgumentos.Hijos)
                AñadirHijo(nodo);
        }

        public override string ToString()
        {
            String parametros = "  ";
            foreach (NodoSemantico nodo in hijos)
            {
                parametros += nodo.ToString() + ", ";
            }
            parametros = parametros.Substring(0, parametros.Length - 2);
            parametros += " ";
            return parametros;
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una lista de argumentos para una llamada a función, 
    /// usado en la regla 34, [ListaArgumentos] ::= , [Expresion] [ListaArgumentos]
    /// </summary>
    public class ListaArgumentos2 : NodoSemantico
    {
        public ListaArgumentos2(Stack<ElementoPila> pila)
            : base("<ListaArgumentos>")
        {
            pila.Pop();
            NodoSemantico listaArgumentos = pila.Pop().Nodo;
            pila.Pop();
            NodoSemantico expresion = pila.Pop().Nodo;
            pila.Pop();
            pila.Pop();

            AñadirHijo(expresion);
            foreach (NodoSemantico nodo in listaArgumentos.Hijos)
                AñadirHijo(nodo);
        }
    }

    #endregion

    //================================================================================

    #region Otros nodos

    /// <summary>
    /// Nodo del árbol que representa una lista de definiciones, usado en la regla 3, 
    /// [Definiciones] ::= [Definicion] [Definiciones]
    /// </summary>
    public class Definiciones : NodoSemantico
    {
        public Definiciones(Stack<ElementoPila> pila)
            : base("<Definiciones>")
        {
            pila.Pop();
            NodoSemantico definiciones = pila.Pop().Nodo;
            pila.Pop();
            NodoSemantico definicion = pila.Pop().Nodo;

            AñadirHijo(definicion);
            for (int i = 0; i < definiciones.Hijos.Count; i++)
                AñadirHijo(definiciones.Hijos[i]);
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa una lista de definiciones locales, usado en la 
    /// regla 16, [DefLocales] ::= [DefLocal] [DefLocales]
    /// </summary>
    public class DefinicionesLocales : NodoSemantico
    {
        public DefinicionesLocales(Stack<ElementoPila> pila)
            : base("<DefLocales>")
        {
            pila.Pop();
            NodoSemantico defLocales = pila.Pop().Nodo;
            pila.Pop();
            NodoSemantico defLocal = pila.Pop().Nodo;

            AñadirHijo(defLocal);
            for (int i = 0; i < defLocales.Hijos.Count; i++)
                AñadirHijo(defLocales.Hijos[i]);
        }
    }

    //================================================================================

    /// <summary>
    /// Nodo del árbol que representa el programa y tiene una lista de definiciones, 
    /// usado en la regla 1, [programa] ::= [Definiciones]
    /// </summary>
    public class Programa : NodoSemantico
    {
        public Programa(Stack<ElementoPila> pila)
            : base("<Programa>")
        {
            pila.Pop();
            AñadirHijo(pila.Pop().Nodo);
        }

        public override void ValidaTiposDatos()
        {
            base.ValidaTiposDatos();

            //Buscamos que hayan definido un main
            NodoSemantico definiciones = hijos[0] as NodoSemantico;
            bool correcto = false;
            foreach (NodoSemantico definicion in definiciones.Hijos)
            {
                if (definicion is DefFunc && (definicion as DefFunc).EsMain())
                {
                    correcto = true;
                }
            }
            if (!correcto)
                NodoSemantico.TablaDeSimbolos.AgregarError("No se encontró la definición de la función principal, main", 0);
        }

        public override void GeneraCodigoEnsamblador()
        {
            base.GeneraCodigoEnsamblador();
            CodigoEnsamblador = ";=============================================" + Environment.NewLine +
                                ";============== Configuración ================" + Environment.NewLine +
                                ";=============================================" + Environment.NewLine + Environment.NewLine +

                                ".386" + Environment.NewLine +
                                ".model flat, stdcall" + Environment.NewLine +
                                "option casemap:none" + Environment.NewLine + Environment.NewLine +

                                ";=============================================" + Environment.NewLine +
                                ";================ Librerias ==================" + Environment.NewLine +
                                ";=============================================" + Environment.NewLine + Environment.NewLine +

                                "include .\\masm32\\include\\kernel32.inc" + Environment.NewLine +
                                "include .\\masm32\\macros\\macros.asm" + Environment.NewLine +
                                "include .\\masm32\\include\\masm32.inc" + Environment.NewLine + Environment.NewLine + 

                                "includelib .\\masm32\\lib\\kernel32.lib" + Environment.NewLine + 
                                "includelib .\\masm32\\lib\\masm32.lib" + Environment.NewLine + Environment.NewLine +

                                ";=============================================" + Environment.NewLine +
                                ";============= Variables globales ============" + Environment.NewLine +
                                ";=============================================" + Environment.NewLine + Environment.NewLine +

                                ".data?" + Environment.NewLine + Environment.NewLine;

            //Ponemos todas las variables globales
            foreach(NodoSemantico definicion in hijos[0].Hijos.FindAll(def => def is Variables))
            {
                CodigoEnsamblador += definicion.CodigoEnsamblador;
            }

            CodigoEnsamblador += Environment.NewLine;

            CodigoEnsamblador += ";=============================================" + Environment.NewLine +
                                 ";================== Código ===================" + Environment.NewLine +
                                 ";=============================================" + Environment.NewLine + Environment.NewLine +

                                 ".code" + Environment.NewLine + Environment.NewLine +

                                 "inicio:" + Environment.NewLine + Environment.NewLine +

                                 ";---------------------------------------------" + Environment.NewLine +
                                 ";----------- Prototipos de funciones ---------" + Environment.NewLine +
                                 ";---------------------------------------------" + Environment.NewLine + Environment.NewLine;

            //Ponemos los prototipos de todas las funciones
            foreach(NodoSemantico definicion in hijos[0].Hijos.FindAll(def => def is DefFunc))
            {
                CodigoEnsamblador += (definicion as DefFunc).ObtienePrototipoFuncion() + Environment.NewLine;
            }

            CodigoEnsamblador += Environment.NewLine;

            CodigoEnsamblador += ";---------------------------------------------" + Environment.NewLine +
                                 ";----------- Prototipos de funciones ---------" + Environment.NewLine +
                                 ";---------------------------------------------" + Environment.NewLine + Environment.NewLine;

            CodigoEnsamblador += "invoke main" + Environment.NewLine +
                                 "invoke ExitProcess, 0" + Environment.NewLine + Environment.NewLine +

                                 ";---------------------------------------------" + Environment.NewLine +
                                 ";----------------- Funciones -----------------" + Environment.NewLine +
                                 ";---------------------------------------------" + Environment.NewLine + Environment.NewLine;
                                 
            //Ponemos el código de todas las funciones
            foreach(NodoSemantico definicion in hijos[0].Hijos.FindAll(def => def is DefFunc))
            {
                CodigoEnsamblador += (definicion as DefFunc).CodigoEnsamblador + Environment.NewLine;
            }
            CodigoEnsamblador += ";---------------------------------------------" + Environment.NewLine +
                                 ";----------------- Funciones -----------------" + Environment.NewLine +
                                 ";---------------------------------------------" + Environment.NewLine + Environment.NewLine +

                                 "end inicio";
        }
    }

    #endregion
}
