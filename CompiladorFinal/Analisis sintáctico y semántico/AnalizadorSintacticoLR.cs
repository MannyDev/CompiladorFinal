using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using ArbolGrafico;

namespace Compiladores
{
    /// <summary>
    /// Permite generar un análisis sintactico para determinar si un grupo de tokens dados 
    /// genera una gramática determinada
    /// </summary>
    public class AnalizadorSintacticoLR
    {
        #region Variables y propiedades

        private AnalizadorLexico analizadorLexico;

        private String entrada;
        private int fila, columna, accion;
        private Stack<ElementoPila> pila;
        private NoTerminal nt;
        private NodoSemantico nodo;
        private NodoSemantico arbolSintactico;
        private bool correcto = false;
        private bool arreglosYTablaCargados = false;

        //Reglas de la grámatica
        int[] idReglas;
        int[] lonReglas;
        String[] strReglas;

        //Tabla de la grámatica
        private int[,] tabla;

        /// <summary>
        /// Obtiene o modifica la entrada que se usa en el análisis
        /// </summary>
        public String Entrada
        {
            get { return entrada; }
            set
            {
                entrada = value;
                analizadorLexico = new AnalizadorLexico(entrada);
                pila.Clear();
            }
        }

        /// <summary>
        /// Si es true indica que el analisis funciono correctamente, y viceversa
        /// </summary>
        public bool Correcto
        {
            get { return correcto; }
        }

        /// <summary>
        /// Obtiene o modifica el último árbol sintáctico obtenido en el análisis
        /// </summary>
        public NodoSemantico ArbolSintactico
        {
            get { return arbolSintactico; }
            set { arbolSintactico = value; }
        }

        #endregion

        #region Eventos

        //Delegado usado para guardar el evento para mostrar la pila
        public delegate void MuestraPilaEventArgs ( object sender, MostrarPilaEventArgs e );

        /// <summary>
        /// Este evento se dispara cuando el analizador necesita mostrar los datos de la 
        /// pila
        /// </summary>
        public event MuestraPilaEventArgs MostrarPila;

        //Delegado usado para guardar el evento para mostrar el árbol
        public delegate void MuestraArbolEventArgs ( object sender, MostrarArbolEventArgs e );

        /// <summary>
        /// Este evento se dispara cuando el analizador termina el analisis, y necesita 
        /// mostrar el árbol sintáctico
        /// </summary>
        public event MuestraArbolEventArgs MostrarArbol;

        #endregion

        //================================================================================

        #region Constructores

        /// <summary>
        /// Constructor
        /// </summary>
        public AnalizadorSintacticoLR ()
            : this("")
        {
        }

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entrada">La cadena a analizar</param>
        public AnalizadorSintacticoLR(String entrada)
        {
            this.entrada = entrada;
            analizadorLexico = new AnalizadorLexico(entrada);
            pila = new Stack<ElementoPila>();
            arbolSintactico = null;

            if (!CargaArreglosYTabla())
                MessageBox.Show("Ocurrio un error al cargar los datos");
        }

        #endregion

        //================================================================================

        #region Analizador sintáctico

        /// <summary>
        /// Ejecuta todo el análisis sintactico, auxiliandose en el análizador léxico
        /// </summary>
        public void Analiza()
        {
            if (!arreglosYTablaCargados)
            {
                MessageBox.Show("No se han cargado los datos de la grámatica del compilador, verifica que el archivo compilador09b.lr se ecuentre en la ruta del ejecutable");
                return;
            }

            try
            {
                NodoSemantico.TipoDeAmbito = TipoAmbito.GLOBAL;
                arbolSintactico = null;
                nt = null;
                nodo = null;
                correcto = false;
                accion = 0;
                pila.Push(new Terminal(Simbolos.PESOS, "$"));
                pila.Push(new Estado(0));
                analizadorLexico.SigSimbolo();

                while (true)
                {
                    //Buscamos la siguiente acción
                    SigAccion();

                    //Mostrar pila, entrada y accion
                    MuestraPila();

                    //Si es positivo es un desplazamiento
                    if (accion > 0)
                    {
                        pila.Push(new Terminal(analizadorLexico.Tipo, analizadorLexico.Simbolo));
                        pila.Push(new Estado(accion));
                        analizadorLexico.SigSimbolo();
                    }

                    //Sino, si es negativo es una reducción o aceptación
                    else if (accion < 0)
                    {
                        //Estado de aceptación
                        if (accion == -1)
                        {
                            correcto = true;
                            pila.Pop();
                            arbolSintactico = pila.Pop().Nodo;
                            break;
                        }

                        int regla = -(accion + 2);

                        switch (regla + 1)
                        {
                            case 1: //<programa> ::= <Definiciones>
                                nodo = new Programa(pila);
                                break;
                            case 2: //<Definiciones> ::= \e
                                nodo = new NodoSemantico("<Definiciones>");
                                break;
                            case 3: //<Definiciones> ::= <Definicion> <Definiciones>
                                nodo = new Definiciones(pila);
                                break;
                            case 4: //<Definicion> ::= <DefVar>
                                pila.Pop();
                                nodo = pila.Pop().Nodo;
                                break;
                            case 5: //<Definicion> ::= <DefFunc>
                                pila.Pop();
                                nodo = pila.Pop().Nodo;
                                break;
                            case 6: //<DefVar> ::= tipo identificador <ListaVar> ;
                                nodo = new Variables(pila);
                                break;
                            case 7: //<ListaVar> ::= \e
                                nodo = new NodoSemantico("<ListaVar>");
                                break;
                            case 8: //<ListaVar> ::= , identificador <ListaVar>
                                nodo = new Variables2(pila);
                                break;
                            case 9: //<DefFunc> ::= tipo identificador ( <Parametros> ) <BloqFunc>
                                nodo = new DefFunc(pila);
                                break;
                            case 10: //<Parametros> ::= \e
                                nodo = new NodoSemantico("<ListaParam>");
                                break;
                            case 11: //<Parametros> ::= tipo identificador <ListaParam>
                                nodo = new Parametros(pila);
                                break;
                            case 12: //<ListaParam> ::= \e
                                nodo = new NodoSemantico("<ListaParam>");
                                break;
                            case 13: //<ListaParam> ::= , tipo identificador <ListaParam>
                                nodo = new Parametros2(pila);
                                break;
                            case 14: //<BloqFunc> ::= { <DefLocales> }
                                nodo = new BloqueFunc(pila);
                                break;
                            case 15: //<DefLocales> ::= \e
                                nodo = new NodoSemantico("<DefLocales>");
                                break;
                            case 16: //<DefLocales> ::= <DefLocal> <DefLocales>
                                nodo = new DefinicionesLocales(pila);
                                break;
                            case 17: //<DefLocal> ::= <DefVar>
                                pila.Pop();
                                nodo = pila.Pop().Nodo;
                                break;
                            case 18: //<DefLocal> ::= <Sentencia>
                                pila.Pop();
                                nodo = pila.Pop().Nodo;
                                break;
                            case 19: //<Sentencias> ::= \e
                                nodo = new NodoSemantico("<Sentencias>");
                                break;
                            case 20: //<Sentencias> ::= <Sentencia> <Sentencias>
                                nodo = new Sentencias(pila);
                                break;
                            case 21: //<Sentencia> ::= identificador = <Expresion> ;
                                nodo = new SentenciaAsignacion(pila);
                                break;
                            case 22: //<Sentencia> ::= if ( <Expresion> ) <SentenciaBloque> <Otro>
                                nodo = new SentenciaIf(pila);
                                break;
                            case 23: //<Sentencia> ::= while ( <Expresion> ) <Bloque>
                                nodo = new SentenciaWhile(pila);
                                break;
                            case 24: //<Sentencia> ::= return <ValorRegresa> ;
                                nodo = new SentenciaValorRegresa(pila);
                                break;
                            case 25: //<Sentencia> ::= <LlamadaFunc> ;
                                nodo = new SentenciaLlamadaFuncion(pila);
                                break;
                            case 26: //<Otro> ::= \e
                                nodo = new NodoSemantico("<Otro>");
                                break;
                            case 27: //<Otro> ::= else <SentenciaBloque>
                                nodo = new Otro(pila);
                                break;
                            case 28: //<Bloque> ::= { <Sentencias> }
                                nodo = new Bloque(pila);
                                break;
                            case 29: //<ValorRegresa> ::= \e
                                nodo = new NodoSemantico("<ValorRegresa>");
                                break;
                            case 30: //<ValorRegresa> ::= <Expresion>
                                pila.Pop();
                                NodoSemantico valorRegresar = new NodoSemantico("<ValorRegresa>");
                                valorRegresar.AñadirHijo(pila.Pop().Nodo);
                                valorRegresar.NumeroLinea = ((NodoSemantico)valorRegresar.Hijos[0]).NumeroLinea;
                                nodo = valorRegresar;
                                break;
                            case 31: //<Argumentos> ::= \e
                                nodo = new NodoSemantico("<ListaArgumentos>");
                                break;
                            case 32: //<Argumentos> ::= <Expresion> <ListaArgumentos>
                                nodo = new ListaArgumentos(pila);
                                break;
                            case 33: //<ListaArgumentos> ::= \e
                                nodo = new NodoSemantico("<ListaArgumentos>");
                                break;
                            case 34: //<ListaArgumentos> ::= , <Expresion> <ListaArgumentos>
                                nodo = new ListaArgumentos2(pila);
                                break;
                            case 35: //<Termino> ::= <LlamadaFunc>
                                pila.Pop();
                                nodo = pila.Pop().Nodo;
                                break;
                            case 36: //<Termino> ::= identificador
                                nodo = new Identificador(pila);
                                break;
                            case 37: //<Termino> ::= entero
                                nodo = new Entero(pila);
                                break;
                            case 38: //<Termino> ::= real
                                nodo = new Real(pila);
                                break;
                            case 39: //<Termino> ::= cadena
                                nodo = new Cadena(pila);
                                break;
                            case 40: //<LlamadaFunc> ::= identificador ( <Argumentos> )
                                nodo = new LlamadaFuncion(pila);
                                break;
                            case 41: //<SentenciaBloque> ::= <Sentencia>
                                pila.Pop();
                                nodo = pila.Pop().Nodo;
                                break;
                            case 42: //<SentenciaBloque> ::= <Bloque>
                                pila.Pop();
                                nodo = pila.Pop().Nodo;
                                break;
                            case 43: //<Expresion> ::= ( <Expresion> )
                                nodo = new ExpresionEntreParentesis(pila);
                                break;
                            case 44: //<Expresion> ::= opSuma <Expresion>
                                nodo = new OperadorAdicion2(pila);
                                break;
                            case 45: //<Expresion> ::= opNot <Expresion>
                                nodo = new OperadorNot(pila);
                                break;
                            case 46: //<Expresion> ::= <Expresion> opMul <Expresion>
                                nodo = new OperadorMultiplicacion(pila);
                                break;
                            case 47: //<Expresion> ::= <Expresion> opSuma <Expresion>
                                nodo = new OperadorAdicion(pila);
                                break;
                            case 48: //<Expresion> ::= <Expresion> opRelac <Expresion>
                                nodo = new OperadorRelacional(pila);
                                break;
                            case 49: //<Expresion> ::= <Expresion> opIgualdad <Expresion>
                                nodo = new OperadorIgualdad(pila);
                                break;
                            case 50: //<Expresion> ::= <Expresion> opAnd <Expresion>
                                nodo = new OperadorAnd(pila);
                                break;
                            case 51: //<Expresion> ::= <Expresion> opOr <Expresion>
                                nodo = new OperadorOr(pila);
                                break;
                            case 52: //<Expresion> ::= <Termino>
                                nodo = new ExpresionSimple(pila);
                                break;
                            default:
                                //Sacamos de la pila el doble de elementos de la regla de reducción
                                for (int i = 0; i < lonReglas[regla] * 2; i++)
                                    pila.Pop();
                                break;
                        }

                        fila = pila.Peek().Id;
                        columna = idReglas[regla];
                        accion = tabla[fila, columna];

                        nt = new NoTerminal(idReglas[regla], strReglas[regla]);
                        nt.Nodo = nodo;

                        pila.Push(nt);
                        pila.Push(new Estado(accion));
                    }

                    //Error
                    if (accion == 0)
                        throw new Exception();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                MuestraArbol();
            }
        }


        //================================================================================

        /// <summary>
        /// Obtiene la siguiente acción que el analizador debe realizar, se basa en la tabla
        /// para obtenerla
        /// </summary>
        private void SigAccion ()
        {
            fila = pila.Peek().Id;
            columna = analizadorLexico.Tipo;
            accion = tabla[fila, columna];
        }

        #endregion

        //================================================================================

        #region Despliegue de datos

        /// <summary>
        /// Dispara el evento para mostrar la pila
        /// </summary>
        private void MuestraPila ()
        {
            //Disparamos el evento para mostrar la pila, sólo si ya se suscribierón a el
            if (MostrarPila != null)
            {
                MostrarPilaEventArgs datosEvento = new MostrarPilaEventArgs(pila, analizadorLexico.Simbolo, accion);
                MostrarPila(this, datosEvento);
            }
        }

        //================================================================================

        /// <summary>
        /// Dispara el evento para mostrar el árbol
        /// </summary>
        private void MuestraArbol ()
        {
            //Disparamos el evento para mostrar el árbol, sólo si ya se suscribierón a el
            if (MostrarArbol != null)
            {
                //Si se aceptó, mostramos el árbol
                if (!correcto)
                    return;

                MostrarArbolEventArgs datosEvento = new MostrarArbolEventArgs(arbolSintactico);
                MostrarArbol(this, datosEvento);
            }
        }

        #endregion

        //================================================================================

        #region Carga de archivo de grámatica

        /// <summary>
        /// Carga los datos de los arreglos y la tabla del analizador sintáctico
        /// </summary>
        /// <returns></returns>
        public bool CargaArreglosYTabla()
        {
            try
            {
                using (FileStream flujoArchivo = new FileStream("compilador09b.lr", FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (StreamReader lector = new StreamReader(flujoArchivo))
                    {
                        String contenidoArchivo = lector.ReadToEnd();
                        int indice = 0;

                        //Inicializamos los arreglos
                        int cantReglas = SigEntero(contenidoArchivo, ref indice);
                        idReglas = new int[cantReglas];
                        lonReglas = new int[cantReglas];
                        strReglas = new string[cantReglas];

                        //Llenamos los arreglos
                        for (int i = 0; i < cantReglas; i++)
                        {
                            idReglas[i] = SigEntero(contenidoArchivo, ref indice);
                            lonReglas[i] = SigEntero(contenidoArchivo, ref indice);
                            strReglas[i] = SigElemento(contenidoArchivo, ref indice);
                        }

                        //Inicializamos la tabla
                        int filas = SigEntero(contenidoArchivo, ref indice);
                        int columnas = SigEntero(contenidoArchivo, ref indice);
                        tabla = new int[filas, columnas];

                        //Llenamos la tabla
                        for (int i = 0; i < filas; i++)
                            for (int j = 0; j < columnas; j++)
                                tabla[i, j] = SigEntero(contenidoArchivo, ref indice);
                    }
                }
            }
            catch(Exception)
            {
                arreglosYTablaCargados = false;
                return false;
            }

            arreglosYTablaCargados = true;
            return true;
        }

        //================================================================================

        /// <summary>
        /// Toma el siguiente elemento de la cadena dada
        /// </summary>
        /// <param name="contenidoArchivo">La fuente desde la que tomamos el elemento</param>
        /// <param name="indice">El índice en el que vamos leyendo</param>
        /// <returns></returns>
        private String SigElemento(String contenidoArchivo, ref int indice)
        {
            String elemento = "";

            //Recorremos los blancos que haya
            if (EsBlanco(contenidoArchivo[indice]))
            {
                do
                {
                    indice++;
                }while (EsBlanco(contenidoArchivo[indice]));
            }

            //Formamos el elemento, hasta encontrarnos un blanco
            do
            {
                elemento += contenidoArchivo[indice];
                indice++;
            } while (!EsBlanco(contenidoArchivo[indice]));

            return elemento;
        }

        //================================================================================

        /// <summary>
        /// Toma el siguiente elemento de la cadena dada, y lo devuelve convertido 
        /// en un entero
        /// </summary>
        /// <param name="contenidoArchivo">La fuente desde la que tomamos el elemento</param>
        /// <param name="indice">El índice en el que vamos leyendo</param>
        /// <returns></returns>
        private int SigEntero(String contenidoArchivo, ref int indice)
        {
            return int.Parse(SigElemento(contenidoArchivo, ref indice));
        }

        //================================================================================

        /// <summary>
        /// Verifica si un caracter es un blanco, regresa true en caso de ser cierto, 
        /// false en caso contrario
        /// </summary>
        /// <param name="caracter">El caracter a revisar</param>
        /// <returns></returns>
        private bool EsBlanco(char caracter)
        {
            return Char.IsWhiteSpace(caracter);
        }

        #endregion
    }
}
