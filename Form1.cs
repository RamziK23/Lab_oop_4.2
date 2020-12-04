using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_oop_4._2
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            InitializeComponent();

            model = new Model();
            model.observers += new System.EventHandler(this.UpdateFromModel);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.setValue(Convert.ToInt32(numericUpDown1.Value),0);

            //if (numericUpDown1.Value % 2 == 1)
            //    numericUpDown1.Value = numericUpDown1.Value + 1;
            //progressBar1.Value = Decimal.ToInt32(numericUpDown1.Value);
            //textBox1.Text = numericUpDown1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(model.getValue().ToString());
            //MessageBox.Show(numericUpDown1.Value.ToString());
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                model.setValue(Convert.ToInt32(textBox1.Text), 1);

                //if (Int32.Parse(textBox1.Text) % 2 == 1)
                //    textBox1.Text = (Int32.Parse(textBox1.Text) + 1).ToString();
                //numericUpDown1.Value = Int32.Parse(textBox1.Text);
                //progressBar1.Value = Int32.Parse(textBox1.Text);

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model.setValue(trackBar1.Value, 2);
        }

        private void UpdateFromModel(object sender, EventArgs e) 
        {
            trackBar1.Value = model.getValue();
            progressBar1.Value = model.getValue();
            if (model.getCheck() == 0) 
            {
                textBox1.Text = (model.getValue() + 1).ToString();
            }
            else if (model.getCheck() == 1)
            {
                textBox1.Text = model.getValue().ToString();
                numericUpDown1.Text = (model.getValue()-1).ToString();
            } 
            else
            {
                numericUpDown1.Text = model.getValue().ToString();
                textBox1.Text = (model.getValue() + 1).ToString();
            }





        }
    }

    public class Model 
    {
        private int value;
        public int check;
        public System.EventHandler observers;
        public void setValue(int value, int check)
        {
            this.value = value;
            this.check = check;
            observers.Invoke(this, null);
        }
        public int getValue()
        {
            return value;
        }
        public int getCheck()
        {
            return check;
        }

    }
}
