using System;
using System.Collections.Generic;
using System.Text;

namespace _20_Lab5_3 {
	class IdentityMatrix : Matrix {
		public IdentityMatrix(int size) : base(size, size) {
			for (int i = 0; i < size; i++)
				content[i, i] = 1;
		}

		public override void Edit() {
			Console.WriteLine("Одиничну матрицю не можна редагувати.");
		}

		public override void Show() {
			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					Console.Write($" {content[j, i]}");
				}
				Console.WriteLine();
			}
		}
	}
}
