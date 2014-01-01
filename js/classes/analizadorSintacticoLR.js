var AnalizadorSintacticoLR = new Class({

    analizadorLexico: null,

    entrada: null,
    fila: null,
    columna: null,
    accion: null,
    pila: null,
    nt: null,
    nodo: null,
    arbolSintactico: null,
    correcto: false,
    arreglosYTablaCargados: false,

    //Reglas de la grámatica
    idReglas: null,
    lonReglas: null,
    strReglas: null,

    //Tabla de la grámatica
    tabla: null,

    /// <summary>
    /// Obtiene o modifica la entrada que se usa en el análisis
    /// </summary>
    Entrada: {
        get: function() {
            return entrada;
        },
        set: function(value) {
            this.entrada = value;
            this.analizadorLexico = new AnalizadorLexico(this.entrada);
            this.pila.Clear();
        }
    },

    //================================================================================

    initiailze: function(entrada) {

        this.entrada = [entrada, ""].pick();
        this.analizadorLexico = new AnalizadorLexico(entrada);
        this.pila = new Pila();
        this.arbolSintactico = null;

        if (!this.CargaArreglosYTabla())
            alert("Ocurrio un error al cargar los datos");
    },

    //================================================================================

    Analiza: function() {

        if (!this.arreglosYTablaCargados) {
            alert("No se han cargado los datos de la grámatica del compilador, verifica que el archivo compilador09b.lr se ecuentre en la ruta del ejecutable");
            return;
        }

        try {

            NodoSemantico.TipoDeAmbito = TipoAmbito.GLOBAL;
            this.arbolSintactico = null;
            this.nt = null;
            this.nodo = null;
            this.correcto = false;
            this.accion = 0;
            this.pila.Push(new Terminal(Simbolos.PESOS, "$"));
            this.pila.Push(new Estado(0));
            this.analizadorLexico.SigSimbolo();

            while (true) {
                //Buscamos la siguiente acción
                this.SigAccion();

                //Mostrar pila, entrada y accion
                this.MuestraPila();

                //Si es positivo es un desplazamiento
                if (this.accion > 0) {
                    this.pila.Push(new Terminal(this.analizadorLexico.tipo, this.analizadorLexico.simbolo));
                    this.pila.Push(new Estado(this.accion));
                    this.analizadorLexico.SigSimbolo();
                }

                //Sino, si es negativo es una reducción o aceptación
                else if (this.accion < 0) {
                    //Estado de aceptación
                    if (this.accion == -1) {
                        this.correcto = true;
                        this.pila.Pop();
                        this.arbolSintactico = this.pila.Pop().nodo;
                        break;
                    }

                    int regla = -(this.accion + 2);

                    switch (regla + 1) {
                        case 1: //<programa> ::= <Definiciones>
                            this.nodo = new Programa(this.pila);
                            break;
                        case 2: //<Definiciones> ::= \e
                            this.nodo = new NodoSemantico("<Definiciones>");
                            break;
                        case 3: //<Definiciones> ::= <Definicion> <Definiciones>
                            this.nodo = new Definiciones(this.pila);
                            break;
                        case 4: //<Definicion> ::= <DefVar>
                            this.pila.Pop();
                            this.nodo = this.pila.Pop().nodo;
                            break;
                        case 5: //<Definicion> ::= <DefFunc>
                            this.pila.Pop();
                            this.nodo = this.pila.Pop().nodo;
                            break;
                        case 6: //<DefVar> ::= tipo identificador <ListaVar> ;
                            this.nodo = new Variables(this.pila);
                            break;
                        case 7: //<ListaVar> ::= \e
                            this.nodo = new NodoSemantico("<ListaVar>");
                            break;
                        case 8: //<ListaVar> ::= , identificador <ListaVar>
                            this.nodo = new Variables2(this.pila);
                            break;
                        case 9: //<DefFunc> ::= tipo identificador ( <Parametros> ) <BloqFunc>
                            this.nodo = new DefFunc(this.pila);
                            break;
                        case 10: //<Parametros> ::= \e
                            this.nodo = new NodoSemantico("<ListaParam>");
                            break;
                        case 11: //<Parametros> ::= tipo identificador <ListaParam>
                            this.nodo = new Parametros(this.pila);
                            break;
                        case 12: //<ListaParam> ::= \e
                            this.nodo = new NodoSemantico("<ListaParam>");
                            break;
                        case 13: //<ListaParam> ::= , tipo identificador <ListaParam>
                            this.nodo = new Parametros2(this.pila);
                            break;
                        case 14: //<BloqFunc> ::= { <DefLocales> }
                            this.nodo = new BloqueFunc(this.pila);
                            break;
                        case 15: //<DefLocales> ::= \e
                            this.nodo = new NodoSemantico("<DefLocales>");
                            break;
                        case 16: //<DefLocales> ::= <DefLocal> <DefLocales>
                            this.nodo = new DefinicionesLocales(this.pila);
                            break;
                        case 17: //<DefLocal> ::= <DefVar>
                            this.pila.Pop();
                            this.nodo = this.pila.Pop().Nodo;
                            break;
                        case 18: //<DefLocal> ::= <Sentencia>
                            this.pila.Pop();
                            this.nodo = this.pila.Pop().Nodo;
                            break;
                        case 19: //<Sentencias> ::= \e
                            this.nodo = new NodoSemantico("<Sentencias>");
                            break;
                        case 20: //<Sentencias> ::= <Sentencia> <Sentencias>
                            this.nodo = new Sentencias(this.pila);
                            break;
                        case 21: //<Sentencia> ::= identificador = <Expresion> ;
                            this.nodo = new SentenciaAsignacion(this.pila);
                            break;
                        case 22: //<Sentencia> ::= if ( <Expresion> ) <SentenciaBloque> <Otro>
                            this.nodo = new SentenciaIf(this.pila);
                            break;
                        case 23: //<Sentencia> ::= while ( <Expresion> ) <Bloque>
                            this.nodo = new SentenciaWhile(this.pila);
                            break;
                        case 24: //<Sentencia> ::= return <ValorRegresa> ;
                            this.nodo = new SentenciaValorRegresa(this.pila);
                            break;
                        case 25: //<Sentencia> ::= <LlamadaFunc> ;
                            this.nodo = new SentenciaLlamadaFuncion(this.pila);
                            break;
                        case 26: //<Otro> ::= \e
                            this.nodo = new NodoSemantico("<Otro>");
                            break;
                        case 27: //<Otro> ::= else <SentenciaBloque>
                            this.nodo = new Otro(this.pila);
                            break;
                        case 28: //<Bloque> ::= { <Sentencias> }
                            this.nodo = new Bloque(this.pila);
                            break;
                        case 29: //<ValorRegresa> ::= \e
                            this.nodo = new NodoSemantico("<ValorRegresa>");
                            break;
                        case 30: //<ValorRegresa> ::= <Expresion>
                            this.pila.Pop();
                            var valorRegresar = new NodoSemantico("<ValorRegresa>");
                            valorRegresar.Añ adirHijo(this.pila.Pop().Nodo);
                            valorRegresar.NumeroLinea = (valorRegresar.Hijos[0]).NumeroLinea;
                            this.nodo = valorRegresar;
                            break;
                        case 31: //<Argumentos> ::= \e
                            this.nodo = new NodoSemantico("<ListaArgumentos>");
                            break;
                        case 32: //<Argumentos> ::= <Expresion> <ListaArgumentos>
                            this.nodo = new ListaArgumentos(this.pila);
                            break;
                        case 33: //<ListaArgumentos> ::= \e
                            this.nodo = new NodoSemantico("<ListaArgumentos>");
                            break;
                        case 34: //<ListaArgumentos> ::= , <Expresion> <ListaArgumentos>
                            this.nodo = new ListaArgumentos2(this.pila);
                            break;
                        case 35: //<Termino> ::= <LlamadaFunc>
                            this.pila.Pop();
                            this.nodo = pila.Pop().Nodo;
                            break;
                        case 36: //<Termino> ::= identificador
                            this.nodo = new Identificador(this.pila);
                            break;
                        case 37: //<Termino> ::= entero
                            this.nodo = new Entero(this.pila);
                            break;
                        case 38: //<Termino> ::= real
                            this.nodo = new Real(this.pila);
                            break;
                        case 39: //<Termino> ::= cadena
                            this.nodo = new Cadena(this.pila);
                            break;
                        case 40: //<LlamadaFunc> ::= identificador ( <Argumentos> )
                            this.nodo = new LlamadaFuncion(this.pila);
                            break;
                        case 41: //<SentenciaBloque> ::= <Sentencia>
                            this.pila.Pop();
                            this.nodo = this.pila.Pop().Nodo;
                            break;
                        case 42: //<SentenciaBloque> ::= <Bloque>
                            this.pila.Pop();
                            this.nodo = this.pila.Pop().Nodo;
                            break;
                        case 43: //<Expresion> ::= ( <Expresion> )
                            this.nodo = new ExpresionEntreParentesis(this.pila);
                            break;
                        case 44: //<Expresion> ::= opSuma <Expresion>
                            this.nodo = new OperadorAdicion2(this.pila);
                            break;
                        case 45: //<Expresion> ::= opNot <Expresion>
                            this.nodo = new OperadorNot(this.pila);
                            break;
                        case 46: //<Expresion> ::= <Expresion> opMul <Expresion>
                            this.nodo = new OperadorMultiplicacion(this.pila);
                            break;
                        case 47: //<Expresion> ::= <Expresion> opSuma <Expresion>
                            this.nodo = new OperadorAdicion(this.pila);
                            break;
                        case 48: //<Expresion> ::= <Expresion> opRelac <Expresion>
                            this.nodo = new OperadorRelacional(this.pila);
                            break;
                        case 49: //<Expresion> ::= <Expresion> opIgualdad <Expresion>
                            this.nodo = new OperadorIgualdad(this.pila);
                            break;
                        case 50: //<Expresion> ::= <Expresion> opAnd <Expresion>
                            this.nodo = new OperadorAnd(this.pila);
                            break;
                        case 51: //<Expresion> ::= <Expresion> opOr <Expresion>
                            this.nodo = new OperadorOr(this.pila);
                            break;
                        case 52: //<Expresion> ::= <Termino>
                            this.nodo = new ExpresionSimple(this.pila);
                            break;
                        default:
                            //Sacamos de la pila el doble de elementos de la regla de reducción
                            for (int i = 0; i < this.lonReglas[regla] * 2; i++)
                                this.pila.Pop();
                            break;
                    }

                    this.fila = this.pila.Peek().Id;
                    this.columna = this.idReglas[regla];
                    this.accion = this.tabla[this.fila, this.columna];

                    this.nt = new NoTerminal(this.idReglas[regla], this.strReglas[regla]);
                    this.nt.Nodo = this.nodo;

                    this.pila.Push(this.nt);
                    this.pila.Push(new Estado(this.accion));
                }

                //Error
                if (this.accion == 0)
                    throw new Exception();
            }
        } catch (Exception) {} finally {
            this.MuestraArbol();
        }
    },


    //================================================================================

    SigAccion: function() {
        this.fila = this.pila.Peek().id;
        this.columna = this.analizadorLexico.tipo;
        this.accion = this.tabla[this.fila, this.columna];
    },

    //================================================================================

    MuestraPila: function() {
        if (MostrarPila != null) {
            var datosEvento = new MostrarPilaEventArgs(pila, analizadorLexico.Simbolo, accion);
            MostrarPila(this, datosEvento);
        }
    },

    //================================================================================

    MuestraArbol: function() {

        if (MostrarArbol != null) {
            if (!correcto)
                return;

            MostrarArbolEventArgs datosEvento = new MostrarArbolEventArgs(arbolSintactico);
            MostrarArbol(this, datosEvento);
        }

    },

    //================================================================================

    CargaArreglosYTabla: function() {
        try {

            var lector = new FileReader("compilador09b.lr");

            var contenidoArchivo = lector.ReadText();
            var indice = 0;

            //Inicializamos los arreglos
            var cantReglas = this.SigEntero(contenidoArchivo, indice);

            this.idReglas = new Array(cantReglas);
            this.lonReglas = new Array(cantReglas);
            this.strReglas = new Array(antReglas);

            //Llenamos los arreglos
            for (var i = 0; i < cantReglas; i++) {
                idReglas[i] = this.SigEntero(contenidoArchivo, indice);
                lonReglas[i] = this.SigEntero(contenidoArchivo, indice);
                strReglas[i] = this.SigElemento(contenidoArchivo, indice);
            }

            //Inicializamos la tabla
            var filas = SigEntero(contenidoArchivo, indice);
            var columnas = SigEntero(contenidoArchivo, indice);
            this.tabla = new Array();

            //Llenamos la tabla
            for (var i = 0; i < filas; i++)
                for (var j = 0; j < columnas; j++)
                    tabla[i][j] = SigEntero(contenidoArchivo, indice);

        } catch (Exception) {
            this.arreglosYTablaCargados = false;
            return false;
        }

        this.arreglosYTablaCargados = true;
        return true;
    },

    //================================================================================

    SigElemento: function(contenidoArchivo, indice) {

        var elemento = "";

        //Recorremos los blancos que haya
        if (this.EsBlanco(contenidoArchivo[indice])) {
            do {
                indice++;
            } while (this.EsBlanco(contenidoArchivo[indice]));
        }

        do {
            elemento += contenidoArchivo[indice];
            indice++;
        } while (!this.EsBlanco(contenidoArchivo[indice]));

        return elemento;
    },

    //================================================================================

    SigEntero: function(contenidoArchivo, indice) {
        return Number.toInt(this.SigElemento(contenidoArchivo, indice));
    },

    //================================================================================

    EsBlanco: function(caracter) {
        return String.IsWhiteSpace(caracter);
    }

})
