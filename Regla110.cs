using System;
using System.Collections;
namespace MT
{
    public class Regla110
    {
        private Hashtable reglas = new Hashtable();
        ArrayList matrix = new ArrayList();
        public Regla110()
        {
             this.reglas.Add("   ", ' ');
             this.reglas.Add("  ▄", '▄');
             this.reglas.Add(" ▄ ", '▄');
             this.reglas.Add(" ▄▄", '▄');
             this.reglas.Add("▄  ", ' ');
             this.reglas.Add("▄ ▄", '▄');
             this.reglas.Add("▄▄ ", '▄');
             this.reglas.Add("▄▄▄", ' ');
        }

        public void play(int k,String cad)
        {
            String cta_ref = "";
            String temp_T = cad;
            int n = cad.Length - 2;
            //LLenamos la cinta de refercia de ceros 
            for (int i = 0; i < cad.Length; i++)
                cta_ref += "▄";
            //Agloritmo R110
            for(int i=0; i<k; i++)
            {
                String n_cta = cta_ref;
                for(int j=0; j<n; j++)
                {
                    String s = reglas[temp_T.Substring(j, 3)].ToString();
                    n_cta = n_cta.Remove(j+1, 1);
                    n_cta = n_cta.Insert(j+1, s);
                }
                Console.WriteLine(n_cta);
                temp_T = n_cta;
            }
        }

        public void acoplamiento(String cad, int k, Automata mt)
        {

            String cta_ref = "";
            String temp_T = cad;
            int n = cad.Length - 2;
            //LLenamos la cinta de referencia de ceros 
            for (int i = 0; i < cad.Length; i++)
                cta_ref += "▄";

            //Agloritmo R110
            String n_cta = cta_ref;
            for(int i=0; i<k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    String s = reglas[temp_T.Substring(j,3)].ToString();
                    n_cta = n_cta.Remove(j + 1, 1);
                    n_cta = n_cta.Insert(j + 1, s);
                }
                //Acoplamiento
                Console.WriteLine(mt.analizaEntrada2(n_cta));
                temp_T = n_cta;
            }
        }

    }
}

