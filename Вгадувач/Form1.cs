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
        private int Number = 0;
        private int iter = 7;//7 спроб
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Number = rnd.Next(100);

            button1.Visible = false;
            textBox1.Visible = true;
            label1.Visible = true;
            textBox1.Text = Convert.ToString(iter);
            MessageBox.Show("Число загадане. У вас 7 спроб вгадати його.\n\tСлідкуйте за підказками.");

        }
    }
}
