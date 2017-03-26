namespace Resource
{
    partial class Child
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtChinese = new System.Windows.Forms.TextBox();
            this.lbChinese = new System.Windows.Forms.Label();
            this.txtEnglish = new System.Windows.Forms.TextBox();
            this.lbEnglish = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "关键字";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(162, 69);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(486, 21);
            this.txtKey.TabIndex = 1;
            // 
            // txtChinese
            // 
            this.txtChinese.Location = new System.Drawing.Point(162, 163);
            this.txtChinese.Name = "txtChinese";
            this.txtChinese.Size = new System.Drawing.Size(486, 21);
            this.txtChinese.TabIndex = 3;
            // 
            // lbChinese
            // 
            this.lbChinese.AutoSize = true;
            this.lbChinese.Location = new System.Drawing.Point(48, 172);
            this.lbChinese.Name = "lbChinese";
            this.lbChinese.Size = new System.Drawing.Size(29, 12);
            this.lbChinese.TabIndex = 2;
            this.lbChinese.Text = "中文";
            // 
            // txtEnglish
            // 
            this.txtEnglish.Location = new System.Drawing.Point(162, 271);
            this.txtEnglish.Name = "txtEnglish";
            this.txtEnglish.Size = new System.Drawing.Size(486, 21);
            this.txtEnglish.TabIndex = 5;
            // 
            // lbEnglish
            // 
            this.lbEnglish.AutoSize = true;
            this.lbEnglish.Location = new System.Drawing.Point(48, 274);
            this.lbEnglish.Name = "lbEnglish";
            this.lbEnglish.Size = new System.Drawing.Size(29, 12);
            this.lbEnglish.TabIndex = 4;
            this.lbEnglish.Text = "英文";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(573, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(492, 345);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "保存";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // Child
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 407);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtEnglish);
            this.Controls.Add(this.lbEnglish);
            this.Controls.Add(this.txtChinese);
            this.Controls.Add(this.lbChinese);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Child";
            this.Text = "明细";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtChinese;
        private System.Windows.Forms.Label lbChinese;
        private System.Windows.Forms.TextBox txtEnglish;
        private System.Windows.Forms.Label lbEnglish;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}