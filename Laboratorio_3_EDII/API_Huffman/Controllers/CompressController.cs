using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Laboratorio_3_EDII.Manager;
using System.IO;

namespace API_Huffman.Controllers
{
    /// <summary>
    /// Compresión de archivos de texto
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class compressController : ControllerBase
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
            try
            {
                if (Path.GetExtension(file.FileName) == ".txt")
                {
                    var new_Path = string.Empty;
                    using (var this_file = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(this_file);
                        new_Path = Path.GetFullPath(this_file.Name);
                    }
                    using (var new_File = new FileStream(new_Path, FileMode.Open))
                    {
                        CompressHuffman Huffman = new CompressHuffman();
                        Huffman.Compress_File(new_File, name);
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
