using System;
using System.Collections.Generic;
using Laboratorio3_EDII.Huffaman;

namespace Laboratorio3_EDII.IHuffaman
{
    public interface IHuffman<T>
    {
        public Nodo ConstruirArbol(List<Nodo> Probabilidades);

    }
}
