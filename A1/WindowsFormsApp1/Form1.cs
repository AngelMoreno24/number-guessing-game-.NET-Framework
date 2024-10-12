using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        GuessingGame.IService1 game = new GuessingGame.Service1Client();
        int number;
        int attempts;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //on clicking the "Generate a Secret Number" button a number is generated and the attempts is set to 0
        private void button1_Click(object sender, EventArgs e)
        {
            number = game.SecretNumber(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            attempts = 0;

            //changes the guesses to 0 after the number is generated
            label5.Text = "Guesses: " + attempts;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        //clicking the "Play" buttom will call the checkNumber operation and display the output in labels.
        private void button2_Click(object sender, EventArgs e)
        {
            string guess = game.checkNumber(Int32.Parse(textBox3.Text), number);

            //displays whether or not the guess is correct
            label6.Text = "Your guess is " + guess;

            //iterated the attempts value and displays the ammount after each guess
            attempts++;
            label5.Text = "Number of Attempts: " + attempts;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
