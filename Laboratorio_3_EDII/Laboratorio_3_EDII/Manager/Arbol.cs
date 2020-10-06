using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Laboratorio_3_EDII.Huffman;
using Laboratorio_3_EDII.IService;
using Laboratorio_3_EDII.Models;

namespace Laboratorio_3_EDII.Manager
{
    public class Arbol 
    {
        public Nodo Raiz { get; set; }
        public List<CodigoCaracter> ListaCodigos { get; set; }

        /// <summary>
        /// Crea el nodo para ser usado
        /// </summary>
        /// <param name="derecho"></param>
        /// <param name="izquierdo"></param>
        /// <returns></returns>
        public Nodo NodoPadre(Nodo derecho, Nodo izquierdo)
        {
            Nodo Padre = new Nodo(0, derecho.Probabilidad + izquierdo.Probabilidad);
            Padre.Derecho = derecho;
            Padre.Izquierdo = izquierdo;
            return Padre;
        }

        /// <summary>
        /// Distribuye los valores dentro de un nodo
        /// </summary>
        /// <param name="ListaProbabilidades"></param>
        /// <returns></returns>
        public Nodo ConstruirNodo(List<Nodo> ListaProbabilidades)
        {
            List<Nodo> LPrincipal = ListaProbabilidades;
            List<Nodo> LSecundaria = new List<Nodo>();

            while (LPrincipal.Count > 2)
            {
                LSecundaria = LPrincipal;
                Nodo nuevoNodo = NodoPadre(LSecundaria[0], LSecundaria[1]);
                LSecundaria.RemoveRange(0, 2);
                LSecundaria.Add(nuevoNodo);
                LPrincipal = LSecundaria.OrderBy(o => o.Probabilidad).ToList();
            }
            return Raiz = NodoPadre(LPrincipal[0], LPrincipal[1]);
        }

        /// <summary>
        /// Realiza la asignación de cógidos prefijos
        /// </summary>
        /// <param name="Raiz"></param>
        public void EtiquetarNodo(Nodo Raiz)
        {
            string Etiquette = Raiz.Etiqueta;
            if (Raiz.Izquierdo != null)
            {
                Raiz.Izquierdo.Etiqueta = Etiquette + "0";
                EtiquetarNodo(Raiz.Izquierdo);
            }
            if (Raiz.Derecho != null)
            {
                //Ó un 1 cuando es hijo derecho
                Raiz.Derecho.Etiqueta = Etiquette + "1";
                EtiquetarNodo(Raiz.Derecho);
            }
            if (Raiz.Derecho == null && Raiz.Izquierdo == null)
            {
                CodigoCaracter nuevoCaracter = new CodigoCaracter(Raiz.Caracter, Raiz.Etiqueta);
                ListaCodigos.Add(nuevoCaracter);
            }
        }
    }
}
