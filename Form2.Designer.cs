namespace FinalLFA
{
    partial class Form2
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
            this.BtnViewTree = new System.Windows.Forms.Button();
            this.BtnCompile = new System.Windows.Forms.Button();
            this.BtnReturn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Símbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nullable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Simbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Follow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CodeBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.Expr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnViewTree
            // 
            this.BtnViewTree.Location = new System.Drawing.Point(1651, 178);
            this.BtnViewTree.Name = "BtnViewTree";
            this.BtnViewTree.Size = new System.Drawing.Size(119, 29);
            this.BtnViewTree.TabIndex = 0;
            this.BtnViewTree.Text = "Visualizar árbol";
            this.BtnViewTree.UseVisualStyleBackColor = true;
            this.BtnViewTree.Click += new System.EventHandler(this.BtnViewTree_Click);
            // 
            // BtnCompile
            // 
            this.BtnCompile.Location = new System.Drawing.Point(1651, 246);
            this.BtnCompile.Name = "BtnCompile";
            this.BtnCompile.Size = new System.Drawing.Size(119, 45);
            this.BtnCompile.TabIndex = 1;
            this.BtnCompile.Text = "Compilar validador";
            this.BtnCompile.UseVisualStyleBackColor = true;
            this.BtnCompile.Click += new System.EventHandler(this.BtnCompile_Click);
            // 
            // BtnReturn
            // 
            this.BtnReturn.Location = new System.Drawing.Point(1651, 332);
            this.BtnReturn.Name = "BtnReturn";
            this.BtnReturn.Size = new System.Drawing.Size(119, 29);
            this.BtnReturn.TabIndex = 2;
            this.BtnReturn.Text = "Regresar";
            this.BtnReturn.UseVisualStyleBackColor = true;
            this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Símbolo,
            this.First,
            this.Last,
            this.Nullable});
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(603, 501);
            this.dataGridView1.TabIndex = 3;
            // 
            // Símbolo
            // 
            this.Símbolo.HeaderText = "Símbolo";
            this.Símbolo.MinimumWidth = 6;
            this.Símbolo.Name = "Símbolo";
            this.Símbolo.Width = 125;
            // 
            // First
            // 
            this.First.HeaderText = "First";
            this.First.MinimumWidth = 6;
            this.First.Name = "First";
            this.First.Width = 125;
            // 
            // Last
            // 
            this.Last.HeaderText = "Last";
            this.Last.MinimumWidth = 6;
            this.Last.Name = "Last";
            this.Last.Width = 125;
            // 
            // Nullable
            // 
            this.Nullable.HeaderText = "Nullable";
            this.Nullable.MinimumWidth = 6;
            this.Nullable.Name = "Nullable";
            this.Nullable.Width = 125;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Simbolo,
            this.Follow});
            this.dataGridView2.Location = new System.Drawing.Point(638, 90);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(328, 501);
            this.dataGridView2.TabIndex = 4;
            // 
            // Simbolo
            // 
            this.Simbolo.HeaderText = "Símbolo";
            this.Simbolo.MinimumWidth = 6;
            this.Simbolo.Name = "Simbolo";
            this.Simbolo.Width = 125;
            // 
            // Follow
            // 
            this.Follow.HeaderText = "Follow";
            this.Follow.MinimumWidth = 6;
            this.Follow.Name = "Follow";
            this.Follow.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tabla de first, last y nulabilidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tabla de follows";
            // 
            // CodeBox
            // 
            this.CodeBox.FormattingEnabled = true;
            this.CodeBox.ItemHeight = 16;
            this.CodeBox.Location = new System.Drawing.Point(985, 90);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(651, 948);
            this.CodeBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(982, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Código a compilar";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(15, 658);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(951, 385);
            this.dataGridView3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 638);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tabla de transiciones";
            // 
            // Expr
            // 
            this.Expr.AutoSize = true;
            this.Expr.Location = new System.Drawing.Point(15, 13);
            this.Expr.Name = "Expr";
            this.Expr.Size = new System.Drawing.Size(0, 17);
            this.Expr.TabIndex = 11;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 1055);
            this.Controls.Add(this.Expr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CodeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnReturn);
            this.Controls.Add(this.BtnCompile);
            this.Controls.Add(this.BtnViewTree);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnViewTree;
        private System.Windows.Forms.Button BtnCompile;
        private System.Windows.Forms.Button BtnReturn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Símbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn First;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nullable;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Follow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox CodeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Expr;
    }
}