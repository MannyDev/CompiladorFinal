var entrada, salida;

Element.implement({
    append: function(value) {
        this.value += value + " ";
    },
    appendln: function(value) {
        this.value += value + "\n";
    },
    clear: function() {
        this.Clear();
    },
    Clear: function() {
        this.value = "";
    }
})


var ejercicio = {

    uno: function() {

        salida.clear();


        var pila = new Pila();
        pila.push();
        pila.push(3);
        pila.push(4);
        pila.push(5);

        pila.muestra();

        salida.appendln(pila.top());
        salida.appendln(pila.top());
        salida.appendln(pila.pop());
        salida.appendln(pila.pop());

    },


    dos: function() {

        salida.clear();

        var lexico = new Lexico("+-+");

        while (!lexico.terminado()) {
            lexico.sigSimbolo();
            salida.appendln(lexico.simbolo);
        }
    },

    tres: function() {

        salida.clear();

        var pila = new Pila();
        var fila, columna, accion;
        var aceptacion = false;

        lexico = new Lexico("a");

        pila.push(Simbolo.PESOS);
        pila.push(0);
        lexico.sigSimbolo();

        fila = pila.top();
        columna = lexico.tipo;
        accion = tablaLR[fila][columna];

        pila.muestra();
        salida.appendln("entrada: " + lexico.simbolo);
        salida.appendln("accion: " + accion);

        pila.push(lexico.tipo);
        pila.push(accion);
        lexico.sigSimbolo();

        fila = pila.top();
        columna = lexico.tipo;
        accion = tablaLR[fila][columna];

        pila.muestra();
        salida.appendln("entrada :" + lexico.simbolo);
        salida.appendln("accion :" + accion);

        pila.pop();
        pila.pop();

        fila = pila.top();
        columna = 2;
        accion = tablaLR[fila][columna];

        pila.push(2);
        pila.push(accion);
        pila.muestra();
        salida.appendln("entrada :" + lexico.simbolo);
        salida.appendln("accion :" + accion);

        fila = pila.top();
        columna = lexico.tipo;
        accion = tablaLR[fila][columna];

        pila.muestra();
        salida.appendln("entrada :" + lexico.simbolo);
        salida.appendln("accion :" + accion + " \n");
        aceptacion = accion == -1;
        if (aceptacion) salida.appendln("aceptacion");
    }

}

var ejemplo = {

    uno: function() {

        salida.clear();

        var pila = new Pila();
        var fila, columna, accion;
        var aceptacion = false;

        var lexico = new Lexico("a+b");

        pila.push(Simbolo.PESOS);
        pila.push(0);

        lexico.sigSimbolo();

        fila = pila.top();
        columna = lexico.tipo;
        accion = tablaLRej1[fila][columna];

        pila.muestra();
        salida.appendln("entrada: " + lexico.simbolo);
        salida.appendln("accion: " + accion);

        pila.push(lexico.tipo);
        pila.push(accion);
        lexico.sigSimbolo();

        fila = pila.top();
        columna = lexico.tipo;
        accion = tablaLRej1[fila][columna];

        pila.muestra();
        salida.appendln("entrada: " + lexico.simbolo);
        salida.appendln("accion: " + accion);

        pila.push(lexico.tipo);
        pila.push(accion);
        lexico.sigSimbolo();

        fila = pila.top();
        columna = lexico.tipo;
        accion = tablaLRej1[fila][columna];

        pila.muestra();
        salida.appendln("entrada: " + lexico.simbolo);
        salida.appendln("accion: " + accion);

        pila.push(lexico.tipo);
        pila.push(accion);
        lexico.sigSimbolo();

        fila = pila.top();
        columna = lexico.tipo;
        accion = tablaLRej1[fila][columna];

        pila.muestra();
        salida.appendln("entrada: " + lexico.simbolo);
        salida.appendln("accion: " + accion);

        pila.pop();
        pila.pop();
        pila.pop();
        pila.pop();
        pila.pop();
        pila.pop();

        fila = pila.top();
        columna = 3;
        accion = tablaLRej1[fila][columna];

        pila.push(3); //el 3 es el entero que representa el no terminal E
        pila.push(accion);
        pila.muestra();
        salida.appendln("entrada: " + lexico.simbolo);
        salida.appendln("accion: " + accion + "\n");

        fila = pila.top();
        columna = lexico.tipo;
        accion = tablaLRej1[fila][columna];
        pila.muestra();
        salida.appendln("entrada: " + lexico.simbolo);
        salida.appendln("accion: " + accion + "\n");
        aceptacion = accion == -1;
        if (aceptacion) salida.appendln("aceptacion");

    },

    dos: function() {

        salida.clear();

        var pila = new Pila();
        var fila, columna, accion;
        var aceptacion = false;
        var idReglas = [3, 3];
        var lonReglas = [3, 1];
        var lexico = new Lexico("a+b+c+d+e");

        pila.push(Simbolo.PESOS);
        pila.push(0);
        lexico.sigSimbolo();

        fila = pila.top();
        columna = lexico.tipo;
        accion = tablaLRej2[fila][columna];

        pila.muestra();
        salida.appendln("entrada: " + lexico.simbolo);
        salida.appendln("accion: " + accion);

        while (!aceptacion) {
            if (accion > 0) {
                pila.push(lexico.tipo);
                pila.push(accion);
                lexico.sigSimbolo();

                fila = pila.top();
                columna = lexico.tipo;
                accion = tablaLRej2[fila][columna];

                pila.muestra();
                salida.appendln("entrada: " + lexico.simbolo);
                salida.appendln("accion: " + accion);

            } else if (accion < 0) {
                if (accion == -1) {
                    fila = pila.top();
                    columna = lexico.tipo;
                    accion = tablaLRej2[fila][columna];
                    salida.appendln("entrada: " + lexico.simbolo);
                    salida.appendln("accion: " + accion);

                    salida.appendln("aceptacion");
                    break;
                }

                var posReduccion = (accion * -1) - 2;
                for (var i = 0; i < lonReglas[posReduccion] * 2; i++)
                    pila.pop();

                fila = pila.top();
                columna = idReglas[posReduccion];
                accion = tablaLRej2[fila][columna];

                pila.push(idReglas[posReduccion]);
                pila.push(accion);


                fila = pila.top();
                columna = lexico.tipo;
                accion = tablaLRej1[fila][columna];
                pila.muestra();

                salida.appendln("entrada: " + lexico.simbolo);
                salida.appendln("accion: " + accion);

                aceptacion = accion == -1;
                if (aceptacion) salida.appendln("aceptacion");


            } else break;
        }

    }
}


main = function() {

    app = $(document.body);
    app.setStyle("text-align", "center");

    win.title = "Practica 2";

    entrada = new Element("textarea.entrada").inject(app);
    salida = new Element("textarea.salida").inject(app);
    analiza = new BlueButton("Analizar texto").inject(app);

    ejercicio1_button = new GreenButton("Ejer 1").inject(app);
    ejercicio2_button = new GreenButton("Ejer 2").inject(app);
    ejercicio3_button = new GreenButton("Ejer 3").inject(app);

    ejemplo1_button = new GreenButton("Ejem 1").inject(app);
    ejemplo2_button = new GreenButton("Ejem 2").inject(app);

    consola = new RedButton("c").inject(app);

    var eval = function() {

        Analizador = new Lexico(entrada.value);
        salida.value = "";


                    Analizador.Entrada = entrada.value;
            Analizador.Analiza();

        // while (Analizador.simbolo != "$") {
        //     Analizador.SigSimbolo();
        //     salida.value += Analizador.simbolo + "\t\t " + Simbolo.ToString(Analizador.tipo) + "\n";
        // }

    };

    analiza.addEvent("click", eval);
    analiza.setProperty("disabled", "disabled")

    ejercicio1_button.addEvent("click", ejercicio.uno);
    ejercicio2_button.addEvent("click", ejercicio.dos);
    ejercicio3_button.addEvent("click", ejercicio.tres);

    ejemplo1_button.addEvent("click", ejemplo.uno);
    ejemplo2_button.addEvent("click", ejemplo.dos);



    consola.addEvent("click", function() {
        win.showDevTools()
    });
    entrada.addEvent("keyup", eval);



}

window.addEvent("domready", main);