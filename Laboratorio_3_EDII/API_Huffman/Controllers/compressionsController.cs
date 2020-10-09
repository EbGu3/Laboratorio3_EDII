using EDII_PROYECTO.Huffman;
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
        public ActionResult Get_File()
        {
            try
            {
                var full_path = $"Compress\\Factores de Compresion.txt";
                List<Files> json = new List<Files>();
                using (StreamReader file = new StreamReader(full_path))
                {
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                        Files values = new Files();
                        values.NombreArchivoOriginal = ln;
                        ln = file.ReadLine();
                        values.RutaArchivoComprimido = ln;
                        ln = file.ReadLine();
                        values.RazonCompresion = Convert.ToDouble(ln);
                        ln = file.ReadLine();
                        values.FactorCompresion = Convert.ToDouble(ln);
                        ln = file.ReadLine();
                        values.PorcentajeReduccion = ln;
                        json.Add(values);
                    }
                }
                var retorno = JsonConvert.SerializeObject(json);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se han realizado compresiones previas - " + e.Message);
            }
        }
    }
}
