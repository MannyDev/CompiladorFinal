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
    GATO: 24,

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
            case this.GATO:
                return "Simbolo de #";
            default:
                return "Error";
        }
    }
}




var q00 = 0,
    q01 = 1,
    q02 = 2,
    q03 = 3,
    q04 = 4,
    q05 = 5,
    q06 = 6,
    q07 = 7,
    q08 = 8,
    q09 = 9,
    q10 = 10,
    q11 = 11,
    q12 = 12,
    q13 = 13,
    q14 = 14,
    q15 = 15,
    q16 = 16,
    q17 = 17,
    q18 = 18,
    q19 = 19,
    q20 = 20,
    q21 = 21,
    q22 = 22,
    q23 = 23,
    q24 = 24,
    q25 = 25,
    q26 = 26,
    q29 = 29,
    FIN = 27,
    ERR = 28;

var tablaEstados = [

//   (_)                                                                                          ( )
//  (a-z) (0-9) (.)  (") (+,-) (*,/) (<,>) (|)  (&)  (!)  (=)  (;)  (,)  (()  ())  ({)  (})  ($)  (\t) (otro)
//  (A-Z)                                                                                         (\n)
    [q23, q18, ERR, q21, q01, q02, q24, q03, q05, q07, q08, q11, q12, q13, q14, q15, q16, q17, FIN, ERR, q29], //q00
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q01
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q02
    [ERR, ERR, ERR, ERR, ERR, ERR, ERR, q04, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, FIN], //q03
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q04
    [ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, q06, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, FIN], //q05
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q06
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, q10, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q07
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, q09, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q08
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q09
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q10
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q11
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q12
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q13
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q14
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q15
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q16
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q17
    [FIN, q18, q19, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q18
    [ERR, q20, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, FIN], //q19
    [FIN, q20, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q20
    [q21, q21, q21, q22, q21, q21, q21, q21, q21, q21, q21, q21, q21, q21, q21, q21, q21, ERR, q21, q21, FIN], //q21
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q22
    [q23, q23, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q23
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, q25, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q24
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q25
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q26
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q27
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q28
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN]  //q29
];
