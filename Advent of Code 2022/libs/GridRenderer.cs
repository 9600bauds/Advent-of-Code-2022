using System;
using System.Collections.Generic;
using System.Drawing;

namespace Advent_of_Code_2022.libs
{
    public static class GridRenderer
    {
        public static void Render(int posx, int posy, char[,] grid, List<Point>? highlights = null)
        {
            int oldy = Console.CursorTop;
            int oldX = Console.CursorLeft;
            int height = grid.GetLength(1);
            int width = grid.GetLength(0);
            for (int y = height - 1; y >= 0; y--)
            {
                string temp = "";
                Console.SetCursorPosition(posx, posy + height - y);
                for (int x = 0; x <= width - 1; x++)
                {
                    if (highlights != null && highlights.Contains(new(x, y)))
                    {
                        Console.Write(temp);
                        temp = "";
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(grid[x, y]);
                        Console.ResetColor();
                    }
                    else
                    {
                        temp += grid[x, y];
                    }

                }
                temp += "\n";
                Console.Write(temp);
            }
            Console.SetCursorPosition(oldX, oldy);
        }
    }
}
