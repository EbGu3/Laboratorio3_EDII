﻿using EDII_PROYECTO.Huffman;
using Laboratorio_3_EDII.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace API_Huffman.Controllers
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get_File()
        {
            try
            {
                FileHandeling fileHandeling = new FileHandeling();
                return Ok(fileHandeling.Get_Compress("Huffman"));
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se han realizado compresiones previas - " + e.Message);
            }
        }
    }
}
