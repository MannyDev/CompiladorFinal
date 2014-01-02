var fs = require("fs");
var gui = require('nw.gui');
var win = gui.Window.get();
var path = require("path");

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

String.implement({
    
    Remove: function(start){
        return this.truncate(start,"").toString();
    },
    
    Length: function(start,count){
        return this.length;
    },
    
    Substring: function(start,count){
        return this.substring(start,count);
    },

    IsWhiteSpace: function(){
        return this.test(/[\u0020\u1680\u180E\u2000\u2001\u2002\u2003\u2004\u2005\u2006\u2007\u2008\u2009\u200A\u202F\u205F\u3000\u2028\u2029\u0009\u000A\u000B\u000C\u000D\u0085\u00A0]/);
    },

    EsLetra: function(){
        return this.test(/[A-Za-z_]/);
    },

    EsDigito: function(){
        return this.test(/[0-9]/);
    },

    count: function(a){
        try{return this.match(new RegExp(a,"g")).length;}catch(e){return 0;}
    }

});

