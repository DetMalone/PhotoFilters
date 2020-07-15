using MyPhotoshop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class GrayingFilter : PixelFilter<EmptyParameters>
    {
        public override string ToString()
        {
            return "Черно-белое";
        }

        protected override Pixel ProcessPixel(Pixel original, EmptyParameters parameters)
        {
            var lightness = original.R * 0.299 + original.G * 0.587 + original.B * 0.114;
            return new Pixel(lightness, lightness, lightness);
        }
    }
}