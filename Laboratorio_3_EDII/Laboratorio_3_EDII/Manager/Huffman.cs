using System;
using System.IO;
using System.Collections.Generic;
using Laboratorio_3_EDII.Models;
using Laboratorio_3_EDII.IService;
using System.Linq;

namespace Laboratorio_3_EDII.Manager
{
    public class Huffman : IHuffman
    {
        List<Nodo> Frecuencias = new List<Nodo>();

        public int Leer(string Direccion)
        {
            var NoCaracteres = 0;
            const int BufferLength = 80;
            var Buffer = new byte[BufferLength];
            var File = Direccion;

            using(var Lectura  = new FileStream(Direccion, FileMode.Open))
            {
                using(var Reader = new BinaryReader(Lectura))
                {
                    while(Reader.BaseStream.Position != Reader.BaseStream.Length)
                    {
                        Buffer = Reader.ReadBytes(BufferLength);

                        foreach (var item in Buffer)
                        {
                            NoCaracteres++;
                            ConteoDeFrecuncia(item);
                        }
                    }
                    Reader.ReadBytes(BufferLength);
                }
            }
            return NoCaracteres;
        }

        public void ConteoDeFrecuncia(byte Elemento)
        {
            int posicionLista;
            if(Frecuencias.Exists(x => x.Caracter == Elemento))
            {
                posicionLista = Frecuencias.FindIndex(x => x.Caracter == Elemento);

                Nodo Prueba = new Nodo();
                Prueba = Frecuencias.Find(x => x.Caracter == Elemento);
                Frecuencias.RemoveAt(posicionLista);
                Frecuencias.Add(new Nodo()
                {
                    Caracter = Elemento,
                    Probabilidad = Prueba.Probabilidad + 1
                });
            }
            else
            {
                Frecuencias.Add(new Nodo()
                {
                    Caracter = Elemento,
                    Probabilidad = 1
                });
            }
        }

        public void CrearArbol()
        {
            List<Nodo> FrecuenciaOrden = new List<Nodo>();
            FrecuenciaOrden = FrecuenciaOrden.OrderBy(x => x.Probabilidad).ToList();

            Arbol ArbolH = new Arbol();

            ArbolH.EtiquetarNodo(ArbolH.ConstruirNodo(FrecuenciaOrden));

            //Agregar Instancia a la API
        }
        public byte[] CrearEncabezado(int noCaracteres)
        {
            double noElementos = Data.Instance.ListaCod.LongCount();
            string codigo = noCaracteres + "," + noElementos;
            foreach (var cosa in Data.Instance.ListaCod)
            {
                string p = Convert.ToString(cosa.caracter, 2);
                codigo = codigo + "," + p;
                codigo = codigo + "," + cosa.codigo;
            }
            byte[] encabezadoBytes = Encoding.ASCII.GetBytes(codigo + ",");
            return encabezadoBytes;
        }
    }
}
