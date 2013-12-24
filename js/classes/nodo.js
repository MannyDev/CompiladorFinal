var Nodo = new Class({
    simbolo: null,
    siguiente: null,

    initialize: function() {
        this.siguiente = null;
    }
});

var Identificador = new Class({
    Extends: Nodo,

    initialize: function(pila) {
        pila.Pop();
        this.simbolo = pila.Pop().elemento;
    }
});

var Entero = new Class({
    Extends: Nodo,

    initialize: function(pila) {
        pila.Pop();
        this.simbolo = pila.Pop().elemento;
    }
});
