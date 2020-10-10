using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace _20_Lab5_1 {
	class RotatableSquare : Square {
		int Angle {
			get; set;
		}

		public RotatableSquare(Form window)
			: base(window) {
		}

		public override void ShowInfo() {
			//
			// A----B
			// |    |
			// |    |
			// C----D
			//
			float radians = Angle * MathF.PI / 180;
			float radians1 = (Angle - 45) * MathF.PI / 180;
			int ax = Pos_X;
			int ay = Pos_Y;
			float bx = Pos_X + ((Size - 1) * MathF.Cos(radians));
			float by = Pos_Y + ((Size - 1) * MathF.Sin(radians));
			float cx = Pos_X + ((Size - 1) * MathF.Sin(radians));
			float cy = Pos_Y + ((Size - 1) * MathF.Cos(radians));
			float dx = Pos_X - ((Size - 1) * MathF.Sin(radians1) * MathF.Sqrt(2));
			float dy = Pos_Y + ((Size - 1) * MathF.Cos(radians1) * MathF.Sqrt(2));

			MessageBox.Show(
				$"Довжина сторони: {Size}\n" +
				$"Кут повороту: {Angle}°\n" +
				"Координати точок:\n" +
				$"A: ({ax}; {ay})\n" +
				$"B: ({bx:0.#}; {by:0.#})\n" +
				$"C: ({cx:0.#}; {cy:0.#})\n" +
				$"D: ({dx:0.#}; {dy:0.#})\n",
				"Інформація про квадрат", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public override void Draw(Graphics g, Color bgcolor) {
			g.Clear(bgcolor);
			g.TranslateTransform(Pos_X, Pos_Y);
			g.RotateTransform(-Angle);
			g.DrawRectangle(new Pen(Color.Black, 2), 0, 0, Size, Size);
			g.FillRectangle(new SolidBrush(Colour), 0, 0, Size, Size);
		}

		public override void MoveLeft(Form window) {
			Angle++;
			if (Angle > 180)
				Angle -= 360;
			window.Invalidate();
		}

		public override void MoveRight(Form window) {
			Angle--;
			if (Angle < -180)
				Angle += 360;
			window.Invalidate();
		}
	}
}
