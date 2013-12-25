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
    c=new FileWriter("file.c"); c.replace(editor.getValue());

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
    editor.setTheme("ace/theme/clouds_midnight");
    editor.getSession().setMode("ace/mode/c_cpp");
    editor.setShowPrintMargin(false);

    var abrir = new ButtonBar("folder_open_icon", "Abrir archivo");
    var nuevo = new ButtonBar("doc_new_icon", "Nuevo archivo");
    var guardar = new ButtonBar("save_icon", "Guardar archivo");
    
    var compilar = new ButtonBar("wrench_plus_2_icon","Compilar");
    var ejecutar = new ButtonBar("playback_play_icon","Ejecutar");

    var copiar = new ButtonBar("clipboard_copy_icon","Copiar");
    var pegar = new ButtonBar("clipboard_past_icon","Pegar");

    var consola = new ButtonBar("app_window_black_icon","Consola");
    var cerrar = new ButtonBar("delete_icon","Cerrar");

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
    cerrar.inject("top");

    /* Eventos */

    copiar.addEvent("click", fn.copiar);
    pegar.addEvent("click", fn.pegar);

    consola.addEvent("click", fn.consola);
    cerrar.addEvent("click", fn.cerrar);

};

var fn = {

    pegarFn: function(){
        editor.insert(gui.Clipboard.get().get());
    },

    copiarFn: function(){
        if (editor.getSelectedText().length == 0) return;
        else gui.Clipboard.get().set(editor.getSelectedText());
    },

    consolaFn: function(){
        win.showDevTools();
    },

    cerrarFn: function(){
        win.close();
    }
}

window.addEvent("domready", main);