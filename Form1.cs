using System;
using System.Windows.Forms;

namespace FinalLFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            var File = file.FileName;
            
            if (File != string.Empty)
            {
                if (File[File.Length - 1] == 't' && File[File.Length - 2] == 'x' && File[File.Length - 3] == 't' && File[File.Length - 4] == '.')
                {
                    var F2 = new Form2(File);
                    F2.Show();
                    Visible = false;
                }
                else MessageBox.Show("Archivo inválido.");
            }
        }
    }
}