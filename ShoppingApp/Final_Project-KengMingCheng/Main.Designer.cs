namespace Final_Project_KengMingCheng
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.designToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hairStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facialFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outfitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.cbbGender = new System.Windows.Forms.ComboBox();
            this.btnHair = new System.Windows.Forms.Button();
            this.btnFace = new System.Windows.Forms.Button();
            this.btnOutfits = new System.Windows.Forms.Button();
            this.lblOutcome = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            this.lblBar = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dollServiceDataSet = new Final_Project_KengMingCheng.DollServiceDataSet();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customersTableAdapter = new Final_Project_KengMingCheng.DollServiceDataSetTableAdapters.CustomersTableAdapter();
            this.btnCart = new System.Windows.Forms.Button();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dollServiceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.designToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1,
            this.ordersToolStripMenuItem,
            this.exitToolStripMenuItem2});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(56, 34);
            this.exitToolStripMenuItem.Text = "File";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(202, 34);
            this.exitToolStripMenuItem1.Text = "Customers";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(202, 34);
            this.ordersToolStripMenuItem.Text = "Orders";
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(202, 34);
            this.exitToolStripMenuItem2.Text = "E&xit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem2_Click);
            // 
            // designToolStripMenuItem
            // 
            this.designToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hairStyleToolStripMenuItem,
            this.facialFeaturesToolStripMenuItem,
            this.outfitsToolStripMenuItem});
            this.designToolStripMenuItem.Name = "designToolStripMenuItem";
            this.designToolStripMenuItem.Size = new System.Drawing.Size(89, 34);
            this.designToolStripMenuItem.Text = "Design";
            // 
            // hairStyleToolStripMenuItem
            // 
            this.hairStyleToolStripMenuItem.Name = "hairStyleToolStripMenuItem";
            this.hairStyleToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.hairStyleToolStripMenuItem.Text = "Hair style";
            this.hairStyleToolStripMenuItem.Click += new System.EventHandler(this.hairStyleToolStripMenuItem_Click);
            // 
            // facialFeaturesToolStripMenuItem
            // 
            this.facialFeaturesToolStripMenuItem.Name = "facialFeaturesToolStripMenuItem";
            this.facialFeaturesToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.facialFeaturesToolStripMenuItem.Text = "Facial features";
            this.facialFeaturesToolStripMenuItem.Click += new System.EventHandler(this.facialFeaturesToolStripMenuItem_Click);
            // 
            // outfitsToolStripMenuItem
            // 
            this.outfitsToolStripMenuItem.Name = "outfitsToolStripMenuItem";
            this.outfitsToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.outfitsToolStripMenuItem.Text = "Outfits";
            this.outfitsToolStripMenuItem.Click += new System.EventHandler(this.outfitsToolStripMenuItem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(313, 78);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(571, 64);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Create Your Own Doll";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(100, 311);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(163, 32);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "You want a ";
            // 
            // cbbGender
            // 
            this.cbbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbGender.FormattingEnabled = true;
            this.cbbGender.Items.AddRange(new object[] {
            "Girl",
            "Boy"});
            this.cbbGender.Location = new System.Drawing.Point(269, 303);
            this.cbbGender.Name = "cbbGender";
            this.cbbGender.Size = new System.Drawing.Size(121, 40);
            this.cbbGender.TabIndex = 3;
            this.cbbGender.SelectedIndexChanged += new System.EventHandler(this.cbbGender_SelectedIndexChanged);
            // 
            // btnHair
            // 
            this.btnHair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHair.Location = new System.Drawing.Point(269, 369);
            this.btnHair.Name = "btnHair";
            this.btnHair.Size = new System.Drawing.Size(210, 50);
            this.btnHair.TabIndex = 4;
            this.btnHair.Text = "&Hair design";
            this.btnHair.UseVisualStyleBackColor = true;
            this.btnHair.Click += new System.EventHandler(this.btnHair_Click);
            // 
            // btnFace
            // 
            this.btnFace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFace.Location = new System.Drawing.Point(545, 369);
            this.btnFace.Name = "btnFace";
            this.btnFace.Size = new System.Drawing.Size(210, 50);
            this.btnFace.TabIndex = 5;
            this.btnFace.Text = "&Facial features";
            this.btnFace.UseVisualStyleBackColor = true;
            this.btnFace.Click += new System.EventHandler(this.btnFace_Click);
            // 
            // btnOutfits
            // 
            this.btnOutfits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutfits.Location = new System.Drawing.Point(815, 369);
            this.btnOutfits.Name = "btnOutfits";
            this.btnOutfits.Size = new System.Drawing.Size(210, 50);
            this.btnOutfits.TabIndex = 6;
            this.btnOutfits.Text = "&Outfits";
            this.btnOutfits.UseVisualStyleBackColor = true;
            this.btnOutfits.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblOutcome
            // 
            this.lblOutcome.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOutcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutcome.Location = new System.Drawing.Point(106, 464);
            this.lblOutcome.Name = "lblOutcome";
            this.lblOutcome.Size = new System.Drawing.Size(600, 120);
            this.lblOutcome.TabIndex = 7;
            this.lblOutcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(815, 534);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(210, 50);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "&Add to bag";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(652, 657);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(210, 50);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "&Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(911, 657);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(210, 50);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblInformation
            // 
            this.lblInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.Location = new System.Drawing.Point(100, 181);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(800, 80);
            this.lblInformation.TabIndex = 11;
            this.lblInformation.Text = "No Customer Information";
            // 
            // lblBar
            // 
            this.lblBar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblBar.Location = new System.Drawing.Point(92, 261);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(1000, 23);
            this.lblBar.TabIndex = 12;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(971, 181);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 50);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "&Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dollServiceDataSet
            // 
            this.dollServiceDataSet.DataSetName = "DollServiceDataSet";
            this.dollServiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember = "Customers";
            this.customersBindingSource.DataSource = this.dollServiceDataSet;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // btnCart
            // 
            this.btnCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.Location = new System.Drawing.Point(97, 657);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(160, 50);
            this.btnCart.TabIndex = 14;
            this.btnCart.Text = "Car&t";
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(62, 34);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.informationToolStripMenuItem.Text = "About";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 736);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblBar);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblOutcome);
            this.Controls.Add(this.btnOutfits);
            this.Controls.Add(this.btnFace);
            this.Controls.Add(this.btnHair);
            this.Controls.Add(this.cbbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Beautiful Dolls";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dollServiceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cbbGender;
        private System.Windows.Forms.Button btnHair;
        private System.Windows.Forms.Button btnFace;
        private System.Windows.Forms.Button btnOutfits;
        private System.Windows.Forms.Label lblOutcome;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripMenuItem designToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hairStyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facialFeaturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outfitsToolStripMenuItem;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Label lblBar;
        private System.Windows.Forms.Button btnEdit;
        private DollServiceDataSet dollServiceDataSet;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private DollServiceDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
    }
}

