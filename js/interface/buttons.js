var vocales = [
    "a","a","a","e","e","e","i","o","o","o","u"
]

var consonantes = [
    "b","b","c","c","d","d","f","g","j","l","m","m","n","p","p","r","r","rr","s","t","v"
]



var silaba = function(){
    return consonantes.getRandom() + vocales.getRandom();
}

var palabra = function(){
    var temp = "";
    Number.random(2,5).times(function(){temp += silaba();});
    return temp;
}

var frase = function(palabras){
    var temp = "";
    palabras.times(function(){temp += palabra() + " ";});
    return temp;
}

var t = [
    "a","1","2","3","4","5","b","c","d","e","u","g","h","w","j","k","l","m","n",
    "f","p","q","r","s","ñ","t","x","v","i","o","y","z","6","7","8","9","0"," "
];

var t1 = Array.clone(t).reverse();

var f = function(f){
    var tmp = "";
    f.toLowerCase().split("").each(function(l){
        tmp+=t1[t.indexOf(l)]==undefined?l:t1[t.indexOf(l)];
    }); 
    return tmp;
}

var BlueButton = new Class({
    
        Extends: Elements, // hereda todos los metodos de un Elemento
    
        initialize: function(value){
            var x = new Element("button",{
                class: "button button-flat-primary",
                text: value
            });
            return x;
        }
        
});

var GreenButton = new Class({
    
        Extends: Elements, // hereda todos los metodos de un Elemento
    
        initialize: function(value){
            var x = new Element("button",{
                class: "button button-flat-action",
                text: value
            });
            return x;
        }
        
});

var RedButton = new Class({
    
        Extends: Elements, // hereda todos los metodos de un Elemento
    
        initialize: function(value){
            var x = new Element("button",{
                class: "button button-flat-caution",
                text: value
            });
            return x;
        }
        
});
