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
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Ingrese el texto a comprimir");
            string Cadena = Console.ReadLine();

            var CompressHuffman = new CompressHuffman();
            Console.WriteLine("Cadena: " + Cadena);
            Console.WriteLine("Compresa Huffman: " + CompressHuffman.CompressionHuffman(Cadena));
            Console.ReadKey();

        }
    }
}
