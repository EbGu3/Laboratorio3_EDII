using System;
namespace Laboratorio_3_EDII.Huffman
{
    public class CodigoCaracter
    {
        public string Codigo { get; set; }
        public byte Caracter { get; set; }

        public CodigoCaracter(byte caracter, string codigo)
        {
            Codigo = codigo;
            Caracter = caracter;
        }
    }
}
