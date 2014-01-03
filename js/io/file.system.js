var fs = require("fs");
var gui = require('nw.gui');
var win = gui.Window.get();
var path = require("path");

var cadena = 'float a,b,c,d;\n\
int e,f,g,h;\n\
\n\
int saluda(int x,int y,float z){\n\
printf ("hola");\n\
a=b+c;\n\
c=d-a;\n\
d=4*5.6;\n\
\n\
if(d){\n\
    printf("");\n\
}\n\
\n\
}\n\
\n\
float compara(){\n\
\n\
if (x<6){\n\
\n\
printf("igual");\n\
}\n\
else{\n\
printf("no igual");\n\
\n\
}\n\
    a=  a>b;\n\
    d=b>=c;\n\
    f=c<=d;\n\
\n\
    while( a != b){\n\
    printf ("Hola mundo");\n\
    return adios;\n\
    }\n\
\n\
}\n\
\n\
void main(int a,float a){\n\n\
    int a,b;\n\
    float c;\n\
\n\
    y= (2!=3) || (z==b);\n\
    x= (2!=3) && (z==b);\n\
    \n\
    y= f(a,b,c)+2 / g(-z);\n\
    return a;\n\
}'

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

    Remove: function(start) {
        return this.truncate(start, "").toString();
    },

    Length: function(start, count) {
        return this.length;
    },

    Substring: function(start, count) {
        return this.substring(start, count);
    },

    IsWhiteSpace: function() {
        return this.test(/[\u0020\u1680\u180E\u2000\u2001\u2002\u2003\u2004\u2005\u2006\u2007\u2008\u2009\u200A\u202F\u205F\u3000\u2028\u2029\u0009\u000A\u000B\u000C\u000D\u0085\u00A0]/);
    },

    EsLetra: function() {
        return this.test(/[A-Za-z_]/);
    },

    EsDigito: function() {
        return this.test(/[0-9]/);
    },

    count: function(a) {
        try {
            return this.match(new RegExp(a, "g")).length;
        } catch (e) {
            return 0;
        }
    },

    regexIndexOf: function(pattern, startIndex) {
        startIndex = startIndex || 0;
        var searchResult = this.substr(startIndex).search(pattern);
        return (-1 === searchResult) ? -1 : searchResult + startIndex;
    },

    declaracionVariables: function() {
        return this.match(/(int|float|void)[\s\t]+([a-zA-Z_][\w_]*)([\s\t]*,[\s\t]*([a-zA-Z_][\w_]*))*[\s\t]*;/g);
    },

    declaracionFunciones: function() {
        /////////////////////// tipo //// espacios identificador // llaves
        return this.match(/(int|float|void)[\s\t]+([a-zA-Z_][\w_]*)[\s\t]*\(.*\)[\s\t]*\{\}/g);
    },

    contenidoFunciones: function() {
        var funciones = new Array();
        var pilaSemantica = new Array();
        this.split("").each(function(c, i, a) {

            if (c == "{") {
                pilaSemantica.push({
                    c: c,
                    i: i
                });
            } else if (c == "}") {
                var inicio = pilaSemantica.pop({
                    c: c,
                    i: i
                });
                if (pilaSemantica.length == 0)
                    funciones.push(a.join("").substring(inicio.i + 1, i));
            }

        });
        return funciones;
    },

    variablesGlobales: function(){

        var cad = cadena;

        cad.contenidoFunciones().each(function(f){
            cad = cad.replace(f,"");
        });

        return cad.declaracionVariables();

    },

    funciones: function(){

        var cad = cadena;

        cad.contenidoFunciones().each(function(f){
            cad = cad.replace(f,"");
        });

        return cad.declaracionFunciones();

    }

});

Patron = {


    IDENTIFICADOR: "^[a-zA-Z_][\w_]*$",
    IF: "if[\s\t]*\("



}
