using System;
using System.Collections.Generic;
using System.Text;

namespace _20_Lab5_2 {
	class Cone {
		public double BaseRadius {
			// Радіус нижньої основи.
			get;
		}
		public double Height {
			// Висота.
			get;
		}
		public double BaseArea {
			// Площа нижньої основи.
			get => BaseRadius * BaseRadius * Math.PI;
		}
		public virtual double Volume {
			// Об'єм.
			get => BaseArea * Height / 3;
		}

		public Cone(double height, double baseradius) {
			if (baseradius < 0 || height < 0)
				// Висота й/або радіус не можуть бути менше нуля.
				throw new ArgumentOutOfRangeException();
			BaseRadius = baseradius;
			Height = height;
		}

		public virtual void ShowInfo() {
			Console.WriteLine("Висота: {0}", Height);
			Console.WriteLine("Радіус нижньої основи: {0}", BaseRadius);
			Console.WriteLine("Площа нижньої основи: {0}", BaseArea);
			Console.WriteLine("Об'єм: {0}", Volume);
		}
	}
}
