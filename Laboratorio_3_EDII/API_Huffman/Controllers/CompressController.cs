using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Laboratorio_3_EDII;

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
        /// <returns></returns>
        [HttpPost, Route("{name}")]
        public ActionResult Post_File_Import(IFormFile name)
        {
            return Ok();
        }
    }
}
