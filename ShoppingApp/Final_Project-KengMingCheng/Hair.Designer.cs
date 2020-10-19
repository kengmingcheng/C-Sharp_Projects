namespace Final_Project_KengMingCheng
{
    partial class Hair
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
            this.lblTitle.Location = new System.Drawing.Point(247, 67);
            this.lblTitle.Size = new System.Drawing.Size(320, 64);
            this.lblTitle.Text = "Hair Design";
            // 
            // lblOP1
            // 
            this.lblOP1.Size = new System.Drawing.Size(126, 32);
            this.lblOP1.Text = "Hairstyle";
            // 
            // lblOP3
            // 
            this.lblOP3.Size = new System.Drawing.Size(142, 32);
            this.lblOP3.Text = "Hair Color";
            // 
            // lblOP2
            // 
            this.lblOP2.Size = new System.Drawing.Size(105, 32);
            this.lblOP2.Text = "Haircut";
            // 
            // cbbOP2
            // 
            this.cbbOP2.Items.AddRange(new object[] {
            "Long Straight",
            "Long Wevy",
            "Med Curly"});
            // 
            // cbbOP3
            // 
            this.cbbOP3.Items.AddRange(new object[] {
            "Brown",
            "Black",
            "Blond",
            "Red"});
            this.cbbOP3.SelectedIndexChanged += new System.EventHandler(this.cbbOP3_SelectedIndexChanged);
            // 
            // cbbOP1
            // 
            this.cbbOP1.Items.AddRange(new object[] {
            "Headband",
            "Double Braids"});
            this.cbbOP1.SelectedIndexChanged += new System.EventHandler(this.cbbOP1_SelectedIndexChanged);
            // 
            // Hair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.ClientSize = new System.Drawing.Size(776, 736);
            this.Name = "Hair";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
