using System;
namespace Laboratorio3_EDII.Huffaman
{
    public class Nodo
    {
        public string Etiqueta { get; set; }
        public double Probabilidad { get; set; }
        public byte Caracter { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(byte caracter, double probabilidad)
        {
            Caracter = caracter;
            Probabilidad = probabilidad;
            Etiqueta = "";
            Izquierdo = null;
            Derecho = null;
        }
    }
}
