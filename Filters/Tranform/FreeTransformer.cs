using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    class FreeTransformer : ITransformer<EmptyParameters>
    {
        private Size oldSize;
        private Func<Size, Size> sizeTransformer;
        private Func<Point, Size, Point> pointTransformer;

        public FreeTransformer
            (Func<Size, Size> sizeTransformer, 
            Func<Point, Size, Point> pointTransformer)
        {
            this.sizeTransformer = sizeTransformer;
            this.pointTransformer = pointTransformer;
        }

        public Size ResultSize { get; private set; }

        public Point? MapPoint(Point newPoint)
        {
            return pointTransformer(newPoint, oldSize);
        }

        public void Prepare(Size size, EmptyParameters parameters)
        {
            oldSize = size;
            ResultSize = sizeTransformer(size);
        }
    }
}
