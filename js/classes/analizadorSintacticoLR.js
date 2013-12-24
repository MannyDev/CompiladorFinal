var Simbolos = Simbolo;

var AnalizadorSintacticoLR = new Class({

    analizadorLexico: null,

    entrada: null,
    fila: null,
    columna: null,
    accion: null,
    pila: null,
    nt: null,
    nodo: null,

    idReglas: [2],
    lonReglas: [1],
    strReglas: ["Termino"],

    tabla: [
        [2, 0, 1],
        [0, -1, 0],
        [0, -2, 0]
    ],

    SetEntrada: function(value) {
        this.entrada = value;
        this.analizadorLexico = new AnalizadorLexico(this.entrada);
        this.pila = new Pila();

    },


    initialize: function(entrada) {
        this.entrada = entrada == null ? "" : entrada;
        this.analizadorLexico = new AnalizadorLexico(this.entrada);
        this.pila = new Pila();
    },

    Analiza: function(salida) {

        this.accion = 0;
        this.pila.Push(new Terminal(Simbolos.PESOS, "$"));
        this.pila.Push(new Estado(0));

        while (true) {
            this.analizadorLexico.SigSimbolo();

            //Buscamos la siguiente acción
            this.SigAccion();

            //Mostrar pila, entrada y accion
            Muestra(salida);

            //Si es positivo es un desplazamiento
            if (this.accion > 0) {
                this.pila.Push(new Terminal(this.analizadorLexico.tipo, this.analizadorLexico.simbolo));
                this.pila.Push(new Estado(this.accion));
            }

            //Sino, si es negativo es una reducción o aceptación
            else if (this.accion < 0) {
                //Estado de aceptación
                if (this.accion == -1) {
                    this.SigAccion();
                    break;
                }

                var posReduccion = (this.accion * -1) - 2; //En positivo menos 1 para hacerla regla, y menos otro del índice del arreglo

                switch (posReduccion) {
                    case 1: //identificador <Termino> ::= <id>
                        this.nodo = new Identificador(this.pila);
                        break;
                    default:
                        //Sacamos de la pila el doble de elementos de la regla de reducción
                        for (var i = 0; i < this.lonReglas[posReduccion] * 2; i++)
                            pila.Pop();
                        break;
                }

                this.fila = this.pila.Peek().id;
                this.columna = this.idReglas[posReduccion];
                this.accion = this.tabla[this.fila, this.columna];

                this.nt = new NoTerminal(this.idReglas[posReduccion], this.strReglas[posReduccion]);
                this.nt.nodo = this.nodo;

                pila.Push(this.nt);
                pila.Push(new Estado(this.accion));

            }

            //Error
            if (this.accion == 0)
                return;
        }
    },

    Muestra: function() {

        var elementos = this.pila.lista;
        var out = "";
        for (var i = elementos.length - 1; i >= 0; i--)
            out += elementos[i].elemento;

        salida.append(out);
        salida.append(this.analizadorLexico.simbolo);
        salida.appendln(this.accion.toString());
    },


    SigAccion: function() {
        this.fila = this.pila.Peek().id;
        this.columna = this.analizadorLexico.Tipo;
        this.accion = this.tabla[this.fila, this.columna];
    }

});