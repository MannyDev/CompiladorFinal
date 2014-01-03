using System;

namespace Compiladores
{
    /// <summary>
    /// Permite generar un análisis léxico para obtener los tokens que componen una 
    /// entrada determinada
    /// </summary>


    public class AnalizadorLexico
    {
        #region Variables y propiedades

        //La fuente de datos que se usa para efectuar el análisis
        private String fuente;

        //El caracter actualmente leído, y su posición en la fuente
        private char c;
        private int indice;

        //El estado actual del automata finito
        private int estado;

        //índica si continuar o parar el análisis
        private bool continua;

        //El último simbolo obtenido por medio del análisis, y su tipo
        private String simbolo;
        private int tipo;

        //El número de línea actual
        static private int numeroLinea = 1;

        //El número de línea en el que se leyo el último simbolo
        static private int numeroLineaUltimoSimbolo = 1;

        //Indica cuando debemos de contabilizar el salto de línea
        private bool saltoLinea = false;

        /// <summary>
        /// Modifica la fuente en la que nos basamos para generar el análisis léxico
        /// </summary>
        /// <param name="fuente">La fuente a la cual aplicar el análisis</param>
        public String Entrada
        {
            set
            {
                indice = 0;
                simbolo = "";
                fuente = value;
            }
        }

        /// <summary>
        /// Obtiene el último simbolo encontrado en el análisis léxico
        /// </summary>
        public String Simbolo
        {
            get { return simbolo; }
        }

        /// <summary>
        /// Obtiene el tipo del último simbolo encontrado en el análisis léxico
        /// </summary>
        public int Tipo
        {
            get { return tipo; }
        }

        /// <summary>
        /// Obtiene el número de línea actual del análisis
        /// </summary>
        static public int NumeroLinea
        {
            get { return numeroLinea; }
        }

        /// <summary>
        /// Obtiene el número de línea del último simbolo encontrado
        /// </summary>
        static public int NumeroLineaUltimoSimbolo
        {
            get { return numeroLineaUltimoSimbolo; }
        }

        #endregion

        #region Estados y tabla del automata

        //Estados para el automata
        private const int q00 = 0;
        private const int q01 = 1;
        private const int q02 = 2;
        private const int q03 = 3;
        private const int q04 = 4;
        private const int q05 = 5;
        private const int q06 = 6;
        private const int q07 = 7;
        private const int q08 = 8;
        private const int q09 = 9;
        private const int q10 = 10;
        private const int q11 = 11;
        private const int q12 = 12;
        private const int q13 = 13;
        private const int q14 = 14;
        private const int q15 = 15;
        private const int q16 = 16;
        private const int q17 = 17;
        private const int q18 = 18;
        private const int q19 = 19;
        private const int q20 = 20;
        private const int q21 = 21;
        private const int q22 = 22;
        private const int q23 = 23;
        private const int q24 = 24;
        private const int q25 = 25;
        private const int FIN = 26;
        private const int ERR = 27;

        //Tabla del automata
        private int[,] tablaEstados = 
        {
        //   (_)                                                                                          ( )
        //  (a-z) (0-9) (.)  (") (+,-) (*,/) (<,>) (|)  (&)  (!)  (=)  (;)  (,)  (()  ())  ({)  (})  ($)  (\t) (otro)
        //  (A-Z)                                                                                         (\n)
            {q23,  q18, ERR, q21, q01,  q02,  q24, q03, q05, q07, q08, q11, q12, q13, q14, q15, q16, q17, FIN,  ERR}, //q00
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q01
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q02
            {ERR,  ERR, ERR, ERR, ERR,  ERR,  ERR, q04, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR,  ERR}, //q03
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q04
            {ERR,  ERR, ERR, ERR, ERR,  ERR,  ERR, ERR, q06, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR,  ERR}, //q05
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q06
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, q10, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q07
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, q09, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q08
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q09
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q10
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q11
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q12
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q13
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q14
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q15
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q16
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q17
            {FIN,  q18, q19, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q18
            {ERR,  q20, ERR, ERR, ERR,  ERR,  ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR,  ERR}, //q19
            {FIN,  q20, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q20
            {q21,  q21, q21, q22, q21,  q21,  q21, q21, q21, q21, q21, q21, q21, q21, q21, q21, q21, ERR, q21,  q21}, //q21
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q22
            {q23,  q23, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q23
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, q25, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN}, //q24
            {FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN} //q25
        };

        #endregion

        //================================================================================

        #region Constructores

        /// <summary>
        /// Constructor
        /// </summary>
        public AnalizadorLexico()
            :this("")
        {
        }

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fuente">La fuente a la cual aplicar el análisis</param>
        public AnalizadorLexico(String fuente)
        {
            indice = 0;
            simbolo = "";
            this.fuente = fuente;
            numeroLinea = 1;
        }

        #endregion

        //================================================================================

        #region Análisis léxico

        /// <summary>
        /// Genera el análisis léxico, leyendo el siguiente simbolo que se encuentre 
        /// en la fuente dada
        /// </summary>
        /// <returns></returns>
        public void SigSimbolo()
        {

            int estadoAnterior, entrada;
            
            continua = true;
            simbolo = "";

            //Revisamos si es una palabra reservada (if, else, while, return, void, int, float, string)
            tipo = EsPalabraReservada(ref simbolo);
            if (tipo != -1)
                return;

            estado = estadoAnterior = q00;
            while(continua)
            {
                c = SigCaracter();
                if (!char.IsWhiteSpace(c))
                {
                    numeroLineaUltimoSimbolo = numeroLinea;
                }

                if (EsLetra(c))
                    entrada = 0;
                else if (EsDigito(c))
                    entrada = 1;
                else if (c == '.')
                    entrada = 2;
                else if (c == '"')
                    entrada = 3;
                else if (c == '+' || c == '-')
                    entrada = 4;
                else if (c == '*' || c == '/')
                    entrada = 5;
                else if (c == '<' || c == '>')
                    entrada = 6;
                else if (c == '|')
                    entrada = 7;
                else if (c == '&')
                    entrada = 8;
                else if (c == '!')
                    entrada = 9;
                else if (c == '=')
                    entrada = 10;
                else if (c == ';')
                    entrada = 11;
                else if (c == ',')
                    entrada = 12;
                else if (c == '(')
                    entrada = 13;
                else if (c == ')')
                    entrada = 14;
                else if (c == '{')
                    entrada = 15;
                else if (c == '}')
                    entrada = 16;
                else if (c == '$')
                    entrada = 17;
                else if (EsBlanco(c))
                    entrada = 18;
                else
                    entrada = 19;
                estadoAnterior = estado;
                estado = CalculaEstado(entrada);
                simbolo += c;
                if (estado == FIN)
                {
                    switch (estadoAnterior)
                    {
                        case q00:
                            break;
                        case q01:
                            tipo = Simbolos.OPERADOR_ADICION;
                            break;
                        case q02:
                            tipo = Simbolos.OPERADOR_MULTIPLICACION;
                            break;
                        case q04:
                            tipo = Simbolos.OPERADOR_OR;
                            break;
                        case q06:
                            tipo = Simbolos.OPERADOR_AND;
                            break;
                        case q07:
                            tipo = Simbolos.OPERADOR_NOT;
                            break;
                        case q08:
                            tipo = Simbolos.OPERADOR_ASIGNACION;
                            break;
                        case q09: case q10:
                            tipo = Simbolos.OPERADOR_IGUALDAD;
                            break;
                        case q11:
                            tipo = Simbolos.PUNTO_Y_COMA;
                            break;
                        case q12:
                            tipo = Simbolos.COMA;
                            break;
                        case q13:
                            tipo = Simbolos.PARENTESIS_INICIO;
                            break;
                        case q14:
                            tipo = Simbolos.PARENTESIS_FIN;
                            break;
                        case q15:
                            tipo = Simbolos.LLAVES_INICIO;
                            break;
                        case q16:
                            tipo = Simbolos.LLAVES_FIN;
                            break;
                        case q17:
                            tipo = Simbolos.PESOS;
                            break;
                        case q18:
                            tipo = Simbolos.ENTERO;
                            break;
                        case q20:
                            tipo = Simbolos.REAL;
                            break;
                        case q22:
                            tipo = Simbolos.CADENA;
                            break;
                        case q23:
                            tipo = Simbolos.IDENTIFICADOR;
                            break;
                        case q24: case q25:
                            tipo = Simbolos.OPERADOR_RELACIONAL;
                            break;
                    }
                    if (EsBlanco(c))
                    {
                        simbolo = simbolo.Remove(simbolo.Length - 1);
                        break;
                    }
                    Retroceso();
                    break;
                }
                else if (estado == ERR)
                {
                    tipo = Simbolos.ERROR;
                    if (estadoAnterior == q23 || estadoAnterior == q19 || estadoAnterior == q03 || estadoAnterior == q05 || estadoAnterior == q21)
                        Retroceso();
                    break;
                }
            }

            //Si es un sólo blanco
            if (estado == FIN && estadoAnterior == q00)
                SigSimbolo();
        }

        //================================================================================

        /// <summary>
        /// Calcula el estado siguiente a partir del estado actual, y la entrada proporcionada
        /// </summary>
        /// <param name="entrada">La entrada</param>
        /// <returns></returns>
        private int CalculaEstado(int entrada)
        {
            return tablaEstados[estado, entrada];
        }

        //================================================================================

        /// <summary>
        /// Revisa si a partir del índice actual podemos localizar una palabra reservada 
        /// de flujo de instrucciones, en la fuente; si encuentra cualquier palabra reservada 
        /// la almacena en palabraReservada y devuelve su tipo de simbolo, en otro caso 
        /// sólo devuelve -1
        /// </summary>
        /// <param name="palabraReservada">Aquí se almacena la palabra reservada en caso de 
        /// encontrarse alguna</param>
        /// <returns></returns>
        private int EsPalabraReservada(ref String palabraReservada)
        {
            if (BuscaPalabra("if"))
            {
                palabraReservada = "if";
                return Simbolos.IF;
            }
            else if (BuscaPalabra("else"))
            {
                palabraReservada = "else";
                return Simbolos.ELSE;
            }
            else if (BuscaPalabra("while"))
            {
                palabraReservada = "while";
                return Simbolos.WHILE;
            }
            else if (BuscaPalabra("return"))
            {
                palabraReservada = "return";
                return Simbolos.RETURN;
            }
            else if (BuscaPalabra("int"))
            {
                palabraReservada = "int";
                return Simbolos.TIPO;
            }
            else if (BuscaPalabra("float"))
            {
                palabraReservada = "float";
                return Simbolos.TIPO;
            }
            else if (BuscaPalabra("string"))
            {
                palabraReservada = "string";
                return Simbolos.TIPO;
            }
            else if (BuscaPalabra("void"))
            {
                palabraReservada = "void";
                return Simbolos.TIPO;
            }
            return -1;
        }

        //================================================================================

        /// <summary>
        /// Busca una palabra especifica en la fuente, si la encuentra adelanta el indice
        /// en su longitud, guarda la línea actual y devuelve un true, false en caso
        /// contrario
        /// </summary>
        /// <param name="palabra">La palabra a buscar</param>
        /// <returns></returns>
        private bool BuscaPalabra(String palabra)
        {
            //Si alcansamos a buscar la palabra en la fuente (desde el indice más la longitud 
            //de la palabra, que no se pase de la longitud de la fuente), y si la encontramos
            if (indice + palabra.Length <= fuente.Length && fuente.Substring(indice, palabra.Length) == palabra)
            {
                //Adelantamos el índice en la longitud de la palabra
                indice += palabra.Length;

                //Guardamos la línea actual
                numeroLineaUltimoSimbolo = numeroLinea;
                return true;
            }
            return false;
        }

        //================================================================================

        #region Flujo de fuente y administración de estados

        /// <summary>
        /// Devuelve el siguiente caracter dentro de la fuente analizada, o el caracter de 
        /// fin de entrada, si se llego al fin de la misma
        /// </summary>
        /// <returns></returns>
        private char SigCaracter()
        {
            return Terminado() ? '$' : fuente[indice++];
        }

        //================================================================================

        /// <summary>
        /// Almacena el estado dado, y concatena el caracter actualmente leído en simbolo
        /// </summary>
        /// <param name="estado">El estado a almacenar</param>
        private void SigEstado(int estado)
        {
            this.estado = estado;
            simbolo += c;
        }

        //================================================================================

        /// <summary>
        /// Toma el estado dado y el caracter actualmente leído, y los alamacena para 
        /// posteriormente detener el análisis del simbolo
        /// </summary>
        /// <param name="estado">El estado actual obtenido en el análisis léxico</param>
        private void Aceptacion(int estado)
        {
            SigEstado(estado);
            continua = false;
        }

        //================================================================================

        /// <summary>
        /// Devuelve true si se llego al fin de la entrada analizada, false en caso contrario
        /// </summary>
        /// <returns></returns>
        private bool Terminado()
        {
            return indice >= fuente.Length;
        }

        //================================================================================

        /// <summary>
        /// Si no se ha llegado al fin de la fuente, retrocede el índice de los caracteres y 
        /// evita continuar el análisis del simbolo
        /// </summary>
        private void Retroceso()
        {
            simbolo = simbolo.Remove(simbolo.Length - 1);
            if (c != '$')
                indice--;
            continua = false;
        }

        #endregion


        #endregion

        //================================================================================

        #region Validación de caracteres

        /// <summary>
        /// Revisa si un caracter es considerado una letra; devuelve true en caso de ser 
        /// una letra, y false en caso contrario
        /// </summary>
        /// <param name="caracter">El caracter a revisar</param>
        /// <returns></returns>
        private bool EsLetra(char caracter)
        {
            return Char.IsLetter(caracter) || caracter == '_';
        }

        //================================================================================

        /// <summary>
        /// Revisa si un caracter es considerado un digito; devuelve true en caso de ser 
        /// un digito, y false en caso contrario
        /// </summary>
        /// <param name="caracter">El caracter a revisar</param>
        /// <returns></returns>
        private bool EsDigito(char caracter)
        {
            return Char.IsDigit(caracter);
        }

        //================================================================================

        /// <summary>
        /// Revisa si un caracter es considerado un blanco; devuelve true en caso de ser 
        /// un blanco, y false en caso contrario
        /// </summary>
        /// <param name="caracter">El caracter a revisar</param>
        /// <returns></returns>
        private bool EsBlanco(char caracter)
        {
            //Si encontramos un salto de línea, incrementamos el número de línea
            if (caracter == Environment.NewLine.ToCharArray()[0])
            {
                if (saltoLinea)
                {
                    numeroLinea++;
                }
                saltoLinea = !saltoLinea;
            }
            return Char.IsWhiteSpace(caracter);
        }
        #endregion
    }
}
