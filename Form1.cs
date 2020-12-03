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
            model.setValue(Decimal.ToInt32(numericUpDown1.Value));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(model.getValue().ToString());
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                model.setValue(Int32.Parse(textBox1.Text));
            }
        }
        private void UpdateFromModel(object sender, EventArgs e) 
        {
            textBox1.Text = model.getValue().ToString();
            numericUpDown1.Value = model.getValue();
            progressBar1.Value = model.getValue();
        }
    }

    public class Model 
    {
        private int value;
        public  System.EventHandler observers;

        public void setValue(int value)
        {
            if (value % 2 == 1)
                this.value = value + 1;
            else
                this.value = value;
            observers.Invoke(this,null);
        }
        public int getValue() 
        {
            return value;
        }
    }
}
