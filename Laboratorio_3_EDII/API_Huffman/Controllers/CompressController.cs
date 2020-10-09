using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Laboratorio_3_EDII;
using System.IO;

namespace API_Huffman.Controllers
{
    /// <summary>
    /// Compresión de archivos de texto
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompressController : ControllerBase
    {
        /// <summary>
        /// Importación del archivo para comprimir
        /// </summary>
        /// <param name="file"></param>
        /// <param name="name"></param>
        /// <response code="200">Archivo comprimido exitosamente</response>
        /// <response code="400">Archivo ingresado no es de extensión .txt</response>
        /// <response code="500">Archivo corrupto o no válido</response>
        /// <returns></returns>
        [HttpPost, Route("{name?}")]
        public async Task<ActionResult> Post_File_Import(IFormFile file, string name)
        {
            if (!Directory.Exists($"Upload"))
            {
                Directory.CreateDirectory($"Upload");
            }
            if (!Directory.Exists($"Compress"))
            {
                Directory.CreateDirectory($"Compress");
            }
            var path = Path.Combine($"Upload", file.FileName);
            //Comprobar directorios
            try
            {
                if (Path.GetExtension(file.FileName) == ".txt")
                {
                    using (var this_file = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(this_file);
                    }
                    return Ok("El archivo ha sido comprimido exitosamente!");
                }
                return BadRequest("El archivo enviado no es de extensión .txt");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Archivo corrupto o no válido - " + e.Message);
            }
        }
    }
}
