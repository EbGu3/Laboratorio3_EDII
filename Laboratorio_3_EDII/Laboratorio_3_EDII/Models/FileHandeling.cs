﻿using EDII_PROYECTO.Huffman;
using Laboratorio_3_EDII.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Laboratorio_3_EDII.Models
{
    public class FileHandeling
    {
        /// <summary>
        /// Create Upload and Compress files
        /// </summary>
        public void Create_File_Import()
        {
            if (!Directory.Exists($"Upload"))
            {
                Directory.CreateDirectory($"Upload");
            }
            if (!Directory.Exists($"Compress"))
            {
                Directory.CreateDirectory($"Compress");
            }
        }
        /// <summary>
        /// Create Upload and Decompress files
        /// </summary>
        public void Create_File_Export()
        {
            if (!Directory.Exists($"Upload"))
            {
                Directory.CreateDirectory($"Upload");
            }
            if (!Directory.Exists($"Decompress"))
            {
                Directory.CreateDirectory($"Decompress");
            }
        }
        /// <summary>
        /// Huffman compress files
        /// </summary>
        /// <param name="new_Path"></param>
        /// <param name="name"></param>
        public void Compress_Huffman(string new_Path, string name)
        {
            using (var new_File = new FileStream(new_Path, FileMode.Open))
            {
                CompressHuffman Huffman = new CompressHuffman();
                Huffman.Compress_File(new_File, name);
            }
        }
        /// <summary>
        /// Huffman decompress files
        /// </summary>
        /// <param name="new_Path"></param>
        public void Decompress_Huffman(string new_Path)
        {
            using (var new_File = new FileStream(new_Path, FileMode.Open))
            {
                CompressHuffman Huffman = new CompressHuffman();
                Huffman.Decompress_File(new_File);
            }
        }
        /// <summary>
        /// LZW compress files
        /// </summary>
        /// <param name="new_Path"></param>
        /// <param name="name"></param>
        public void Compress_LZW(string new_Path, string name)
        {
            using (var new_File = new FileStream(new_Path, FileMode.Open))
            {
                //Mandar archivo a compresión
            }
        }
        /// <summary>
        /// LZW decompress files
        /// </summary>
        /// <param name="new_Path"></param>
        /// <param name="name"></param>
        public void Decompress_LZW(string new_Path)
        {
            using (var new_File = new FileStream(new_Path, FileMode.Open))
            {
                //Llamar para descompresionar
            }
        }
        public string Get_Compress(string type)
        {
            var full_path = $"Compress\\Factores de Compresion " + type + ".txt";
            List<Files> json = new List<Files>();
            using (StreamReader file = new StreamReader(full_path))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    Files values = new Files();
                    values.NombreArchivoOriginal = ln;
                    ln = file.ReadLine();
                    values.RutaArchivoComprimido = ln;
                    ln = file.ReadLine();
                    values.RazonCompresion = Convert.ToDouble(ln);
                    ln = file.ReadLine();
                    values.FactorCompresion = Convert.ToDouble(ln);
                    ln = file.ReadLine();
                    values.PorcentajeReduccion = ln;
                    json.Add(values);
                }
            }
            return JsonConvert.SerializeObject(json);
        }
    }
}
