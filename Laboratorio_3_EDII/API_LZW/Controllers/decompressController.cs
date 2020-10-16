using System;
using System.IO;
using System.Threading.Tasks;
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
            if (!Directory.Exists($"Upload"))
            {
                Directory.CreateDirectory($"Upload");
            }
            if (!Directory.Exists($"Decompress"))
            {
                Directory.CreateDirectory($"Decompress");
            }
            var path = Path.Combine($"Upload", file.FileName);
            try
            {
                if (Path.GetExtension(file.FileName) == ".lzw")
                {
                    var new_Path = string.Empty;
                    using (var this_file = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(this_file);
                        new_Path = Path.GetFullPath(this_file.Name);
                    }
                    using (var new_File = new FileStream(new_Path, FileMode.Open))
                    {
                        //Llamar para descompresionar
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
