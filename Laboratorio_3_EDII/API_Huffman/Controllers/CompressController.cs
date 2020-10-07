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
    [Route("api/[controller]")]
    [ApiController]
    public class CompressController : ControllerBase
    {
        /// <summary>
        /// Obtiene un archivo de texto y devuelve {nombre}.huff
        /// </summary>
        /// <param name="file"></param>
        /// <response code="200">Archivo no comprimido exitosamente</response>
        /// <response code="400">Archivo ingresado no es de extensión .txt</response>
        /// <response code="500">Archivo corrupto o no válido</response>
        /// <returns></returns>
        [HttpPost, Route("{name}")]
        public ActionResult Post_File_Import(IFormFile name)
        {
            try
            {
                var extension = Path.GetExtension(name.FileName);
                if (extension != ".txt")
                {
                    return BadRequest("El archivo enviado no es de extensión .txt");
                }
                return Ok("El archivo ha sido comprimido exitosamente!");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Archivo corrupto o no válido - " + e.Message);
            }
        }
    }
}
