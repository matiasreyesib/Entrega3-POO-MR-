using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Entrega_3._1
{

    public partial class Form1 : Form
    {
        // Creamos aca toda la informacion que va a necesitar el juego
        private const int FILAS = 8;
        private const int COLUMNAS = 8;
        // Informacion de la celda
        List<Button> listaBotones;
        Button[,] matrizBotones;
        List<Bitmon> bitmons = new List<Bitmon>();


        //FileStream file = new FileStream("C: /Users/matia/Desktop/Entrega3_POO/Imagenes/btn3.jpg", FileMode.Open);

        public Form1()
        {
            InitializeComponent();
            // Creamos el mapa (la matriz de botones)
            matrizBotones = new Button[FILAS, COLUMNAS];
            listaBotones = new List<Button>();
            Random random = new Random();    // random a los botones para que quede como 'cubo rubix'
            // Agregamos los botones con codigo, para no tener que ponerlos de 1 en 1
            // Utilizamos dos 'for' para dar la informacion que necisitamos a cada una de las celdas
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    List<Bitmon> bitmons = new List<Bitmon>();
                    //Random random = new Random(); // filas de color completo
                    int variable;
                    string nombre_terreno ="0";
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Padding = new Padding(0, 0, 0, 0);
                    button.FlatStyle = FlatStyle.Popup;
                    button.FlatAppearance.BorderSize = 0;
                    button.Enabled = false;
                    tableLayoutPanel1.Controls.Add(button, columna, fila);
                    matrizBotones[fila, columna] = button;
                    listaBotones.Add(button);

                    // Asignamos los 'Terrenos' con sus colores respectivos a cada Celda
                    variable = random.Next(5);
                    switch (variable)
                    {
                        case 0 ://agua
                            nombre_terreno = "acuatico";
                            button.BackColor = Color.Blue;
                            break;
                        case 1://desierto
                            nombre_terreno = "desierto";
                            button.BackColor = Color.SandyBrown;
                            break;
                        case 2://vegetacion
                            nombre_terreno = "vegetacion";
                            button.BackColor = Color.GreenYellow;
                            break;
                        case 3://nieve
                            nombre_terreno = "nieve";
                            button.BackColor = Color.White;
                            break;
                        case 4://volcan
                            nombre_terreno = "volcan";
                            button.BackColor = Color.DarkRed;
                            break;
                        default:
                            nombre_terreno = "vacio";
                            button.BackColor = Color.Black;
                            break;

                    }
                    Terreno terreno = new Terreno(nombre_terreno);
                }
            }
            // Utilizamos el metodo siguiente para crear los bitmons aleatorios dentro del mapa
            crearBitmons();
        }

        private void crearBitmons()
        {

             // Imagen dentro del boton
            //Image toLoad = Image.FromStream(file);

            Random random = new Random();
            int creados = 0;

            while (creados < 3)
            {
                int fila = random.Next(FILAS);
                int columna = random.Next(COLUMNAS);
                //
                int tiempoDeVida = random.Next(10);
                //
                Wetar wetar = new Wetar(fila, columna,tiempoDeVida);
                //matrizBotones[fila, columna].Text = bitmon.get_nombre(); 
                matrizBotones[fila, columna].Text = wetar.get_especie();
                bitmons.Add(wetar);
                creados++;

                
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Aca esta el 'Timer' del juego, lo utilizamos para el movimiento de los Bitmons
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Para usar imagen dentro del boton
            //Image toLoad = Image.FromStream(file);
            foreach (Bitmon i in bitmons)
            {
                i.ReducirTiempoDeVida();
                if (i.Muerte() == 1)
                {
                    matrizBotones[i.get_posx(), i.get_posy()].Text = i.get_especie_vacio();
                }
                else
                {
                    matrizBotones[i.get_posx(), i.get_posy()].Text = i.get_especie_vacio();
                    i.moverse();
                    matrizBotones[i.get_posx(), i.get_posy()].Text = i.get_especie(); //Convert.ToString(i.get_tiempoDeVida());
                }
            }
        }
    }
}
