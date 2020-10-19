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
    public partial class Info : Form
    {
        private String[] reportInfo = new String[6];
        public Info()
        {
            InitializeComponent();
        }
        public String[] report()
        {
            reportInfo[0] = txtName.Text;
            reportInfo[1] = txtSAddress.Text;
            reportInfo[2] = txtBAddress.Text;
            reportInfo[3] = txtPhone.Text;
            reportInfo[4] = cbbCreditCard.Text;
            reportInfo[5] = txtCreditCard.Text;

            return reportInfo;
        }

        private void txtSAddress_MouseDown(object sender, MouseEventArgs e)
        {
            txtSAddress.DoDragDrop(txtSAddress.Text, DragDropEffects.Copy);
        }

        private void txtSAddress_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtSAddress_DragDrop(object sender, DragEventArgs e)
        {
            txtSAddress.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void txtBAddress_MouseDown(object sender, MouseEventArgs e)
        {
            txtBAddress.DoDragDrop(txtBAddress.Text, DragDropEffects.Copy);
        }

        private void txtBAddress_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtBAddress_DragDrop(object sender, DragEventArgs e)
        {
            txtBAddress.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
