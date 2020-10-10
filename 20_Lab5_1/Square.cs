using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace _20_Lab5_1 {
	class Square {
		protected int Pos_X {
			get; set;
		}
		protected int Pos_Y {
			get; set;
		}
		protected int Size {
			get; set;
		}
		protected Color Colour {
			get; set;
		}

		public Square(Form window) {
			Pos_X = 200;
			Pos_Y = 200;
			Form2 f = new Form2();
			if (f.ShowDialog() == DialogResult.OK) {
				Size = f.ObjSize;
				Colour = f.ObjColour;
			} else {
				window.Close();
			}
		}

		public virtual void ShowInfo() {
			//
			// A----B
			// |    |
			// |    |
			// C----D
			//
			int ax = Pos_X;
			int ay = Pos_Y;
			int bx = Pos_X + Size - 1;
			int by = Pos_Y;
			int cx = Pos_X;
			int cy = Pos_Y + Size - 1;
			int dx = Pos_X + Size - 1;
			int dy = Pos_Y + Size - 1;

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
			g.DrawRectangle(new Pen(Color.Black, 2), Pos_X, Pos_Y, Size, Size);
			g.FillRectangle(new SolidBrush(Colour), Pos_X, Pos_Y, Size, Size);
		}

		public virtual void MoveLeft(Form window) {
			if (Pos_X > 0) {
				Pos_X--;
				window.Invalidate();
			}
		}

		public virtual void MoveRight(Form window) {
			if (Pos_X < window.Width - 17) {
				Pos_X++;
				window.Invalidate();
			}
		}
	}
}
