using System;
using System.IO;
using EDII_PROYECTO.Huffman;

namespace Laboratorio_3_EDII.Models
{
    public class Factor
    {
        public void GuaradarCompresiones(Files Archivo, string tipo)
        {
            string ArchivoMapeo = "TusArchivos/" + tipo;
            string archivoLeer = ArchivoMapeo + Path.GetFileName("ListaCompresiones");
            using (var writer = new StreamWriter(archivoLeer, true))
            {
                if (!(Archivo.TamanoArchivoComprimido <= 0 && Archivo.TamanoArchivoDescomprimido <= 0))
                {
                    writer.WriteLine(Archivo.NombreArchivoOriginal + "|" + Archivo.TamanoArchivoDescomprimido + "|" + Archivo.TamanoArchivoComprimido + "|" + Archivo.FactorCompresion + "|" + Archivo.RazonCompresion + "|" + Archivo.PorcentajeReduccion + "|" + Archivo.FormatoCompresion);
                }
            }
        }
    }
}
