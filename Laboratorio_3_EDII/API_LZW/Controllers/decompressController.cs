using System;
using System.IO;
using System.Threading.Tasks;
using Laboratorio_3_EDII.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_LZW.Controllers
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
        /// <param name="file"></param>
        /// <response code="200">Archivo descomprimido exitosamente</response>
        /// <response code="400">Archivo ingresado no es de extensión .huff</response>
        /// <response code="500">Archivo corrupto o no válido</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post_File_Export(IFormFile file)
        {
            try
            {
                if (Path.GetExtension(file.FileName) == ".lzw")
                {
                    FileHandeling fileHandeling = new FileHandeling();
                    fileHandeling.Create_File_Import();
                    var new_Path = string.Empty;
                    var path = Path.Combine($"Upload", file.FileName);
                    using (var this_file = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(this_file);
                        new_Path = Path.GetFullPath(this_file.Name);
                    }

                    return Ok("El archivo ha sido descomprimido exitosamente!");
                }
                return BadRequest("El archivo enviado no es de extensión .lzw");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Archivo corrupto o no válido - " + e.Message);
            }
        }
    }
}
