using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _20_Lab5_1 {
	class Square {
		protected float Pos_X {
			// Координата X.
			get; set;
		}
		protected float Pos_Y {
			// Координата Y.
			get; set;
		}
		protected float Size {
			// Розмір сторони квадрата.
			get; set;
		}
		protected Pen Outline {
			// Контур квадрата.
			get; set;
		}
		protected Brush FillBrush {
			// Пензель для заливки.
			get; set;
		}

		public Square(Form window) {
			Pos_X = 200.5F;
			Pos_Y = 200.5F;

			// Запросити у користувача розмір сторони і колір заливки.
			Form2 f = new Form2();
			if (f.ShowDialog() == DialogResult.OK) {
				Size = f.ObjSize;
				Outline = new Pen(Color.Black, 2);
				FillBrush = new SolidBrush(f.ObjColour);
			} else {
				// Якщо це діалогове вікно закривається неправильно, закрити програму.
				window.Close();
			}
			f.Dispose();  // Знищити діалогове вікно та звільнити пам'ять.
		}

		public virtual void ShowInfo() {
			// Обчислити координати точок квадрата.
			//
			// A----B
			// |    |
			// |    |
			// C----D
			//
			float ax = Pos_X;
			float ay = Pos_Y;
			float bx = Pos_X + Size - 1;
			float by = Pos_Y;
			float cx = Pos_X;
			float cy = Pos_Y + Size - 1;
			float dx = Pos_X + Size - 1;
			float dy = Pos_Y + Size - 1;

			// Вивести на екран дані про цей квадрат.
			MessageBox.Show(
				$"Довжина сторони: {Size}\n" +
				"Координати точок:\n" +
				$"A: ({ax}; {ay})\n" +
				$"B: ({bx}; {by})\n" +
				$"C: ({cx}; {cy})\n" +
				$"D: ({dx}; {dy})\n",
				"Інформація про квадрат", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public virtual void Draw(Graphics g, Color bgcolor) {
			g.Clear(bgcolor);  // Очистити тло.
			g.SmoothingMode = SmoothingMode.HighQuality;  // Зглажування.
			g.DrawRectangle(Outline, Pos_X, Pos_Y, Size, Size);  // Намалювати контур квадрата.
			g.FillRectangle(FillBrush, Pos_X, Pos_Y, Size, Size);  // Заливка.
		}

		public virtual bool MoveLeft(Form window) {
			if (Pos_X > 0) {  // Перевірити, що квадрат не вилазить за межі форми.
				Pos_X--;
				window.Invalidate();  // Перемалювати квадрат.
				return true;  // Успішно.
			}
			return false;  // Невдало.
		}

		public virtual bool MoveRight(Form window) {
			if (Pos_X < window.Width - Size - 17) {  // Перевірити, що квадрат не вилазить за межі форми.
				Pos_X++;
				window.Invalidate();  // Перемалювати квадрат.
				return true;  // Успішно.
			}
			return false;  // Невдало.
		}
	}
}
