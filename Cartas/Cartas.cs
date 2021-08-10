using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Resources;
using System.Globalization;

namespace Cartas
{
    class Cartas
    {

        public char Naipe { get; set; }
        public int Valor { get; set; }
        public bool Mao { get; set; }
        private Image Imagem { get; set; }
        public static int Vira { get; set; }

        public static IDictionary<string, Image> Baralho = new Dictionary<string, Image>();

        public Cartas(char naipe, int valor)
        {

            Valor = valor;
            Naipe = naipe;
            Mao = true;
        }

        public static void InicarRecurso()
        {
            ResourceSet res = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            foreach(DictionaryEntry de in res)
            {
                string nomeArquivo = de.Key.ToString();
                object imagemArquivo = de.Value;

                if(imagemArquivo is Bitmap && nomeArquivo != "verso")
                {
                    Baralho.Add(nomeArquivo, (Image)imagemArquivo);
                }
            }
        }

        public Image MostrarImagem(char n, int v)
        {
            var chave = n.ToString() + v.ToString();
            return Imagem = Baralho[chave];
        }
    }
}
