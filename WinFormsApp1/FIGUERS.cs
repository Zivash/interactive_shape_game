using System.Drawing;

namespace FIGURES
{
    using System;
    using System.Collections;

    public enum FIG { Circle, Parallelogram, Rectangle, Square }

    public abstract class Figure
    {
        float x;
        float y;
        Color clr, changeClr;
        bool isHighlighted;
        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Color color
        {
            get
            {
                return clr;
            }
            set
            {
                clr = value;
            }
        }
        public Color ChangeColor
        {
            get
            {
                return changeClr;
            }
            set
            {
                changeClr = value;
            }
        }
        public bool IsHighlighted
        {
            get
            {
                return isHighlighted;
            }
            set
            {
                isHighlighted = value;
            }
        }
        public abstract void Draw(Graphics g);
        public abstract bool isInside(int xP, int yP);
        public Color RandomColor()
        {
            Random rnd = new Random();
            Color c = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            return c;
        }
        public void SwitchHighlight()
        {
            Color tmp = color;
            color = changeClr;
            changeClr = tmp;
            isHighlighted = (isHighlighted) ? false : true;
        }
    }

    public class myCircle : Figure
    {
        float radius;
        public myCircle()
            : this(10, 10, 5)
        { }
        public myCircle(float xVal, float yVal, float rVal)
        {
            X = xVal;
            Y = yVal;
            radius = rVal;
            color = RandomColor();
            ChangeColor = Color.Red;
            IsHighlighted = false;
        }
        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
        public override void Draw(Graphics g)
        {
            SolidBrush br = new SolidBrush(color);
            Pen pen = new Pen(color);
            g.FillEllipse(br, X - radius, Y - radius, 2 * radius, 2 * radius);
            g.DrawEllipse(pen, X - radius, Y - radius, 2 * radius, 2 * radius);
        }
        public override bool isInside(int xP, int yP)
        {
            return Math.Sqrt((xP - X) * (xP - X) + (yP - Y) * (yP - Y)) < radius;
        }
        ~myCircle() { }
    }

    public class mySquare : Figure
    {
        float height;
        public mySquare() : this(10, 10, 10)
        { }
        public mySquare(float X, float Y, float height)
        {
            this.X = X;
            this.Y = Y;
            this.height = height;
            color = RandomColor();
            ChangeColor = Color.Red;
            IsHighlighted = false;
        }
        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public override void Draw(Graphics g)
        {
            SolidBrush br = new SolidBrush(color);
            Pen pen = new Pen(color, 2);
            g.FillRectangle(br, X - height / 2, Y - height / 2, height, height);
            g.DrawRectangle(pen, X - height / 2, Y - height / 2, height, height);
        }
        public override bool isInside(int xP, int yP)
        {
            return Math.Abs(xP - X) <= height / 2 && Math.Abs(yP - Y) <= height / 2;
        }
        ~mySquare() { }
    }

    public class myParallelogram : mySquare
    {
        float width;
        float offset;
        public myParallelogram() : this(10, 10, 10, 10, 6)
        { }
        public myParallelogram(float xVal, float yVal, float width, float height, float offset)
        {
            this.width = width;
            this.offset = offset;
            Height = height;
            X = xVal;
            Y = yVal;
            color = RandomColor();
            ChangeColor = Color.Red;
            IsHighlighted = false;
        }
        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public float Offset
        {
            get
            {
                return offset;
            }
            set
            {
                offset = value;
            }
        }
        public override void Draw(Graphics g)
        {
            PointF[] points = GetPoints();
            SolidBrush br = new SolidBrush(color);
            Pen pen = new Pen(color, 2);
            g.FillClosedCurve(br, points, System.Drawing.Drawing2D.FillMode.Winding, 0);
            g.DrawClosedCurve(pen, points, 0, System.Drawing.Drawing2D.FillMode.Winding);
        }
        public override bool isInside(int xP, int yP)
        {
            PointF[] points = GetPoints();
            PointF myPoint = new PointF(xP, yP);
            if (offset > 0)
            {
                if ((IsAboveLine(GetEq(points[2], points[3]), myPoint) || IsEqualLine(GetEq(points[2], points[3]), myPoint)) && (IsAboveLine(GetEq(points[3], points[0]), myPoint) || IsEqualLine(GetEq(points[3], points[0]), myPoint))
                    && !IsAboveLine(GetEq(points[0], points[1]), myPoint) && !IsAboveLine(GetEq(points[1], points[2]), myPoint))
                    return true;
            }
            else if (offset < 0)
            {
                if ((IsAboveLine(GetEq(points[0], points[1]), myPoint) || IsEqualLine(GetEq(points[0], points[1]), myPoint)) && (IsAboveLine(GetEq(points[3], points[0]), myPoint) || IsEqualLine(GetEq(points[3], points[0]), myPoint))
                    && !IsAboveLine(GetEq(points[1], points[2]), myPoint) && !IsAboveLine(GetEq(points[2], points[3]), myPoint))
                    return true;
            }
            else
            {
                return Math.Abs(xP - X) <= Width / 2 && Math.Abs(yP - Y) <= Height / 2;
            }
            return false;
        }
        private PointF[] GetPoints()
        {
            PointF[] points = { new PointF(X - width / 2, Y - Height / 2), new PointF(X - width / 2 + offset, Y + Height / 2), new PointF(X + width / 2 + offset, Y + Height / 2), new PointF(X + width / 2, Y - Height / 2) };
            return points;
        }
        private float[] GetEq(PointF p1, PointF p2)
        {
            if (p1.X - p2.X == 0)
                return null;
            float slope = (p1.Y - p2.Y) / (p1.X - p2.X);
            float c = p1.Y - slope * p1.X;
            float[] myEq = { slope, c };
            return myEq;
        }
        private bool IsAboveLine(float[] eq, PointF p)
        {
            float res = p.Y - eq[0] * p.X - eq[1];
            return (res > 0);
        }
        private bool IsEqualLine(float[] eq, PointF p)
        {
            float res = p.Y - eq[0] * p.X - eq[1];
            return (res == 0);
        }
        ~myParallelogram() { }
    }

    public class myRectangle : mySquare
    {
        float width;
        public myRectangle()
            : this(10, 10, 10, 20)
        { }
        public myRectangle(float xVal, float yVal, float wVal, float hVal)
        {
            X = xVal;
            Y = yVal;
            width = wVal;
            Height = hVal;
            color = RandomColor();
            ChangeColor = Color.Red;
            IsHighlighted = false;
        }

        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public override void Draw(Graphics g)
        {
            SolidBrush br = new SolidBrush(color);
            Pen pen = new Pen(color, 2);
            g.FillRectangle(br, X - Width / 2, Y - Height / 2, Width, Height);
            g.DrawRectangle(pen, X - Width / 2, Y - Height / 2, Width, Height);
        }
        public override bool isInside(int xP, int yP)
        {
            return Math.Abs(xP - X) <= Width / 2 && Math.Abs(yP - Y) <= Height / 2;
        }
        ~myRectangle() { }
    }

    public class FigureList
    {
        protected SortedList figures;

        public FigureList()
        {
            figures = new SortedList();
        }
        public int NextIndex
        {
            get
            {
                return figures.Count;
            }
        }
        public Figure this[int index]
        {
            get
            {
                if (index >= figures.Count)
                    return (Figure)null;
                return (Figure)figures.GetByIndex(index);
            }
            set
            {
                if (index <= figures.Count)
                    figures[index] = value;
            }
        }
        public void Remove(int element)
        {
            if (element >= 0 && element < figures.Count)
            {
                for (int i = element; i < figures.Count - 1; i++)
                    figures[i] = figures[i + 1];
                figures.RemoveAt(figures.Count - 1);
            }
        }
        public void RemoveAll()
        {
            for (int i = figures.Count - 1; i >= 0; i--)
                figures.RemoveAt(i);
        }
        public void DrawAll(Graphics g)
        {
            Figure prev, cur;
            for (int i = 1; i < figures.Count; i++)
            {
                prev = (Figure)figures[i - 1];
                cur = (Figure)figures[i];
                ((Figure)figures[i]).Draw(g);
            }
            for (int i = 0; i < figures.Count; i++)
                ((Figure)figures[i]).Draw(g);
        }
    }
}