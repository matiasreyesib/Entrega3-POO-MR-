using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega_3._1
{
    class Wetar : Bitmon
    {
        /*
        Random rnd = new Random();
        new int tiempoDeVida;
        new int puntosDeVida;
        new int puntosDeAtaque;
        new string especie;
        new int cantidadDeHijos;
        */
        Random rnd = new Random();
        new int tiempoDeVida = 0;
        new int posx;
        new int posy;

        // Al constructor dedl bitmons le metemos los parametros de su ubicacion para que el bitmon los guarde
        public Wetar(int posx, int posy, int tiempoDeVida)
        {
            this.posx = posx;
            this.posy = posy;
            this.tiempoDeVida = tiempoDeVida;
        }

        public override int get_tiempoDeVida()
        {
            return tiempoDeVida;
        }
        // Reduce el tiempo de vida mientras pasan los meses
        public override void ReducirTiempoDeVida()
        {
            if (tiempoDeVida > 0)
            {
                tiempoDeVida -= 1;
            }
            else
            {
                tiempoDeVida = 0;
            }

        }
        // Para ver cuando un bitmon muere
        public override int Muerte()
        {
            if (tiempoDeVida == 0) //|| puntosDeVida == 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public override string CambioTerreno()
        {
            return "";
        }

        public override int Daño(Bitmon bitmon)
        {
            if (bitmon.get_especie() == "Gofue" || bitmon.get_especie() == "Taplan")
            {
                return puntosDeAtaque * 2;
            }
            else
            {
                return Convert.ToInt32(puntosDeAtaque * 0.5);
            }
        }


        public override string get_especie()
        {
            return especie = "Wetar";
        }
        // Retornamos el nombre de la especie vacio, para poder hacer que 
        // desaparezca el nombre del bitmon cuando se mueve
        public override string get_especie_vacio()
        {
            return especie = "";
        }
        // Nos da la posision 'x' e 'y' del bitmon
        public override int get_posx()
        {
            return posx;
        }
        public override int get_posy()
        {
            return posy;
        }

        // Se mueve en 'fila' y 'columna'
        public int moverse_fila()
        {
            posx += rnd.Next(-1, 2);
            return posx;
        }
        public int moverse_columna()
        {
            posy += rnd.Next(-1, 2);
            return posy;
        }

        public override void moverse()
        {
            int x = posx;
            int y = posy;
            int mx = moverse_fila();
            int my = moverse_columna();

            if (mx > 0 && mx < 8 & my > 0 && my < 8)
            {
                posx = mx;
                posy = my;
            }
            else
            {
                if (x == 0 && y == 0)
                {
                    posx += 1;
                    posy += 1;
                }
                else if (x == 7 && y == 0)
                {
                    posx -= 1;
                    posy += 1;
                }
                else if (x == 0 && y == 7)
                {
                    posx += 1;
                    posy -= 1;
                }
                else if (x == 7 && y == 7)
                {
                    posx -= 1;
                    posy -= 1;
                }
                else if (x == 0 && y!=0 && y!=7)
                {
                    posx += 1;
                }
                else if (x == 7 && y != 0 && y != 7)
                {
                    posx -= 1;
                }
                else if (y == 0 && x != 0 && x != 7)
                {
                    posy += 1;
                }
                else if (y == 7 && x != 0 && x != 7)
                {
                    posy -= 1;
                }

                else
                {
                    posx += 0;
                    posy += 0;
                }

            }



        }



    }
}
