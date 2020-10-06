using System;
namespace Laboratorio_3_EDII.Models
{
    public class Nodo
    {
        public string Etiqueta { get; set; }
        public double Probabilidad { get; set; }
        public byte Caracter { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(byte caracter = 0, double probabilidad = 0)
        {
            Caracter = caracter;
            Probabilidad = probabilidad;
            Etiqueta = "";
            Izquierdo = null;
            Derecho = null;
        }
    }
}
