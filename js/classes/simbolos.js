var Simbolos = {

    ERROR: -1,
    IDENTIFICADOR: 0,
    ENTERO: 1,
    REAL: 2,
    CADENA: 3,
    TIPO: 4, //int, float void
    OPERADOR_ADICION: 5, //1, //+, -
    OPERADOR_MULTIPLICACION: 6, //*, /
    OPERADOR_RELACIONAL: 7, //<, <=, >, >=
    OPERADOR_OR: 8, //||
    OPERADOR_AND: 9, //&&
    OPERADOR_NOT: 10, //!
    OPERADOR_IGUALDAD: 11, //==, !=
    PUNTO_Y_COMA: 12,
    COMA: 13,
    PARENTESIS_INICIO: 14,
    PARENTESIS_FIN: 15,
    LLAVES_INICIO: 16,
    LLAVES_FIN: 17,
    OPERADOR_ASIGNACION: 18,
    IF: 19,
    WHILE: 20,
    RETURN: 21,
    ELSE: 22,
    PESOS: 23,

    ToString: function(simbolo) {
        switch (simbolo) {
            case this.IDENTIFICADOR:
                return "Identificador";
            case this.ENTERO:
                return "Entero";
            case this.REAL:
                return "Real";
            case this.CADENA:
                return "Cadena";
            case this.TIPO:
                return "Tipo";
            case this.OPERADOR_ADICION:
                return "Operador adición";
            case this.OPERADOR_MULTIPLICACION:
                return "Operador multiplicación";
            case this.OPERADOR_RELACIONAL:
                return "Operador relacional";
            case this.OPERADOR_OR:
                return "Operador Or";
            case this.OPERADOR_AND:
                return "Operador And";
            case this.OPERADOR_NOT:
                return "Operador Not";
            case this.OPERADOR_IGUALDAD:
                return "Operador igualdad";
            case this.PUNTO_Y_COMA:
                return "Punto y coma";
            case this.COMA:
                return "Coma";
            case this.PARENTESIS_INICIO:
                return "Parentesis inicio";
            case this.PARENTESIS_FIN:
                return "Parentesis fin";
            case this.LLAVES_INICIO:
                return "Llaves inicio";
            case this.LLAVES_FIN:
                return "Llaves fin";
            case this.OPERADOR_ASIGNACION:
                return "Operador asignación";
            case this.IF:
                return "Palabra reservada if";
            case this.WHILE:
                return "Palabra reservada while";
            case this.RETURN:
                return "Palabra reservada return";
            case this.ELSE:
                return "Palabra reservada else";
            case this.PESOS:
                return "Fin de la Entrada";
            default:
                return "Error";
        }
    }
}