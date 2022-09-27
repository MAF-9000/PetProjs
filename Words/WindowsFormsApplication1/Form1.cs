using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Слова
{
    public partial class Form1 : Form
    {
        string c = "";
        
        string[] lines = new string[14842];
        bool[] f;
        int sch = 0;
        bool ps = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Text = "";
            int n = 0;
            sch = 1;
            string s;
            f = new bool[lines.Length];
            for (int i = 0; i < f.Length; i++) { f[i] = false; }
            StreamReader f1 = new StreamReader("1.txt", Encoding.GetEncoding(1251));
            while ((s = f1.ReadLine()) != null) { lines[n] = s; n++; }
            textBox1.Visible = true;
            listBox1.Visible = true;
        }
        public static bool Input(string c, string[] lines,out int j)
        {
            bool k=false;
            j = 0;
            for (int i = 0; i < lines.Length; i++)
                if (c == lines[i]) { k = true; j = i; break; }
            return k;
        }
        public static string O(string c,string[] lines,out int j,bool[] f)
        {
            int p = 0 ;
            char s1 = c[c.Length-1];
            if(s1=='ь'||s1=='ъ'||s1=='ы'){s1 = c[c.Length-2];}
            Random t = new Random();

            for(int i=t.Next(0,10000);i<lines.Length;i++)
                if (lines[i][0] == s1&&!f[i]) { c = lines[i]; p = i; break; }
            j = p;
            return c;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox1.Text != "")
                {
                    int j = 0;
                    char t = ' ';
                    if (ps)
                    {
                        c = textBox1.Text;
                        if (Input(c, lines, out j))
                        {
                            if (!f[j]) { f[j] = true; listBox1.Items.Add(c); c = O(c, lines, out j, f); f[j] = true; listBox1.Items.Add(c); }
                            else { label1.Text = "введенное слово уже было!"; }
                            ps = false;
                            label1.Text = "";
                        }
                        else label1.Text = "введенное слово не подходит!";

                    }
                    else
                    {
                        if (c[c.Length - 1] == 'ы' || c[c.Length - 1] == 'ь' || c[c.Length - 1] == 'ъ') { t = c[c.Length - 2]; }
                        else { t = c[c.Length - 1]; }
                        if (textBox1.Text[0] == t)
                        {

                            if (Input(textBox1.Text, lines, out j))
                            {

                                if (!f[j])
                                {
                                    c = textBox1.Text;
                                    f[j] = true;
                                    listBox1.Items.Add(textBox1.Text);
                                    c = O(c, lines, out j, f);
                                    f[j] = true;
                                    listBox1.Items.Add(c);
                                    sch += 2; listBox1.SetSelected(sch, true);
                                    label1.Text = "";
                                }
                                else { label1.Text = "введенное слово уже было!"; }

                            }
                            else label1.Text = "введенного слова нет в списке!";
                        }
                        else label1.Text = "введенное слово не подходит!";
                    }

                    textBox1.Text = "";
                    textBox1.SelectionStart = 0;
                }
            }
            else { label1.Text = "Ведите слово!"; }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("exit game?", "Close?",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            e.Cancel = (result == DialogResult.No);
        }
    }
}
