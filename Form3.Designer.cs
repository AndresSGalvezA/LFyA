namespace FinalLFA
{
    partial class Form3
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
            this.BtnReturn = new System.Windows.Forms.Button();
            this.Area = new System.Windows.Forms.Panel();
            this.BtnView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnReturn
            // 
            this.BtnReturn.Location = new System.Drawing.Point(1832, 87);
            this.BtnReturn.Name = "BtnReturn";
            this.BtnReturn.Size = new System.Drawing.Size(80, 79);
            this.BtnReturn.TabIndex = 0;
            this.BtnReturn.Text = "Regresar al módulo de carga";
            this.BtnReturn.UseVisualStyleBackColor = true;
            this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // Area
            // 
            this.Area.Location = new System.Drawing.Point(-400, 13);
            this.Area.Name = "Area";
            this.Area.Size = new System.Drawing.Size(2207, 962);
            this.Area.TabIndex = 1;
            // 
            // BtnView
            // 
            this.BtnView.Location = new System.Drawing.Point(1832, 33);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(80, 23);
            this.BtnView.TabIndex = 2;
            this.BtnView.Text = "Ver";
            this.BtnView.UseVisualStyleBackColor = true;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 987);
            this.Controls.Add(this.BtnView);
            this.Controls.Add(this.Area);
            this.Controls.Add(this.BtnReturn);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Area;
        private System.Windows.Forms.Button BtnReturn;
        private System.Windows.Forms.Button BtnView;
    }
}