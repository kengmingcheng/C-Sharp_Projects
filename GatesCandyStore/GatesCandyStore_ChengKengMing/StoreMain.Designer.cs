namespace GatesCandyStore_ChengKengMing
{
    partial class StoreMain
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblCandyTyoe = new System.Windows.Forms.Label();
            this.lblSelceted = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.lblCandyOutput = new System.Windows.Forms.Label();
            this.cbbSelectCandy = new System.Windows.Forms.ComboBox();
            this.btnPressSelection = new System.Windows.Forms.Button();
            this.lblYourSel = new System.Windows.Forms.Label();
            this.lblMarshmello = new System.Windows.Forms.Label();
            this.lblLollipop = new System.Windows.Forms.Label();
            this.lblChocolate = new System.Windows.Forms.Label();
            this.lblDisplayCho = new System.Windows.Forms.Label();
            this.lblDisplayLol = new System.Windows.Forms.Label();
            this.lblDisplayMar = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(97, 101);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(161, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Enter your name:";
            // 
            // lblCandyTyoe
            // 
            this.lblCandyTyoe.AutoSize = true;
            this.lblCandyTyoe.Location = new System.Drawing.Point(97, 174);
            this.lblCandyTyoe.Name = "lblCandyTyoe";
            this.lblCandyTyoe.Size = new System.Drawing.Size(173, 25);
            this.lblCandyTyoe.TabIndex = 1;
            this.lblCandyTyoe.Text = "Select candy type:";
            this.lblCandyTyoe.Click += new System.EventHandler(this.Label1_Click);
            // 
            // lblSelceted
            // 
            this.lblSelceted.AutoSize = true;
            this.lblSelceted.Location = new System.Drawing.Point(97, 253);
            this.lblSelceted.Name = "lblSelceted";
            this.lblSelceted.Size = new System.Drawing.Size(214, 25);
            this.lblSelceted.TabIndex = 2;
            this.lblSelceted.Text = "Selected candy type is:";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(358, 98);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(240, 29);
            this.txbName.TabIndex = 3;
            this.txbName.TextChanged += new System.EventHandler(this.txbName_TextChanged);
            // 
            // lblCandyOutput
            // 
            this.lblCandyOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCandyOutput.Location = new System.Drawing.Point(358, 250);
            this.lblCandyOutput.Name = "lblCandyOutput";
            this.lblCandyOutput.Size = new System.Drawing.Size(240, 30);
            this.lblCandyOutput.TabIndex = 4;
            this.lblCandyOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbbSelectCandy
            // 
            this.cbbSelectCandy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSelectCandy.FormattingEnabled = true;
            this.cbbSelectCandy.Items.AddRange(new object[] {
            "Chocolates",
            "Lollipops",
            "Marshmellos"});
            this.cbbSelectCandy.Location = new System.Drawing.Point(358, 171);
            this.cbbSelectCandy.Name = "cbbSelectCandy";
            this.cbbSelectCandy.Size = new System.Drawing.Size(240, 32);
            this.cbbSelectCandy.TabIndex = 5;
            this.cbbSelectCandy.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnPressSelection
            // 
            this.btnPressSelection.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPressSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPressSelection.Location = new System.Drawing.Point(102, 352);
            this.btnPressSelection.Name = "btnPressSelection";
            this.btnPressSelection.Size = new System.Drawing.Size(256, 64);
            this.btnPressSelection.TabIndex = 6;
            this.btnPressSelection.Text = "Process Candy Selection";
            this.btnPressSelection.UseVisualStyleBackColor = false;
            this.btnPressSelection.Click += new System.EventHandler(this.btnPressSelection_Click);
            // 
            // lblYourSel
            // 
            this.lblYourSel.AutoSize = true;
            this.lblYourSel.Location = new System.Drawing.Point(97, 621);
            this.lblYourSel.Name = "lblYourSel";
            this.lblYourSel.Size = new System.Drawing.Size(151, 25);
            this.lblYourSel.TabIndex = 7;
            this.lblYourSel.Text = "Your selections:";
            // 
            // lblMarshmello
            // 
            this.lblMarshmello.AutoSize = true;
            this.lblMarshmello.Location = new System.Drawing.Point(160, 882);
            this.lblMarshmello.Name = "lblMarshmello";
            this.lblMarshmello.Size = new System.Drawing.Size(201, 25);
            this.lblMarshmello.TabIndex = 8;
            this.lblMarshmello.Text = "Marshmello selection:";
            // 
            // lblLollipop
            // 
            this.lblLollipop.AutoSize = true;
            this.lblLollipop.Location = new System.Drawing.Point(160, 788);
            this.lblLollipop.Name = "lblLollipop";
            this.lblLollipop.Size = new System.Drawing.Size(167, 25);
            this.lblLollipop.TabIndex = 9;
            this.lblLollipop.Text = "Lollipop selection:";
            this.lblLollipop.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblChocolate
            // 
            this.lblChocolate.AutoSize = true;
            this.lblChocolate.Location = new System.Drawing.Point(160, 685);
            this.lblChocolate.Name = "lblChocolate";
            this.lblChocolate.Size = new System.Drawing.Size(189, 25);
            this.lblChocolate.TabIndex = 10;
            this.lblChocolate.Text = "Chocolate selection:";
            // 
            // lblDisplayCho
            // 
            this.lblDisplayCho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDisplayCho.Location = new System.Drawing.Point(389, 682);
            this.lblDisplayCho.Name = "lblDisplayCho";
            this.lblDisplayCho.Size = new System.Drawing.Size(400, 30);
            this.lblDisplayCho.TabIndex = 11;
            this.lblDisplayCho.Text = "Nothing";
            this.lblDisplayCho.Click += new System.EventHandler(this.lblDisplayCho_Click);
            // 
            // lblDisplayLol
            // 
            this.lblDisplayLol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDisplayLol.Location = new System.Drawing.Point(389, 785);
            this.lblDisplayLol.Name = "lblDisplayLol";
            this.lblDisplayLol.Size = new System.Drawing.Size(400, 30);
            this.lblDisplayLol.TabIndex = 12;
            this.lblDisplayLol.Text = "Nothing";
            // 
            // lblDisplayMar
            // 
            this.lblDisplayMar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDisplayMar.Location = new System.Drawing.Point(389, 879);
            this.lblDisplayMar.Name = "lblDisplayMar";
            this.lblDisplayMar.Size = new System.Drawing.Size(400, 30);
            this.lblDisplayMar.TabIndex = 13;
            this.lblDisplayMar.Text = "Nothing";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(160, 984);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(94, 25);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Balance: ";
            // 
            // StoreMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1176, 1236);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDisplayMar);
            this.Controls.Add(this.lblDisplayLol);
            this.Controls.Add(this.lblDisplayCho);
            this.Controls.Add(this.lblChocolate);
            this.Controls.Add(this.lblLollipop);
            this.Controls.Add(this.lblMarshmello);
            this.Controls.Add(this.lblYourSel);
            this.Controls.Add(this.btnPressSelection);
            this.Controls.Add(this.cbbSelectCandy);
            this.Controls.Add(this.lblCandyOutput);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.lblSelceted);
            this.Controls.Add(this.lblCandyTyoe);
            this.Controls.Add(this.lblName);
            this.Name = "StoreMain";
            this.Text = "Welcome To Gate\'s Candy Store";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCandyTyoe;
        private System.Windows.Forms.Label lblSelceted;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label lblCandyOutput;
        private System.Windows.Forms.ComboBox cbbSelectCandy;
        private System.Windows.Forms.Button btnPressSelection;
        private System.Windows.Forms.Label lblYourSel;
        private System.Windows.Forms.Label lblMarshmello;
        private System.Windows.Forms.Label lblLollipop;
        private System.Windows.Forms.Label lblChocolate;
        private System.Windows.Forms.Label lblDisplayCho;
        private System.Windows.Forms.Label lblDisplayLol;
        private System.Windows.Forms.Label lblDisplayMar;
        private System.Windows.Forms.Label lblTotal;
    }
}

