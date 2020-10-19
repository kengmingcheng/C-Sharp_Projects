namespace Final_Project_KengMingCheng
{
    partial class BaseForm
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
            this.lblOP1 = new System.Windows.Forms.Label();
            this.lblOP3 = new System.Windows.Forms.Label();
            this.lblOP2 = new System.Windows.Forms.Label();
            this.cbbOP1 = new System.Windows.Forms.ComboBox();
            this.cbbOP2 = new System.Windows.Forms.ComboBox();
            this.cbbOP3 = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(318, 72);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(135, 64);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOP1
            // 
            this.lblOP1.AutoSize = true;
            this.lblOP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOP1.Location = new System.Drawing.Point(101, 207);
            this.lblOP1.Name = "lblOP1";
            this.lblOP1.Size = new System.Drawing.Size(123, 32);
            this.lblOP1.TabIndex = 3;
            this.lblOP1.Text = "Option 1";
            // 
            // lblOP3
            // 
            this.lblOP3.AutoSize = true;
            this.lblOP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOP3.Location = new System.Drawing.Point(101, 416);
            this.lblOP3.Name = "lblOP3";
            this.lblOP3.Size = new System.Drawing.Size(123, 32);
            this.lblOP3.TabIndex = 4;
            this.lblOP3.Text = "Option 3";
            // 
            // lblOP2
            // 
            this.lblOP2.AutoSize = true;
            this.lblOP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOP2.Location = new System.Drawing.Point(101, 313);
            this.lblOP2.Name = "lblOP2";
            this.lblOP2.Size = new System.Drawing.Size(123, 32);
            this.lblOP2.TabIndex = 5;
            this.lblOP2.Text = "Option 2";
            // 
            // cbbOP1
            // 
            this.cbbOP1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOP1.FormattingEnabled = true;
            this.cbbOP1.Location = new System.Drawing.Point(298, 199);
            this.cbbOP1.Name = "cbbOP1";
            this.cbbOP1.Size = new System.Drawing.Size(400, 40);
            this.cbbOP1.TabIndex = 6;
            this.cbbOP1.SelectedIndexChanged += new System.EventHandler(this.cbbOP1_SelectedIndexChanged);
            // 
            // cbbOP2
            // 
            this.cbbOP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOP2.FormattingEnabled = true;
            this.cbbOP2.Location = new System.Drawing.Point(298, 305);
            this.cbbOP2.Name = "cbbOP2";
            this.cbbOP2.Size = new System.Drawing.Size(400, 40);
            this.cbbOP2.TabIndex = 7;
            // 
            // cbbOP3
            // 
            this.cbbOP3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOP3.FormattingEnabled = true;
            this.cbbOP3.Location = new System.Drawing.Point(298, 408);
            this.cbbOP3.Name = "cbbOP3";
            this.cbbOP3.Size = new System.Drawing.Size(400, 40);
            this.cbbOP3.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(298, 625);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(210, 50);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(545, 625);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(210, 50);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 736);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbbOP3);
            this.Controls.Add(this.cbbOP2);
            this.Controls.Add(this.cbbOP1);
            this.Controls.Add(this.lblOP2);
            this.Controls.Add(this.lblOP3);
            this.Controls.Add(this.lblOP1);
            this.Controls.Add(this.lblTitle);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.Label lblOP1;
        protected System.Windows.Forms.Label lblOP3;
        protected System.Windows.Forms.Label lblOP2;
        protected System.Windows.Forms.ComboBox cbbOP2;
        protected System.Windows.Forms.ComboBox cbbOP3;
        protected System.Windows.Forms.ComboBox cbbOP1;
    }
}