var ElementoPila = new Class({

    id: null,
    elemento: null,
    tipo: null,
    subTipo: null,
    nodo: null,

    EsEstado: function() {
        return false;
    },
    EsTerminal: function() {
        return false;
    },
    EsNoTerminal: function() {
        return false;
    }

});



var Terminal = new Class({
    Extends: ElementoPila,

    initialize: function(id, elemento) {
        this.id = id;
        this.elemento = elemento == null ? "" : elemento;
    },
    EsTerminal: function() {
        return true;
    }

});


var NoTerminal = new Class({
    Extends: ElementoPila,

    initialize: function(id, elemento) {
        this.id = id;
        this.elemento = elemento == null ? "" : elemento;
    },
    EsNoTerminal: function() {
        return true;
    }

});


var Estado = new Class({
    Extends: ElementoPila,

    initialize: function(id) {
        this.id = id;
    },

    Elemento: function() {
        return this.id.toString();
    },

    EsEstado: function() {
        return true;
    }

});