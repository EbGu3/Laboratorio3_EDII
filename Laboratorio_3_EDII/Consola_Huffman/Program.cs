using System;
using Laboratorio_3_EDII.Manager;
using Laboratorio_3_EDII.IService;
using Laboratorio_3_EDII.Models;
using Laboratorio_3_EDII.Helper;

namespace Consola_Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el texto a comprimir");
            string Cadena = Console.ReadLine();

            var CompressHuffman = new CompressHuffman();
            CompressHuffman.CompressionHuffman(Cadena);
        }
    }
}
