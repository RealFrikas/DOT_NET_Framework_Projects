using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic_design_solutions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //hoi
        }

        //places numbers in tables
        private void Placenumbers(int n1, int n2, int n3, int n4, int modif, string table)
        {
            //a1 a2 a3 a4 mod and which d

            if (n1 % modif >= modif / 2)
            {
                Label kmaploc = Controls.Find(table + "0", true).FirstOrDefault() as Label;
                kmaploc.Text = "1";
            }
            else
            {
                Label kmaploc = Controls.Find(table + "0", true).FirstOrDefault() as Label;
                kmaploc.Text = "0";
            }
            if (n2 % modif >= modif / 2)
            {
                Label kmaploc = Controls.Find(table + n1, true).FirstOrDefault() as Label;
                kmaploc.Text = "1";
            }
            else
            {
                Label kmaploc = Controls.Find(table + n1, true).FirstOrDefault() as Label;
                kmaploc.Text = "0";
            }
            if (n3 % modif >= modif / 2)
            {
                Label kmaploc = Controls.Find(table + n2, true).FirstOrDefault() as Label;
                kmaploc.Text = "1";
            }
            else
            {
                Label kmaploc = Controls.Find(table + n2, true).FirstOrDefault() as Label;
                kmaploc.Text = "0";
            }
            if (n4 % modif >= modif / 2)
            {
                Label kmaploc = Controls.Find(table + n3, true).FirstOrDefault() as Label;
                kmaploc.Text = "1";
            }
            else
            {
                Label kmaploc = Controls.Find(table + n3, true).FirstOrDefault() as Label;
                kmaploc.Text = "0";
            }

            Label kmaplocl = Controls.Find(table + n4, true).FirstOrDefault() as Label;
            kmaplocl.Text = "0";

        }

        //makes all tables x again
        private void Resetall()
        {
            for(int i = 0; i < 8; i++)
            {
                Label kmaploc0 = Controls.Find("D0" + i, true).FirstOrDefault() as Label;
                kmaploc0.Text = "x";
                Label kmaploc1 = Controls.Find("D1" + i, true).FirstOrDefault() as Label;
                kmaploc1.Text = "x";
                Label kmaploc2 = Controls.Find("D2" + i, true).FirstOrDefault() as Label;
                kmaploc2.Text = "x";
            }
        }

        //when pressed it takes the numbers and does the magic
        int sequence;
        private void submitbtn_Click(object sender, EventArgs e)
        {
            //if nothing is in
            try
            {
                sequence = Int32.Parse(sequencebox.Text);
            }
            catch (Exception)
            {
                Errorbox.Text = "Wrong sequence";
            }
            //removes the extra zero if dumb guy enters 073450
            if (sequence % 10 == 0 && sequence > 9999)
            {
                sequence = sequence / 10;
            }
            int a1 = sequence % 10;
            int a2 = sequence % 100 - a1;
            int a3 = sequence % 1000 - a1 - a2;
            int a4 = sequence - a1 - a2 - a3;
            a2 = a2 / 10;
            a3 = a3 / 100;
            a4 = a4 / 1000;
            //checks if the numbers taken are right (>0,<8,no numbers match,no more than 4 numbers)
            // || a1 == 0 || a2 == 0 || a3 == 0 || a4 == 0 || a1 >= 8 || a2 >= 8 || a3 >= 8 || a4 >= 8 || a1 == a2 || a1 == a3 || a1 == a4 || a2 == a3 || a2 ==a4 || a3 == a4
            if (sequence / 10000 != 0)
            {
                Errorbox.Text = "Sequence is too big";
            }
            else if (a4 == 0)
            {
                Errorbox.Text = "Sequence is too smol";
            }
            else if (a2 == 0 || a3 == 0 || a1 == 0)
            {
                Errorbox.Text = "Zeroes aren't allowed inside the sequence";
            }
            else if (a1 >= 8 || a2 >= 8 || a3 >= 8 || a4 >= 8)
            {
                Errorbox.Text = "Numbers above 7 cannot be reached by 3 flip-flops";
            }
            else if (a1 == a2 || a1 == a3 || a1 == a4 || a2 == a3 || a2 == a4 || a3 == a4)
            {
                Errorbox.Text = "Repetition of numbers isn't possible";
            }
            else
            {
                Errorbox.Text = "No Errors";
                Resetall();
                Placenumbers(a4, a3, a2, a1, 2, "D0");
                Placenumbers(a4, a3, a2, a1, 4, "D1");
                Placenumbers(a4, a3, a2, a1, 8, "D2");
            }         
        }

        //press submit when enter is pressed
        private void sequencebox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submitbtn_Click(sender,e);
            }
        }
        
        //numbers only in the textbox
        private void sequencebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }
    }
}
