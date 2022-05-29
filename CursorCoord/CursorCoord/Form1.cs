using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace CursorCoord
{
    public partial class Form1 : Form
    {
        public Form1() // Form size: 668; 279
        {
            InitializeComponent();
        }








        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy,
                              int dwData, int dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        public static void CiftSolTiklama(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }












        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Anlık Mouse Koordinatları: \nX: " + Cursor.Position.X + " \nY: " + Cursor.Position.Y;
        }

        int maxlist = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            this.Text = "Cursor Coord - Çözünürlük: " + screenWidth + "x" + screenHeight;
            timer1.Start();
            maxlist = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label1.Text);
            MessageBox.Show("Kopyalandı!" + "\n"+ label1.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D) // ctrl+d yapınca
            {
                Clipboard.SetText(label1.Text);
                MessageBox.Show("Kopyalandı!" + "\n" + label1.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.Control && e.KeyCode == Keys.E) // ctrl+e yapınca
            {
                if(label2.Text.Length < 50 && maxlist == 0)
                {
                    label2.Text += "X: " + Cursor.Position.X + " \nY: " + Cursor.Position.Y + "\n\n";
                }
                else if (label2.Text.Length > 50 && maxlist == 0)
                {
                    label3.Text += "X: " + Cursor.Position.X + " \nY: " + Cursor.Position.Y + "\n\n";
                }

                if (label3.Text.Length > 50)
                {
                    MessageBox.Show("Lütfen listeyi temizleyin!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maxlist = 1;
                }
            }

            if (e.Control && e.KeyCode == Keys.F) // ctrl+f yapınca
            {
                textBox1.Text = "" + Cursor.Position.X;
                textBox2.Text = "" + Cursor.Position.Y;
            }
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
            maxlist = 0;
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            if (label2.Text.Length < 50 && maxlist == 0)
            {
                label2.Text += "X: " + Cursor.Position.X + " \nY: " + Cursor.Position.Y + "\n";
            }
            else if (label2.Text.Length > 50 && maxlist == 0)
            {
                label3.Text += "X: " + Cursor.Position.X + " \nY: " + Cursor.Position.Y + "\n";
            }

            if (label3.Text.Length > 50)
            {
                MessageBox.Show("Lütfen listeyi temizleyin!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maxlist = 1;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                CiftSolTiklama(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            }
            else if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("X ve Y koordinatlarını boş bırakmayın.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "" + Cursor.Position.X;
            textBox2.Text = "" + Cursor.Position.Y;
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen sadece sayı yazınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen sadece sayı yazınız", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
