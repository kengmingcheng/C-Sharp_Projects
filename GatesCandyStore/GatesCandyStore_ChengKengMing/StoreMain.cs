using System;
using System.Windows.Forms;

namespace GatesCandyStore_ChengKengMing
{
    public partial class StoreMain : Form
    {
        private static string username = "";
        private double[] subtotal = new double[3];
        private double total_price = 0;

        public static string getUsername()
        {
            return username;
        }

        public StoreMain()
        {
            InitializeComponent();
            
        }
        public string choText
        {
            get
            {
                return lblDisplayCho.Text;
            }
            set
            {
                lblDisplayCho.Text = value;
            }
        }

        public string lolText
        {
            get
            {
                return lblDisplayLol.Text;
            }
            set
            {
                lblDisplayLol.Text = value;
            }
        }

        public string marText
        {
            get
            {
                return lblDisplayMar.Text;
            }
            set
            {
                lblDisplayMar.Text = value;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCandyOutput.Text = cbbSelectCandy.Text;
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {
            username = txbName.Text;
        }

        private void btnPressSelection_Click(object sender, EventArgs e)
        {
            if (cbbSelectCandy.Text == "Chocolates")
            {
                chocolates Cho = new chocolates();
                Cho.ShowDialog();
                lblDisplayCho.Text = Cho.returnString();
                subtotal[0] = Cho.getSubtotal();
            }
            else if (cbbSelectCandy.Text == "Lollipops")
            {
                lollipops Lol = new lollipops();
                Lol.ShowDialog();
                lblDisplayLol.Text = Lol.returnString();
                subtotal[1] = Lol.getSubtotal();
            }
            else if (cbbSelectCandy.Text == "Marshmellos")
            {
                marshmellos Mar = new marshmellos();
                Mar.ShowDialog();
                lblDisplayMar.Text = Mar.returnString();
                subtotal[2] = Mar.getSubtotal();
            }

            lblTotal.Text = "Balance: " + (subtotal[0] + subtotal[1] + subtotal[2]).ToString();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblDisplayCho_Click(object sender, EventArgs e)
        {
        }
    }
}
