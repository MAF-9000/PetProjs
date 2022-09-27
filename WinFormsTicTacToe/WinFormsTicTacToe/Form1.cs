namespace WinFormsTicTacToe
{
    public partial class Form1 : Form
    {
        public bool turn = true;
        public int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            count++;
            CheckForWinner();

        }

        private void CheckForWinner()
        {
            bool winner = false;
            if (((but1.Text == but2.Text) && (but2.Text == but3.Text) && (!but1.Enabled)) || 
                ((but4.Text == but5.Text) && (but5.Text == but6.Text) && (!but4.Enabled)) || 
                ((but7.Text == but8.Text) && (but8.Text == but9.Text) && (!but7.Enabled)))
            {
                //���������� �� �����������
                winner = true;
            }
            else if (((but1.Text == but4.Text) && (but4.Text == but7.Text) && (!but1.Enabled)) || 
                ((but2.Text == but5.Text) && (but5.Text == but8.Text) && (!but2.Enabled)) || 
                ((but3.Text == but6.Text) && (but6.Text == but9.Text) && (!but3.Enabled)))
            {
                //���������� �� ���������
                winner = true;
            }
            else if (((but1.Text == but5.Text) && (but5.Text == but9.Text) && (!but1.Enabled)) || 
                ((but3.Text == but5.Text) && (but5.Text == but7.Text) && (!but5.Enabled)))
            {
                //���������� �� ���������
                winner = true;
            }

            if (winner)
            {
                DisabledButtons();
                string win;
                if (turn)
                {
                    win = "O";
                }
                else
                {
                    win = "X";
                }
                MessageBox.Show($"{win} ��������!");
            }
            else
            {
                if (count == 9)
                {
                    MessageBox.Show($"�����!");
                }
            }
        }
        private void DisabledButtons()
        {
            try
            {
                foreach (Control control in Controls)
                {
                    Button b = (Button)control;
                    b.Enabled = false;
                }

            }
            catch { }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            count = 0;
            try
            {
                foreach (Control control in Controls)
                {
                    Button b = (Button)control;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}