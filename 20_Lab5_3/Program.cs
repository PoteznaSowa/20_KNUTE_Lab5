using System;

namespace _20_Lab5_3 {
	class Program {
		static void Main() {
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.Title = "Lab5_3";

			Matrix matrix = null;
			while (Console.KeyAvailable)
				Console.ReadKey();  // Очистити буфер вводу.
			for (; ; ) {
				int a, b;
				if (matrix == null) {
					Console.WriteLine("Оберіть тип матриці:");
					Console.WriteLine("1. Звичайна");
					Console.WriteLine("2. Одинична");
					Console.WriteLine("3. Верхня трикутна");
					do {
						a = GetNumberKey();
					} while (a < 1 || a > 3);
					switch (a) {
					case 1:
						Console.Write("Введіть довжину матриці від 1 до 9: ");
						do {
							a = GetNumberKey();
						} while (a < 1);
						Console.WriteLine(a);

						Console.Write("Введіть ширину матриці від 1 до 9: ");
						do {
							b = GetNumberKey();
						} while (b < 1);
						Console.WriteLine(b);

						matrix = new Matrix(a, b);
						break;
					case 2:
						Console.Write("Введіть розмір квадратної матриці від 1 до 9: ");
						do {
							a = GetNumberKey();
						} while (a < 1);
						Console.WriteLine(a);

						matrix = new IdentityMatrix(a);
						break;
					case 3:
						Console.Write("Введіть розмір квадратної матриці від 1 до 9: ");
						do {
							a = GetNumberKey();
						} while (a < 1);
						Console.WriteLine(a);

						matrix = new UpperTriangularMatrix(a);
						break;
					}

				}

				Console.WriteLine("Що Ви хочете зробити?");
				Console.WriteLine("1. Показати матрицю");
				Console.WriteLine("2. Редагувати матрицю");
				Console.WriteLine("3. Перестворити матрицю");
				Console.WriteLine("4. Вийти з програми");

				do {
					a = GetNumberKey();
				} while (a < 1 || a > 4);
				switch (a) {
				case 1:
					matrix.Show();
					break;
				case 2:
					matrix.Edit();
					break;
				case 3:
					matrix = null;
					break;
				case 4:
					return;
				}
			}
		}
		static int GetNumberKey() {
			for (; ; ) {
				var key = Console.ReadKey(true).Key;
				switch (key) {
				case ConsoleKey.D0:
				case ConsoleKey.D1:
				case ConsoleKey.D2:
				case ConsoleKey.D3:
				case ConsoleKey.D4:
				case ConsoleKey.D5:
				case ConsoleKey.D6:
				case ConsoleKey.D7:
				case ConsoleKey.D8:
				case ConsoleKey.D9:
					return key - ConsoleKey.D0;
				case ConsoleKey.NumPad0:
				case ConsoleKey.NumPad1:
				case ConsoleKey.NumPad2:
				case ConsoleKey.NumPad3:
				case ConsoleKey.NumPad4:
				case ConsoleKey.NumPad5:
				case ConsoleKey.NumPad6:
				case ConsoleKey.NumPad7:
				case ConsoleKey.NumPad8:
				case ConsoleKey.NumPad9:
					return key - ConsoleKey.NumPad0;
				}
			}
		}
	}
}
