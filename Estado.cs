using System;
using System.Collections.Generic;
namespace MT
{
    public class Estado
    {
        private bool aceptacion;
        private int id;
        private Transicion tabTransiciones;
        private bool muerto;

        public Estado(int id)
        {
            this.id = id;
            tabTransiciones = new Transicion();
            this.aceptacion = false;
            this.muerto = false;
        }

        public void setAceptacion()
        {
            this.aceptacion = true;
        }

        public void setMuerto()
        {
            this.muerto = true;
        }

        public bool getMuerto()
        {
            return this.muerto;
        }

        public void updateTablaTrans(char r, int idEdoDestino, String w, int d)
        {
            this.tabTransiciones.setTransicion(r,idEdoDestino,w,d);
        }

        public int getIdEdo()
        {
            return this.id;
        }

        public Transicion getTabTransiciones()
        {
            return this.tabTransiciones;
        }


        public bool getAceptacion()
        {
            return this.aceptacion;
        }


        public Object[] getControles(char lectura)
        {
            return (Object[]) this.tabTransiciones.getValueofReading(lectura);
        }

       

    }
}
