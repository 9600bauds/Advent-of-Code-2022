using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.libs
{
    public static class GridRenderer
    {
        public static void Render(int posx, int posy, char[,] grid)
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
                    temp += grid[x, y];
                }
                temp += "\n";
                Console.Write(temp);
            }
            Console.SetCursorPosition(oldX, oldy);
        }
    }
}
