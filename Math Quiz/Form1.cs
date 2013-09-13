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

        int timeLeft;


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

            //Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        public void subtractionProblem()
        {
            subtraction1 = randomizer.Next(1, 101);
            subtraction2 = randomizer.Next(1, subtraction1);

            MinusLeftLabel.Text = subtraction1.ToString();
            minusRightLabel.Text = subtraction2.ToString();

            difference.Value = 0;
        }

        public void additionProblem()
        {

            add1 = randomizer.Next(51);
            add2 = randomizer.Next(51);

            plusLeftLable.Text = add1.ToString();
            plusRightLabel.Text = add2.ToString();

            sum.Value = 0;
        
        }

        public void multiplicationProblem()
        {
            multi1 = randomizer.Next(2,11);
            multi2 = randomizer.Next(2,11);

            timesLeftLabel.Text = multi1.ToString();
            timesRightLabel.Text = multi2.ToString();

            product.Value = 0;   
        }

        public void divisionProblem()
        {
            div1 = randomizer.Next(2,11);
            int tempNumber = randomizer.Next(2,11);
            div2 = div1 * tempNumber;

            dividedLeftLabel.Text = div2.ToString();
            dividedRightLabel.Text = div1.ToString();

            quotient.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (CheckTheAnswer())
            { 
                //If the user gets the answer right stop the timmer
                //and show the victory message.

                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations");
                startButton.Enabled = true;
            }

            if (timeLeft > 0)
            {
                //Display the new time left
                //by updating the time left label

                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            { 
                //if the user run out of time stop the timer show
                //a message box and fill in the answers

                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                
                //These really could be a function that returns an int for the whole proj
                sum.Value = add1 + add2;
                difference.Value = subtraction1 - subtraction2;
                quotient.Value = div2 / div1;
                product.Value = multi1 * multi2;

                startButton.Enabled = true;
            }
        } //Timer Tick

        private bool CheckTheAnswer()
        {
            if (add1 + add2 == sum.Value
                && subtraction1 - subtraction2 == difference.Value 
                && multi1 * multi2 == product.Value
                && quotient.Value == div2 / div1 )
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //Select the whole answer in the Answer Box
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
