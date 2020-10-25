using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatesCandyStore_ChengKengMing
{
    public partial class chocolates : Form
    {
        private int[] price_list = new int[] { 10, 12, 15, 20 };
        private int price = 0;
        private int quantity = 1;
        private double subtotal = 0;
        private string cho_flavor = "";
        public chocolates()
        {
            InitializeComponent();
            lblSummary.Text = StoreMain.getUsername() + " selected:  nothing";
            txbQty.Text = "1";
        }
        public string getFlavor()
        {
            return cho_flavor;
        }
        public double getSubtotal()
        {
            return subtotal;
        }
        public int getQty()
        {
            return quantity;
        }
        public string returnString()
        {
            return quantity.ToString() + " " + cho_flavor + " , Price: " + subtotal.ToString();
        }

        private void lblReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblSummary_Click(object sender, EventArgs e)
        {

        }

        private void cbbflavors_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSummary.Text = StoreMain.getUsername() + " selected:  " + cbbflavors.Text;
            cho_flavor = cbbflavors.Text;
            price = price_list[cbbflavors.SelectedIndex];
            subtotal = price * Int32.Parse(txbQty.Text);
            lblTotalNumber.Text = Convert.ToString(subtotal);
        }

        private void txbQty_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txbQty.Text, out quantity))
            {
                quantity = Int32.Parse(txbQty.Text);
            }
            else
            {
                quantity = 0;
            }

            subtotal = price * quantity;
            lblTotalNumber.Text = Convert.ToString(subtotal);
        }
    }
}
