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

var save = function() {
    c = new FileWriter("file.c");
    c.replace(editor.getValue());

    var exec = require('child_process').exec,
        d, child;

    child = exec('/usr/bin/gcc file.c | /usr/bin/gcc file.c -o exe | /usr/bin/open exe');

    child.stderr.on("data", function(data) {
        console.log(data)
    });

}


main = function() {

    app = $(document.body);
    //app.setStyle("text-align", "center");

    win.title = "Compilador final";

    window.editor = ace.edit("editor");
    //    editor.setTheme("ace/theme/xcode");
    editor.setTheme("ace/theme/clouds_midnight");
    editor.getSession().setMode("ace/mode/c_cpp");
    editor.setShowPrintMargin(false);

    var salida = document.id("salida");
    var salida1 = document.id("salida1");
    var salida2 = document.id("salida2");

    var abrir = new ButtonBar("folder_open_icon", "Abrir archivo");
    var nuevo = new ButtonBar("doc_new_icon", "Nuevo archivo");
    var guardar = new ButtonBar("save_icon", "Guardar archivo");

    var compilar = new ButtonBar("wrench_plus_2_icon", "Compilar");
    var ejecutar = new ButtonBar("playback_play_icon", "Ejecutar");

    var copiar = new ButtonBar("clipboard_copy_icon", "Copiar");
    var pegar = new ButtonBar("clipboard_past_icon", "Pegar");

    var consola = new ButtonBar("app_window_black_icon", "Consola");
    var maximiza = new ButtonWindow("round_plus_icon", "Maximizar");
    var minimiza = new ButtonWindow("round_minus_icon", "Minimiza");
    var cerrar = new ButtonWindow("round_delete_icon", "Cerrar");

    nuevo.inject("top");
    abrir.inject("top");
    guardar.inject("top");

    separador().inject("top");

    compilar.inject("top");
    ejecutar.inject("top");

    separador().inject("top");

    copiar.inject("top");
    pegar.inject("top");

    separador().inject("top");

    consola.inject("top");

    separador().inject("top");

    minimiza.inject("top");
    maximiza.inject("top");
    cerrar.inject("top").setStyle("margin-right", 20);

    /* Eventos */

    abrir.addEvent("click", fn.open);
    $("open").addEvent("change", fn.open);
    guardar.addEvent("click", fn.save);
    $("save").addEvent("change", fn.save);
    nuevo.addEvent("click", fn.nuevo);

    copiar.addEvent("click", fn.copiar);
    pegar.addEvent("click", fn.pegar);

    consola.addEvent("click", fn.consola);
    maximiza.addEvent("click", fn.maximiza);
    minimiza.addEvent("click", fn.minimiza);
    cerrar.addEvent("click", fn.cerrar);


    var eval = function() {

        var Analizador = new AnalizadorLexico(editor.getValue().replace(/\#include\s*[\<\"]\w+(\.h)?[\>\"]/g, ""));
        var errores = new Array();
        salida.value = "";
        salida1.value = "";
        salida2.value = "";

        while (Analizador.simbolo != "$") {
            Analizador.SigSimbolo();

            if (Analizador.tipo == -1) {
                errores.include({
                    row: Analizador.numeroLinea - 1,
                    column: 0,
                    text: "Error en analisis lexico (un token no identificado)",
                    type: "error" // also warning and information
                })
            }

            salida.value += Analizador.simbolo + "\t\t " + Simbolos.ToString(Analizador.tipo) + "\n";
            salida1.value += Analizador.simbolo + "\t\t " + Simbolos.ToString(Analizador.tipo) + "\n";
            salida2.value += Analizador.simbolo + "\t\t " + Simbolos.ToString(Analizador.tipo) + "\n";
        }

        editor.getSession().setAnnotations(errores);

        if (errores.length > 0) return;

        var Analizador = new AnalizadorSintacticoLR(editor.getValue());
        
        // if(Analizador.start().type == "error")
        //     console.log("error");

    };

    editor.on("change", eval)


};

var fn = {

    file: "",

    pegar: function() {
        editor.insert(gui.Clipboard.get().get());
    },

    copiar: function() {
        if (editor.getSelectedText().length == 0) return;
        else gui.Clipboard.get().set(editor.getSelectedText());
    },

    consola: function() {
        win.showDevTools();
    },

    cerrar: function() {
        win.close();
    },

    open: function(e) {

        editor.focus();


        if (e.type == "click") {
            document.id("open").click();
            return;
        }

        if (e.type == "change" && $("open").value != "") {

            fn.file = $("open").value;

            var c = new FileReader(fn.file);
            editor.setValue(c.readText());
            editor.gotoLine(0, 0);

            $("open").value = "";

        }
    },

    save: function(e) {

        editor.focus();

        if (e.type == "click") {

            console.log(fn.file == $("open").value, fn.file, $("open").value)

            if (fn.file != "") {
                var c = new FileWriter(fn.file);
                c.replace(editor.getValue());
            } else document.id("save").click();

            return;

        }

        if (e.type == "change") {

            fn.file = this.value;

            var folders = fn.file;
            folders = folders.split(path.sep);

            var nombre_archivo = folders.pop();
            nombre_archivo = nombre_archivo.test(/.+\.c/) ? nombre_archivo : nombre_archivo + ".c";

            folders.push(nombre_archivo);

            fn.file = folders.join(path.sep)

            var c = new FileWriter(fn.file);
            c.replace(editor.getValue());

        }

    },

    nuevo: function() {
        document.id("open").value = "";
        document.id("save").value = "";
        editor.setValue("");
        fn.file = "";
        editor.focus();
    },

    saveAs: function() {

    },

    maximiza: function() {
        win.maximize();
    },

    minimiza: function() {
        win.minimize();
    }
}

window.addEvent("domready", main);
