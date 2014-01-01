
var NodoSemantico = new Class({

        Extends: Nodo,

        tablaDeSimbolos: null,
        TipoDeAmbito: TipoAmbito.GLOBAL,
        funcionActual: "",
        definicionVariables: false,

        tipoDeDato: null,
        numeroLinea: 1,
        codigoEnsamblador: null,

        //================================================================================

        initialize: function(texto): base(texto) {
            
            this.tipoDeDato = Tipos.VOID;
            this.numeroLinea = AnalizadorLexico.NumeroLineaUltimoSimbolo;
            this.codigoEnsamblador = "";
        }

        ValidaTiposDatos: function() {
            this.tipoDeDato = Tipos.VOID;


            foreach(NodoSemantico nodo in hijos)
                nodo.ValidaTiposDatos();
        }

        //================================================================================

        GeneraCodigoEnsamblador: function() {
            this.codigoEnsamblador = "";
            foreach(NodoSemantico nodo in hijos)
                nodo.GeneraCodigoEnsamblador();
        }
    }
}
