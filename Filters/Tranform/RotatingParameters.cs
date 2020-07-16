using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class RotatingParameters : IParameters
    {
        public double Angle { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo { Name = "Угол", MaxValue = 360, MinValue = 0, Increment = 5, DefaultValue = 90 }
            };
        }

        public void Parse(double[] values)
        {
            Angle = values[0];
        }
    }
}
