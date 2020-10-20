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

            string RUTA = "/Users/eber.g/Desktop/Prueba.txt";

            using(var File  = new FileStream(RUTA, FileMode.OpenOrCreate))
            {
                CompressLZW compressLZW = new CompressLZW();

                compressLZW.CompresionLZWImportar(File);

            }
            


        }
    }
}
