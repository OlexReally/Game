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
        private int rangeCount = 3;//3 варіанти відстаней
        private int[] min = new int[3];
        private int[] max = new int[3];
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
            catch (Exception)
            {
                MessageBox.Show("Incorrect max value:\n");
            }
            finally
            {
                Random rnd = new Random();
                Number = rnd.Next(MaxNum);
                RangeCalculate();

                button1.Visible = false;
                button2.Visible = true;
                //button3.Visible = true;
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

        //синій - далеко +-50%
        //жовтий - середньо +-30%
        //червоний - близько +-10%
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

        private void RangeCalculate()//обчислення відстаней різниці між загаданим числом і варіантом гравця
        {
            min[0] = Convert.ToInt32(Number - 0.1 * MaxNum);
            min[1] = Convert.ToInt32(Number - 0.3 * MaxNum);
            min[2] = Convert.ToInt32(Number - 0.5 * MaxNum);

            max[0] = Convert.ToInt32(Number + 0.1 * MaxNum);
            max[1] = Convert.ToInt32(Number + 0.3 * MaxNum);
            max[2] = Convert.ToInt32(Number + 0.5 * MaxNum);

            for (int i = 0; i < 3; i++)
            {
                if (min[i] < 0)
                    min[i] = 0;
                if (max[i] > MaxNum)
                    max[i] = MaxNum;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int yNum;
            if (!int.TryParse(textBox4.Text, out yNum))
                MessageBox.Show("Некоректне значення");
            else
            {
                textBox1.Text = Convert.ToString(--iter);

                if (yNum == Number)
                {
                    MessageBox.Show("Вітаємо! Ви вгадали число з " + (Iterator - iter) + " спроби");
                    Reset();
                    return;
                }
                //синій - далеко +-50% і більше
                //жовтий - середньо +-30%
                //червоний - близько +-10%
                else if (yNum > min[0] && yNum < max[0]) //червоний
                {
                    label6.BackColor = Color.Red;
                    label6.ForeColor = Color.White;
                    label6.Text = "Різниця складає до " + Convert.ToInt32(0.1 * MaxNum) + " одиниць";
                }
                else if (yNum > min[1] && yNum < max[1]) //жовтий
                {
                    label6.BackColor = Color.Yellow;
                    label6.ForeColor = Color.Black;
                    label6.Text = "Різниця складає до " + Convert.ToInt32(0.3 * MaxNum) + " одиниць";
                }
                else if (yNum > min[2] && yNum < max[2])//синій
                {
                    label6.BackColor = Color.Blue;
                    label6.ForeColor = Color.White;
                    label6.Text = "Різниця складає до " + Convert.ToInt32(0.5 * MaxNum) + " одиниць";
                }
                else//повний непопад
                {
                    label6.BackColor = Color.Black;
                    label6.ForeColor = Color.White;
                    label6.Text = "Різниця складає від " + Convert.ToInt32(0.5 * MaxNum) + " одиниць";
                }

                if (yNum != Number && iter != 0)
                {
                    MessageBox.Show("Спроба невдала! У вас залишилось " + iter + " спроб.");
                }
                else if (iter == 0)
                {
                    MessageBox.Show("На жаль спроби вичерпались. Спробуйте ще раз!");
                    Reset();
                }
            }
        }

        private void Reset()
        {
            MaxNum = 0;
            Number = 0;
            iter = 7;//7 спроб

            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            label1.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = false;
            label6.BackColor = Control.DefaultBackColor;
            label6.ForeColor = Control.DefaultForeColor;
            label6.Text = "";
            textBox4.Text = "";
            label7.Visible = false;
            button1.Visible = true;
            button2.Visible = false;
            //button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)//Заново
        {
            Reset();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)//Допомога -> Автор
        {
            const string caption = "Автор";
            const string message = "Автор програми - Кутаєв О. В.";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)//Допомога -> Про гру
        {
            const string caption = "Про гру";
            const string message = "Гра створена для навчальний цілей. Розвовсюджується за вільної ліцензії. Version alpha@0.1";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)//Допомога -> Правила гри
        {
            const string caption = "Правила гри";
            const string message = "Вас вітає гра \"Вгадай число\"." 
                + "Основна мета гри - вгадати число з вибраного діапазону чисел. На це гравцеві виділено 7 спроб." 
                + "\nГравцеві доступні підказки у вигляді числової відстані до загаданого числа, серед них:"
                + "\n\t- різниця між числами складає до 50%. \n\tКольорова підсвітка - синій колір."
                + "\n\t- різниця між числами складає до 30%. \n\tКольорова підсвітка - жовтий колір."
                + "\n\t- різниця між числами складає до 10%. \n\tКольорова підсвітка - червоний колір."
                + "\n\t- різниця між числами складає більше 50%. \n\tКольорова підсвітка - чорний колір.";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)//Меню -> Заново
        {
            Reset();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)//Меню -> Вихід
        {
            Close();
        }
    }
}