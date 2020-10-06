using System;
using System.IO;
using EDII_PROYECTO.Huffman;
using Laboratorio_3_EDII.IService;

namespace Laboratorio_3_EDII.Manager
{
    public class CompressHuffman : ICompression
    {
        /// <summary>
        /// Obtiene un archivo de texto para devolver un archivo comprimido con extensión .huff
        /// </summary>
        /// <param name="Archivo"></param>
        public void CompresionHuffman(FileStream Archivo)
        {
            string nombreArchivo = Path.GetFileNameWithoutExtension(Archivo.Name);
            var huffman = new Huffman();
            var PropiedadesArchivoActual = new Files();
            PropiedadesArchivoActual.TamanoArchivoDescomprimido = Archivo.Length;
            PropiedadesArchivoActual.NombreArchivoOriginal = Archivo.Name;
            Archivo.Close();
            var direccion = Path.GetFullPath(Archivo.Name);
            int cantidadCaracteres = huffman.Leer(direccion);
            huffman.CrearArbol();
            byte[] encabezado = huffman.CrearEncabezado(cantidadCaracteres);
            nombreArchivo = nombreArchivo.Replace("EXPORTADO_", string.Empty);
            using (FileStream ArchivoComprimir = new FileStream($"TusArchivos/{nombreArchivo}" + ".huff", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                foreach (var item in encabezado)
                {
                    ArchivoComprimir.WriteByte(item);
                }
                int bufferLength = 80;
                var buffer = new byte[bufferLength];
                string textoCifrado = string.Empty;
                using (var file = new FileStream(Archivo.Name, FileMode.Open))
                {
                    using (var reader = new BinaryReader(file))
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            buffer = reader.ReadBytes(bufferLength);
                            foreach (var item in buffer)
                            {
                                int posiList;
                                posiList = Data.Instance.ListaCod.FindIndex(x => x.caracter == item);
                                textoCifrado = textoCifrado + Data.Instance.ListaCod.ElementAt(posiList).codigo;
                                if ((textoCifrado.Length / 8) > 0)
                                {
                                    string escribirByte = textoCifrado.Substring(0, 8);
                                    byte byteEscribir = Convert.ToByte(escribirByte, 2);
                                    ArchivoComprimir.WriteByte(byteEscribir);
                                    textoCifrado = textoCifrado.Substring(8);
                                }
                            }
                        }
                        reader.ReadBytes(bufferLength);
                    }
                }
                if (textoCifrado.Length > 0 && (textoCifrado.Length % 8) == 0)
                {
                    byte byteEsc = Convert.ToByte(textoCifrado, 2);
                }
                else if (textoCifrado.Length > 0)
                {
                    textoCifrado = textoCifrado.PadRight(8, '0');
                    byte byteEsc = Convert.ToByte(textoCifrado, 2);
                }
            }
        }


        public void DescompresionHuffman(FileStream ArchivoImportado)
        {
            throw new NotImplementedException();
        }
    }
}
