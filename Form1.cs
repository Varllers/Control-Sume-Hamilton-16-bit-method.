using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3Heming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        byte[] r = new byte[5];
        Words k = new Words(16);
        Words s = new Words(21);
        private void button1_Click(object sender, EventArgs e)
        {
            Translate(k,button3,textBox1,textBox4);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Translate(s, button4, textBox2, textBox5);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            int j = 0;
            r[0] = (byte)(k[1-1] ^ k[2 - 1] ^ k[4 - 1] ^ k[5 - 1] ^ k[7 - 1] ^ k[9 - 1] ^ k[11 - 1] ^ k[12 - 1] ^ k[14 - 1] ^ k[16-1]);
            r[1] = (byte)(k[1-1] ^ k[3 - 1] ^ k[4 - 1] ^ k[6 - 1] ^ k[7 - 1] ^ k[10 - 1] ^ k[11 - 1] ^ k[13 - 1] ^ k[14 - 1]);
            r[2] = (byte)(k[2-1] ^ k[3 - 1] ^ k[4 - 1] ^ k[8 - 1] ^ k[9 - 1] ^ k[10 - 1] ^ k[11 - 1] ^ k[15 - 1] ^ k[16-1]);
            r[3] = (byte)(k[5-1] ^ k[6 - 1] ^ k[7 - 1] ^ k[8 - 1] ^ k[9 - 1] ^ k[10 - 1] ^ k[11 - 1]);
            r[4] = (byte)(k[12-1] ^ k[13 - 1] ^ k[14 - 1] ^ k[15 - 1] ^ k[16 - 1]);
            for(int i = 0; i <= 20; i++)
            {
                if (i == 0 || i == 1 || i == 3 || i == 7 || i == 15)
                {
                    textBox3.Text += r[j];
                    label6.Text += r[j] + "\n";
                    j++;
                }
                else
                {
                    if (i >= 2)
                    {
                        textBox3.Text += k[i - j];
                        label6.Text += k[i-j] + "\n";
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            r[0] = (byte)(s[0] ^ s[2] ^ s[4] ^ s[6] ^ s[8] ^ s[10] ^ s[12] ^ s[14] ^ s[16] ^ s[18] ^ s[20]);
            r[1] = (byte)(s[1] ^ s[2] ^ s[5] ^ s[6] ^ s[9] ^ s[10] ^ s[13] ^ s[14] ^ s[17] ^ s[18]);
            r[2] = (byte)(s[3] ^ s[4] ^ s[5] ^ s[6] ^ s[11] ^ s[12] ^ s[13] ^ s[14] ^ s[19] ^ s[20]);
            r[3] = (byte)(s[7] ^ s[8] ^ s[9] ^ s[10] ^ s[11] ^ s[12] ^ s[13] ^ s[14]);
            r[4] = (byte)(s[15] ^ s[16] ^ s[17] ^ s[18] ^ s[19] ^ s[20]);
            string str = default;
            foreach (byte i in r) {
                label8.Text += i + "\n";
                str += i.ToString();
            }
            Array.Reverse(r);
            foreach (byte i in r)
            { 
                str += i.ToString();
            }
            label9.Text = $"Bug in {Convert.ToInt32(str, 2).ToString()} digit";
            
        }
        private void Translate(Words g, Button bt, params TextBox[] Tx)
        {
            try
            {
                if (Tx[0].Text.ToCharArray().Length > g.Lenght)
                    throw new Exception($"Word must contains {g.Lenght} digit");
                char[] a = Tx[0].Text.ToCharArray();
                Tx[1].Clear();
                for (int i = 0; i < g.Lenght; i++)
                {
                    g[i] = byte.Parse(a[i].ToString());
                    
                }
                foreach (var i in g)
                    Tx[1].Text += i.ToString();
                bt.Enabled = true;
            }
            catch (Exception ex)
            {
                Tx[1].Text = ex.Message;
                bt.Enabled = false;
            }
        }
    }
}
