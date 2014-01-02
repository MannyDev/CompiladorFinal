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
    saltoLinea: false,

    Entrada: {
        set: function(entrada) {

            this.indice = 0;
            this.simbolo = "";
            this.fuente = [entrada, ""].pick();

        }
    },

    Simbolo: {
        get: function() {
            return this.simbolo;
        }
    },

    Tipo: {
        get: function() {
            return this.tipo;
        }
    },

    NumeroLinea: {
        get: function() {
            return this.numeroLinea;
        }
    },

    NumeroLineaUltimoSimbolo: {
        get: function() {
            return this.numeroLineaUltimoSimbolo;
        }
    },

    initialize: function(fuente) {

        this.fuente = [fuente, ""].pick();
        this.numeroLinea = 1;
        this.indice = 0;

    },

    SigSimbolo: function() {

        var estadoAnterior, entrada;

        this.continua = true;
        this.simbolo = "";

        this.estado = estadoAnterior = q00;

        while (this.continua) {

            this.c = this.SigCaracter();

            if (!String.IsWhiteSpace(this.c)) {
                this.numeroLineaUltimoSimbolo = this.numeroLinea;
            }

            if (this.c.EsLetra())
                entrada = 0;
            else if (this.c.EsDigito())
                entrada = 1;
            else if (this.c == '#')
                entrada = 20;
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
                        break;
                    case q01:
                        this.tipo = Simbolos.OPERADOR_ADICION;
                        break;
                    case q02:
                        this.tipo = Simbolos.OPERADOR_MULTIPLICACION;
                        break;
                    case q04:
                        this.tipo = Simbolos.OPERADOR_OR;
                        break;
                    case q06:
                        this.tipo = Simbolos.OPERADOR_AND;
                        break;
                    case q07:
                        this.tipo = Simbolos.OPERADOR_NOT;
                        break;
                    case q08:
                        this.tipo = Simbolos.OPERADOR_ASIGNACION;
                        break;
                    case q09:
                    case q10:
                        this.tipo = Simbolos.OPERADOR_IGUALDAD;
                        break;
                    case q11:
                        this.tipo = Simbolos.PUNTO_Y_COMA;
                        break;
                    case q12:
                        this.tipo = Simbolos.COMA;
                        break;
                    case q13:
                        this.tipo = Simbolos.PARENTESIS_INICIO;
                        break;
                    case q14:
                        this.tipo = Simbolos.PARENTESIS_FIN;
                        break;
                    case q15:
                        this.tipo = Simbolos.LLAVES_INICIO;
                        break;
                    case q16:
                        this.tipo = Simbolos.LLAVES_FIN;
                        break;
                    case q17:
                        this.tipo = Simbolos.PESOS;
                        break;
                    case q18:
                        this.tipo = Simbolos.ENTERO;
                        break;
                    case q20:
                        this.tipo = Simbolos.REAL;
                        break;
                    case q22:
                        this.tipo = Simbolos.CADENA;
                        break;
                    case q23:
                        this.tipo = Simbolos.IDENTIFICADOR;
                        break;
                    case q24:
                    case q25:
                        this.tipo = Simbolos.OPERADOR_RELACIONAL;
                        break;
                    case q29:
                        this.tipo = Simbolos.GATO;
                        break;
                }
                if (this.EsBlanco(this.c)) {
                    this.simbolo = this.simbolo.Remove(this.simbolo.length - 1);
                    break;
                }
                this.Retroceso();
                break;
            } else if (this.estado == ERR) {
                this.tipo = Simbolos.ERROR;
                if (estadoAnterior == q23 || estadoAnterior == q19 || estadoAnterior == q03 || estadoAnterior == q05 || estadoAnterior == q21)
                    this.Retroceso();
                break;
            }
        }


        if (this.tipo == Simbolos.IDENTIFICADOR) {
            this.tipo = this.EsPalabraReservada(this.simbolo);
        }

        if (this.tipo == Simbolos.IDENTIFICADOR) {
            this.tipo = this.EsTipo(this.simbolo);
        }

        //Si es un sólo blanco
        if (this.estado == FIN && estadoAnterior == q00)
            this.SigSimbolo();
    },

    CalculaEstado: function(entrada) {
        return tablaEstados[this.estado][entrada];
    },

    EsPalabraReservada: function(palabraReservada) {

        if (palabraReservada == "if")
            return Simbolos.IF;
        if (palabraReservada == "else")
            return Simbolos.ELSE;
        if (palabraReservada == "while")
            return Simbolos.WHILE;
        if (palabraReservada == "return")
            return Simbolos.RETURN;
        return Simbolos.IDENTIFICADOR;

    },


    EsTipo: function(tipo) {

        if (tipo.test(/int|float|void/))
            return Simbolos.TIPO;
        return Simbolos.IDENTIFICADOR;

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

        this.simbolo = this.simbolo.Remove(this.simbolo.length - 1);
        if (this.c != '$')
            this.indice--;
        this.continua = false;
    },

    EsBlanco: function(caracter) {

        if (caracter == "\n") {
            if (this.saltoLinea) {
                this.numeroLinea++;
            }
            this.saltoLinea = !this.saltoLinea;
        }
        return String.IsWhiteSpace(caracter);
    }
})
