
var separador = function(){return new Element("span", {styles:{padding: "0px 30px"}});};


var ButtonBar = new Class({

    Extends: Elements, // hereda todos los metodos de un Elemento

    initialize: function(value, alt){
        var x = new Element("button",{
            class: "boton_m",
            alt: alt,
            title: alt
        });

        x.adopt(new Element("img", {
            src: "img/icons/"+value+"&16.png",
            alt: alt,
            title: alt,
            styles: {
                opacity: 0.7
            }
        }))

        return x;
    } 

})

var ButtonWindow = new Class({

    Extends: Elements, // hereda todos los metodos de un Elemento

    initialize: function(value, alt){
        var x = new Element("button",{
            class: "boton_w",
            alt: alt,
            title: alt
        });

        x.adopt(new Element("img", {
            src: "img/icons/"+value+"&16.png",
            alt: alt,
            title: alt,
            styles: {
                opacity: 0.7
            }
        }))

        return x;
    } 

})

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
