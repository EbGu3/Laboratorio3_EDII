﻿using Laboratorio_3_EDII.Models;
using System;
using System.IO;
using Laboratorio_3_EDII.Manager;

namespace Consola_LZW
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            CompressLZW compressLZW = new CompressLZW();
            while (true)
            {
                Console.WriteLine("\t..::LZW::..");
                Console.WriteLine("Ingrese una opción:");
                Console.WriteLine("  1)Compresión");
                Console.WriteLine("  2)Salir");
                var option = Console.ReadLine();
                var RUTA = string.Empty;
                var newName = string.Empty;
                FileHandeling fileHandeling = new FileHandeling();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Ingrese el texto a comprimir");
                        var Texto_Comprimir = Console.ReadLine();
                        var Texto_Comprimido = compressLZW.Compress_Text(Texto_Comprimir);
                        Console.WriteLine($"El texto comprimido es: {Texto_Comprimido}");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Saliendo...");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Por favor seleccione una opción válida.");
                        break;
                }
            }
        }
    }
}
