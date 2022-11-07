using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsGL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            lbl_ouputText.Text = txt_input.Text;
            txt_input.Text = string.Empty;

            fontDialog1.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = "Demo Applikation " + DateTime.Now;
        }
    }
}
