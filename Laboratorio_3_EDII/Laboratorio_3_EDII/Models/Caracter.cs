using System;
namespace Laboratorio_3_EDII.Models
{
    public class Caracter : IComparable
    {
        public byte CaracterTexto { get; set; }
        public int Frecuencias { get; set; }
        public int Indice { get; set; }
        public string BinarioText { get; set; }
        public bool CaracterYaRecorrido { get; set; }
        public bool CaraterUsar { get; set; }


        public Caracter()
        {
            CaracterYaRecorrido = false;
            CaraterUsar = false;
        }

        public int CompareTo(object obj)
        {
            var vComparador = (Caracter)obj;
            return CaracterTexto.CompareTo(vComparador.CaracterTexto);
        }
    }
}
