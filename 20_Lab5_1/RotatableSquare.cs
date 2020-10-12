using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _20_Lab5_1 {
	class RotatableSquare : Square {
		int Angle {
			// Кут повороту в градусах.
			get; set;
		}

		public RotatableSquare(Form window)
			: base(window) {
		}

		public override void ShowInfo() {
			// Обчислити координати точок квадрата.
			//
			// A----B
			// |    |
			// |    |
			// C----D
			//
			float radians = Angle * MathF.PI / 180;
			float radians1 = (Angle - 45) * MathF.PI / 180;
			float ax = Pos_X;
			float ay = Pos_Y;
			float bx = Pos_X + ((Size - 1) * MathF.Cos(radians));
			float by = Pos_Y + ((Size - 1) * MathF.Sin(radians));
			float cx = Pos_X + ((Size - 1) * MathF.Sin(radians));
			float cy = Pos_Y + ((Size - 1) * MathF.Cos(radians));
			float dx = Pos_X - ((Size - 1) * MathF.Sin(radians1) * MathF.Sqrt(2));
			float dy = Pos_Y + ((Size - 1) * MathF.Cos(radians1) * MathF.Sqrt(2));

			// Вивести на екран дані про цей квадрат.
			MessageBox.Show(
				$"Довжина сторони: {Size}\n" +
				$"Кут повороту: {Angle}°\n" +
				"Координати точок:\n" +
				$"A: ({ax}; {ay})\n" +
				$"B: ({bx:0.#}; {by:0.#})\n" +
				$"C: ({cx:0.#}; {cy:0.#})\n" +
				$"D: ({dx:0.#}; {dy:0.#})\n",
				"Інформація про квадрат", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		public override void Draw(Graphics canvas, Color bgcolor) {
			canvas.Clear(bgcolor);  // Очистити тло.
			canvas.SmoothingMode = SmoothingMode.HighQuality;  // Зглажування.
			canvas.TranslateTransform(Pos_X, Pos_Y);
			canvas.RotateTransform(-Angle);  // Повернути тло.
			canvas.DrawRectangle(Outline, 0, 0, Size, Size);  // Намалювати контур квадрата.
			canvas.FillRectangle(FillBrush, 0, 0, Size, Size);  // Заливка.
		}

		public override bool MoveLeft(Form window) {
			// Поворот проти годинникової стрілки.
			Angle++;
			if (Angle > 180)
				Angle -= 360;
			window.Invalidate();  // Перемалювати квадрат.
			return true;  // Успішно.
		}

		public override bool MoveRight(Form window) {
			// Поворот за годинниковою стрілкою.
			Angle--;
			if (Angle < -180)
				Angle += 360;
			window.Invalidate();  // Перемалювати квадрат.
			return true;  // Успішно.
		}
	}
}
