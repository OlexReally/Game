using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Вгадувач
{
    public partial class Form1 : Form
    {
        private int MaxNum = 0;
        private int Number = 0;
        private int iter = 7;//7 спроб
        private int Iterator = 0;
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            label1.Visible = false;
            Iterator = iter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MaxNum = Convert.ToInt32(textBox3.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Incorrect max value:\n" + ex);
            }
            finally
            {
                Random rnd = new Random();
                Number = rnd.Next(MaxNum);                

                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                textBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = true;
                textBox1.Text = Convert.ToString(iter);
                label5.Text = "Діапазон: від 0 до " + MaxNum;
                label6.Visible = true;
                label7.Visible = true;
                MessageBox.Show("Число загадане. У вас 7 спроб вгадати його.\n\tСлідкуйте за підказками.");
            }
        }

        //синій - далеко 
        //жовтий - середньо +-10
        //червоний - близько +-5
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Press1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Number = Convert.ToInt32(textBox4.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Incorrect max value:\n" + ex);
            }
            finally
            {
                textBox1.Text = Convert.ToString(--iter);

                if (Convert.ToInt32(textBox4.Text) == Number)
                {
                    int rizn = Iterator-iter;
                    MessageBox.Show("Вітаємо! Ви вгадали число з " + rizn + " спроби");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MaxNum = 0;
            Number = 0;
            iter = 7;//7 спроб

            textBox1.Visible = false;
            label1.Visible = false;
        }
    }
}
