using System;
using System.Collections;
using System.Collections.Generic;

namespace MT
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numEstados = 2;
            String entrada = "▄ ▄   ▄▄▄▄▄▄▄▄  ▄▄▄ ▄▄       ▄▄▄▄▄▄▄▄▄▄▄ ▄▄ ▄ ▄ ▄ ▄     ▄▄▄  ▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄    ▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄   ▄▄ ▄ ▄ ▄ ▄▄▄▄▄▄▄▄▄▄▄▄   ▄ ▄ ▄ ▄          ▄";
            //------MÁQUINA DE TURING-------
            Automata mt = new Automata(numEstados);
            mt.creaAutomata();

            //COMPLEMENETO DE UN NUMERO BIANRIO
            mt.asignaTransiciones(0, ' ', 0, "▄", 1);
            mt.asignaTransiciones(0, '▄', 0, " ", 1);
            mt.asignaTransiciones(0, 'b', 1, "b", 1);
            mt.asignaEdoAceptacion(1);
            mt.imprimeAutomata();
            mt.analizaEntrada(entrada);


            Regla110 r110 = new Regla110();
            //Esta linea acopla la salida de la regla 110 del automata celular
            //Con la mauina de Turing, la cual será su entrada de la máquina
            r110.acoplamiento(entrada,1000, mt);
            //r110.play(10000, entrada);


        }
    }


}
