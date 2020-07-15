using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class GrayingFilter : TemplateFilter
    {
        public override ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];
        }

        public override string ToString()
        {
            return "Черно-белое";
        }

        protected override Pixel ProcessPixel(Pixel original, double[] parameters)
        {
            var lightness = original.R * 0.299 + original.G * 0.587 + original.B * 0.114;
            return new Pixel(lightness, lightness, lightness);
        }
    }
}