using MyPhotoshop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    abstract public class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        protected abstract Pixel ProcessPixel(Pixel original, TParameters parameters);

        public override Photo Process(Photo original, TParameters parameters)
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