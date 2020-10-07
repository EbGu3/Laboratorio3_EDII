using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Huffman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class compressionsController : ControllerBase
    {
        /// <summary>
        /// Devuelve un listado Json con las compresiones
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get_File()
        {
            return Ok();
        }
    }
}
