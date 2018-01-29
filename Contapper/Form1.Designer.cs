namespace Contapper
{
    partial class Form1
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
            this.companiesDataGrid = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.InterestedBox = new System.Windows.Forms.CheckBox();
            this.NotInterestedBox = new System.Windows.Forms.CheckBox();
            this.InderterminateBox = new System.Windows.Forms.CheckBox();
            this.CompensationBox = new System.Windows.Forms.CheckBox();
            this.BlockBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.companiesDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // companiesDataGrid
            // 
            this.companiesDataGrid.AllowUserToAddRows = false;
            this.companiesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companiesDataGrid.Location = new System.Drawing.Point(42, 74);
            this.companiesDataGrid.Name = "companiesDataGrid";
            this.companiesDataGrid.Size = new System.Drawing.Size(818, 365);
            this.companiesDataGrid.TabIndex = 0;
            this.companiesDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.companiesDataGrid_CellClick);
            this.companiesDataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.companiesDataGrid_CellFormatting);
            this.companiesDataGrid.SelectionChanged += new System.EventHandler(this.companiesDataGrid_SelectionChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(72, 452);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(174, 452);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Izmeni";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(275, 452);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Obrisi";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(42, 33);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(207, 20);
            this.searchBox.TabIndex = 4;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(275, 31);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Pretrazi";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // InterestedBox
            // 
            this.InterestedBox.AutoSize = true;
            this.InterestedBox.Location = new System.Drawing.Point(356, 35);
            this.InterestedBox.Name = "InterestedBox";
            this.InterestedBox.Size = new System.Drawing.Size(96, 17);
            this.InterestedBox.TabIndex = 6;
            this.InterestedBox.Text = "Zainteresovani";
            this.InterestedBox.UseVisualStyleBackColor = true;
            this.InterestedBox.CheckedChanged += new System.EventHandler(this.InterestedBox_CheckedChanged);
            // 
            // NotInterestedBox
            // 
            this.NotInterestedBox.AutoSize = true;
            this.NotInterestedBox.Location = new System.Drawing.Point(458, 35);
            this.NotInterestedBox.Name = "NotInterestedBox";
            this.NotInterestedBox.Size = new System.Drawing.Size(108, 17);
            this.NotInterestedBox.TabIndex = 7;
            this.NotInterestedBox.Text = "Nezainteresovani";
            this.NotInterestedBox.UseVisualStyleBackColor = true;
            // 
            // InderterminateBox
            // 
            this.InderterminateBox.AutoSize = true;
            this.InderterminateBox.Location = new System.Drawing.Point(572, 35);
            this.InderterminateBox.Name = "InderterminateBox";
            this.InderterminateBox.Size = new System.Drawing.Size(83, 17);
            this.InderterminateBox.TabIndex = 8;
            this.InderterminateBox.Text = "Neodredjeni";
            this.InderterminateBox.UseVisualStyleBackColor = true;
            // 
            // CompensationBox
            // 
            this.CompensationBox.AutoSize = true;
            this.CompensationBox.Location = new System.Drawing.Point(661, 35);
            this.CompensationBox.Name = "CompensationBox";
            this.CompensationBox.Size = new System.Drawing.Size(92, 17);
            this.CompensationBox.TabIndex = 9;
            this.CompensationBox.Text = "Kompenzacija";
            this.CompensationBox.UseVisualStyleBackColor = true;
            // 
            // BlockBox
            // 
            this.BlockBox.AutoSize = true;
            this.BlockBox.Location = new System.Drawing.Point(759, 35);
            this.BlockBox.Name = "BlockBox";
            this.BlockBox.Size = new System.Drawing.Size(47, 17);
            this.BlockBox.TabIndex = 10;
            this.BlockBox.Text = "Blok";
            this.BlockBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 487);
            this.Controls.Add(this.BlockBox);
            this.Controls.Add(this.CompensationBox);
            this.Controls.Add(this.InderterminateBox);
            this.Controls.Add(this.NotInterestedBox);
            this.Controls.Add(this.InterestedBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.companiesDataGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companiesDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView companiesDataGrid;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.CheckBox InterestedBox;
        private System.Windows.Forms.CheckBox NotInterestedBox;
        private System.Windows.Forms.CheckBox InderterminateBox;
        private System.Windows.Forms.CheckBox CompensationBox;
        private System.Windows.Forms.CheckBox BlockBox;
    }
}

