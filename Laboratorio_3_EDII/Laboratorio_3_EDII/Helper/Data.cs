using System;
using System.Collections.Generic;
using System.Text;
using static Laboratorio_3_EDII.Manager.Arbol;

namespace Laboratorio_3_EDII.Helper
{
    public class Data
    {
        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null) _instance = new Data();
                return _instance;
            }
        }
        public int value;
        public List<CaracterCodigo> ListaCod = new List<CaracterCodigo>();
        public Dictionary<string, byte> DicCarcacteres = new Dictionary<string, byte>();
        public string DirectorioHuff;
        public int grade;
        public Delegate getNode;
        public Delegate getText;
        public string adress;
    }
}
