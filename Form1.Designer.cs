namespace FinalLFA
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnLoadFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnLoadFile
            // 
            this.BtnLoadFile.Location = new System.Drawing.Point(74, 59);
            this.BtnLoadFile.Name = "BtnLoadFile";
            this.BtnLoadFile.Size = new System.Drawing.Size(183, 49);
            this.BtnLoadFile.TabIndex = 0;
            this.BtnLoadFile.Text = "Cargar archivo";
            this.BtnLoadFile.UseVisualStyleBackColor = true;
            this.BtnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 176);
            this.Controls.Add(this.BtnLoadFile);
            this.Name = "Form1";
            this.Text = "Carga de archivo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadFile;
    }
}

