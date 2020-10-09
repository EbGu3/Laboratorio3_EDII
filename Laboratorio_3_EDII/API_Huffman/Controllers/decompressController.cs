﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Huffman.Controllers
{
    /// <summary>
    /// Descompresión de archivos huffman
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class decompressController : ControllerBase
    {
        /// <summary>
        /// Recibe un archivo .huff y devuelve el archivo original de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <response code="200">Archivo descomprimido exitosamente</response>
        /// <response code="400">Archivo ingresado no es de extensión .huff</response>
        /// <response code="500">Archivo corrupto o no válido</response>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post_File_Export(IFormFile archivo)
        {
            if (!Directory.Exists($"Upload"))
            {
                Directory.CreateDirectory($"Upload");
            }
            if (!Directory.Exists($"Decompress"))
            {
                Directory.CreateDirectory($"Decompress");
            }
            //Comprobar directorios
            try
            {
                var extension = Path.GetExtension(archivo.FileName);
                if (extension == ".huff")
                {
                    return Ok("El archivo ha sido descomprimido exitosamente!");
                }
                return BadRequest("El archivo enviado no es de extensión .huff");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Archivo corrupto o no válido - " + e.Message);
            }
        }
    }
}
