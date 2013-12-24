var fs = require("fs");
var gui = require('nw.gui');
var win = gui.Window.get();


var FileReader = new Class({
    initialize: function(archivo) {
        this.content = fs.readFileSync(archivo, 'utf8');
    },
    readAll: function() {
        return this.content.split("\n");
    },
    readEval: function() {
        return JSON.parse(this.content);
    },
    readText: function() {
        return (this.content);
    }
});

var FileWriter = new Class({
    initialize: function(file) {
        this.file = file;
    },
    replace: function(text) {
        return fs.writeFileSync(this.file, text);
    },
    append: function(text) {
        return fs.appendFileSync(this.file, text);
    }
});