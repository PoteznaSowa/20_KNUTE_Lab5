using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20_Lab5_1 {
	public partial class Form1 : Form {
		Square square;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch (e.KeyData) {
			case Keys.Space:
				square.ShowInfo();
				break;
			case Keys.Left:
				square.MoveLeft(this);
				break;
			case Keys.Right:
				square.MoveRight(this);
				break;
			default:
				break;
			}
		}

		private void Form1_Load(object sender, EventArgs e) {
			// Показати діалогове вікно.
			switch (MessageBox.Show("Чи потрібно, щоб квадрат можна було повертати вліво або вправо?",
				"Створення квадрату", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) {
			case DialogResult.Yes:
				square = new RotatableSquare(this);
				break;
			case DialogResult.No:
				square = new Square(this);
				break;
			default:
				Close();
				break;
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			square.Draw(e.Graphics, BackColor);
		}
	}
}
