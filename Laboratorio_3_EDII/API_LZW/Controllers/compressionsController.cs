using System;
using Laboratorio_3_EDII.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_LZW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class compressionsController : ControllerBase
    {
        /// <summary>
        /// Despliega en formato Json los parametros respectivos de las compresiones
        /// </summary>
        /// <response code="200">Muestra de json con compresiones</response>
        /// <response code="500">No se han realizado compresiones previas</response>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get_File()
        {
            try
            {
                FileHandeling fileHandeling = new FileHandeling();
                return Ok(fileHandeling.Get_Compress("LZW"));
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se han realizado compresiones previas - " + e.Message);
            }
        }
    }
}
