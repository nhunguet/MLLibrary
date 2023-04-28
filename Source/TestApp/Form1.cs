using MachineLearningLib;
using System;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form

    {

        NaiveBayes ml_naivebaye = null;
        public Form1()
        {
            InitializeComponent();

            ml_naivebaye = new NaiveBayes();
        }

        /// <summary>
        /// Initalization button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 


        private void button2_Click(object sender, EventArgs e)

        {
            ml_naivebaye.Initialization(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ml_naivebaye.Setting();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ml_naivebaye.Training();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ml_naivebaye.Predict();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ml_naivebaye.SaveModel();
        }

        private void button6_Click(object sender, EventArgs e)

        {
            ml_naivebaye.LoadModel();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            var openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = openFileDialog1.FileName;

            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = openFileDialog1.FileName;

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.website.com");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var openFileDialog2 = new OpenFileDialog();
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = openFileDialog2.FileName;

            }
        }
    }
}
