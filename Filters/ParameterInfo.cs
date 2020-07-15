using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class ParameterInfo
    {
        public string Name;
        public double DefaultValue;
        public double MinValue = 0;
        public double MaxValue = 1;
        public double Increment;
    }
}