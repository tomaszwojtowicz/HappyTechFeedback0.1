namespace HappyTechFeedback
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
            this.headerGroupBox = new System.Windows.Forms.GroupBox();
            this.templateEditGroupBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // headerGroupBox
            // 
            this.headerGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerGroupBox.Location = new System.Drawing.Point(12, 12);
            this.headerGroupBox.Name = "headerGroupBox";
            this.headerGroupBox.Size = new System.Drawing.Size(938, 100);
            this.headerGroupBox.TabIndex = 0;
            this.headerGroupBox.TabStop = false;
            this.headerGroupBox.Text = "Header: To be filled by Alessio";
            // 
            // templateEditGroupBox
            // 
            this.templateEditGroupBox.AutoSize = true;
            this.templateEditGroupBox.Location = new System.Drawing.Point(13, 119);
            this.templateEditGroupBox.Name = "templateEditGroupBox";
            this.templateEditGroupBox.Size = new System.Drawing.Size(937, 554);
            this.templateEditGroupBox.TabIndex = 6;
            this.templateEditGroupBox.TabStop = false;
            this.templateEditGroupBox.Text = "templateEditinGroupBox";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(991, 873);
            this.Controls.Add(this.templateEditGroupBox);
            this.Controls.Add(this.headerGroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox headerGroupBox;
        private System.Windows.Forms.GroupBox templateEditGroupBox;
    }
}

