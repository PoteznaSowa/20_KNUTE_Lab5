using System;

namespace _20_Lab5_3 {
	class Matrix {
		protected int[,] content;
		protected int width;
		protected int height;

		public Matrix(int width, int height) {
			if (width < 1 || height < 1) {
				throw new ArgumentOutOfRangeException();
			}
			content = new int[width, height];
			this.width = width;
			this.height = height;
		}

		public virtual void Edit() {
			Show();

			ConsoleColor fgc = Console.ForegroundColor;
			ConsoleColor bgc = Console.BackgroundColor;
			int x = 0;
			int y = 0;
			var currentline = Console.CursorTop;
			Console.CursorVisible = false;
			if (Console.KeyAvailable)
				Console.ReadKey();
			for (; ; ) {
				Console.CursorLeft = x * 4;
				Console.CursorTop = currentline - height + y;
				Console.BackgroundColor = fgc;
				Console.ForegroundColor = bgc;
				Console.Write("{0,4}", content[x, y]);
				Console.ResetColor();
				Console.CursorLeft = 0;
				Console.CursorTop = currentline;

				ConsoleKey key = Console.ReadKey(true).Key;
				Console.CursorLeft = x * 4;
				Console.CursorTop = currentline - height + y;
				Console.Write("{0,4}", content[x, y]);
				Console.CursorLeft = 0;
				Console.CursorTop = currentline;
				switch (key) {
				case ConsoleKey.Enter:
					goto Exit;
				case ConsoleKey.LeftArrow:
					if (x > 0)
						x--;
					break;
				case ConsoleKey.UpArrow:
					if (y > 0)
						y--;
					break;
				case ConsoleKey.RightArrow:
					if (x < width - 1)
						x++;
					break;
				case ConsoleKey.DownArrow:
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
					content[x, y] = content[x, y] * 10 % 100;
					if (content[x, y] >= 0)
						content[x, y] += key - ConsoleKey.D0;
					else
						content[x, y] -= key - ConsoleKey.D0;
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
					content[x, y] = content[x, y] * 10 % 100;
					if (content[x, y] >= 0)
						content[x, y] += key - ConsoleKey.NumPad0;
					else
						content[x, y] -= key - ConsoleKey.NumPad0;
					break;
				case ConsoleKey.OemMinus:
				case ConsoleKey.Subtract:
					content[x, y] = -content[x, y];
					break;
				default:
					break;
				}
			}
		Exit:
			Console.CursorVisible = true;
		}

		public virtual void Show() {
			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					Console.Write("{0,4}", content[j, i]);
				}
				Console.WriteLine();
			}
		}
	}
}
