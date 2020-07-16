using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    abstract public class ParametrizedFilter<TParameters> : IFilter
        where TParameters : IParameters, new()
    {
        public ParameterInfo[] GetParameters()
        {
            return new TParameters().GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = new TParameters();
            parameters.Parse(values);
            return Process(original, parameters);
        }

        abstract public Photo Process(Photo original, TParameters parameters);

        protected string name;
        public override string ToString()
        {
            return name;
        }
    }
}
