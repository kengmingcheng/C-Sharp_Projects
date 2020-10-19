namespace Final_Project_KengMingCheng
{
    partial class Info
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSAddress = new System.Windows.Forms.Label();
            this.lblBAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCreditCard = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSAddress = new System.Windows.Forms.TextBox();
            this.txtBAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCreditCard = new System.Windows.Forms.TextBox();
            this.cbbCreditCard = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(229, 61);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(555, 64);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Edit Your Information";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(67, 207);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(153, 32);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Your name";
            // 
            // lblSAddress
            // 
            this.lblSAddress.AutoSize = true;
            this.lblSAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSAddress.Location = new System.Drawing.Point(67, 294);
            this.lblSAddress.Name = "lblSAddress";
            this.lblSAddress.Size = new System.Drawing.Size(239, 32);
            this.lblSAddress.TabIndex = 4;
            this.lblSAddress.Text = "Shipping Address";
            // 
            // lblBAddress
            // 
            this.lblBAddress.AutoSize = true;
            this.lblBAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBAddress.Location = new System.Drawing.Point(67, 380);
            this.lblBAddress.Name = "lblBAddress";
            this.lblBAddress.Size = new System.Drawing.Size(205, 32);
            this.lblBAddress.TabIndex = 5;
            this.lblBAddress.Text = "Billing Address";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(67, 471);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(201, 32);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone number";
            // 
            // lblCreditCard
            // 
            this.lblCreditCard.AutoSize = true;
            this.lblCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCard.Location = new System.Drawing.Point(67, 569);
            this.lblCreditCard.Name = "lblCreditCard";
            this.lblCreditCard.Size = new System.Drawing.Size(153, 32);
            this.lblCreditCard.TabIndex = 7;
            this.lblCreditCard.Text = "Credit card";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(685, 800);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(210, 50);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "&Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(319, 204);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(400, 39);
            this.txtName.TabIndex = 11;
            // 
            // txtSAddress
            // 
            this.txtSAddress.AllowDrop = true;
            this.txtSAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSAddress.Location = new System.Drawing.Point(319, 291);
            this.txtSAddress.Name = "txtSAddress";
            this.txtSAddress.Size = new System.Drawing.Size(600, 39);
            this.txtSAddress.TabIndex = 12;
            this.txtSAddress.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtSAddress_DragDrop);
            this.txtSAddress.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtSAddress_DragEnter);
            this.txtSAddress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSAddress_MouseDown);
            // 
            // txtBAddress
            // 
            this.txtBAddress.AllowDrop = true;
            this.txtBAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBAddress.Location = new System.Drawing.Point(319, 377);
            this.txtBAddress.Name = "txtBAddress";
            this.txtBAddress.Size = new System.Drawing.Size(600, 39);
            this.txtBAddress.TabIndex = 13;
            this.txtBAddress.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBAddress_DragDrop);
            this.txtBAddress.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBAddress_DragEnter);
            this.txtBAddress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBAddress_MouseDown);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(319, 468);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(400, 39);
            this.txtPhone.TabIndex = 14;
            // 
            // txtCreditCard
            // 
            this.txtCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditCard.Location = new System.Drawing.Point(541, 569);
            this.txtCreditCard.Name = "txtCreditCard";
            this.txtCreditCard.Size = new System.Drawing.Size(400, 39);
            this.txtCreditCard.TabIndex = 15;
            // 
            // cbbCreditCard
            // 
            this.cbbCreditCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCreditCard.FormattingEnabled = true;
            this.cbbCreditCard.Items.AddRange(new object[] {
            "MasterCard",
            "VISA",
            "JCB",
            "DISCOVER",
            "A.E."});
            this.cbbCreditCard.Location = new System.Drawing.Point(319, 568);
            this.cbbCreditCard.Name = "cbbCreditCard";
            this.cbbCreditCard.Size = new System.Drawing.Size(200, 40);
            this.cbbCreditCard.TabIndex = 16;
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 936);
            this.Controls.Add(this.cbbCreditCard);
            this.Controls.Add(this.txtCreditCard);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtBAddress);
            this.Controls.Add(this.txtSAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblCreditCard);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblBAddress);
            this.Controls.Add(this.lblSAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Name = "Info";
            this.Text = "Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSAddress;
        private System.Windows.Forms.Label lblBAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCreditCard;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSAddress;
        private System.Windows.Forms.TextBox txtBAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCreditCard;
        private System.Windows.Forms.ComboBox cbbCreditCard;
    }
}