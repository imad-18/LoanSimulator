using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labrini_Imad
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public double calcule_de_mensualite(double c, double t, double a)
        {
            double n = a * 12;
            double tt = t / 100; 
            double op1 = c * (tt / 12);
            double op2 = 1 - Math.Pow(1 + (tt / 12), -n);
            double m = op1 / op2;

            return Math.Round(m, 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double credit) &&
                double.TryParse(textBox2.Text, out double taux) &&
                double.TryParse(textBox3.Text, out double duree))
            {
                double mensualite = calcule_de_mensualite(credit, taux, duree);
                richTextBox1.Text = mensualite.ToString();
            }
            else
            {
                MessageBox.Show("Saisissez des valeurs correctes svp!!.");
            }

        }

        public void eligibility(double salaire, double mensualite)
        {
            if (mensualite <= 0.25 * salaire)
            {
                richTextBox2.Text = "Vous êtes éligible pour un crédit";
            
            }
            else
            {
                richTextBox2.Text = "Vous n'êtes pas éligible pour ce crédit!";
                String proposition_deal = "\nVous pouvez bénéficier d'un crédit de " + 0.25 * salaire + " DH. " +
                    "Pour continuer, tapez OK!";
                richTextBox2.Text += proposition_deal;
                AjouterBoutonOK();
            }
        }
        private void AjouterBoutonOK()
        {
            Button boutonOK = new Button();
            boutonOK.Text = "OK";
            boutonOK.Location = new Point(richTextBox2.Location.X, richTextBox2.Location.Y + richTextBox2.Height + 10);
            boutonOK.Click += new EventHandler(BoutonOK_Click);
            this.Controls.Add(boutonOK);
        }

        private void BoutonOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Congrats💵, vous etes maintenant éligible pour votre nouveau crédit!" +
                "Cliquer sur le bouton \'Calculer la mensualité\' pour visualiser votre mensualité." +
                "\nN.B que vous pouvez changer le taux et la durée comme vous voulez.");
            double salTag = double.Parse(textBox4.Text);
            textBox1.Text = (salTag / 4).ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox4.Text, out double salaire))
            {
                eligibility(salaire, double.Parse(richTextBox1.Text));
            }
            else
            {
                MessageBox.Show("Saisissez des valeurs correctes svp!!!.");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
