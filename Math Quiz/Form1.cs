using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {

        Random randomizer = new Random();

        //These will store ints for the addition problems
        int add1;
        int add2;

        int subtraction1;
        int subtraction2;

        int multi1;
        int multi2;

        int div1;
        int div2;


        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        public void StartTheQuiz()
        {
            additionProblem();
            subtractionProblem();
            multiplicationProblem();
            divisionProblem();
        }

        public void subtractionProblem()
        { }

        public void additionProblem()
        {

            add1 = randomizer.Next(51);
            add2 = randomizer.Next(51);

            plusLeftLable.Text = add1.ToString();
            plusRightLabel.Text = add2.ToString();

            sum.Value = 0;
        
        }

        public void multiplicationProblem()
        { }

        public void divisionProblem()
        { }

    }
}
