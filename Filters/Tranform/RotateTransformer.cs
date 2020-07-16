using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    class RotateTransformer : ITransformer<RotatingParameters>
    {
        private double angle;
        public Size OriginalSize { get; private set; }
        public Size ResultSize { get; private set; }

        public void Prepare(Size size, RotatingParameters parameters)
        {
            OriginalSize = size;
            angle = Math.PI * parameters.Angle / 180;
            ResultSize = new Size(
                (int)(size.Width * Math.Abs(Math.Cos(angle)) + size.Height * Math.Abs(Math.Sin(angle))),
                (int)(size.Height * Math.Abs(Math.Cos(angle)) + size.Width * Math.Abs(Math.Sin(angle))));
        }

        public Point? MapPoint(Point newPoint)
        {
            var delta = 1e-9;
            newPoint = new Point(newPoint.X - ResultSize.Width / 2, newPoint.Y - ResultSize.Height / 2);
            var x = OriginalSize.Width / 2 + (int)(newPoint.X * Math.Cos(angle) + newPoint.Y * Math.Sin(angle) - delta);
            var y = OriginalSize.Height / 2 + (int)(-newPoint.X * Math.Sin(angle) + newPoint.Y * Math.Cos(angle) - delta);
            if (x < 0 || x >= OriginalSize.Width || y < 0 || y >= OriginalSize.Height) return null;
            return new Point(x, y);
        }
    }
}
