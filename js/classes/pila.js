 Pila = new Class({

     lista: new Array(),

     Push: function(x) {
         console.log("antes de push: ", this.lista);
         this.lista.push(x);
         console.log("despues de push: ", this.lista);

     },

     Peek: function() {
         console.log("tope: ", this.lista.getLast());
         return this.lista.getLast();
     },

     Pop: function() {
         console.log("antes de pop: ", this.lista);

         var x = this.lista.pop();
         console.log("despues de pop: ", this.lista);

         return x;
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