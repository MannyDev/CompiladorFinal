using System;

namespace Compiladores
{
    
    /// <summary>
    /// Representa los diferentes simbolos, o elementos lexicos, que acepta el analizador
    /// </summary>
    public class Simbolos
    {
        public const int ERROR = -1;
        public const int IDENTIFICADOR = 0;
        public const int ENTERO = 1;
        public const int REAL = 2;
        public const int CADENA = 3;
        public const int TIPO = 4; //int, float, string, void
        public const int OPERADOR_ADICION = 5; //+, -
        public const int OPERADOR_MULTIPLICACION = 6; //*, /
        public const int OPERADOR_RELACIONAL = 7; //<, <=, >, >=
        public const int OPERADOR_OR = 8; //||
        public const int OPERADOR_AND = 9; //&&
        public const int OPERADOR_NOT = 10; //!
        public const int OPERADOR_IGUALDAD = 11; //==, !=
        public const int PUNTO_Y_COMA = 12;
        public const int COMA = 13;
        public const int PARENTESIS_INICIO = 14;
        public const int PARENTESIS_FIN = 15;
        public const int LLAVES_INICIO = 16;
        public const int LLAVES_FIN = 17;
        public const int OPERADOR_ASIGNACION = 18;
        public const int IF = 19;
        public const int WHILE = 20;
        public const int RETURN = 21;
        public const int ELSE = 22;
        public const int PESOS = 23;

        //================================================================================

        #region ToString

        /// <summary>
        /// Devuelve el tipo del simbolo solicitado, en forma de cadena
        /// </summary>
        /// <param name="simbolo">El simbolo al cual devolver su identificación en cadena</param>
        /// <returns></returns>
        public static String ToString(int simbolo)
        {
            switch (simbolo)
            {
                case IDENTIFICADOR:
                    return "Identificador";
                case ENTERO:
                    return "Entero";
                case REAL:
                    return "Real";
                case CADENA:
                    return "Cadena";
                case TIPO:
                    return "Tipo";
                case OPERADOR_ADICION:
                    return "Operador adición";
                case OPERADOR_MULTIPLICACION:
                    return "Operador multiplicación";
                case OPERADOR_RELACIONAL:
                    return "Operador relacional";
                case OPERADOR_OR:
                    return "Operador Or";
                case OPERADOR_AND:
                    return "Operador And";
                case OPERADOR_NOT:
                    return "Operador Not";
                case OPERADOR_IGUALDAD:
                    return "Operador igualdad";
                case PUNTO_Y_COMA:
                    return "Punto y coma";
                case COMA:
                    return "Coma";
                case PARENTESIS_INICIO:
                    return "Parentesis inicio";
                case PARENTESIS_FIN:
                    return "Parentesis fin";
                case LLAVES_INICIO:
                    return "Llaves inicio";
                case LLAVES_FIN:
                    return "Llaves fin";
                case OPERADOR_ASIGNACION:
                    return "Operador asignación";
                case IF:
                    return "Palabra reservada if";
                case WHILE:
                    return "Palabra reservada while";
                case RETURN:
                    return "Palabra reservada return";
                case ELSE:
                    return "Palabra reservada else";
                case PESOS:
                    return "Fin de la Entrada";
                default:
                    return "Error";
            }
        }

        #endregion
    }
}
