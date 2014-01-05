

    var AnalizadorSemantico = new Class(
    {

        tablaDeSimbolos:null,
        raizArbolSemantico:null,
        listaErrores:null,

        RaizArbolSintactico:
        {
            get: function(argument) { return raizArbolSemantico; },
            set: function(argument) { raizArbolSemantico = value; }
        },

        initialize: function(){


            this.ensambla();

        },

        ensambla: function(){

            salida2.Clear();
            salida2.appendln("Analizando...");

            var ruta = location.pathname.split("/");
                ruta.pop();
                ruta.reverse();
                ruta.pop();
                ruta.reverse();
                ruta = ruta.join("/");

            var rutaFile = fn.file.split("\\");
            var fileName = rutaFile.pop();
            var name = fileName.split("\.").reverse().pop();
                rutaFile = rutaFile.join("/");
                
                require('child_process').exec(ruta + '/gcc/bin/gcc.exe ' + fn.file + ' -S', function(a,b,c) {
                    console.log(a,b,c);
                    
                    if(a == null){
                        this.compila();
                    } else {

                        salida2.appendln("ERROR: ")

                        try {
                            salida2.appendln("Parece que hubo un error en la linea: " + c.match(/:(\d+):(\d+): error:/)[1]);

                            editor.getSession().setAnnotations([{
                                row: c.match(/:(\d+):(\d+): error:/)[1] - 1,
                                column: 0,
                                text: "Error",
                                type: "error" // also warning and information
                            }]);
                        } catch(e){
                            salida2.appendln("Parece que las reglas semanticas de este compilador no comprende parte del texto.")
                        }
                    }

                }.bind(this)).stdin.end();

        },

        compila: function(){

            var ruta = location.pathname.split("/");
                ruta.pop();
                ruta.reverse();
                ruta.pop();
                ruta.reverse();
                ruta = ruta.join("/");

            var rutaFile = fn.file.split("\\");
            var fileName = rutaFile.pop();
            var name = fileName.split("\.").reverse().pop();
                rutaFile = rutaFile.join("/");
                
                require('child_process').exec(ruta + '/gcc/bin/gcc.exe ' + fn.file + ' -o ' + name, function(a,b,c) {
                    console.log(a,b,c);

                    salida2.Clear();

                    
                    if(a == null){

                        salida2.appendln("Leyendo archivo ASM para mostrarlo...");
                        salida2.appendln("Presiona [play] para ejecutar el codigo");
                        var asm = new FileReader(name + ".s");
                        salida2.appendln("\n\nASM:\n");
                        salida2.appendln(asm.readText());

                    } else {

                        salida2.appendln("ERROR: ")

                        try {
                            salida2.appendln("Parece que hubo un error en la linea: " + c.match(/:(\d+):(\d+): error:/)[1]);

                            editor.getSession().setAnnotations([{
                                row: c.match(/:(\d+):(\d+): error:/)[1] - 1,
                                column: 0,
                                text: "Error",
                                type: "error" // also warning and information
                            }]);
                        } catch(e){
                            salida2.appendln("Parece que las reglas semanticas de este compilador no comprende parte del texto.")
                        }
                    }

                }.bind(this)).stdin.end();        },

        ejecuta: function(){

        },

        Correcto:
        {
            get: function() { return tablaDeSimbolos.ListaErrores.Count == 0 ? true : false; }
        },

        AnalizadorSemantico: function(raizArbolSintactico)
        {
            this.listaErrores = new List();
            this.raizArbolSemantico = raizArbolSintactico;
            this.NodoSemantico.TablaDeSimbolos = tablaDeSimbolos = new TablaSimbolos(listaErrores);
        },

        Analiza: function()
        {
            if (raizArbolSemantico == null)
                return;

            raizArbolSemantico.ValidaTiposDatos();
            MuestraTablaSimbolos();
            MuestraErrores();
        },

        MuestraTablaSimbolos: function()
        {
            //Disparamos el evento para mostrar la tabla de simbolos, sólo si ya se suscribierón a el
            if (MostrarTablaSimbolos != null)
            {
                var datosEvento = new MostrarTablaSimbolosEventArgs(tablaDeSimbolos.Tabla);
                MostrarTablaSimbolos(this, datosEvento);
            }
        },

        //================================================================================

        MuestraErrores: function()
        {
            //Disparamos el evento para mostrar la lista de errores, sólo si ya se suscribierón a el
            if (MostrarErrores != null)
            {
                var datosEvento = new MostrarErroresEventArgs(listaErrores);
                MostrarErrores(this, datosEvento);
            }
        },

        //================================================================================

  
        Limpiar: function()
        {
            salida.Clear();
            salida1.Clear();
            salida2.Clear();
            raizArbolSemantico = null;
        }
    
})