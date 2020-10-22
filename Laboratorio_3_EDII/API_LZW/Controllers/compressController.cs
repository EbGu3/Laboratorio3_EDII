using System;
using System.IO;
using System.Threading.Tasks;
using Laboratorio_3_EDII.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_LZW.Controllers
{
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
            try
            {
                if (Path.GetExtension(file.FileName) == ".txt")
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
                    fileHandeling.Compress_LZW(new_Path, name);
                    fileHandeling.Delete_Import(path);
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
