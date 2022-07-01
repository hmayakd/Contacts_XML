namespace Contacts_XML
{
    partial class MainForm
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
            this.lblAge = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.tBAge = new System.Windows.Forms.TextBox();
            this.tBFirstName = new System.Windows.Forms.TextBox();
            this.tBLastName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dGVContacts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGVContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(61, 14);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 13);
            this.lblAge.TabIndex = 0;
            this.lblAge.Text = "AGE:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(18, 47);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(75, 13);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "FIRST NAME:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(22, 78);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(71, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "LAST NAME:";
            // 
            // tBAge
            // 
            this.tBAge.Location = new System.Drawing.Point(99, 11);
            this.tBAge.Name = "tBAge";
            this.tBAge.Size = new System.Drawing.Size(100, 20);
            this.tBAge.TabIndex = 3;
            // 
            // tBFirstName
            // 
            this.tBFirstName.Location = new System.Drawing.Point(99, 44);
            this.tBFirstName.Name = "tBFirstName";
            this.tBFirstName.Size = new System.Drawing.Size(100, 20);
            this.tBFirstName.TabIndex = 4;
            // 
            // tBLastName
            // 
            this.tBLastName.Location = new System.Drawing.Point(99, 75);
            this.tBLastName.Name = "tBLastName";
            this.tBLastName.Size = new System.Drawing.Size(100, 20);
            this.tBLastName.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(231, 9);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dGVContacts
            // 
            this.dGVContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVContacts.Location = new System.Drawing.Point(12, 111);
            this.dGVContacts.Name = "dGVContacts";
            this.dGVContacts.Size = new System.Drawing.Size(776, 327);
            this.dGVContacts.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dGVContacts);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tBLastName);
            this.Controls.Add(this.tBFirstName);
            this.Controls.Add(this.tBAge);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblAge);
            this.Name = "MainForm";
            this.Text = "Contacts";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox tBAge;
        private System.Windows.Forms.TextBox tBFirstName;
        private System.Windows.Forms.TextBox tBLastName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dGVContacts;
    }
}

