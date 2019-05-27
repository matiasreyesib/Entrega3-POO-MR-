using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega_3._1
{
    abstract class Bitmon
    {
        Random rnd = new Random();
        protected int tiempoDeVida;
        protected int puntosDeVida;
        protected int puntosDeAtaque;
        protected string especie;
        protected int cantidadDeHijos;
        protected int posx;
        protected int posy;


        public abstract int get_tiempoDeVida();
         // Desde aca meto los metodos de la entrega pasada
        public abstract string CambioTerreno();

        public abstract int Daño(Bitmon bitmon);

        // Para retornar la 'Especie' del bitmon
        public abstract string get_especie();

        // Retornamos el nombre de la especie vacio, para poder hacer que 
        // desaparezca el nombre del bitmon cuando se mueve
        public abstract string get_especie_vacio();

        // Nos da la posision 'x' e 'y' del bitmon
        public abstract int get_posx();

        public abstract int get_posy();

        // Para ver cuando un bitmon muere
        public abstract int Muerte();
        // Para aumentar la cantidad de hijos cuando se reproduce
        public void Reproducirse()
        {
            cantidadDeHijos += 1;
        }
        // Reduce el tiempo de vida mientras pasan los meses
        public abstract void ReducirTiempoDeVida();
        // Reduce los puntos de vida por algun ataque
        public void ReducirPuntosDeVida(int ataque)
        {
            puntosDeVida -= ataque;
        }
        // La afinidad que tiene con el terreno
        public abstract void moverse();

    }
}
