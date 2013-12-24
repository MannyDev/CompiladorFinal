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



main = function() {

    app = $(document.body);
    //app.setStyle("text-align", "center");

    win.title = "Compilador final";
    win.showDevTools();

    window.editor = ace.edit("editor");
    editor.setTheme("ace/theme/chaos");
    editor.getSession().setMode("ace/mode/c_cpp");
    editor.setShowPrintMargin(false);
    


}

window.addEvent("domready", main);