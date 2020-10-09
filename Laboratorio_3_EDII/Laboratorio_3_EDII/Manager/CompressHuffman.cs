﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using EDII_PROYECTO.Huffman;
using Laboratorio_3_EDII.Helper;
using Laboratorio_3_EDII.IService;

namespace Laboratorio_3_EDII.Manager
{
    public class CompressHuffman : ICompression
    {
        /// <summary>
        /// Obtiene un archivo de texto para devolver un archivo comprimido con extensión .huff
        /// </summary>
        /// <param name="exportado"></param>
        /// <param name="name"></param>
        public void Compress_File(FileStream exportado, string name)
        {
            string nombreArchivo = Path.GetFileNameWithoutExtension(exportado.Name);
            var huffman = new Huffman();
            var PropiedadesArchivoActual = new Files();
            PropiedadesArchivoActual.TamanoArchivoDescomprimido = exportado.Length;
            PropiedadesArchivoActual.NombreArchivoOriginal = exportado.Name;
            exportado.Close();
            var direccion = Path.GetFullPath(exportado.Name);
            int cantidadCaracteres = huffman.Leer(direccion);
            huffman.CrearArbol();
            byte[] encabezado = huffman.CrearEncabezado(cantidadCaracteres);
            var full_path = $"Compress\\" + name + ".huff";
            using (FileStream ArchivoComprimir = new FileStream(full_path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                foreach (var item in encabezado)
                {
                    ArchivoComprimir.WriteByte(item);
                }
                int bufferLength = 80;
                var buffer = new byte[bufferLength];
                string textoCifrado = string.Empty;
                using (var file = new FileStream(exportado.Name, FileMode.Open))
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

        /// <summary>
        /// Obtiene un archivo comprimido con extensión huff y devuelve el archivo original con extensión .txt
        /// </summary>
        /// <param name="Importado"></param>
        public void Decompress_File(FileStream Importado)
        {
            string nombreArchivo = Path.GetFileNameWithoutExtension(Importado.Name);
            var full_path = $"Decompress\\" + nombreArchivo + ".txt";
            using (FileStream archivo = new FileStream(full_path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                int contador = 0;
                int contadorCarac = 0;
                int CantCaracteres = 0;
                int CaracteresDif = 0;
                string texto = string.Empty;
                string acumula = "";
                byte auxiliar = 0;
                int bufferLength = 80;
                var buffer = new byte[bufferLength];
                string textoCifrado = string.Empty;
                Importado.Close();
                using (var file = new FileStream(Importado.Name, FileMode.Open))
                {
                    using (var reader = new BinaryReader(file))
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            buffer = reader.ReadBytes(bufferLength);
                            foreach (var item in buffer)
                            {

                                if (contador == ((CaracteresDif * 2) + 2) && contadorCarac < CantCaracteres)
                                {
                                    texto = Convert.ToString(item, 2);
                                    if (texto.Length < 8)
                                    {
                                        texto = texto.PadLeft(8, '0');
                                    }
                                    acumula = acumula + texto;
                                    int cont = 0;
                                    int canteliminar = 0;
                                    string validacion = "";
                                    foreach (var item2 in acumula)
                                    {
                                        validacion = validacion + item2;
                                        cont++;
                                        if (Data.Instance.DicCarcacteres.ContainsKey(validacion))
                                        {
                                            archivo.WriteByte(Data.Instance.DicCarcacteres[validacion]);
                                            acumula = acumula.Substring(cont);
                                            cont = 0;
                                            contadorCarac++;
                                            canteliminar = cont;
                                            validacion = "";
                                        }
                                    }
                                }
                                if (item != 44)
                                {
                                    byte[] byteCarac = { item };
                                    texto = texto + Encoding.ASCII.GetString(byteCarac);
                                }
                                if (item == 44 && contador > 1 && contador < ((CaracteresDif * 2) + 2))
                                {
                                    if (item == 44 && contador % 2 == 0)
                                    {
                                        auxiliar = Convert.ToByte(texto, 2);
                                        texto = string.Empty;
                                        contador++;
                                    }
                                    else if (contador % 2 != 0 && item == 44)
                                    {
                                        Data.Instance.DicCarcacteres.Add(texto, auxiliar);
                                        texto = string.Empty;
                                        contador++;
                                    }
                                }
                                else
                                {
                                    if (item == 44 && contador == 0)
                                    {
                                        CantCaracteres = int.Parse(texto);
                                        texto = string.Empty;
                                        contador++;
                                    }
                                    else if (item == 44 && contador == 1)
                                    {
                                        CaracteresDif = int.Parse(texto);
                                        texto = string.Empty;
                                        contador++;
                                    }
                                }
                            }
                        }
                        reader.ReadBytes(bufferLength);
                    }
                }
            };
            Data.Instance.DicCarcacteres.Clear();
        }
        public void CompressionHuffman(string Cadena)
        {
            string TextoCifrado = string.Empty;
            var CantidadCaracteres = 0;
            var Huffman = new Huffman();
            CantidadCaracteres = Huffman.LeerCadena(Cadena);
            var ListadoCodigos = Huffman.CrearTree();

            for (int i = 0; i < Cadena.Length; i++)
            {
                foreach (var caracterList in ListadoCodigos)
                {
                    byte caracter = Convert.ToByte(Cadena[i]);
                    if (caracter == caracterList.caracter)
                    {
                        TextoCifrado += caracterList.codigo;
                    }
                }
            }
            Console.WriteLine(TextoCifrado);
        }
    }
}
