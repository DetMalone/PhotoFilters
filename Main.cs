using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main ()
		{
			var window = new MainWindow();

			window.AddFilter(new PixelFilter<LighteningParameters>
				("Осветление / затемнение",
				(pixel, parameters) => pixel * parameters.Coefficient));

			window.AddFilter(new PixelFilter<EmptyParameters>
				("Черно-белое",
				(pixel, parameters) =>
				{
					var lightness = pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114;
					return new Pixel(lightness, lightness, lightness);
				}));

            window.AddFilter(new TransformFilter
                ("Отразить по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - 1 - point.X, point.Y)));

            window.AddFilter(new TransformFilter
                ("Отразить по вертикали",
                size => size,
                (point, size) => new Point(point.X, size.Height - 1 - point.Y)));

            window.AddFilter(new TransformFilter<RotatingParameters>
				("Свободный поворот", new RotateTransformer()));

			Application.Run(window);
		}
	}
}
