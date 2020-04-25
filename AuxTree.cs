using System.Drawing;

namespace FinalLFA
{
    public class Figure
    {
        private Color Color;
        private Point Pos;
        private string Symbol;

        public Figure(string chain, int PX, int PY)
        {
            Symbol = chain;
            Color = Color.Coral;
            Pos = new Point(PX, PY);
        }

        public void Create(Graphics Fig)
        {
            Brush CS = new SolidBrush(Color.Black);
            Brush C = new SolidBrush(Color);
            Font font = new Font("Arial", 10, FontStyle.Bold);
            RectangleF RF = new RectangleF(Pos.X, Pos.Y, 40, 20);
            Fig.FillEllipse(C, RF);
            Fig.DrawString(Symbol, font, CS, Pos.X + 10, Pos.Y + 3);
        }
    }
    
    public class Union
    {
        static Point PosI = new Point();
        static Point PosF = new Point();
        Color Color;

        public Union(int PosXI, int PosYI, int PosXF, int PosYF)
        {
            PosI.X = PosXI;
            PosI.Y = PosYI;
            PosF.X = PosXF;
            PosF.Y = PosYF;
            Color = Color.Black;
        }

        public void Create(Graphics Line)
        {
            Pen pen = new Pen(Color);
            Line.DrawLine(pen, PosI.X, PosI.Y, PosF.X, PosF.Y);
        }
    }
    
    public class AuxTree
    {
    }
}