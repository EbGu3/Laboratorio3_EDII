using Laboratorio_3_EDII.Models;
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
            compressLZW.Compress_Text("ABRACADABRA");
            Console.ReadKey();










            while (true)
            {
                Console.WriteLine("\t..::LZW::..");
                Console.WriteLine("Ingrese una opción:");
                Console.WriteLine("  1)Compresión");
                Console.WriteLine("  2)Descompresión");
                Console.WriteLine("  3)Salir");
                var option = Console.ReadLine();
                var RUTA = string.Empty;
                var newName = string.Empty;
                FileHandeling fileHandeling = new FileHandeling();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Ingrese la ruta del archivo a comprimir (extensión .txt)");
                        RUTA = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre del nuevo archivo");
                        newName = Console.ReadLine();
                        fileHandeling.Create_File_Import();
                        using (var File = new FileStream(RUTA, FileMode.OpenOrCreate))
                        {
                            var ext = Path.GetExtension(File.Name);
                            var new_Path = string.Empty;
                            var old_Name = Path.GetFileName(File.Name);
                            var path = Path.Combine($"Upload", old_Name);
                            using (var this_file = new FileStream(path, FileMode.Create))
                            {
                                await File.CopyToAsync(this_file);
                                new_Path = Path.GetFullPath(this_file.Name);
                            }
                            fileHandeling.Compress_LZW(new_Path, newName);
                            System.IO.File.Delete(path);
                        }
                        Console.WriteLine("Archivo compreso exitosamente!");
                        break;
                    case "2":
                        Console.WriteLine("Ingrese la ruta del archivo a descomprimir (extensión .lzw)");
                        RUTA = Console.ReadLine();
                        fileHandeling.Create_File_Export();
                        using (var File = new FileStream(RUTA, FileMode.OpenOrCreate))
                        {
                            var ext = Path.GetExtension(File.Name);
                            var new_Path = string.Empty;
                            var path = Path.Combine($"Upload", newName + ext);
                            using (var this_file = new FileStream(path, FileMode.Create))
                            {
                                await File.CopyToAsync(this_file);
                                new_Path = Path.GetFullPath(this_file.Name);
                            }
                            fileHandeling.Decompress_LZW(new_Path);
                            System.IO.File.Delete(path);
                        }
                        Console.WriteLine("Archivo descompreso exitosamente!");
                        break;
                    case "3":
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
