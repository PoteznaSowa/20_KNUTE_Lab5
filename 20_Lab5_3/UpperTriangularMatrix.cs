using System;
using System.Collections.Generic;
using System.Text;

namespace _20_Lab5_3 {
	class UpperTriangularMatrix : Matrix {
		public UpperTriangularMatrix(int size) : base(size, size) { }

		public override void Edit() {
			Show();

			ConsoleColor fgc = Console.ForegroundColor;
			ConsoleColor bgc = Console.BackgroundColor;
			var x = 0;
			var y = 0;
			var currentline = Console.CursorTop;
			Console.CursorVisible = false;
			while (Console.KeyAvailable)
				Console.ReadKey();  // Очистити буфер вводу.
			for (; ; ) {
				Console.SetCursorPosition(x * 4, currentline - height + y);
				Console.BackgroundColor = fgc;
				Console.ForegroundColor = bgc;
				Console.Write("{0,4}", content[x, y]);
				Console.ResetColor();
				Console.SetCursorPosition(0, currentline);

				ConsoleKey key = Console.ReadKey(true).Key;
				Console.SetCursorPosition(x * 4, currentline - height + y);
				Console.Write("{0,4}", content[x, y]);
				Console.SetCursorPosition(0, currentline);
				switch (key) {
				case ConsoleKey.Enter:
					goto Exit;
				case ConsoleKey.LeftArrow:
					// За головну діагональ не можна вилазити.
					if (x > y)
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
					// За головну діагональ не можна вилазити.
					if (y < height - 1 && x > y)
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
					if (content[x, y] < 0)
						content[x, y] = -content[x, y];
					content[x, y] = (content[x, y] % 10 * 10) + (key - ConsoleKey.NumPad0);
					break;
				case ConsoleKey.Subtract:
				case ConsoleKey.OemMinus:
					content[x, y] = -content[x, y];
					break;
				default:
					break;
				}
			}
		Exit:
			Console.CursorVisible = true;
		}
	}
}
