using System;
using System.Collections;

namespace MT
{
    public class Transicion
    {
        private Hashtable transTabla;
        public Transicion()
        {
            transTabla = new Hashtable();
        }

        public void printTansiciones()
        {          
            foreach (DictionaryEntry t in this.transTabla)
            {
                char lectura = (char)t.Key;
                Object[] control =(Object[]) t.Value;
                Console.WriteLine(
                    " Símbolo de lectura {0}, " +
                    " Estado destino {1}," +
                    " Simbolo de escritura {2}" +
                    " Desplazamiento de cabezal {3}",lectura,control[0],control[1],control[2]
                    );
            }

        }

        public void setTransicion(char r, int idEdoDestino, String w, int d)
        {
            Object[] ctrl = new object[3];
            ctrl[0] = idEdoDestino;
            ctrl[1] = w;
            ctrl[2] = d;
            this.transTabla.Add(r, ctrl);
        }

        public Object[] getValueofReading(char lectura)
        {
            return (Object[])this.transTabla[lectura];
        }

    }
}
