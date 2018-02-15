using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingGame01
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        int finalScore;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //calls random chars
            listBox1.Items.Add((Keys)random.Next(65, 90));
            //condition for full screen
            if (listBox1.Items.Count > 7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game Over!");
                timer1.Stop();
                finalScore = stats.m_Correct;
                SettingHighScore();

            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if correct input. remove keys from listbox
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                //change time and game goes on longer

                if (timer1.Interval > 400)
                {
                    timer1.Interval -= 10;
                }
                if (timer1.Interval > 250)
                {
                    timer1.Interval -= 7;
                }
                if (timer1.Interval > 100)
                {
                    timer1.Interval -= 2;
                }
                //calculations for diffculty progressBar average
                difficultyProgressBar.Value = 800 - timer1.Interval;

                //pass through correct stats
                stats.Update(true);
            }
            else
            {
                stats.Update(false);
            }
            // Update the labels on the StatusStrip
            correctLabel.Text = "Correct: " + stats.m_Correct;
            missedLabel.Text = "Missed: " + stats.m_Missed;
            totalLabel.Text = "Total: " + stats.m_Total;
            accuracyLabel.Text = "Accuracy: " + stats.m_Accuracy + "%";
        }

        private void restToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by: Halim Lais \n Isolated Gamerz \n github.com/hlais");
        }

        private void bestScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Highest Score: " + Properties.Settings.Default.HighScore);

        }
        private void SettingHighScore()
        {
            if (finalScore > Properties.Settings.Default.HighScore)
            {
                Properties.Settings.Default.HighScore = finalScore;
                Properties.Settings.Default.Save();

            }
            else
                return;
        }
    }
}
