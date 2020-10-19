using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_KengMingCheng
{
    public partial class BaseForm : Form
    {
        protected bool OKbutton = false;
        public BaseForm()
        {
            InitializeComponent();
        }
        public bool click_ok()
        {
            return OKbutton;
        }
        public String StyleString()
        {
            return cbbOP1.Text +" " + cbbOP2.Text + " " + cbbOP3.Text;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            OKbutton = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbOP1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
