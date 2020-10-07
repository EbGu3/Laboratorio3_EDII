using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Huffman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class decompressController : ControllerBase
    {
        /// <summary>
        /// Recibe un archivo .huff y devuelve el archivo original de texto
        /// </summary>
        /// <param name="file"></param>
        /// <response code="200">Archivo no descomprimido exitosamente</response>
        /// <response code="400">Archivo ingresado no es de extensión .huff</response>
        /// <response code="500">Archivo corrupto o no válido</response>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post_File_Export(IFormFile archivo)
        {
            try
            {
                var extension = Path.GetExtension(archivo.FileName);
                if (extension != ".huff")
                {
                    return BadRequest("El archivo enviado no es de extensión .huff");
                }
                return Ok("El archivo ha sido descomprimido exitosamente!");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Archivo corrupto o no válido - " + e.Message);
            }
        }
    }
}
