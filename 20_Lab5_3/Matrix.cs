using System;

namespace _20_Lab5_3 {
	class Matrix {
		protected int[,] content;
		protected int width;
		protected int height;

		public Matrix(int width, int height) {
			if (width < 1 || height < 1) {
				// Матриця не існуватиме, якщо її "площа" є недодатньою.
				throw new ArgumentOutOfRangeException();
			}
			// Фактично матриця є двомірним масивом.
			content = new int[width, height];
			this.width = width;
			this.height = height;
		}

		public virtual void Edit() {
			Show();

			var fgc = Console.ForegroundColor;
			var bgc = Console.BackgroundColor;
			var x = 0;
			var y = 0;
			var currentline = Console.CursorTop;  // Запам'ятати номер рядка в консолі.
			Console.CursorVisible = false;  // Приховати курсор, щоб не заважав.
			while (Console.KeyAvailable)
				Console.ReadKey();  // Очистити буфер вводу.
			for (; ; ) {
				// Оновити та підсвітити елемент матриці.
				Console.SetCursorPosition(x * 4, currentline - height + y);
				Console.BackgroundColor = fgc;
				Console.ForegroundColor = bgc;
				Console.Write("{0,4}", content[x, y]);
				// Скинути стан курсора на випадок, якщо програму буде примусово закрито.
				Console.ResetColor();
				Console.SetCursorPosition(0, currentline);

				ConsoleKey key = Console.ReadKey(true).Key;
				// Прибрати підсвітку елемента.
				Console.SetCursorPosition(x * 4, currentline - height + y);
				Console.Write("{0,4}", content[x, y]);
				Console.SetCursorPosition(0, currentline);
				switch (key) {
				case ConsoleKey.Enter:
					goto Exit;  // Вийти з нескінченого циклу for(;;).
				case ConsoleKey.LeftArrow:
					// Перемістити курсор вліво.
					if (x > 0)
						x--;
					break;
				case ConsoleKey.UpArrow:
					// Перемістити курсор вверх.
					if (y > 0)
						y--;
					break;
				case ConsoleKey.RightArrow:
					// Перемістити курсор вправо.
					if (x < width - 1)
						x++;
					break;
				case ConsoleKey.DownArrow:
					// Перемістити курсор вниз.
					if (y < height - 1)
						y++;
					break;
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
					// Якщо ввести цифру, мінус губиться.
					if (content[x, y] < 0)
						content[x, y] = -content[x, y];
					content[x, y] = (content[x, y] % 10 * 10) + (key - ConsoleKey.D0);
					break;
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
					// Якщо ввести цифру, мінус губиться.
					if (content[x, y] < 0)
						content[x, y] = -content[x, y];
					content[x, y] = (content[x, y] % 10 * 10) + (key - ConsoleKey.NumPad0);
					break;
				case ConsoleKey.OemMinus:
				case ConsoleKey.Subtract:
					// Переключити мінус.
					content[x, y] = -content[x, y];
					break;
				default:
					break;
				}
			}
		Exit:
			Console.CursorVisible = true;  // Показати курсор.
		}

		public virtual void Show() {
			// Вивести на екран матрицю.
			for (var i = 0; i < height; i++) {
				for (var j = 0; j < width; j++) {
					Console.Write("{0,4}", content[j, i]);
				}
				Console.WriteLine();
			}
		}
	}
}
