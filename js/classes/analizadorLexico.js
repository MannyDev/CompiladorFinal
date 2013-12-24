

String.implement({
    
    Remove: function(start){
        return this.truncate(start,"");
    },
    
    Length: function(start,count){
        return this.length;
    },
    
    Substring: function(start,count){
        return this.substring(start,count);
    }

});


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
    FIN = 27,
    ERR = 28;

var tablaEstados = [
    //   (_)                                                                                          ( )
    //  (a-z) (0-9) (.)  (") (+,-) (*,/) (<,>) (|)  (&)  (!)  (=)  (;)  (,)  (()  ())  ({)  (})  ($)  (\t) (otro)
    //  (A-Z)                                                                                         (\n)
    [q24, q18, ERR, q21, q01, q02, q25, q03, q05, q07, q08, q11, q12, q13, q14, q15, q16, q17, FIN, ERR], //q00
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q01
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q02
    [ERR, ERR, ERR, ERR, ERR, ERR, ERR, q04, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR], //q03
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q04
    [ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, q06, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR], //q05
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q06
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, q10, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q07
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, q09, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q08
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q09
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q10
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q11
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q12
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q13
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q14
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q15
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q16
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q17
    [FIN, q18, q19, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q18
    [ERR, q20, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR], //q19
    [FIN, q20, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q20
    [q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, ERR, q22, q22], //q21
    [q22, q22, q22, q23, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, q22, ERR, q22, q22], //q22
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q23
    [q24, q24, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q24
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, q26, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN], //q25
    [FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN] //q26
];

AnalizadorLexico = new Class({

    fuente: null,
    indice: null,
    continua: null,
    c: null,
    estado: null,
    simbolo: null,
    tipo: null,
    numeroLinea: 1,
    numeroLineaUltimoSimbolo: 1,
    cambiar: false,

    Simbolo: function(){return this.simbolo;},
    Tipo: function(){return this.tipo;},
    NumeroLinea: function(){return this.numeroLinea;},
    NumeroLineaUltimoSimbolo: function(){return this.numeroLineaUltimoSimbolo;},

    initialize: function(i) {
        this.entrada = i;
        this.fuente = i;
        this.indice = 0;
    },

    SigSimbolo: function() {
        var estadoAnterior, entrada;

        this.continua = true;
        this.simbolo = "";

        this.tipo = this.EsPalabraReservada(this.simbolo);
        if (this.tipo != -1)
            return;

        this.tipo = this.EsTipo(this.simbolo);
        if (this.tipo != -1)
            return;

        this.estado = estadoAnterior = q00;

        while (this.continua) {
            this.c = this.SigCaracter();

            if (this.EsLetra(this.c))
                entrada = 0;
            else if (this.EsDigito(this.c))
                entrada = 1;
            else if (this.c == '.')
                entrada = 2;
            else if (this.c == '"')
                entrada = 3;
            else if (this.c == '+' || this.c == '-')
                entrada = 4;
            else if (this.c == '*' || this.c == '/')
                entrada = 5;
            else if (this.c == '<' || this.c == '>')
                entrada = 6;
            else if (this.c == '|')
                entrada = 7;
            else if (this.c == '&')
                entrada = 8;
            else if (this.c == '!')
                entrada = 9;
            else if (this.c == '=')
                entrada = 10;
            else if (this.c == ';')
                entrada = 11;
            else if (this.c == ',')
                entrada = 12;
            else if (this.c == '(')
                entrada = 13;
            else if (this.c == ')')
                entrada = 14;
            else if (this.c == '{')
                entrada = 15;
            else if (this.c == '}')
                entrada = 16;
            else if (this.c == '$')
                entrada = 17;
            else if (this.EsBlanco(this.c))
                entrada = 18;
            else
                entrada = 19;

            estadoAnterior = this.estado;
            this.estado = this.CalculaEstado(entrada);
            this.simbolo += this.c;

            if (this.estado == FIN) {
                switch (estadoAnterior) {
                    case q00:
                        //estado = estadoAnterior = q00;
                        break;
                    case q01:
                        this.tipo = Simbolo.OPERADOR_ADICION;
                        break;
                    case q02:
                        this.tipo = Simbolo.OPERADOR_MULTIPLICACION;
                        break;
                    case q04:
                        this.tipo = Simbolo.OPERADOR_OR;
                        break;
                    case q06:
                        this.tipo = Simbolo.OPERADOR_AND;
                        break;
                    case q07:
                        this.tipo = Simbolo.OPERADOR_NOT;
                        break;
                    case q08:
                        this.tipo = Simbolo.OPERADOR_ASIGNACION;
                        break;
                    case q09:
                        this.tipo = Simbolo.OPERADOR_RELACIONAL;
                        break;
                    case q10:
                        this.tipo = Simbolo.OPERADOR_RELACIONAL;
                        break;
                    case q11:
                        this.tipo = Simbolo.PUNTO_Y_COMA;
                        break;
                    case q12:
                        this.tipo = Simbolo.COMA;
                        break;
                    case q13:
                        this.tipo = Simbolo.PARENTESIS_INICIO;
                        break;
                    case q14:
                        this.tipo = Simbolo.PARENTESIS_FIN;
                        break;
                    case q15:
                        this.tipo = Simbolo.LLAVES_INICIO;
                        break;
                    case q16:
                        this.tipo = Simbolo.LLAVES_FIN;
                        break;
                    case q17:
                        this.tipo = Simbolo.PESOS;
                        break;
                    case q18:
                        this.tipo = Simbolo.ENTERO;
                        break;
                    case q20:
                        this.tipo = Simbolo.REAL;
                        break;
                    case q23:
                        this.tipo = Simbolo.CADENA;
                        break;
                    case q24:
                        this.tipo = Simbolo.IDENTIFICADOR;
                        break;
                    case q25:
                        this.tipo = Simbolo.OPERADOR_RELACIONAL;
                        break;
                    case q26:
                        this.tipo = Simbolo.OPERADOR_RELACIONAL;
                        break;
                }
                if (this.EsBlanco(this.c)) {
                    this.simbolo = simbolo.Remove(simbolo.Length - 1);
                    break;
                }
                this.Retroceso();
                break;
            } else if (this.estado == ERR) {
                this.tipo = Simbolo.ERROR;
                if (estadoAnterior == q24 || estadoAnterior == q19 || estadoAnterior == q03 || estadoAnterior == q05 || estadoAnterior == q22)
                    this.Retroceso();
                break;
            }
        }

        if (this.estado == FIN && estadoAnterior == q00)
            this.SigSimbolo();
    },

    CalculaEstado: function(entrada) {
        return tablaEstados[this.estado, entrada];
    },

    EsPalabraReservada: function(palabraReservada) {
        if (this.indice + 2 <= this.fuente.length && this.fuente.substring(this.indice, 2) == "if") {
            palabraReservada = "if";
            this.indice += 2;
            return Simbolo.IF;
        } else if (this.indice + 4 <= this.fuente.length && this.fuente.substring(this.indice, 4) == "else") {
            palabraReservada = "else";
            this.indice += 4;
            return Simbolo.ELSE;
        } else if (this.indice + 5 <= this.fuente.length && this.fuente.substring(this.indice, 5) == "while") {
            palabraReservada = "while";
            indice += 5;
            return Simbolo.WHILE;
        } else if (this.indice + 6 <= this.fuente.length && this.fuente.substring(this.indice, 6) == "return") {
            palabraReservada = "return";
            this.indice += 6;
            return Simbolo.RETURN;
        }
        return -1;
    },


    EsTipo: function(tipo) {
        if (this.indice + 3 <= this.fuente.length && this.fuente.substring(this.indice, 3) == "int") {
            tipo = "int";
            this.indice += 3;
            return Simbolo.TIPO;
        } else if (this.indice + 5 <= this.fuente.length && this.fuente.substring(this.indice, 5) == "float") {
            tipo = "float";
            this.indice += 5;
            return Simbolo.TIPO;
        } else if (this.indice + 4 <= this.fuente.length && this.fuente.substring(this.indice, 4) == "void") {
            tipo = "void";
            this.indice += 4;
            return Simbolo.TIPO;
        }
        return -1;
    },

    Entrada: function(fuente) {
        this.indice = 0;
        this.simbolo = "";
        this.fuente = fuente;
    },

    SigCaracter: function() {
        return this.Terminado() ? '$' : this.fuente[this.indice++];
    },

    SigEstado: function(estado) {
        this.estado = estado;
        this.simbolo += this.c;
    },

    Aceptacion: function(estado) {
        this.SigEstado(estado);
        this.continua = false;
    },

    Terminado: function() {
        return this.indice >= this.fuente.length;
    },

    Retroceso: function() {
        this.simbolo = this.simbolo.Remove(this.simbolo.Length - 1);
        if (this.c != '$')
            this.indice--;
        this.continua = false;
    },

    EsLetra: function(caracter) {
        return caracter.test(/[A-Za-z_]/);
    },

    EsDigito: function(caracter) {
        return caracter.test(/[0-9]/);
    },

    EsBlanco: function(caracter) {
        return caracter.test(/[\s\t\n]/);
    },









    tipoAcad: function() {

        var cad = "";

        switch (this.tipo) {
            case Simbolo.IDENTIFICADOR:
                cad = "Identificador";
                break;
            case Simbolo.OPADIC:
                cad = "Op. Adicion";
                break;
            case Simbolo.OPMULT:
                cad = "Op. Multiplicacion";
                break;
            case Simbolo.PESOS:
                cad = "Fin de la Entrada";
                break;
            case Simbolo.ENTERO:
                cad = "Entero";
                break;
            case Simbolo.REAL:
                cad = "Real";
                break;
            case Simbolo.OPASIGNACION:
                cad = "Op. Asignacion";
                break;
            case Simbolo.OPNOT:
                cad = "Op. Not";
                break;
            case Simbolo.OPAND:
                cad = "Op. And";
                break;
            case Simbolo.OPOR:
                cad = "Op. Or";
                break;
            case Simbolo.PUNTOCOMA:
                cad = "Punto y Coma";
                break;
            case Simbolo.OPRELAC:
                cad = "Op. Relacional";
                break;
            case Simbolo.ERROR:
                cad = "ERROR";
                break;
            case Simbolo.PALABRARESERVADA:
                cad = "Palabra Reservada";
                break;
            case Simbolo.PARENTESIS:
                cad = "Parentesis";
                break;
            case Simbolo.LLAVE:
                cad = "Llave";
                break;
        }

        return cad;

    },

    sigSimbolo: function() {

        this.estado = 0;
        this.continua = true;
        this.simbolo = "";

        while (this.continua) {

            this.c = this.sigCaracter();

            switch (this.estado) {
                case 0:
                    if (this.c == '+' || this.c == '-') this.aceptacion(2);
                    else
                    if (this.c == '$') this.aceptacion(3);
                    else
                    if (this.c == '*' || this.c == '/') this.aceptacion(4);
                    else
                    if (this.esDigito(this.c)) this.sigEstado(5);
                    else
                    if (this.c == '=') this.sigEstado(19);
                    else
                    if (this.c == '!') this.sigEstado(25);
                    else
                    if (this.c == '&') this.sigEstado(12);
                    else
                    if (this.c == '|') this.sigEstado(14);
                    else
                    if (this.c == ';') this.aceptacion(16);
                    else
                    if (this.c == '<' || this.c == '>') this.sigEstado(17);
                    else
                    if (this.esLetra(this.c)) this.sigEstado(20);
                    else
                    if (this.c == '(' || this.c == ')') this.aceptacion(23);
                    else
                    if (this.c == '{' || this.c == '}') this.aceptacion(24);
                    break;
                case 5:
                    if (this.esDigito(this.c)) this.sigEstado(5);
                    else
                    if (this.c == '.') this.sigEstado(6);
                    else {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(8);
                    }
                    break;
                case 6:
                    if (this.esDigito(this.c)) this.sigEstado(7);
                    else {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(-1);
                    }
                    break;
                case 7:
                    if (this.esDigito(this.c)) this.sigEstado(7);
                    else {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(9);
                    }
                    break;
                case 12:
                    if (this.c == '&') this.aceptacion(13);
                    else {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(-1);
                    }
                    break;
                case 14:
                    if (this.c == '|') this.aceptacion(15);
                    else {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(-1);
                    }
                    break;
                case 17:
                    if (this.c == '=') this.aceptacion(18);
                    else {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(18);
                    }
                    break;
                case 19:
                    if (this.c == '=') this.aceptacion(18);
                    else {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(10);
                    }
                    break;
                case 20:
                    if (this.esLetra(this.c) || this.esDigito(this.c)) this.sigEstado(20);
                    else
                    if (this.simbolo == "if" || this.simbolo == "else" || this.simbolo == "while" || this.simbolo == "return" || this.simbolo == "int" || this.simbolo == "float" || this.simbolo == "for") {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(21);
                    } else {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(22);
                    }
                    break;
                case 25:
                    if (this.c == '=') this.aceptacion(18);
                    else {
                        this.retroceso();
                        this.c = ' ';
                        this.aceptacion(11);
                    }
                    break;
            }
        }

        switch (this.estado) {
            case -1:
                this.tipo = Simbolo.ERROR;
                break;
            case 2:
                this.tipo = Simbolo.OPADIC;
                break;
            case 3:
                this.tipo = Simbolo.PESOS;
                break;
            case 4:
                this.tipo = Simbolo.OPMULT;
                break;
            case 8:
                this.tipo = Simbolo.ENTERO;
                break;
            case 9:
                this.tipo = Simbolo.REAL;
                break;
            case 10:
                this.tipo = Simbolo.OPASIGNACION;
                break;
            case 11:
                this.tipo = Simbolo.OPNOT;
                break;
            case 13:
                this.tipo = Simbolo.OPAND;
                break;
            case 15:
                this.tipo = Simbolo.OPOR;
                break;
            case 16:
                this.tipo = Simbolo.PUNTOCOMA;
                break;
            case 18:
                this.tipo = Simbolo.OPRELAC;
                break;
            case 21:
                this.tipo = Simbolo.PALABRARESERVADA;
                break;
            case 22:
                this.tipo = Simbolo.IDENTIFICADOR;
                break;
            case 23:
                this.tipo = Simbolo.PARENTESIS;
                break;
            case 24:
                this.tipo = TipoSimbolo.LLAVE;
                break;
                dafault: this.tipo = TipoSimbolo.ERROR;
        }

        return this.tipo;
    },

    sigCaracter: function() {
        if (this.terminado()) return '$';
        return this.fuente[this.indice++];
    },


    sigEstado: function(estado) {
        this.estado = estado;
        this.simbolo += this.c;
    },

    aceptacion: function(estado) {
        this.sigEstado(estado);
        this.continua = false;
    },

    terminado: function() {
        return this.indice >= this.fuente.length;
    },

    esLetra: function(c) {
        return (c).test(/^[A-Za-z_]$/);
    },


    esDigito: function(c) {
        return (c).test(/^\d$/);
    },

    esEspacio: function(c) {
        return c == ' ' || c == '\t';
    },


    retroceso: function() {
        if (this.c != '$') this.indice--;
        this.continua = false;
    }
})