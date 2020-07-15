using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double r;
        private double g;
        private double b;
        public double R { get => r; set => r = Check(value); }
        public double G { get => g; set => g = Check(value); }
        public double B { get => b; set => b = Check(value); }

        public Pixel(double r, double g, double b)
        {
            this.r = this.g = this.b = 0;
            R = r;
            G = g;
            B = b;
        }

        public static Pixel operator *(Pixel p, double n)
        {
            return new Pixel(Trim(p.R * n), Trim(p.G * n), Trim(p.B * n));
        }

        public static Pixel operator *(double n, Pixel p)
        {
            return p * n;
        }

        private double Check(double value)
        {
            if (value < 0 || value > 1) throw new ArgumentException();
            return value;
        }

        public static double Trim(double value)
        {
            return value < 0 ? 0 : value > 1 ? 1 : value;
        }
    }
}