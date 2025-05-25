using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saat_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        List<int> AlarmSaat = new List<int>();
        List<int> AlarmDakika = new List<int>();
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Visible = false;
                groupBox1.Enabled = false;

                button5.Enabled = true;
                button6.Enabled = true;

                listBox1.Items.Add(textBox3.Text);
                listBox2.Items.Add(textBox1.Text + ":" + textBox2.Text);

                AlarmSaat.Add(Convert.ToInt32(textBox1.Text));
                AlarmDakika.Add(Convert.ToInt32(textBox2.Text));
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch
            {
                MessageBox.Show("Lütfen saat ve dakika değerlerini doğru giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox1.Enabled = false;

            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox1.Enabled = true;

            button5.Enabled = false;
            button6.Enabled = false;
        }
        int tamamlandi = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(var item in AlarmSaat)
            {
                for (int i = 0; i < AlarmSaat.Count; i++)
                {
                    if (AlarmSaat[i] == DateTime.Now.Hour && AlarmDakika[i] == DateTime.Now.Minute && tamamlandi == 0)
                    {
                        MessageBox.Show("Alarm: " + listBox1.Items[i].ToString() + " çaldı!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        listBox1.Items.RemoveAt(i);
                        listBox2.Items.RemoveAt(i);
                        AlarmSaat.RemoveAt(i);
                        AlarmDakika.RemoveAt(i);

                        break;
                        // Listeyi değiştiriyorsak döngüden çıkmak önemli
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("HH:mm:ss");

            label8.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        int kronometreSaniye = 0;
        int kronometreDakika = 0;
        int kronometreSaat = 0;
        int kronometreSalise = 0;
        private void button10_Click(object sender, EventArgs e)
        {
            timer3.Start();

            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            kronometreSalise++;
            if(kronometreSalise == 1000)
            {
                kronometreSalise = 0;
                kronometreSaniye++;
            }
            if (kronometreSaniye == 60)
            {
                kronometreSaniye = 0;
                kronometreDakika++;
            }
            if (kronometreDakika == 60)
            {
                kronometreDakika = 0;
                kronometreSaat++;
            }
            label10.Text = kronometreSaat.ToString("D2") + ":" + kronometreDakika.ToString("D2") + ":" + kronometreSaniye.ToString("D2") + "." + (kronometreSalise / 10).ToString("D2");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer3.Stop();
            kronometreSaniye = 0;
            kronometreDakika = 0;
            kronometreSaat = 0;
            kronometreSalise = 0;
            label10.Text = "00:00:00.00";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer3.Stop();

        }

        int zamanSaat = 0;
        int zamanDakika = 0;
        int zamanSaniye = 0;
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                zamanSaat = Convert.ToInt32(textBox4.Text);
                zamanDakika = Convert.ToInt32(textBox5.Text);
                zamanSaniye = Convert.ToInt32(textBox6.Text);
                if (zamanSaat < 0 || zamanDakika < 0 || zamanSaniye < 0)
                {
                    MessageBox.Show("Lütfen pozitif değerler giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(zamanDakika >= 60 || zamanSaniye >= 60)
                {
                    MessageBox.Show("Dakika ve saniye değerleri 0-59 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                timer4.Start();

                if (zamanSaat == 0 && zamanDakika == 0 && zamanSaniye == 0)
                {
                    MessageBox.Show("Zamanlayıcı başlatılamadı. Lütfen geçerli bir süre giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Lütfen saat, dakika ve saniye değerlerini doğru giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            timer4.Stop();
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            zamanSaat = 0;
            zamanDakika = 0;
            zamanSaniye = 0;
            textBox4.Text = zamanSaat.ToString("D2");
            textBox5.Text = zamanDakika.ToString("D2");
            textBox6.Text = zamanSaniye.ToString("D2");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            timer4.Stop();
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel2.Enabled = false;
            panel3.Visible = false;
            panel3.Enabled = false;
            panel4.Visible = false;
            panel4.Enabled = false;
            panel1.Visible = true;
            panel1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.Enabled = true;
            panel3.Visible = false;
            panel3.Enabled = false;
            panel4.Visible = false;
            panel4.Enabled = false;
            panel1.Visible = false;
            panel1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel2.Enabled = false;
            panel3.Visible = true;
            panel3.Enabled = true;
            panel4.Visible = false;
            panel4.Enabled = false;
            panel1.Visible = false;
            panel1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel2.Enabled = false;
            panel3.Visible = false;
            panel3.Enabled = false;
            panel4.Visible = true;
            panel4.Enabled = true;
            panel1.Visible = false;
            panel1.Enabled = false;
        }

        private void timer4_Tick_1(object sender, EventArgs e)
        {
            if (zamanSaniye == 0 && zamanDakika == 0 && zamanSaat == 0)
            {
                timer4.Stop();
                MessageBox.Show("Zamanlayıcı süresi doldu!", "Zamanlayıcı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                return;
            }
            if (zamanSaniye == 0)
            {
                if (zamanDakika == 0)
                {
                    zamanSaat--;
                    zamanDakika = 59;
                    zamanSaniye = 59;
                }
                else
                {
                    zamanDakika--;
                    zamanSaniye = 59;
                }
            }
            else
            {
                zamanSaniye--;
            }
            textBox4.Text = zamanSaat.ToString("D2");
            textBox5.Text = zamanDakika.ToString("D2");
            textBox6.Text = zamanSaniye.ToString("D2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Enabled = true;
            panel2.Visible = false;
            panel2.Enabled = false;
            panel3.Visible = false;
            panel3.Enabled = false;
            panel4.Visible = false;
            panel4.Enabled = false;
            timer1.Start();
            timer2.Start();
            timer3.Stop();
            timer4.Stop();
            groupBox1.Visible = false;
            groupBox1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<int> silinecekAlarm = new List<int>();

            foreach (int i in listBox1.SelectedIndices)
            {
                silinecekAlarm.Add(i);
            }

            foreach(int i in silinecekAlarm)
            {
                listBox1.Items.RemoveAt(i);
                listBox2.Items.RemoveAt(i);
                AlarmSaat.RemoveAt(i);
                AlarmDakika.RemoveAt(i);
            }

        }
    }
}
