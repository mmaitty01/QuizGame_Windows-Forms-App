using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizGame
{
    public partial class Form1 : Form
    {
        // variables list for this quiz game
        int correctAnswer;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;

        int timeLeft = 5; // เวลาตอบคำถาม (วินาที)
        Random random = new Random();
        Timer questionTimer = new Timer();

        public Form1()
        {
            InitializeComponent();
            askQuestion(questionNumber);

            totalQuestions = 10;

            // ตั้งค่า Timer
            questionTimer.Interval = 1000; // 1 วินาที
            questionTimer.Tick += QuestionTimer_Tick;
            
        }

        private void StartQuestion()
        {
            timeLeft = 5;
            lblTimer.Text = $"{timeLeft}";
            questionTimer.Start();
        }

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = $"{timeLeft}";

            if (timeLeft <= 0)
            {
                questionTimer.Stop();
                AutoSelectAnswer(); // หมดเวลาจะสุ่มเลือกคำตอบให้
            }
        }

        private void AutoSelectAnswer()
        {
            // หาปุ่มตัวเลือกทั้งหมด
            Button[] answerButtons = { button1, button2, button3, button4 };
            int randomIndex = random.Next(answerButtons.Length);

            // กระตุ้น Event กดปุ่มแบบสุ่ม
            ClickAnswerEvent(answerButtons[randomIndex], EventArgs.Empty);
        }


        private void ClickAnswerEvent(object sender, EventArgs e)
        {
            questionTimer.Stop(); // หยุดจับเวลา

            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);


            if (buttonTag == correctAnswer)
            {
                score++;


            }

            if (questionNumber == totalQuestions)
            {
                // work out the percentage here
                percentage = (int)Math.Round((double)(100 * score) / totalQuestions);


                MessageBox.Show("Quiz Ended" + Environment.NewLine +
                                "You have answered " + score + " questions correcly" + Environment.NewLine +
                                "Your total percentage is " + percentage + " %" + Environment.NewLine +
                                "Click Ok to play again"

                    );

                score = 0;
                questionNumber = 0;

                askQuestion(questionNumber);
            }

            questionNumber++;

            askQuestion(questionNumber);

            StartQuestion(); // 🛠️ เพิ่มให้เริ่มจับเวลาข้อใหม่
        }

        private void askQuestion(int qnum)
        {
            switch (qnum)
            {

                case 1:

                    pictureBox1.Image = Properties.Resources.q091;
                    lblQuestion.Text = "What’s the name of this K-pop group?";

                    button1.Text = "BTS";
                    button2.Text = "EXO";
                    button3.Text = "TXT";
                    button4.Text = "NCT";

                    correctAnswer = 1;

                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.q03;
                    lblQuestion.Text = "What song is this MV?";

                    button1.Text = "Boy With Luv";
                    button2.Text = "DNA";
                    button3.Text = "Dynamite";
                    button4.Text = "Spring Day";

                    correctAnswer = 3;

                    break;

                case 3:

                    pictureBox1.Image = Properties.Resources.Q10;

                    lblQuestion.Text = "Who is the leader";

                    button1.Text = "Suga";
                    button2.Text = "J-Hope";
                    button3.Text = "Jimin";
                    button4.Text = "RM";

                    correctAnswer = 4;

                    break;

                case 4:

                    pictureBox1.Image = Properties.Resources.q04;

                    lblQuestion.Text = "What song is this MV?";

                    button1.Text = "Dynamite";
                    button2.Text = "Butter";
                    button3.Text = "IDOL";
                    button4.Text = "I Need U";

                    correctAnswer = 3;

                    break;

                case 5:

                    pictureBox1.Image = Properties.Resources.q06;

                    lblQuestion.Text = "Who is the oldest member?";

                    button1.Text = "Jin";
                    button2.Text = "JungKook";
                    button3.Text = "Jimin";
                    button4.Text = "Suga";

                    correctAnswer = 1;

                    break;

                case 6:

                    pictureBox1.Image = Properties.Resources.q07;

                    lblQuestion.Text = "Who is the maknae?";

                    button1.Text = "Jin";
                    button2.Text = "V";
                    button3.Text = "JungKook";
                    button4.Text = "RM";

                    correctAnswer = 3;

                    break;

                case 7:

                    pictureBox1.Image = Properties.Resources.q05;

                    lblQuestion.Text = "What song is this MV?";

                    button1.Text = "Spring Day";
                    button2.Text = "Fire";
                    button3.Text = "Butter";
                    button4.Text = "Fake Love";

                    correctAnswer = 2;

                    break;

                case 8:

                    pictureBox1.Image = Properties.Resources.q08;

                    lblQuestion.Text = "Who doesn’t use the last name Kim?";

                    button1.Text = "V";
                    button2.Text = "RM";
                    button3.Text = "J-Hope";
                    button4.Text = "Jin";

                    correctAnswer = 3;

                    break;
                case 9:

                    pictureBox1.Image = Properties.Resources.q02;

                    lblQuestion.Text = "What song is this MV?";

                    button1.Text = "Fake Love";
                    button2.Text = "DNA";
                    button3.Text = "Spring Day";
                    button4.Text = "IDOL";

                    correctAnswer = 2;

                    break;
                case 10:

                    pictureBox1.Image = Properties.Resources.q01;

                    lblQuestion.Text = "What song is this MV?";

                    button1.Text = "Butter";
                    button2.Text = "Boy With Luv";
                    button3.Text = "Fire";
                    button4.Text = "DOPE";

                    correctAnswer = 2;

                    break;
            }
        }
    }
}
