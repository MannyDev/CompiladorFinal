using System;
using System.Windows.Forms;
using System.IO;

namespace Compiladores
{
    /// <summary>
    /// Se encarga de traducir a código ensamblador
    /// </summary>
    public class GeneradorCodigoEnsamblador
    {
        private String codigoEnsamblador;
        private NodoSemantico raizArbolSemantico;
        private String rutaArchivoAsm;

        /// <summary>
        /// El código ensamblador generado
        /// </summary>
        public String CodigoEnsamblador
        {
            get { return codigoEnsamblador; }
        }

        /// <summary>
        /// Obtiene o modifica la ruta que usa el generador de código para 
        /// crear el archivo .asm
        /// </summary>
        public String RutaArchivoAsm
        {
            get { return rutaArchivoAsm; }
            set { rutaArchivoAsm = value; }
        }

        //================================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="raizArbolSemantico">El árbol semántico del cual se obtiene el código ensamblador</param>
        public GeneradorCodigoEnsamblador(NodoSemantico raizArbolSemantico)
        {
            codigoEnsamblador = "";
            this.raizArbolSemantico = raizArbolSemantico;
        }

        //================================================================================

        /// <summary>
        /// Crea el código ensamblador en base al árbol semántico dado
        /// </summary>
        public void GeneraCodigo()
        {
            raizArbolSemantico.GeneraCodigoEnsamblador();
            codigoEnsamblador = raizArbolSemantico.CodigoEnsamblador;
        }

        //================================================================================

        /// <summary>
        /// Crea el archivo .asm con el código en ensamblador obtenido del árbol semántico
        /// </summary>
        /// <returns></returns>
        public bool CreaArchivoAsm()
        {
            try
            {
                using (FileStream flujoArchivo = new FileStream("prueba.asm", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter escritor = new StreamWriter(flujoArchivo))
                    {
                        escritor.Write(codigoEnsamblador);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al intentar guardar el archivo prueba.asm, el error fue el siguiente: " + ex.ToString(), "Error al guardar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public String ObtieneCodigoVariable(String identificador)
        {
            return "";
        }

        /// <summary>
        /// Revisa si el nombre del identificador actual ya lo tiene algún simbolo en la 
        /// tabla de simbolos, si esto es cierto entonces genera un nombre disponible (no 
        /// ocupado por ningún otro simbolo en la tabla de simbolos) y lo guarda en 
        /// identificadorSecundario
        /// </summary>
        /// <returns></returns>
        private String ObtieneIdentificadorLibre()
        {
            String identificadorLibre = "";
            //Buscamos si ya definieron globalmente esta variable
            /*if (NodoSemantico.TablaDeSimbolos.VariableGlobalDefinida(texto))
            {
                int numeroLibre = 1;
                //Nos ciclamos buscando un nombre disponible
                do
                {
                    numeroLibre++;
                } while (NodoSemantico.TablaDeSimbolos.VariableGlobalDefinida(identificadorSecundario + numeroLibre.ToString()));

                //Cuando hayamos un nombre disponible lo guardamos como el nuevo
                //identificadorSecundario
                identificadorSecundario += numeroLibre.ToString();
            }*/
            return identificadorLibre;
        }
    }
}
