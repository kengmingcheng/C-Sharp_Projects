namespace Final_Project_KengMingCheng
{
    partial class Face
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
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(216, 72);
            this.lblTitle.Size = new System.Drawing.Size(414, 64);
            this.lblTitle.Text = "Facial Features";
            // 
            // lblOP1
            // 
            this.lblOP1.Size = new System.Drawing.Size(133, 32);
            this.lblOP1.Text = "Eye color";
            // 
            // lblOP3
            // 
            this.lblOP3.Size = new System.Drawing.Size(103, 32);
            this.lblOP3.Text = "Braces";
            // 
            // lblOP2
            // 
            this.lblOP2.Size = new System.Drawing.Size(122, 32);
            this.lblOP2.Text = "Freckles";
            // 
            // cbbOP2
            // 
            this.cbbOP2.Items.AddRange(new object[] {
            "Freckles",
            "No freckle"});
            // 
            // cbbOP3
            // 
            this.cbbOP3.Items.AddRange(new object[] {
            "Braces",
            "No brace"});
            this.cbbOP3.SelectedIndexChanged += new System.EventHandler(this.cbbOP3_SelectedIndexChanged);
            // 
            // cbbOP1
            // 
            this.cbbOP1.Items.AddRange(new object[] {
            "Blue",
            "Brown",
            "Green"});
            // 
            // Face
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.ClientSize = new System.Drawing.Size(776, 736);
            this.Name = "Face";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
