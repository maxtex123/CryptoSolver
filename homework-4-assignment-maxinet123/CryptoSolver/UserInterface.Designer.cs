namespace CryptoSolver
{
    partial class UserInterface
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
            this.uxMessageLbl = new System.Windows.Forms.Label();
            this.uxMessage = new System.Windows.Forms.TextBox();
            this.uxResult = new System.Windows.Forms.TextBox();
            this.uxEncrypt = new System.Windows.Forms.Button();
            this.uxDecrypt = new System.Windows.Forms.Button();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxMessageLbl
            // 
            this.uxMessageLbl.AutoSize = true;
            this.uxMessageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxMessageLbl.Location = new System.Drawing.Point(12, 9);
            this.uxMessageLbl.Name = "uxMessageLbl";
            this.uxMessageLbl.Size = new System.Drawing.Size(154, 37);
            this.uxMessageLbl.TabIndex = 0;
            this.uxMessageLbl.Text = "Message:";
            // 
            // uxMessage
            // 
            this.uxMessage.Location = new System.Drawing.Point(19, 49);
            this.uxMessage.Multiline = true;
            this.uxMessage.Name = "uxMessage";
            this.uxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxMessage.Size = new System.Drawing.Size(652, 214);
            this.uxMessage.TabIndex = 1;
            // 
            // uxResult
            // 
            this.uxResult.Location = new System.Drawing.Point(19, 359);
            this.uxResult.Multiline = true;
            this.uxResult.Name = "uxResult";
            this.uxResult.ReadOnly = true;
            this.uxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxResult.Size = new System.Drawing.Size(652, 231);
            this.uxResult.TabIndex = 2;
            // 
            // uxEncrypt
            // 
            this.uxEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxEncrypt.Location = new System.Drawing.Point(80, 280);
            this.uxEncrypt.Name = "uxEncrypt";
            this.uxEncrypt.Size = new System.Drawing.Size(204, 61);
            this.uxEncrypt.TabIndex = 3;
            this.uxEncrypt.Text = "Encrypt";
            this.uxEncrypt.UseVisualStyleBackColor = true;
            this.uxEncrypt.Click += new System.EventHandler(this.UxEncrypt_Click);
            // 
            // uxDecrypt
            // 
            this.uxDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxDecrypt.Location = new System.Drawing.Point(392, 280);
            this.uxDecrypt.Name = "uxDecrypt";
            this.uxDecrypt.Size = new System.Drawing.Size(204, 61);
            this.uxDecrypt.TabIndex = 4;
            this.uxDecrypt.Text = "Decrypt";
            this.uxDecrypt.UseVisualStyleBackColor = true;
            this.uxDecrypt.Click += new System.EventHandler(this.UxDecrypt_Click);
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.FileName = "openFileDialog1";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 614);
            this.Controls.Add(this.uxDecrypt);
            this.Controls.Add(this.uxEncrypt);
            this.Controls.Add(this.uxResult);
            this.Controls.Add(this.uxMessage);
            this.Controls.Add(this.uxMessageLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Crypto Solver";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxMessageLbl;
        private System.Windows.Forms.TextBox uxMessage;
        private System.Windows.Forms.TextBox uxResult;
        private System.Windows.Forms.Button uxEncrypt;
        private System.Windows.Forms.Button uxDecrypt;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}

