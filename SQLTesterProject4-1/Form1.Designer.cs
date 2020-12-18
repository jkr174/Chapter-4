namespace SQLTesterProject4_1
{
    partial class frmBooks
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
            this.btnAll = new System.Windows.Forms.Button();
            this.grdBooks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(422, 258);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(159, 23);
            this.btnAll.TabIndex = 3;
            this.btnAll.TabStop = false;
            this.btnAll.Text = "Show All Records";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // grdBooks
            // 
            this.grdBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBooks.Location = new System.Drawing.Point(12, 12);
            this.grdBooks.Name = "grdBooks";
            this.grdBooks.Size = new System.Drawing.Size(569, 186);
            this.grdBooks.TabIndex = 4;
            this.grdBooks.TabStop = false;
            this.grdBooks.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grdSQLTester_ColumnAdded);
            // 
            // frmBooks
            // 
            this.AcceptButton = this.btnAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 293);
            this.Controls.Add(this.grdBooks);
            this.Controls.Add(this.btnAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Books Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSQLTester_FormClosing);
            this.Load += new System.EventHandler(this.frmSQLTester_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DataGridView grdBooks;
    }
}

