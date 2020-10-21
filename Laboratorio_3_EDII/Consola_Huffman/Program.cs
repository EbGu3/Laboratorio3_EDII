using System;
using Laboratorio_3_EDII.Manager;
using Laboratorio_3_EDII.IService;
using Laboratorio_3_EDII.Models;
using Laboratorio_3_EDII.Helper;
using System.IO;

namespace Consola_Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el texto a comprimir");
            string Cadena = Console.ReadLine();

            var CompressHuffman = new CompressHuffman();
            Console.WriteLine("Cadena: " + Cadena);
            Console.WriteLine("Compresa Huffman: " + CompressHuffman.CompressionHuffman(Cadena));
            Console.ReadKey();

            string RUTA = "/Users/eber.g/Desktop/PrimerAño/2Ciclo2020/EstructuraDatos II/Laboratorios/Laboratorio4_EDII/Laboratorio3_EDII/Laboratorio_3_EDII/Consola_Huffman/bin/Debug/netcoreapp3.1/Compress/Eber.lzw";





            using(var File  = new FileStream(RUTA, FileMode.OpenOrCreate))
            {
                FileHandeling fileHandeling = new FileHandeling();
                var extesión = Path.GetExtension(File.Name);

                if(extesión == ".txt")
                {
                    fileHandeling.Create_File_Import();
                    fileHandeling.Compress_LZW(File.Name, "Eber");

                }
                else if(extesión == ".lzw")
                {
                    fileHandeling.Create_File_Export();
                    fileHandeling.Decompress_LZW(File.Name);
                }

            }
            


        }
    }
}
