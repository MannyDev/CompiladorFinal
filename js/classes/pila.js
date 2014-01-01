 Pila = new Class({

     lista: new Array(),

     Push: function(x) {
         this.lista.push(x);
     },

     Peek: function() {
         return this.lista.getLast();
     },

     Pop: function() {
         var x = this.lista.pop();
         return x;
     },

     Clear: function() {
         this.lista.empty();
     },

     Muestra: function(s) {

         var out = "Pila: "

         this.lista.each(function(elemento, c) {
             out += (this.lista[c]) + " ";
         }, this);

         if (s == null)
             salida.appendln(out);
         else
             s.appendln(out);
     }

 });