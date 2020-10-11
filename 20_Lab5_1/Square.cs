using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _20_Lab5_1 {
	class Square {
		protected float Pos_X {
			get; set;
		}
		protected float Pos_Y {
			get; set;
		}
		protected float Size {
			get; set;
		}
		protected Pen Outline {
			// Контур
			get; set;
		}
		protected Brush FillBrush {
			// Пензель для заливки
			get; set;
		}

		public Square(Form window) {
			Pos_X = 200.5F;
			Pos_Y = 200.5F;
			Form2 f = new Form2();
			if (f.ShowDialog() == DialogResult.OK) {
				Size = f.ObjSize;
				Outline = new Pen(Color.Black, 2);
				FillBrush = new SolidBrush(f.ObjColour);
			} else {
				window.Close();
			}
			f.Dispose();
		}

		public virtual void ShowInfo() {
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
			g.Clear(bgcolor);
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.DrawRectangle(Outline, Pos_X, Pos_Y, Size, Size);
			g.FillRectangle(FillBrush, Pos_X, Pos_Y, Size, Size);
		}

		public virtual bool MoveLeft(Form window) {
			if (Pos_X > 0) {
				Pos_X--;
				window.Invalidate();
				return true;
			}
			return false;
		}

		public virtual bool MoveRight(Form window) {
			if (Pos_X < window.Width - Size - 17) {
				Pos_X++;
				window.Invalidate();
				return true;
			}
			return false;
		}
	}
}
