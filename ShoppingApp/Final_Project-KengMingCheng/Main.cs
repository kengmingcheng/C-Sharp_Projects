using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Final_Project_KengMingCheng
{
    public partial class Main : Form
    {
        private String hairString = "";
        private String faceString = "";
        private String outfitsString = "";
        private static String[] InfoList = new string[6];
        private static String[][] OrderList = new String[5][];
        private int OLindex = 0;
        private String connectionString;

        public Main()
        {
            InitializeComponent();
            cbbGender.Text = "girl";
        }
        private void displayText()
        {
            lblOutcome.Text = "";
            if (hairString != "")
            {
                lblOutcome.Text += "Hair design: " + hairString + "\n";
            }
            if (faceString != "")
            {
                lblOutcome.Text += "Facial features: " + faceString + "\n";
            }
            if (outfitsString != "")
            {
                lblOutcome.Text += "Outfits: " + outfitsString;
            }
        }
        public static String[] reportInfo()
        {
            return InfoList;
        }
        public static String[][] reportOrder()
        {
            return OrderList;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerList newList = new CustomerList();
            newList.Show();
        }

        private void cbbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dollServiceDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.dollServiceDataSet.Customers);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (OLindex < 5)
            {
                String[] newOrder = new string[4];
                newOrder[0] = cbbGender.Text;
                newOrder[1] = hairString;
                newOrder[2] = faceString;
                newOrder[3] = outfitsString;
                OrderList[OLindex] = newOrder;
                OLindex += 1;

                hairString = "";
                faceString = "";
                outfitsString = "";
                lblOutcome.Text = "Item is already in the cart";
            }
            else
            {
                MessageBox.Show("You can only place 5 dolls in the cart.");
            }
        }

        private void btnHair_Click(object sender, EventArgs e)
        {
            Hair newHair = new Hair();
            newHair.ShowDialog();
            if (newHair.click_ok() == true)
            {
                hairString = newHair.StyleString();
            }
            displayText();
        }

        private void btnFace_Click(object sender, EventArgs e)
        {
            Face newFace = new Face();
            newFace.ShowDialog();
            if (newFace.click_ok() == true)
            {
                faceString = newFace.StyleString();
            }
            displayText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Outfits newOutfits = new Outfits();
            newOutfits.ShowDialog();
            if (newOutfits.click_ok() == true)
            {
                outfitsString = newOutfits.StyleString();
            }
            displayText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Info newInfo = new Info();
            newInfo.ShowDialog();
            InfoList = newInfo.report();
            lblInformation.Text = "Name:    " + InfoList[0] + "\nShip to: " + InfoList[1];
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            updateCustomersDB();

        }

        private void updateCustomersDB()
        {
            if (InfoList[0] != null)
            {
                SqlConnection con;
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\App_Data\DollService.mdf;Integrated Security=True";
                String statement = "INSERT INTO Customers(Name,ShippingAddress,BillingAddress,PhoneNumber,CreditCardType,CreditCardNumber) values(@Name,@ShippingAddress,@BillingAddress,@PhoneNumber,@CreditCardType,@CreditCardNumber)";
                using (con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(statement, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", InfoList[0]);
                    cmd.Parameters.AddWithValue("@ShippingAddress", InfoList[1]);
                    cmd.Parameters.AddWithValue("@BillingAddress", InfoList[2]);
                    cmd.Parameters.AddWithValue("@PhoneNumber", InfoList[3]);
                    cmd.Parameters.AddWithValue("@CreditCardType", InfoList[4]);
                    cmd.Parameters.AddWithValue("@CreditCardNumber", InfoList[5]);

                    cmd.ExecuteScalar();
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hairStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHair.PerformClick();
        }

        private void facialFeaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFace.PerformClick();
        }

        private void outfitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOutfits.PerformClick();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCart.PerformClick();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            Cart newCart = new Cart();
            newCart.ShowDialog();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About newAbout = new About();
            newAbout.ShowDialog();
        }
    }
}
