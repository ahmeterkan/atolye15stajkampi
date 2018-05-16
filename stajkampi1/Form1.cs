using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stajkampi1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int skor = 7;
        int sayac;
        
        void BuyukUnluUyumu(string[,] sesliharf)
        {
            //büyük ünlü uyumu
            if (sesliharf[0, 0] == "a" || sesliharf[0, 0] == "ı" || sesliharf[0, 0] == "o" || sesliharf[0, 0] == "u")
            {
                for (int i = 1; i < sayac; i++)
                {
                    if (sesliharf[i, 0] == "e" || sesliharf[i, 0] == "i" || sesliharf[i, 0] == "ö" || sesliharf[i, 0] == "ü")
                    {
                        skor--;
                        break;
                    }
                }
            }
            else if (sesliharf[0, 0] == "e" || sesliharf[0, 0] == "i" || sesliharf[0, 0] == "ö" || sesliharf[0, 0] == "ü")
            {
                for (int i = 0; i < sayac; i++)
                {
                    if (sesliharf[i, 0] == "a" || sesliharf[i, 0] == "ı" || sesliharf[i, 0] == "o" || sesliharf[i, 0] == "u")
                    {
                        skor--;
                        break;
                    }
                }

            }
        }
        void KucukUnluUyumu(string[,] sesliharf)
        {
            //küçük ünlü uyumu
            //düz ünlüden sonra düz
            if (sesliharf[0, 0] == "a" || sesliharf[0, 0] == "e" || sesliharf[0, 0] == "ı" || sesliharf[0, 0] == "i")
            {
                for (int i = 1; i < sayac; i++)
                {
                    if (sesliharf[i, 0] == "u" || sesliharf[i, 0] == "ü" || sesliharf[i, 0] == "ö" || sesliharf[i, 0] == "o")
                    {
                        skor--;
                        break;
                    }
                }
            }
            //yuvarlak ünlüden sonra yuvarlak dar
            if (sesliharf[0, 0] == "o" || sesliharf[0, 0] == "ö" || sesliharf[0, 0] == "u" || sesliharf[0, 0] == "ü")
            {
                for (int i = 1; i < sayac; i++)
                {
                    if (sesliharf[i, 0] == "o" || sesliharf[i, 0] == "ö" || sesliharf[i, 0] == "ı" || sesliharf[i, 0] == "i")
                    {
                        skor--;
                        break;
                    }
                }
            }
        }
        void bcdgKontrol(string kelime)
        {
            //b,c,d,g,ğ kontrolü
            if (kelime[kelime.Length-1] == 'b' || kelime[kelime.Length - 1] == 'c' || kelime[kelime.Length - 1] == 'd' || kelime[kelime.Length - 1] == 'g' || kelime[kelime.Length - 1] == 'ğ')
            {
                skor--;
            }
        }
        void YanyanaSesliHarfKontrol(string[,] sesliharf)
        {
            //yanyana sesli harf kontrolü
            for (int i = 0; i < sayac; i++)
            {
                if (sesliharf[i, 1] == sesliharf[i + 1, 1])
                {
                    skor--;
                    break;
                }
            }
        }

        void fjhSesikontrol(string kelime)
        {
            for (int i = 0; i < kelime.Length; i++)
            {
                if (kelime[i]=='f' || kelime[i] == 'j'|| kelime[i] == 'h')
                {
                    skor--;
                }
            }
        }

        void BastaBulunmayanHarfler(string kelime)
        {
            if (kelime[0]=='c' || kelime[0] == 'ğ' || kelime[0] == 'l' || kelime[0] == 'm' || kelime[0] == 'n' || kelime[0] == 'r' || kelime[0] == 'v' || kelime[0] == 'z')
            {
                skor--;
            }
        }

        void BastaİkiSessizHarfKontrol(string[,] sesliharf)
        {
            if (sesliharf[0,1]=="3")
            {
                skor--;
            }
        }

        private void btnKontrolEt_Click(object sender, EventArgs e)
        {
            string kelime;
            kelime = txtKelime.Text;
            string[,] sesliharf = new string[kelime.Length, 2];
            //sesli harf kontrolü
            sayac = 0;
            for (int i = 0; i < kelime.Length; i++)
            {
                if (kelime[i] == 'a' || kelime[i] == 'ı' || kelime[i] == 'o' || kelime[i] == 'u' || kelime[i] == 'e' || kelime[i] == 'i' || kelime[i] == 'ö' || kelime[i] == 'ü')
                {
                    sesliharf[sayac, 0] = kelime[i].ToString();//harf
                    sesliharf[sayac, 1] = (i + 1).ToString();//harfin bulunduğu konum
                    sayac++;
                }
            }
            BuyukUnluUyumu(sesliharf);
            KucukUnluUyumu(sesliharf);
            bcdgKontrol(kelime);
            YanyanaSesliHarfKontrol(sesliharf);
            fjhSesikontrol(kelime);
            BastaBulunmayanHarfler(kelime);
            BastaİkiSessizHarfKontrol(sesliharf);
            double sonuc;
            sonuc = (100 / 7)*skor;
            MessageBox.Show("%" + sonuc.ToString()+" sonuc ile Türkçe bir kelime");
        }
    }
}
