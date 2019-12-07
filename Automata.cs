using System;
using System.Collections.Generic;
namespace MT
{
    public class Automata
    {
        private Estado[] aut;
        private String cinta;
        private int num_trasnciones=0;

        public Automata(int numEdos)
        {
            aut = new Estado[numEdos];

        }

        public void creaAutomata()
        {
            for (int i=0; i<this.aut.Length; i++)
            {
                Estado e = new Estado(i);
                aut[i] = e;
            }
        }
        
        public void asignaTransiciones(int idEdo,char r, int idEdoDestino,String w, int d)
        {   
            this.aut[idEdo].updateTablaTrans(r, idEdoDestino, w, d);
        }


        public void imprimeAutomata()
        {
            {
                for(int i=0; i<aut.Length; i++)
                {
                    Console.WriteLine("Estado " + this.aut[i].getIdEdo() + "\n");
                    this.aut[i].getTabTransiciones().printTansiciones();
                }
            }
        }

        public void asignaEdoAceptacion(int idEdo)
        {
            this.aut[idEdo].setAceptacion();
            this.aut[idEdo].updateTablaTrans('$', idEdo, "", 1);
        }


        public void analizaEntrada(String entrada)
        {
            this.cinta = "b" + entrada + "b";
            if (motor())
            {
                Console.WriteLine("\n Salida: " + this.cinta +"\n");
                Console.WriteLine("\n Numero de transiciones : " + this.num_trasnciones+"\n");
            }
            else
            {
                Console.WriteLine("\n ¡ Cadena no eceptada ! \n");
            }
        }

        public String analizaEntrada2(String entrada)
        {
            this.cinta = "b" + entrada + "b";
            if (motor())
                return cinta;
            else
                return "";

        }


        private bool MotorRecursivo(Estado e, char lec, String esc, int idx_cta)
        {
            if (e.getAceptacion() == true)
            {
                //Si el estado es de aceptacion salimos, la cadena se acepta
                return true;
            }
            else
            {
                //Escribimos en la cinta
                this.cinta = this.cinta.Remove(idx_cta, 1);
                this.cinta = this.cinta.Insert(idx_cta, esc);
                //Actualizamos datos para la sig llamda recursiva
                lec = (char) this.cinta[idx_cta]; //LEctura
                esc = (String) e.getControles(lec)[1]; //Escritura
                e = aut[(int)e.getControles(lec)[0]]; //Sig edo
                idx_cta += (int)e.getControles(lec)[2]; //moviento del cabezal
                return MotorRecursivo(e,lec,esc,idx_cta);
            }
        }

        private bool motor()
        {
            int idx_edos = 0, idx_cta=1, m;
            String w;
            char r;
            Object[] ctrl = new object[3];
            Estado e = this.aut[idx_edos];
            try
            {
                while (e.getAceptacion() != true)
                {
                    r = cinta[idx_cta];
                    ctrl = e.getControles(r);
                    idx_edos = (int)ctrl[0];
                    w = (String)ctrl[1];
                    m = (int)ctrl[2];
                    this.cinta = this.cinta.Remove(idx_cta, 1);
                    this.cinta = this.cinta.Insert(idx_cta, w);
                    /*
                      Si leemos un simbolo 'b' en el ultimo extremo de la cinta
                      y a continuación se moverá a la derecha m = 1
                      se agrga otro simbolo 'b' y se muve el idx_cta
                    */
                    if ((idx_cta == cinta.Length - 1) && m == 1)
                    {
                        cinta += "b";
                        idx_cta += m;
                    }
                    /*
                      Si leemos un simbolo en el primer extremo de la cinta
                      y a continuación se moverá a la izquierda m = -1
                      se agrga otro simbolo 'b' y se muve el idx_cta
                    */
                    else if ((idx_cta == 0) && m < 0)
                    {
                        cinta = "b" + cinta;
                        idx_cta = 0;
                    }
                    else
                    {
                        idx_cta += m;
                    }
                    e = this.aut[idx_edos];
                    this.num_trasnciones += 1;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
