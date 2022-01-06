using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Json
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Kitap> liste = new List<Kitap>();
        JavaScriptSerializer tercuman = new JavaScriptSerializer();


        private void button2_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap();
            kitap.baslik = textBox1.Text;
            kitap.fiyat = numericUpDown1.Value;

            liste.Add(kitap);
            JsonDosyasinaYaz(liste);
        }

        private void JsonDosyasinaYaz(List<Kitap> liste)
        {
            string jason = tercuman.Serialize(liste);//liste'yi json cevir yani Serialize et.
            //File.WriteAllText("../../kitaplar.jason",jason);//WriteAllText siler,yazar dosya bin klasörünün içindedir
           File.AppendAllText("../../kitaplar.jason", jason); //Var olan kitaplar.jason dosyanın icerisine  yazar.


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string contain = File.ReadAllText("../../kitaplar.jason");
            var liste = tercuman.Deserialize<List<Kitap>>(contain);//kitaplar.jason dosyasından veri okuyup contain datasına attıktan sonra bu veriyi List bir sekilde Kitap'daki degiskenelere esleyerel deserialize et.

            listBox1.DisplayMember = "baslik";

            foreach (Kitap kitap in liste)
            {
                listBox1.Items.Add((kitap));
            }

        
        }
    }
}
