using System;
using System.Drawing;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class GameForm : Form
    {

        enum enBoxesNumbers { eBox1 = 1, eBox2 = 2, eBox3 = 4, eBox4 = 8, eBox5 = 16, eBox6 = 32, eBox7 = 64, eBox8 = 128, eBox9 = 256 };
        private enBoxesNumbers Player1Boxes = 0;
        private enBoxesNumbers Player2Boxes = 0;
        private enBoxesNumbers TakenBoxes = 0;
        private enBoxesNumbers[] WiningCombos = {

            (enBoxesNumbers.eBox1 | enBoxesNumbers.eBox2 | enBoxesNumbers.eBox3),
            (enBoxesNumbers.eBox4 | enBoxesNumbers.eBox5 | enBoxesNumbers.eBox6),
            (enBoxesNumbers.eBox7 | enBoxesNumbers.eBox8 | enBoxesNumbers.eBox9),
            (enBoxesNumbers.eBox1 | enBoxesNumbers.eBox4 | enBoxesNumbers.eBox7),
            (enBoxesNumbers.eBox2 | enBoxesNumbers.eBox5 | enBoxesNumbers.eBox8),
            (enBoxesNumbers.eBox3 | enBoxesNumbers.eBox6 | enBoxesNumbers.eBox9),
            (enBoxesNumbers.eBox3 | enBoxesNumbers.eBox5 | enBoxesNumbers.eBox7),
            (enBoxesNumbers.eBox1 | enBoxesNumbers.eBox5 | enBoxesNumbers.eBox9)
        };
        private int Turn = 0; // to control player turn and which picture to show
        private int Rounds = 1;
        bool IsPlayer2Computer = false;

        public GameForm(String Player2)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            pictureBox1.Click += PictureBoxes_Click;
            pictureBox1.Tag = enBoxesNumbers.eBox1;
            pictureBox2.Click += PictureBoxes_Click;
            pictureBox2.Tag = enBoxesNumbers.eBox2;
            pictureBox3.Click += PictureBoxes_Click;
            pictureBox3.Tag = enBoxesNumbers.eBox3;
            pictureBox4.Click += PictureBoxes_Click;
            pictureBox4.Tag = enBoxesNumbers.eBox4;
            pictureBox5.Click += PictureBoxes_Click;
            pictureBox5.Tag = enBoxesNumbers.eBox5;
            pictureBox6.Click += PictureBoxes_Click;
            pictureBox6.Tag = enBoxesNumbers.eBox6;
            pictureBox7.Click += PictureBoxes_Click;
            pictureBox7.Tag = enBoxesNumbers.eBox7;
            pictureBox8.Click += PictureBoxes_Click;
            pictureBox8.Tag = enBoxesNumbers.eBox8;
            pictureBox9.Click += PictureBoxes_Click;
            pictureBox9.Tag = enBoxesNumbers.eBox9;

            IsPlayer2Computer = Player2 == "Computer" ? true : false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 220, 0));
            pen.Width = 6;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Flat;

            // vertical lines
            e.Graphics.DrawLine(pen, 288, 715, 288, 288);
            e.Graphics.DrawLine(pen, 571, 715, 571, 288);
            // horizontal lines
            e.Graphics.DrawLine(pen, 40, 420, 820, 420);
            e.Graphics.DrawLine(pen, 40, 580, 820, 580);

            pen.Dispose();

        }

        private void SwitchPicBox(PictureBox ClickedBox)
        {

            ClickedBox.Image = Turn % 2 == 0 ? Resources.x1 : Resources.o2;
            TakenBoxes |= (enBoxesNumbers)ClickedBox.Tag;

            if (Turn % 2 == 0)
            {
                Player1Boxes |= (enBoxesNumbers)ClickedBox.Tag;
            }
            else
            {
                Player2Boxes |= (enBoxesNumbers)ClickedBox.Tag;
            }


            Turn++;
            lblCurrentPlayer.Text = Turn % 2 == 0 ? "Player 1" : "Player 2";

        }

        private bool CheckWinner(enBoxesNumbers PlayerBoxes)
        {
            if ((PlayerBoxes & WiningCombos[0]) == WiningCombos[0])
            {
                pictureBox1.BackColor = Color.Green;
                pictureBox2.BackColor = Color.Green;
                pictureBox3.BackColor = Color.Green;
                return true;
            }
            else if ((PlayerBoxes & WiningCombos[1]) == WiningCombos[1])
            {
                pictureBox4.BackColor = Color.Green;
                pictureBox5.BackColor = Color.Green;
                pictureBox6.BackColor = Color.Green;
                return true;
            }
            else if ((PlayerBoxes & WiningCombos[2]) == WiningCombos[2])
            {
                pictureBox7.BackColor = Color.Green;
                pictureBox8.BackColor = Color.Green;
                pictureBox9.BackColor = Color.Green;
                return true;
            }
            else if ((PlayerBoxes & WiningCombos[3]) == WiningCombos[3])
            {
                pictureBox1.BackColor = Color.Green;
                pictureBox4.BackColor = Color.Green;
                pictureBox7.BackColor = Color.Green;
                return true;
            }
            else if ((PlayerBoxes & WiningCombos[4]) == WiningCombos[4])
            {
                pictureBox2.BackColor = Color.Green;
                pictureBox5.BackColor = Color.Green;
                pictureBox8.BackColor = Color.Green;
                return true;
            }
            else if ((PlayerBoxes & WiningCombos[5]) == WiningCombos[5])
            {
                pictureBox3.BackColor = Color.Green;
                pictureBox6.BackColor = Color.Green;
                pictureBox9.BackColor = Color.Green;
                return true;
            }
            else if ((PlayerBoxes & WiningCombos[6]) == WiningCombos[6])
            {
                pictureBox3.BackColor = Color.Green;
                pictureBox5.BackColor = Color.Green;
                pictureBox7.BackColor = Color.Green;
                return true;
            }
            else if ((PlayerBoxes & WiningCombos[7]) == WiningCombos[7])
            {
                pictureBox1.BackColor = Color.Green;
                pictureBox5.BackColor = Color.Green;
                pictureBox9.BackColor = Color.Green;
                return true;
            }

            return false;
        }

        // one click handler for all 9 picture boxes
        private void PictureBoxes_Click(object sender, EventArgs e)
        {
            PictureBox ClickedBox = ((PictureBox)sender);

            if (ClickedBox == null)
                return;

            if (((enBoxesNumbers)ClickedBox.Tag & TakenBoxes ) != 0)
            {
                MessageBox.Show("Wrong Choice! Place Already Taken", "Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SwitchPicBox(ClickedBox);



            int WinnerPlayer = CheckWinner(Player1Boxes) ? 1 : CheckWinner(Player2Boxes) ? 2 : 0;

            if (WinnerPlayer > 0)
            {
                lblWinner.Text = $"Player {WinnerPlayer}";
                MessageBox.Show($"Player {WinnerPlayer} Won The Round!!!", "Round Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                plBoxes.Enabled = false;
                btnNewRound.ForeColor = Color.Green;
                return;
            }
            else if (Turn == 9)
            {
                lblWinner.Text = "Draw";
                MessageBox.Show("No Winner, it is a Draw!", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                plBoxes.Enabled = false;
                btnNewRound.ForeColor = Color.Green;
                return;
            }
        
        }

        private void btnNewRound_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.Q;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.Image = Resources.Q;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.Image = Resources.Q;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.Image = Resources.Q;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.Image = Resources.Q;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.Image = Resources.Q;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox7.Image = Resources.Q;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox8.Image = Resources.Q;
            pictureBox8.BackColor = Color.Transparent;
            pictureBox9.Image = Resources.Q;
            pictureBox9.BackColor = Color.Transparent;

            TakenBoxes = 0;
            Player1Boxes = 0;
            Player2Boxes = 0;

            lblCurrentPlayer.Text = "Player 1";
            lblWinner.Text = "In Progress";
            Rounds++;
            Turn = 0;
            lblRoundCounter.Text = Rounds.ToString();
            plBoxes.Enabled = true;
            btnNewRound.ForeColor = Color.FromArgb(255, 220, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
