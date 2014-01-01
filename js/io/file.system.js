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
            [q23,  q18, ERR, q21, q01,  q02,  q24, q03, q05, q07, q08, q11, q12, q13, q14, q15, q16, q17, FIN,  ERR], //q00
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q01
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q02
            [ERR,  ERR, ERR, ERR, ERR,  ERR,  ERR, q04, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR,  ERR], //q03
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q04
            [ERR,  ERR, ERR, ERR, ERR,  ERR,  ERR, ERR, q06, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR,  ERR], //q05
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q06
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, q10, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q07
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, q09, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q08
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q09
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q10
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q11
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q12
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q13
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q14
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q15
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q16
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q17
            [FIN,  q18, q19, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q18
            [ERR,  q20, ERR, ERR, ERR,  ERR,  ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR,  ERR], //q19
            [FIN,  q20, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q20
            [q21,  q21, q21, q22, q21,  q21,  q21, q21, q21, q21, q21, q21, q21, q21, q21, q21, q21, ERR, q21,  q21], //q21
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q22
            [q23,  q23, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q23
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, q25, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN], //q24
            [FIN,  FIN, FIN, FIN, FIN,  FIN,  FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN, FIN,  FIN] //q25
        ];
