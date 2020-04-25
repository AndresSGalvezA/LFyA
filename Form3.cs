using System;
using System.Windows.Forms;

namespace FinalLFA
{
    public partial class Form3 : Form
    {
        Node Exp = default;

        public Form3(Node exp)
        {
            InitializeComponent();
            Exp = exp;
        }

        private void Tree(Node root, int posX, int posY, int separator)
        {
            if (root != null)
            {
                Figure Circle = new Figure(root.element.Character, posX, posY);
                Circle.Create(Area.CreateGraphics());
                
                if (root.RightNode != null)
                {
                    Union union = new Union(posX + 15, posY + 15, posX + separator + 15, posY + 65);
                    union.Create(Area.CreateGraphics());
                    Tree(root.RightNode, (posX + separator), (posY + 50), Convert.ToInt32(separator / 1.5));
                }
                if (root.LeftNode != null)
                {
                    Union union = new Union(posX + 15, posY + 15, posX - separator + 15, posY + 65);
                    union.Create(Area.CreateGraphics());
                    Tree(root.LeftNode, (posX - separator), (posY + 50), Convert.ToInt32(separator / 1.3));
                }
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            var F1 = new Form1();
            F1.Show();
            Visible = false;
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            Area.Refresh();
            Tree(Exp, this.Width - 350, 80, 250);
        }
    }
}