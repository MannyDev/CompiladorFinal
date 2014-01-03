namespace Compiladores
{
    partial class VentanaPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStripMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogAbrir = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogGuardar = new System.Windows.Forms.SaveFileDialog();
            this.tabControlAnalisis = new System.Windows.Forms.TabControl();
            this.tabPageAnalisisSintactico = new System.Windows.Forms.TabPage();
            this.splitContainerAnalisisSintactico = new System.Windows.Forms.SplitContainer();
            this.labelArbolSintactico = new System.Windows.Forms.Label();
            this.arbol = new ArbolGrafico.Arbol();
            this.labelPila = new System.Windows.Forms.Label();
            this.dataGridViewAnalisis = new System.Windows.Forms.DataGridView();
            this.ColumnPila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageAnalisisSemantico = new System.Windows.Forms.TabPage();
            this.splitContainerAnalisisSemanticoPrincipal = new System.Windows.Forms.SplitContainer();
            this.groupBoxTablaSimbolos = new System.Windows.Forms.GroupBox();
            this.splitContainerAnalisisSemanticoSecundario = new System.Windows.Forms.SplitContainer();
            this.dataGridViewVariables = new System.Windows.Forms.DataGridView();
            this.ColumnIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFuncionPadre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnParametro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelVariables = new System.Windows.Forms.Label();
            this.labelFunciones = new System.Windows.Forms.Label();
            this.dataGridViewFunciones = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewErrores = new System.Windows.Forms.DataGridView();
            this.ColumnError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFunción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumeroLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelErrores = new System.Windows.Forms.Label();
            this.tabPageGeneracionCodigoEnsamblador = new System.Windows.Forms.TabPage();
            this.textEditorControlEnsamblador = new ICSharpCode.TextEditor.TextEditorControl();
            this.labelCodigoEnsamblador = new System.Windows.Forms.Label();
            this.splitContainerPrincipal = new System.Windows.Forms.SplitContainer();
            this.textEditorControlEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.buttonAnalizar = new System.Windows.Forms.Button();
            this.menuStripMenuPrincipal.SuspendLayout();
            this.tabControlAnalisis.SuspendLayout();
            this.tabPageAnalisisSintactico.SuspendLayout();
            this.splitContainerAnalisisSintactico.Panel1.SuspendLayout();
            this.splitContainerAnalisisSintactico.Panel2.SuspendLayout();
            this.splitContainerAnalisisSintactico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalisis)).BeginInit();
            this.tabPageAnalisisSemantico.SuspendLayout();
            this.splitContainerAnalisisSemanticoPrincipal.Panel1.SuspendLayout();
            this.splitContainerAnalisisSemanticoPrincipal.Panel2.SuspendLayout();
            this.splitContainerAnalisisSemanticoPrincipal.SuspendLayout();
            this.groupBoxTablaSimbolos.SuspendLayout();
            this.splitContainerAnalisisSemanticoSecundario.Panel1.SuspendLayout();
            this.splitContainerAnalisisSemanticoSecundario.Panel2.SuspendLayout();
            this.splitContainerAnalisisSemanticoSecundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrores)).BeginInit();
            this.tabPageGeneracionCodigoEnsamblador.SuspendLayout();
            this.splitContainerPrincipal.Panel1.SuspendLayout();
            this.splitContainerPrincipal.Panel2.SuspendLayout();
            this.splitContainerPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMenuPrincipal
            // 
            this.menuStripMenuPrincipal.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStripMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStripMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripMenuPrincipal.Name = "menuStripMenuPrincipal";
            this.menuStripMenuPrincipal.Size = new System.Drawing.Size(880, 24);
            this.menuStripMenuPrincipal.TabIndex = 6;
            this.menuStripMenuPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarArchivoToolStripMenuItem,
            this.guardarArchivoToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cargarArchivoToolStripMenuItem
            // 
            this.cargarArchivoToolStripMenuItem.Name = "cargarArchivoToolStripMenuItem";
            this.cargarArchivoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.cargarArchivoToolStripMenuItem.Text = "Cargar archivo";
            this.cargarArchivoToolStripMenuItem.Click += new System.EventHandler(this.cargarArchivoToolStripMenuItem_Click);
            // 
            // guardarArchivoToolStripMenuItem
            // 
            this.guardarArchivoToolStripMenuItem.Name = "guardarArchivoToolStripMenuItem";
            this.guardarArchivoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.guardarArchivoToolStripMenuItem.Text = "Guardar archivo";
            this.guardarArchivoToolStripMenuItem.Click += new System.EventHandler(this.guardarArchivoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // openFileDialogAbrir
            // 
            this.openFileDialogAbrir.DefaultExt = "txt";
            this.openFileDialogAbrir.Filter = "Archivo de texto|*.txt|Todos los archivos|*.*";
            this.openFileDialogAbrir.Title = "Cargar Archivo";
            // 
            // saveFileDialogGuardar
            // 
            this.saveFileDialogGuardar.DefaultExt = "txt";
            this.saveFileDialogGuardar.Filter = "Archivo de texto|*.txt|Todos los archivos|*.*";
            // 
            // tabControlAnalisis
            // 
            this.tabControlAnalisis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAnalisis.Controls.Add(this.tabPageAnalisisSintactico);
            this.tabControlAnalisis.Controls.Add(this.tabPageAnalisisSemantico);
            this.tabControlAnalisis.Controls.Add(this.tabPageGeneracionCodigoEnsamblador);
            this.tabControlAnalisis.Location = new System.Drawing.Point(12, 9);
            this.tabControlAnalisis.Name = "tabControlAnalisis";
            this.tabControlAnalisis.SelectedIndex = 0;
            this.tabControlAnalisis.Size = new System.Drawing.Size(853, 317);
            this.tabControlAnalisis.TabIndex = 4;
            // 
            // tabPageAnalisisSintactico
            // 
            this.tabPageAnalisisSintactico.Controls.Add(this.splitContainerAnalisisSintactico);
            this.tabPageAnalisisSintactico.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalisisSintactico.Name = "tabPageAnalisisSintactico";
            this.tabPageAnalisisSintactico.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalisisSintactico.Size = new System.Drawing.Size(845, 291);
            this.tabPageAnalisisSintactico.TabIndex = 0;
            this.tabPageAnalisisSintactico.Text = "Análisis sintáctico";
            this.tabPageAnalisisSintactico.UseVisualStyleBackColor = true;
            // 
            // splitContainerAnalisisSintactico
            // 
            this.splitContainerAnalisisSintactico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAnalisisSintactico.Location = new System.Drawing.Point(3, 3);
            this.splitContainerAnalisisSintactico.Name = "splitContainerAnalisisSintactico";
            this.splitContainerAnalisisSintactico.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerAnalisisSintactico.Panel1
            // 
            this.splitContainerAnalisisSintactico.Panel1.Controls.Add(this.labelArbolSintactico);
            this.splitContainerAnalisisSintactico.Panel1.Controls.Add(this.arbol);
            // 
            // splitContainerAnalisisSintactico.Panel2
            // 
            this.splitContainerAnalisisSintactico.Panel2.Controls.Add(this.labelPila);
            this.splitContainerAnalisisSintactico.Panel2.Controls.Add(this.dataGridViewAnalisis);
            this.splitContainerAnalisisSintactico.Size = new System.Drawing.Size(839, 285);
            this.splitContainerAnalisisSintactico.SplitterDistance = 141;
            this.splitContainerAnalisisSintactico.TabIndex = 5;
            // 
            // labelArbolSintactico
            // 
            this.labelArbolSintactico.AutoSize = true;
            this.labelArbolSintactico.Location = new System.Drawing.Point(9, 8);
            this.labelArbolSintactico.Name = "labelArbolSintactico";
            this.labelArbolSintactico.Size = new System.Drawing.Size(82, 13);
            this.labelArbolSintactico.TabIndex = 5;
            this.labelArbolSintactico.Text = "Árbol sintáctico:";
            // 
            // arbol
            // 
            this.arbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.arbol.AutoScroll = true;
            this.arbol.BackColor = System.Drawing.Color.White;
            this.arbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arbol.Location = new System.Drawing.Point(9, 29);
            this.arbol.Name = "arbol";
            this.arbol.Raiz = null;
            this.arbol.Size = new System.Drawing.Size(820, 100);
            this.arbol.TabIndex = 4;
            // 
            // labelPila
            // 
            this.labelPila.AutoSize = true;
            this.labelPila.Location = new System.Drawing.Point(9, 8);
            this.labelPila.Name = "labelPila";
            this.labelPila.Size = new System.Drawing.Size(129, 13);
            this.labelPila.TabIndex = 1;
            this.labelPila.Text = "Pila del análisis sintáctico:";
            // 
            // dataGridViewAnalisis
            // 
            this.dataGridViewAnalisis.AllowUserToAddRows = false;
            this.dataGridViewAnalisis.AllowUserToDeleteRows = false;
            this.dataGridViewAnalisis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAnalisis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAnalisis.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridViewAnalisis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAnalisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnalisis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPila,
            this.ColumnEntrada,
            this.ColumnAccion});
            this.dataGridViewAnalisis.Location = new System.Drawing.Point(9, 29);
            this.dataGridViewAnalisis.MultiSelect = false;
            this.dataGridViewAnalisis.Name = "dataGridViewAnalisis";
            this.dataGridViewAnalisis.ReadOnly = true;
            this.dataGridViewAnalisis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAnalisis.Size = new System.Drawing.Size(820, 100);
            this.dataGridViewAnalisis.TabIndex = 0;
            // 
            // ColumnPila
            // 
            this.ColumnPila.FillWeight = 1000F;
            this.ColumnPila.HeaderText = "Contenido de la pila";
            this.ColumnPila.Name = "ColumnPila";
            this.ColumnPila.ReadOnly = true;
            // 
            // ColumnEntrada
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnEntrada.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnEntrada.FillWeight = 200F;
            this.ColumnEntrada.HeaderText = "Entrada";
            this.ColumnEntrada.Name = "ColumnEntrada";
            this.ColumnEntrada.ReadOnly = true;
            // 
            // ColumnAccion
            // 
            this.ColumnAccion.HeaderText = "Acción";
            this.ColumnAccion.Name = "ColumnAccion";
            this.ColumnAccion.ReadOnly = true;
            // 
            // tabPageAnalisisSemantico
            // 
            this.tabPageAnalisisSemantico.Controls.Add(this.splitContainerAnalisisSemanticoPrincipal);
            this.tabPageAnalisisSemantico.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalisisSemantico.Name = "tabPageAnalisisSemantico";
            this.tabPageAnalisisSemantico.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalisisSemantico.Size = new System.Drawing.Size(845, 291);
            this.tabPageAnalisisSemantico.TabIndex = 1;
            this.tabPageAnalisisSemantico.Text = "Análisis semántico";
            this.tabPageAnalisisSemantico.UseVisualStyleBackColor = true;
            // 
            // splitContainerAnalisisSemanticoPrincipal
            // 
            this.splitContainerAnalisisSemanticoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAnalisisSemanticoPrincipal.Location = new System.Drawing.Point(3, 3);
            this.splitContainerAnalisisSemanticoPrincipal.Name = "splitContainerAnalisisSemanticoPrincipal";
            this.splitContainerAnalisisSemanticoPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerAnalisisSemanticoPrincipal.Panel1
            // 
            this.splitContainerAnalisisSemanticoPrincipal.Panel1.Controls.Add(this.groupBoxTablaSimbolos);
            // 
            // splitContainerAnalisisSemanticoPrincipal.Panel2
            // 
            this.splitContainerAnalisisSemanticoPrincipal.Panel2.Controls.Add(this.dataGridViewErrores);
            this.splitContainerAnalisisSemanticoPrincipal.Panel2.Controls.Add(this.labelErrores);
            this.splitContainerAnalisisSemanticoPrincipal.Size = new System.Drawing.Size(839, 285);
            this.splitContainerAnalisisSemanticoPrincipal.SplitterDistance = 152;
            this.splitContainerAnalisisSemanticoPrincipal.TabIndex = 3;
            // 
            // groupBoxTablaSimbolos
            // 
            this.groupBoxTablaSimbolos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTablaSimbolos.Controls.Add(this.splitContainerAnalisisSemanticoSecundario);
            this.groupBoxTablaSimbolos.Location = new System.Drawing.Point(12, 7);
            this.groupBoxTablaSimbolos.Name = "groupBoxTablaSimbolos";
            this.groupBoxTablaSimbolos.Size = new System.Drawing.Size(815, 135);
            this.groupBoxTablaSimbolos.TabIndex = 2;
            this.groupBoxTablaSimbolos.TabStop = false;
            this.groupBoxTablaSimbolos.Text = "Tabla de simbolos";
            // 
            // splitContainerAnalisisSemanticoSecundario
            // 
            this.splitContainerAnalisisSemanticoSecundario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAnalisisSemanticoSecundario.Location = new System.Drawing.Point(3, 16);
            this.splitContainerAnalisisSemanticoSecundario.Name = "splitContainerAnalisisSemanticoSecundario";
            // 
            // splitContainerAnalisisSemanticoSecundario.Panel1
            // 
            this.splitContainerAnalisisSemanticoSecundario.Panel1.Controls.Add(this.dataGridViewVariables);
            this.splitContainerAnalisisSemanticoSecundario.Panel1.Controls.Add(this.labelVariables);
            // 
            // splitContainerAnalisisSemanticoSecundario.Panel2
            // 
            this.splitContainerAnalisisSemanticoSecundario.Panel2.Controls.Add(this.labelFunciones);
            this.splitContainerAnalisisSemanticoSecundario.Panel2.Controls.Add(this.dataGridViewFunciones);
            this.splitContainerAnalisisSemanticoSecundario.Size = new System.Drawing.Size(809, 116);
            this.splitContainerAnalisisSemanticoSecundario.SplitterDistance = 396;
            this.splitContainerAnalisisSemanticoSecundario.TabIndex = 3;
            // 
            // dataGridViewVariables
            // 
            this.dataGridViewVariables.AllowUserToAddRows = false;
            this.dataGridViewVariables.AllowUserToDeleteRows = false;
            this.dataGridViewVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewVariables.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVariables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdentificador,
            this.ColumnTipo,
            this.ColumnLocal,
            this.ColumnFuncionPadre,
            this.ColumnParametro});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewVariables.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewVariables.Location = new System.Drawing.Point(12, 31);
            this.dataGridViewVariables.MultiSelect = false;
            this.dataGridViewVariables.Name = "dataGridViewVariables";
            this.dataGridViewVariables.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVariables.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVariables.Size = new System.Drawing.Size(369, 71);
            this.dataGridViewVariables.TabIndex = 1;
            // 
            // ColumnIdentificador
            // 
            this.ColumnIdentificador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIdentificador.FillWeight = 250F;
            this.ColumnIdentificador.HeaderText = "Identificador";
            this.ColumnIdentificador.Name = "ColumnIdentificador";
            this.ColumnIdentificador.ReadOnly = true;
            // 
            // ColumnTipo
            // 
            this.ColumnTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTipo.HeaderText = "Tipo";
            this.ColumnTipo.Name = "ColumnTipo";
            this.ColumnTipo.ReadOnly = true;
            // 
            // ColumnLocal
            // 
            this.ColumnLocal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnLocal.HeaderText = "Ambito";
            this.ColumnLocal.Name = "ColumnLocal";
            this.ColumnLocal.ReadOnly = true;
            // 
            // ColumnFuncionPadre
            // 
            this.ColumnFuncionPadre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnFuncionPadre.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnFuncionPadre.FillWeight = 250F;
            this.ColumnFuncionPadre.HeaderText = "Funcion padre";
            this.ColumnFuncionPadre.Name = "ColumnFuncionPadre";
            this.ColumnFuncionPadre.ReadOnly = true;
            // 
            // ColumnParametro
            // 
            this.ColumnParametro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnParametro.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnParametro.FillWeight = 150F;
            this.ColumnParametro.HeaderText = "Parámetro";
            this.ColumnParametro.Name = "ColumnParametro";
            this.ColumnParametro.ReadOnly = true;
            // 
            // labelVariables
            // 
            this.labelVariables.AutoSize = true;
            this.labelVariables.Location = new System.Drawing.Point(9, 7);
            this.labelVariables.Name = "labelVariables";
            this.labelVariables.Size = new System.Drawing.Size(53, 13);
            this.labelVariables.TabIndex = 2;
            this.labelVariables.Text = "Variables:";
            // 
            // labelFunciones
            // 
            this.labelFunciones.AutoSize = true;
            this.labelFunciones.Location = new System.Drawing.Point(11, 7);
            this.labelFunciones.Name = "labelFunciones";
            this.labelFunciones.Size = new System.Drawing.Size(59, 13);
            this.labelFunciones.TabIndex = 4;
            this.labelFunciones.Text = "Funciones:";
            // 
            // dataGridViewFunciones
            // 
            this.dataGridViewFunciones.AllowUserToAddRows = false;
            this.dataGridViewFunciones.AllowUserToDeleteRows = false;
            this.dataGridViewFunciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFunciones.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFunciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFunciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFunciones.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewFunciones.Location = new System.Drawing.Point(14, 31);
            this.dataGridViewFunciones.MultiSelect = false;
            this.dataGridViewFunciones.Name = "dataGridViewFunciones";
            this.dataGridViewFunciones.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFunciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewFunciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFunciones.Size = new System.Drawing.Size(383, 71);
            this.dataGridViewFunciones.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 150F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Identificador";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.FillWeight = 400F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Parámetros";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewErrores
            // 
            this.dataGridViewErrores.AllowUserToAddRows = false;
            this.dataGridViewErrores.AllowUserToDeleteRows = false;
            this.dataGridViewErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewErrores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewErrores.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewErrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnError,
            this.ColumnFunción,
            this.ColumnNumeroLinea});
            this.dataGridViewErrores.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewErrores.MultiSelect = false;
            this.dataGridViewErrores.Name = "dataGridViewErrores";
            this.dataGridViewErrores.ReadOnly = true;
            this.dataGridViewErrores.RowHeadersWidth = 55;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewErrores.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewErrores.Size = new System.Drawing.Size(815, 91);
            this.dataGridViewErrores.TabIndex = 2;
            // 
            // ColumnError
            // 
            this.ColumnError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnError.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColumnError.FillWeight = 1000F;
            this.ColumnError.HeaderText = "Error";
            this.ColumnError.Name = "ColumnError";
            this.ColumnError.ReadOnly = true;
            // 
            // ColumnFunción
            // 
            this.ColumnFunción.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFunción.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColumnFunción.FillWeight = 200F;
            this.ColumnFunción.HeaderText = "Función";
            this.ColumnFunción.Name = "ColumnFunción";
            this.ColumnFunción.ReadOnly = true;
            // 
            // ColumnNumeroLinea
            // 
            this.ColumnNumeroLinea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnNumeroLinea.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColumnNumeroLinea.FillWeight = 150F;
            this.ColumnNumeroLinea.HeaderText = "Número de línea";
            this.ColumnNumeroLinea.Name = "ColumnNumeroLinea";
            this.ColumnNumeroLinea.ReadOnly = true;
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.Location = new System.Drawing.Point(9, 8);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(82, 13);
            this.labelErrores.TabIndex = 1;
            this.labelErrores.Text = "Lista de errores:";
            // 
            // tabPageGeneracionCodigoEnsamblador
            // 
            this.tabPageGeneracionCodigoEnsamblador.Controls.Add(this.textEditorControlEnsamblador);
            this.tabPageGeneracionCodigoEnsamblador.Controls.Add(this.labelCodigoEnsamblador);
            this.tabPageGeneracionCodigoEnsamblador.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneracionCodigoEnsamblador.Name = "tabPageGeneracionCodigoEnsamblador";
            this.tabPageGeneracionCodigoEnsamblador.Size = new System.Drawing.Size(845, 291);
            this.tabPageGeneracionCodigoEnsamblador.TabIndex = 2;
            this.tabPageGeneracionCodigoEnsamblador.Text = "Generación de código";
            this.tabPageGeneracionCodigoEnsamblador.UseVisualStyleBackColor = true;
            // 
            // textEditorControlEnsamblador
            // 
            this.textEditorControlEnsamblador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditorControlEnsamblador.BackColor = System.Drawing.Color.White;
            this.textEditorControlEnsamblador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEditorControlEnsamblador.IsReadOnly = false;
            this.textEditorControlEnsamblador.Location = new System.Drawing.Point(15, 29);
            this.textEditorControlEnsamblador.Name = "textEditorControlEnsamblador";
            this.textEditorControlEnsamblador.Size = new System.Drawing.Size(816, 247);
            this.textEditorControlEnsamblador.TabIndex = 1;
            // 
            // labelCodigoEnsamblador
            // 
            this.labelCodigoEnsamblador.AutoSize = true;
            this.labelCodigoEnsamblador.Location = new System.Drawing.Point(12, 12);
            this.labelCodigoEnsamblador.Name = "labelCodigoEnsamblador";
            this.labelCodigoEnsamblador.Size = new System.Drawing.Size(106, 13);
            this.labelCodigoEnsamblador.TabIndex = 0;
            this.labelCodigoEnsamblador.Text = "Código ensamblador:";
            // 
            // splitContainerPrincipal
            // 
            this.splitContainerPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerPrincipal.Location = new System.Drawing.Point(0, 28);
            this.splitContainerPrincipal.Name = "splitContainerPrincipal";
            this.splitContainerPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerPrincipal.Panel1
            // 
            this.splitContainerPrincipal.Panel1.Controls.Add(this.tabControlAnalisis);
            // 
            // splitContainerPrincipal.Panel2
            // 
            this.splitContainerPrincipal.Panel2.Controls.Add(this.textEditorControlEditor);
            this.splitContainerPrincipal.Panel2.Controls.Add(this.buttonBorrar);
            this.splitContainerPrincipal.Panel2.Controls.Add(this.buttonAnalizar);
            this.splitContainerPrincipal.Size = new System.Drawing.Size(880, 484);
            this.splitContainerPrincipal.SplitterDistance = 337;
            this.splitContainerPrincipal.TabIndex = 5;
            // 
            // textEditorControlEditor
            // 
            this.textEditorControlEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditorControlEditor.BackColor = System.Drawing.Color.White;
            this.textEditorControlEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEditorControlEditor.IsReadOnly = false;
            this.textEditorControlEditor.Location = new System.Drawing.Point(12, 13);
            this.textEditorControlEditor.Name = "textEditorControlEditor";
            this.textEditorControlEditor.Size = new System.Drawing.Size(678, 118);
            this.textEditorControlEditor.TabIndex = 5;
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBorrar.Location = new System.Drawing.Point(790, 13);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrar.TabIndex = 3;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = true;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // buttonAnalizar
            // 
            this.buttonAnalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnalizar.Location = new System.Drawing.Point(696, 13);
            this.buttonAnalizar.Name = "buttonAnalizar";
            this.buttonAnalizar.Size = new System.Drawing.Size(75, 23);
            this.buttonAnalizar.TabIndex = 2;
            this.buttonAnalizar.Text = "Analizar";
            this.buttonAnalizar.UseVisualStyleBackColor = true;
            this.buttonAnalizar.Click += new System.EventHandler(this.buttonAnalizar_Click);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 512);
            this.Controls.Add(this.splitContainerPrincipal);
            this.Controls.Add(this.menuStripMenuPrincipal);
            this.MainMenuStrip = this.menuStripMenuPrincipal;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "VentanaPrincipal";
            this.Text = "Compilador";
            this.menuStripMenuPrincipal.ResumeLayout(false);
            this.menuStripMenuPrincipal.PerformLayout();
            this.tabControlAnalisis.ResumeLayout(false);
            this.tabPageAnalisisSintactico.ResumeLayout(false);
            this.splitContainerAnalisisSintactico.Panel1.ResumeLayout(false);
            this.splitContainerAnalisisSintactico.Panel1.PerformLayout();
            this.splitContainerAnalisisSintactico.Panel2.ResumeLayout(false);
            this.splitContainerAnalisisSintactico.Panel2.PerformLayout();
            this.splitContainerAnalisisSintactico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalisis)).EndInit();
            this.tabPageAnalisisSemantico.ResumeLayout(false);
            this.splitContainerAnalisisSemanticoPrincipal.Panel1.ResumeLayout(false);
            this.splitContainerAnalisisSemanticoPrincipal.Panel2.ResumeLayout(false);
            this.splitContainerAnalisisSemanticoPrincipal.Panel2.PerformLayout();
            this.splitContainerAnalisisSemanticoPrincipal.ResumeLayout(false);
            this.groupBoxTablaSimbolos.ResumeLayout(false);
            this.splitContainerAnalisisSemanticoSecundario.Panel1.ResumeLayout(false);
            this.splitContainerAnalisisSemanticoSecundario.Panel1.PerformLayout();
            this.splitContainerAnalisisSemanticoSecundario.Panel2.ResumeLayout(false);
            this.splitContainerAnalisisSemanticoSecundario.Panel2.PerformLayout();
            this.splitContainerAnalisisSemanticoSecundario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrores)).EndInit();
            this.tabPageGeneracionCodigoEnsamblador.ResumeLayout(false);
            this.tabPageGeneracionCodigoEnsamblador.PerformLayout();
            this.splitContainerPrincipal.Panel1.ResumeLayout(false);
            this.splitContainerPrincipal.Panel2.ResumeLayout(false);
            this.splitContainerPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogAbrir;
        private System.Windows.Forms.SaveFileDialog saveFileDialogGuardar;
        private System.Windows.Forms.TabControl tabControlAnalisis;
        private System.Windows.Forms.TabPage tabPageAnalisisSintactico;
        private ArbolGrafico.Arbol arbol;
        private System.Windows.Forms.DataGridView dataGridViewAnalisis;
        private System.Windows.Forms.TabPage tabPageAnalisisSemantico;
        private System.Windows.Forms.SplitContainer splitContainerPrincipal;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.Button buttonAnalizar;
        private System.Windows.Forms.SplitContainer splitContainerAnalisisSintactico;
        private System.Windows.Forms.SplitContainer splitContainerAnalisisSemanticoPrincipal;
        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.GroupBox groupBoxTablaSimbolos;
        private System.Windows.Forms.SplitContainer splitContainerAnalisisSemanticoSecundario;
        private System.Windows.Forms.DataGridView dataGridViewVariables;
        private System.Windows.Forms.Label labelVariables;
        private System.Windows.Forms.Label labelFunciones;
        private System.Windows.Forms.DataGridView dataGridViewFunciones;
        private System.Windows.Forms.DataGridView dataGridViewErrores;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnError;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFunción;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumeroLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPila;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccion;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControlEditor;
        private System.Windows.Forms.Label labelArbolSintactico;
        private System.Windows.Forms.Label labelPila;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFuncionPadre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParametro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabPage tabPageGeneracionCodigoEnsamblador;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControlEnsamblador;
        private System.Windows.Forms.Label labelCodigoEnsamblador;
    }
}

