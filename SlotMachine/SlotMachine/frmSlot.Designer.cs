
namespace SlotMachine
{
    partial class frmSlot
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
            this.lblSlot1 = new System.Windows.Forms.Label();
            this.tmrSlot1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblSlot1
            // 
            this.lblSlot1.AutoSize = true;
            this.lblSlot1.Location = new System.Drawing.Point(193, 156);
            this.lblSlot1.Name = "lblSlot1";
            this.lblSlot1.Size = new System.Drawing.Size(13, 13);
            this.lblSlot1.TabIndex = 0;
            this.lblSlot1.Text = "1";
            this.lblSlot1.Click += new System.EventHandler(this.lblSlot1_Click);
            // 
            // tmrSlot1
            // 
            this.tmrSlot1.Tick += new System.EventHandler(this.tmrSlot1_Tick);
            // 
            // frmSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSlot1);
            this.Name = "frmSlot";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSlot1;
        private System.Windows.Forms.Timer tmrSlot1;
    }
}

