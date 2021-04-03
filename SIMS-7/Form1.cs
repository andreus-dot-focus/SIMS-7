using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMS_7
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        int fireCount;

        int day = 0;
        int month = 0;
        int year = 0;

        int trainings;
        int quality;
        double SF;

        int SO = 120;

        int fire;
        int human=100;
        int money=1000;

        double KTP;

        double B;
        double inB;
        double outB;

        double Z = 0.2;

        double CH;
        double inCH;
        double outCH;

        double PR = 1;

        int P=20;
        int outP=0; //пожарники тушат все пожары
        int inP;
        public Form1()
        {
            InitializeComponent();
            chart1.Series[0].Points.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            trainings = Convert.ToInt32(TrainingsTB.Text);
            quality = Convert.ToInt32(QualityTB.Text);

            SF = 4 + (trainings + quality) * 0.000001;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            day++;
          
            if (day == 30)
            {
                day = 0;
                chart1.Series[0].Points.AddXY(month, fireCount/30);
                fireCount = 0;
                month++;
                if (month == 12)
                {
                    chart1.Series[0].Points.Clear();

                    month = 0;
                    year++;
                    inB = money * Z;
                    B = B + inB;

                    outCH = rnd.Next(10, 30);
                }
            }

            dayLabel.Text = day.ToString();
            monthLabel.Text = month.ToString();
            yearLabel.Text = year.ToString();

            human += 100;


            PR = 0.1*rnd.Next(1,10);
            B -= PR*B;
            
            outB = B;

            inCH = human / SO;
            CH = inCH - outCH;

            fire = rnd.Next(2, 100);
            KTP = SF * CH * B * 0.01;
            inP = Convert.ToInt32(Math.Round(fire + KTP));
            P = inP - outP;
            fireCount += P;
            Console.WriteLine(P);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
