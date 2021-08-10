using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartas
{
    public partial class Form1 : Form
    {

        Cartas[] cartas = new Cartas[6];
        PictureBox[] pictures = new PictureBox[6];
        char[] naipes = { 'O', 'C', 'E', 'P' };
        Random rdn = new Random();

        public Form1()
        {
            InitializeComponent();
            Iniciar();
            
        }

        private void Iniciar()
        {
            Cartas.InicarRecurso();
            pictures[0] = pb1;
            pictures[1] = pb2;
            pictures[2] = pb3;
            pictures[3] = pb4;
            pictures[4] = pb5;
            pictures[5] = pb6;
        }

        private void SortearCartas()
        {
            List<string> repetidas = new List<string>();
            repetidas.Clear();

            for (int i = 0; i <= 5; i++)
            {
                var encontrou = false;

                while (!encontrou)
                {
                    var naipeSorteado = naipes[rdn.Next(0, naipes.Length)];
                    var valorSorteado = rdn.Next(4, 14);

                    if(!repetidas.Contains(naipeSorteado.ToString() + valorSorteado.ToString()))
                    {
                        cartas[i] = new Cartas(naipeSorteado, valorSorteado);
                        pictures[i].Image = cartas[i].MostrarImagem(naipeSorteado, valorSorteado);
                        repetidas.Add(naipeSorteado.ToString() + valorSorteado.ToString());
                        encontrou = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SortearCartas();
            }
            catch
            {
                
            }
        }
    }
}
