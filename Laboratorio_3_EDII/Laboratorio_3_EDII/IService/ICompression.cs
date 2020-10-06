using System;
using System.IO;
namespace Laboratorio_3_EDII.IService
{
    public interface ICompression
    {
        public void CompresionHuffman(FileStream Archivo);
        public void DescompresionHuffman(FileStream ArchivoImportado);
    }
}
