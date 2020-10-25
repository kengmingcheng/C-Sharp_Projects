namespace GatesCandyStore_ChengKengMing
{
    partial class lollipops
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblReturn = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lbldescribe = new System.Windows.Forms.Label();
            this.cbbflavors = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalNumber = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txbQty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblReturn
            // 
            this.lblReturn.Location = new System.Drawing.Point(161, 568);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(186, 48);
            this.lblReturn.TabIndex = 7;
            this.lblReturn.Text = "Return to Main";
            this.lblReturn.UseVisualStyleBackColor = true;
            this.lblReturn.Click += new System.EventHandler(this.lblReturn_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(156, 329);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(64, 25);
            this.lblSummary.TabIndex = 6;
            this.lblSummary.Text = "label1";
            this.lblSummary.Click += new System.EventHandler(this.lblSummary_Click);
            // 
            // lbldescribe
            // 
            this.lbldescribe.AutoSize = true;
            this.lbldescribe.Location = new System.Drawing.Point(156, 139);
            this.lbldescribe.Name = "lbldescribe";
            this.lbldescribe.Size = new System.Drawing.Size(382, 25);
            this.lbldescribe.TabIndex = 4;
            this.lbldescribe.Text = "Pick the lollipop flavor that you want to buy:";
            // 
            // cbbflavors
            // 
            this.cbbflavors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbflavors.FormattingEnabled = true;
            this.cbbflavors.Items.AddRange(new object[] {
            "Cotton Candy",
            "Bubble Gun",
            "Wild Cherry",
            "Orange Splash"});
            this.cbbflavors.Location = new System.Drawing.Point(161, 217);
            this.cbbflavors.Name = "cbbflavors";
            this.cbbflavors.Size = new System.Drawing.Size(300, 32);
            this.cbbflavors.TabIndex = 8;
            this.cbbflavors.SelectedIndexChanged += new System.EventHandler(this.cbbflavors_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(156, 477);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 25);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Subtotal:";
            // 
            // lblTotalNumber
            // 
            this.lblTotalNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalNumber.Location = new System.Drawing.Point(252, 474);
            this.lblTotalNumber.Name = "lblTotalNumber";
            this.lblTotalNumber.Size = new System.Drawing.Size(110, 30);
            this.lblTotalNumber.TabIndex = 13;
            this.lblTotalNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(156, 403);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(91, 25);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Quantity:";
            // 
            // txbQty
            // 
            this.txbQty.Location = new System.Drawing.Point(262, 400);
            this.txbQty.Name = "txbQty";
            this.txbQty.Size = new System.Drawing.Size(100, 29);
            this.txbQty.TabIndex = 11;
            this.txbQty.Text = "1";
            this.txbQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbQty.TextChanged += new System.EventHandler(this.txbQty_TextChanged);
            // 
            // lollipops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 736);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalNumber);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txbQty);
            this.Controls.Add(this.cbbflavors);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lbldescribe);
            this.Name = "lollipops";
            this.Text = "Lollipops";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lblReturn;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lbldescribe;
        private System.Windows.Forms.ComboBox cbbflavors;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalNumber;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txbQty;
    }
}