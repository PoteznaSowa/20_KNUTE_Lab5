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
			// Перевірити, яку клавішу було натиснуто.
			switch (e.KeyData) {
			case Keys.Space:
				// Зупинити рух об'єкта та вивести інформацію про нього.
				movemode = 0;
				square.ShowInfo();
				break;
			case Keys.Left:
				// Рухати об'єкт вліво.
				movemode = 1;
				break;
			case Keys.Right:
				// Рухати об'єкт вправо.
				movemode = 2;
				break;
			default:
				break;
			}
		}

		private void Form1_Load(object sender, EventArgs e) {
			// Показати діалогове вікно створення квадрату.
			switch (MessageBox.Show("Чи потрібно, щоб квадрат можна було повертати вліво або вправо?",
				"Створення квадрату", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2)) {
			case DialogResult.Yes:
				square = new RotatableSquare(this);
				break;
			case DialogResult.No:
				square = new Square(this);
				break;
			default:
				// Якщо якось це вікно повідомлень закриється інакше, закрити програму.
				Close();
				break;
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			square.Draw(e.Graphics, BackColor);
		}

		int movemode = 0;  // Режим руху квадрата.
		private void timer1_Tick(object sender, EventArgs e) {
			// Оновлювати стан об'єкту кожні 1/64 секунди.
			// Чому 1/64 секунди?
			// Було виставлено період таймеру на 1 мілісекунду, що є 1/1000 секунди, але
			// таймери в .NET спрацьовують раз на 1/64 секунди.
			switch (movemode) {
			case 1:
				if (!square.MoveLeft(this))
					movemode = 2;
				return;
			case 2:
				if (!square.MoveRight(this))
					movemode = 1;
				return;
			}
		}
	}
}
