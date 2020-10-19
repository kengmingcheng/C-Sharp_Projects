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
    public partial class Cart : Form
    {
        private int intPageCount = 1;

        private String[] InfoList;
        private String[][] OrderList;

        public Cart()
        {
            InitializeComponent();
            InfoList = Main.reportInfo();
            OrderList = Main.reportOrder();

            lblCustomer.Text = InfoList[0] +
              "\nShipping address: " + InfoList[1] +
              "\nPhone number: " + InfoList[3];
            
            String OrderText = "Order list: \n\n";
            foreach (String[] order in OrderList)
            {
                if (order != null)
                {
                    OrderText += order[0] + " doll" +
                        "\nHair design: " + order[1] +
                        "\nFacial features: " + order[2] +
                        "\nOutfits: " + order[3] +
                        "\n------------------------------------------------------\n";
                }
                else
                {
                    break;
                }
            }
            lblOrder.Text = OrderText;
        }

        private void Cart_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCutomer_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Set up print document data
            float fltColumnEnd;
            float fltColumnX;
            string strOutput;
            SizeF fontSize = new SizeF();
            Font printFont = new Font("Arial", 12);
            Font titleFont = new Font("Arial", 20);
            float fltLineHeight = printFont.GetHeight() + 2;
            float fltPrintX = e.MarginBounds.Left;
            float fltPrintY = e.MarginBounds.Top;
            fltPrintX = 375f;
            fltColumnEnd = 400f;
            e.Graphics.DrawString("Your Order", titleFont,
            Brushes.Black, fltPrintX, fltPrintY);
            fltPrintX = 150f;
            fltPrintY += fltLineHeight * 2;
            strOutput = lblCustomer.Text;
            fontSize = e.Graphics.MeasureString(strOutput, printFont);
            e.Graphics.DrawString(strOutput, printFont,
            Brushes.Black, fltPrintX, fltPrintY);
            fltPrintY += fltLineHeight * 5;

            strOutput = lblOrder.Text;
            fontSize = e.Graphics.MeasureString(strOutput, printFont);
            e.Graphics.DrawString(strOutput, printFont,
            Brushes.Black, fltPrintX, fltPrintY);

            intPageCount++;
            if (intPageCount <= 4)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void lblOrder_Click(object sender, EventArgs e)
        {
        }
    }
}
