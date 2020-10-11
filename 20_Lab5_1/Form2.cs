using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _20_Lab5_1 {
	public partial class Form2 : Form {
		public int ObjSize {
			get; private set;
		}
		public Color ObjColour {
			get; private set;
		}
		readonly ColorDialog d;

		public Form2() {
			ObjSize = 99;
			ObjColour = Color.Lime;
			d = new ColorDialog() {
				Color = ObjColour
			};
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			if (d.ShowDialog() == DialogResult.OK) {
				button1.BackColor = ObjColour = d.Color;
				// Переконатися, що текст на кнопці буде видно.
				if (ObjColour.R < 99 && ObjColour.G < 99 && ObjColour.B < 99) {
					button1.ForeColor = Color.White;
				} else {
					button1.ForeColor = Color.Black;
				}
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			Close();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
			ObjSize = (int)numericUpDown1.Value;
		}
	}
}
