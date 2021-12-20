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

namespace ŚwiatAlkoholi_MilenaBrowczuk
{
    public partial class Świat_Alkoholi_weryfikacja : Form
    {
        public Świat_Alkoholi_weryfikacja()
        {
            InitializeComponent();
           
        }

        private void show()
        {
            panel1.Visible = true;
        }
        private void hide()
        {
            panel1.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int data = int.Parse(dateTimePicker1.Value.ToString("yyyyMMdd"));
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int wiek = ((now - data) / 10000);
            if (wiek >= 18)
            {
                panel1.Visible = true;
                wyślij.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

        }
        private void dodaj_Click(object sender, EventArgs e)
        {
            if (lista_produktów.Text.Length != 0)
            {
                koszyk.Text += lista_produktów.Text;
                koszyk.Text += ",  ";
            }
        }
        private void lista_produktów_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
       
        


        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\mimil\Desktop\Uczelnia\Programowanie i testowanie aplikacji desktopowych\Formularze" + nazwisko.Text + "_" + imię.Text + ".txt";
            string tekst = "Dane klienta: \r\n ";
            tekst += "nazwisko: " + nazwisko.Text + " " + "imie: " + " " + imię.Text + "\r\n ";
            tekst += "Dane kontaktowe: \r\n";
            tekst += "Adres: " + adres.Text + "/" + nrlokalu.Text + "\r\n";
            tekst += "Zamówienie: " + koszyk.Text + "\r\n";
            tekst += "złożono: " + DateTime.Now.ToString("dddd, dd MM yyyy") + "\r\n";
            if (imię.Text.Length == 0 || nazwisko.Text.Length == 0 || adres.Text.Length == 0 || nrlokalu.Text.Length == 0)
            {
                MessageBox.Show("Uzupełnij brakujące dane w formularzu!");
            }
            else
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, tekst);
                }
                else
                {
                    string zmiana = "";
                    zmiana += "złożono: " + DateTime.Now.ToString("dddd, dd MM yyyy") + "\r\n";
                    File.AppendAllText(path, zmiana);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void koszyk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
