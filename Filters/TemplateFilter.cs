using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    abstract public class TemplateFilter : IFilter
    {
        public abstract ParameterInfo[] GetParameters();
        protected abstract Pixel ProcessPixel(Pixel original, double[] parameters);

        public Photo Process(Photo original, double[] parameters)
        {
            var result = new Photo(original.Width, original.Height);
            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++)
                {
                    result[x, y] = ProcessPixel(original[x, y], parameters);
                }
            return result;
        }
    }
}