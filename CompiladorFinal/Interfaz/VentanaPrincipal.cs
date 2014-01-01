using System;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.TextEditor.Document;

namespace Compiladores
{
    public partial class VentanaPrincipal : Form
    {
        AnalizadorSintacticoLR analizadorSintactico;
        AnalizadorSemantico analizadorSemantico;

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        public VentanaPrincipal()
        {
            InitializeComponent();
            cargaArchivoColoreoSintaxis();

            analizadorSintactico = new AnalizadorSintacticoLR();
            analizadorSintactico.MostrarPila += new AnalizadorSintacticoLR.MuestraPilaEventArgs(analizadorSintactico_MostrarPila);
            analizadorSintactico.MostrarArbol += new AnalizadorSintacticoLR.MuestraArbolEventArgs(analizadorSintactico_MostrarArbol);

            analizadorSemantico = new AnalizadorSemantico();
            analizadorSemantico.MostrarTablaSimbolos += new AnalizadorSemantico.MuestraTablaSimbolosEventArgs(analizadorSemantico_MostrarTablaSimbolos);
            analizadorSemantico.MostrarErrores += new AnalizadorSemantico.MuestraErroresEventArgs(analizadorSemantico_MostrarErrores);

            textEditorControlEnsamblador.IsReadOnly = true;
        }

        //================================================================================

        /// <summary>
        /// Carga el archivo con las reglas de coloreo de sintaxis del textBox
        /// </summary>
        void cargaArchivoColoreoSintaxis()
        {
            String dir = Directory.GetCurrentDirectory();
            FileSyntaxModeProvider fsmProvider; //El provedor de la sintaxis
            if (Directory.Exists(dir))
            {
                fsmProvider = new FileSyntaxModeProvider(dir); //Lo instanciamos con el directorio actual
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmProvider); //Se lo ponemos al textBox
                textEditorControlEditor.SetHighlighting("C"); // Activamos el coloreo de sintaxis, usando el nombre del nodo SyntaxDefinition, definido en el archivo
            }
        }

        //================================================================================

        /// <summary>
        /// Se genera cuando termina el analisis semántico, y muestra la lista de errores 
        /// encontrados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void analizadorSemantico_MostrarErrores(object sender, MostrarErroresEventArgs e)
        {
            labelErrores.Text = "Errores: " + e.Errores.Count;
            for (int i = 0; i < e.Errores.Count; i++)
            {
                dataGridViewErrores.Rows.Add(e.Errores[i].Error, e.Errores[i].FuncionPadre, (e.Errores[i].NumeroLinea == 0 ? " " : e.Errores[i].NumeroLinea.ToString()));
                dataGridViewErrores.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        //================================================================================

        /// <summary>
        /// Se genera cuando termina el analisis semántico, y muestra la tabla de simbolos 
        /// generada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void analizadorSemantico_MostrarTablaSimbolos(object sender, MostrarTablaSimbolosEventArgs e)
        {
            labelVariables.Text = "Variables: " + e.CantVariables;
            labelFunciones.Text = "Funciones: " + e.CantFunciones;
            foreach (ElementoTabla elemento in e.Elementos)
            {
                if (elemento.EsVariable())
                    dataGridViewVariables.Rows.Add(elemento.Identificador, elemento.Tipo.ToString().ToLower(), (elemento.EsVarLocal() ? "Local" : "Global"), ((Variable)elemento).FuncionPadre, (((Variable)elemento).EsParametro() ? "Sí" : "No"));
                else
                    dataGridViewFunciones.Rows.Add(elemento.Identificador, elemento.Tipo.ToString().ToLower(), ((Funcion)elemento).ParametrosString);
            }
        }

        //================================================================================

        /// <summary>
        /// Se genera cuando termina el analisis sintáctico, y muestra el árbol de analisis 
        /// sintáctico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void analizadorSintactico_MostrarArbol (object sender, MostrarArbolEventArgs e)
        {
            //Mostramos el árbol sintáctico
            arbol.Raiz = e.RaizArbolSintactico;
            arbol.Actualizar();

            if (arbol.Raiz == null)
                return;

            //Analizamos semánticamente el árbol sintáctico producido
            analizadorSemantico.RaizArbolSintactico = (NodoSemantico)arbol.Raiz;
            analizadorSemantico.Analiza();

            //Generación de código
            if (analizadorSemantico.Correcto)
            {
                MessageBox.Show("sin errores!!!! ahora a generar el código ensamblador");
                GeneradorCodigoEnsamblador generador = new GeneradorCodigoEnsamblador(analizadorSemantico.RaizArbolSintactico);
                generador.GeneraCodigo();
                textEditorControlEnsamblador.Text = generador.CodigoEnsamblador;
                textEditorControlEnsamblador.Refresh();
                generador.CreaArchivoAsm();
            }
        }

        //================================================================================

        /// <summary>
        /// Se genera cada vez que el analizador sintáctico necesita mostrar la pila
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void analizadorSintactico_MostrarPila(object sender, MostrarPilaEventArgs e)
        {
            dataGridViewAnalisis.Rows.Add(e.ElementosEnPila, e.Simbolo, e.Accion.ToString());
        }

        //================================================================================

        /// <summary>
        /// Limpia toda la interfaz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBorrar_Click(object sender, System.EventArgs e)
        {
            arbol.Limpiar();
            dataGridViewAnalisis.Rows.Clear();
            textEditorControlEditor.Text = "";
            textEditorControlEditor.Refresh();

            analizadorSemantico.Limpiar();
            labelFunciones.Text = "Funciones:";
            labelVariables.Text = "Variables:";
            labelErrores.Text = "Errores:";
            dataGridViewVariables.Rows.Clear();
            dataGridViewFunciones.Rows.Clear();
            dataGridViewErrores.Rows.Clear();
            textEditorControlEnsamblador.Text = "";
            textEditorControlEnsamblador.Refresh();
        }

        //================================================================================

        /// <summary>
        /// Se genera al dar click en el boton de análisis, y ejecuta el análisis sintático
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnalizar_Click ( object sender, System.EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            Analizar();
            Cursor = Cursors.Default;
        }

        //================================================================================

        /// <summary>
        /// Comienza el análisis sintáctico, usando como entrada lo que el usuario haya 
        /// escrito en el textboxEntrada
        /// </summary>
        private void Analizar ()
        {
            //Limpiamos la interfaz de analisis anteriores
            arbol.Limpiar();
            dataGridViewAnalisis.Rows.Clear();

            analizadorSemantico.Limpiar();
            labelFunciones.Text = "Funciones:";
            labelVariables.Text = "Variables:";
            labelErrores.Text = "Errores:";
            dataGridViewVariables.Rows.Clear();
            dataGridViewFunciones.Rows.Clear();
            dataGridViewErrores.Rows.Clear();
            textEditorControlEnsamblador.Text = "";
            textEditorControlEnsamblador.Refresh();

            //Analizamos con lo que escribio el usuario como entrada
            analizadorSintactico.Entrada = textEditorControlEditor.Text;
            analizadorSintactico.Analiza();
        }

        //================================================================================

        /// <summary>
        /// Se genera cuando se presiona el botón Cargar archivo, del menú principal; 
        /// proporciona un cuadro de texto para buscar y abrir un archivo, una ves seleccionado 
        /// el archivo, se procede a cargarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cargarArchivoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (openFileDialogAbrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (FileStream flujoArchivo = new FileStream(openFileDialogAbrir.FileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        using (StreamReader lector = new StreamReader(flujoArchivo))
                        {
                            textEditorControlEditor.Text = lector.ReadToEnd();
                            textEditorControlEditor.Refresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al intentar abrir el archivo, el error fue el siguiente: " + ex.ToString(), "Error al abrir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //================================================================================

        /// <summary>
        /// Se genera cuando se presiona el botón Guardar archivo, del menú principal; 
        /// proporciona un cuadro de texto para guardar un archivo con los datos del textboxEntrada 
        /// en una ubicación seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarArchivoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialogGuardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (FileStream flujoArchivo = new FileStream(saveFileDialogGuardar.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (StreamWriter escritor = new StreamWriter(flujoArchivo))
                        {
                            escritor.Write(textEditorControlEditor.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al intentar guardar el archivo, el error fue el siguiente: " + ex.ToString(), "Error al guardar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //================================================================================

        /// <summary>
        /// Se genera cuando se presiona el botón Salir, del menú principal; termina la 
        /// ejecución del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
