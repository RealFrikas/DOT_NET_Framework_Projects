using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ses_V2
{
    public partial class Form1 : Form
    {
        int a1 = 1, a2 = 1, a3 = 4, a4 = 1, a5 = 4, a6 = 1, a7 = 1, a8 = 4, a9 = 4, a10 = 4;

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            string halfval = ((RadioButton)sender).Name.Substring(1);
            int val = Convert.ToInt32(halfval);
            switch (val / 10)
            {
                case 1:
                    a1 = val % 10;
                    break;
                case 2:
                    a2 = val % 10;
                    break;
                case 3:
                    a3 = val % 10;
                    break;
                case 4:
                    a4 = val % 10;
                    break;
                case 5:
                    a5 = val % 10;
                    break;
                case 6:
                    a6 = val % 10;
                    break;
                case 7:
                    a7 = val % 10;
                    break;
                case 8:
                    a8 = val % 10;
                    break;
                case 9:
                    a9 = val % 10;
                    break;
                case 10:
                    a10 = val % 10;
                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float ans = (float)(a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10) / 10;
            lblans.Text = "Your self esteem is:\n" + ans + "\n" + "Out of 4.";
        }
    }
}
