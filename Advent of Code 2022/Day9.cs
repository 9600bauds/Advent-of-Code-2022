using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day9
    {
        class Board
        {
            public int miny = 1;
            public int maxy = 3;
            public int minx = 1;
            public int maxx = 3; //the cooler max
            public List<RopeSegment> segments = new List<RopeSegment>();
            public HashSet<(int, int)> markedCoords = new HashSet<(int, int)> ();
            public String Draw(bool drawMarks = false)
            {
                String board = "";
                for(int col = maxy + 1; col > miny - 1; col--)
                {
                    for(int row = minx - 1; row <= maxx + 1; row++)
                    {
                        board += getCharForCoords(row, col, drawMarks);
                    }
                    board += "\r\n";
                }
                return board;
            }

            public char getCharForCoords(int x, int y, bool drawMarks)
            {
                if (drawMarks)
                {
                    if (markedCoords.Contains((x, y)))
                    {
                        return '#';
                    }
                    return '.';
                }
                if (x == 0 && y == 0)
                {
                    return 's';
                }
                foreach (RopeSegment segment in segments)
                {
                    if (segment.x == x && segment.y == y)
                    {
                        return segment.sprite;
                    }
                }
                return '.';
            }

            public void Mark((int, int) coords)
            {
                markedCoords.Add(coords);
            }

            public void updateMaxes(RopeSegment seg)
            {
                if(seg.x < minx)
                {
                    minx = seg.x;
                }
                if(seg.x > maxx)
                {
                    maxx = seg.x;
                }
                if(seg.y < miny)
                {
                    miny = seg.y;
                }
                if(seg.y > maxy)
                {
                    maxy = seg.y;
                }
            }

            public (int, int) dirToOffsets(String dir)
            {
                int xoffset = 0;
                int yoffset = 0;
                switch (dir)
                {
                    case "U":
                        yoffset++;
                        break;
                    case "D":
                        yoffset--;
                        break;
                    case "L":
                        xoffset--;
                        break;
                    case "R":
                        xoffset++;
                        break;
                }
                return (xoffset, yoffset);
            }
        }


        class RopeSegment
        {
            public int x;
            public int y;
            public RopeSegment child;
            public Board board;
            public char sprite;
            public bool marker;

            public RopeSegment(int x, int y, Board board, char sprite, bool marker, RopeSegment child = null)
            {
                this.x = x;
                this.y = y;
                this.board = board;
                board.segments.Add(this);
                this.sprite = sprite;
                this.marker = marker;
                if (marker)
                {
                    board.Mark((x, y));
                }
                if(child != null)
                {
                    this.child = child;
                }
            }

            public void Move(int xoffset, int yoffset)
            {
                x += xoffset;
                y += yoffset;
                board.updateMaxes(this);
                if (marker)
                {
                    board.Mark((x, y));
                }
                //Console.WriteLine($"{sprite} - My coords after moving are: {x}, {y}");
                if (child != null)
                {
                    child.Follow(this);
                }
            }

            public void Follow (RopeSegment parent)
            {
                int deltax = x - parent.x;
                int deltay = y - parent.y;
                //Console.WriteLine($"{sprite} - Following {parent.sprite}! My delta is: {deltax}, {deltay}");
                int distance = Math.Abs(deltay) + Math.Abs(deltax);
                if(distance > 2)
                {
                    //Shuh oh! Diagonal move time!!
                    Move(Math.Sign(deltax) * -1, Math.Sign(deltay) * -1);
                    return;
                }
                if (Math.Abs(deltax) > 1)
                {
                    Move(Math.Sign(deltax) * -1, 0);
                    return;
                }
                if (Math.Abs(deltay) > 1)
                {
                    Move(0, Math.Sign(deltay) * -1);
                    return;
                }
            }
        }

        public static void Run()
        {
            //string input = "R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2";
            //string input = "R 5\r\nU 8\r\nL 8\r\nD 3\r\nR 17\r\nD 10\r\nL 25\r\nU 20";
            string input = "U 2\r\nL 2\r\nU 1\r\nR 2\r\nD 2\r\nL 1\r\nR 1\r\nU 2\r\nD 1\r\nL 2\r\nD 2\r\nR 2\r\nD 1\r\nL 1\r\nU 2\r\nD 2\r\nR 1\r\nU 1\r\nL 1\r\nD 1\r\nL 1\r\nR 2\r\nU 1\r\nD 2\r\nU 2\r\nD 1\r\nL 1\r\nD 1\r\nL 2\r\nR 2\r\nD 2\r\nR 1\r\nD 2\r\nR 1\r\nD 2\r\nR 1\r\nU 2\r\nL 1\r\nU 2\r\nR 2\r\nD 2\r\nU 1\r\nR 1\r\nL 2\r\nD 1\r\nL 1\r\nR 1\r\nD 2\r\nR 2\r\nL 1\r\nR 2\r\nU 1\r\nL 2\r\nR 1\r\nD 1\r\nR 2\r\nU 2\r\nR 2\r\nL 1\r\nU 2\r\nR 1\r\nL 1\r\nU 2\r\nR 2\r\nD 2\r\nU 1\r\nL 2\r\nD 2\r\nR 1\r\nL 2\r\nD 2\r\nL 2\r\nR 1\r\nL 1\r\nU 2\r\nD 1\r\nU 1\r\nD 1\r\nL 1\r\nD 2\r\nU 1\r\nL 2\r\nR 2\r\nD 1\r\nU 1\r\nD 2\r\nL 2\r\nD 1\r\nR 1\r\nU 2\r\nD 2\r\nL 2\r\nR 2\r\nU 1\r\nD 1\r\nU 1\r\nL 1\r\nD 2\r\nR 1\r\nD 2\r\nU 1\r\nD 2\r\nU 2\r\nL 2\r\nR 2\r\nD 2\r\nR 1\r\nU 2\r\nR 2\r\nL 2\r\nU 1\r\nL 3\r\nU 3\r\nD 1\r\nU 2\r\nR 1\r\nU 3\r\nR 2\r\nU 3\r\nD 1\r\nR 1\r\nU 2\r\nD 2\r\nU 2\r\nD 2\r\nR 2\r\nU 3\r\nD 1\r\nL 1\r\nR 2\r\nU 2\r\nL 3\r\nU 3\r\nD 2\r\nL 3\r\nU 3\r\nR 2\r\nD 3\r\nL 3\r\nU 2\r\nD 2\r\nU 3\r\nR 1\r\nD 1\r\nR 2\r\nU 3\r\nD 3\r\nR 3\r\nD 2\r\nL 3\r\nD 2\r\nR 3\r\nD 1\r\nR 2\r\nU 1\r\nD 3\r\nR 2\r\nD 1\r\nU 3\r\nL 1\r\nU 2\r\nL 1\r\nR 3\r\nD 1\r\nL 1\r\nD 1\r\nR 2\r\nU 2\r\nR 1\r\nD 1\r\nR 2\r\nD 1\r\nR 3\r\nL 3\r\nU 1\r\nR 2\r\nU 1\r\nL 1\r\nD 1\r\nU 3\r\nD 1\r\nL 1\r\nR 1\r\nU 1\r\nD 3\r\nU 1\r\nR 3\r\nU 1\r\nL 1\r\nD 2\r\nR 2\r\nU 1\r\nR 1\r\nL 2\r\nR 1\r\nU 2\r\nL 3\r\nR 3\r\nL 1\r\nR 3\r\nD 3\r\nU 3\r\nR 1\r\nU 2\r\nL 2\r\nD 2\r\nR 3\r\nL 2\r\nR 3\r\nU 1\r\nL 1\r\nR 2\r\nD 2\r\nR 3\r\nU 2\r\nD 3\r\nR 2\r\nL 1\r\nD 3\r\nR 2\r\nL 3\r\nU 2\r\nL 1\r\nU 2\r\nR 1\r\nU 2\r\nD 1\r\nL 2\r\nU 3\r\nR 1\r\nU 4\r\nR 1\r\nU 4\r\nR 1\r\nL 1\r\nD 3\r\nL 3\r\nR 3\r\nU 4\r\nL 1\r\nR 2\r\nD 4\r\nU 2\r\nL 3\r\nU 1\r\nR 4\r\nD 1\r\nL 1\r\nU 4\r\nD 4\r\nL 3\r\nR 2\r\nD 4\r\nR 4\r\nD 1\r\nU 2\r\nL 4\r\nU 3\r\nD 2\r\nL 4\r\nD 2\r\nL 4\r\nU 2\r\nD 4\r\nL 1\r\nD 2\r\nU 4\r\nL 2\r\nU 1\r\nD 3\r\nU 4\r\nD 2\r\nL 1\r\nR 2\r\nL 4\r\nU 4\r\nL 3\r\nR 4\r\nD 3\r\nR 4\r\nD 2\r\nL 3\r\nU 2\r\nL 3\r\nU 1\r\nD 3\r\nL 4\r\nR 2\r\nD 2\r\nL 1\r\nU 2\r\nR 2\r\nL 1\r\nD 2\r\nU 3\r\nL 1\r\nU 1\r\nL 4\r\nU 4\r\nL 2\r\nR 1\r\nU 1\r\nR 4\r\nL 4\r\nD 2\r\nL 4\r\nD 4\r\nL 3\r\nU 4\r\nD 4\r\nL 2\r\nU 1\r\nL 1\r\nR 1\r\nL 4\r\nU 4\r\nL 2\r\nD 1\r\nR 2\r\nD 2\r\nL 2\r\nR 2\r\nL 1\r\nU 3\r\nL 1\r\nU 2\r\nD 2\r\nR 2\r\nD 3\r\nL 4\r\nR 2\r\nL 3\r\nR 3\r\nU 3\r\nL 5\r\nU 1\r\nD 3\r\nL 1\r\nU 5\r\nL 3\r\nU 4\r\nL 4\r\nR 5\r\nD 5\r\nR 1\r\nL 3\r\nD 1\r\nU 5\r\nR 3\r\nU 4\r\nD 4\r\nU 1\r\nD 4\r\nU 4\r\nR 4\r\nU 4\r\nR 4\r\nU 5\r\nR 3\r\nD 3\r\nL 1\r\nD 3\r\nU 4\r\nR 2\r\nU 2\r\nR 2\r\nU 2\r\nL 3\r\nR 4\r\nL 2\r\nD 5\r\nU 4\r\nD 4\r\nL 4\r\nR 4\r\nU 5\r\nR 1\r\nD 4\r\nL 4\r\nU 1\r\nL 2\r\nU 3\r\nD 1\r\nR 5\r\nU 4\r\nD 5\r\nL 5\r\nD 2\r\nL 1\r\nU 3\r\nD 4\r\nR 4\r\nL 2\r\nR 4\r\nD 3\r\nR 5\r\nL 4\r\nR 1\r\nD 3\r\nL 2\r\nR 5\r\nD 3\r\nR 1\r\nU 1\r\nL 5\r\nD 1\r\nU 4\r\nL 2\r\nU 4\r\nD 5\r\nL 4\r\nD 5\r\nL 2\r\nD 3\r\nR 5\r\nL 2\r\nD 1\r\nR 5\r\nD 1\r\nL 2\r\nU 1\r\nD 1\r\nL 3\r\nR 4\r\nL 1\r\nD 1\r\nU 3\r\nD 1\r\nR 2\r\nD 5\r\nR 3\r\nD 5\r\nL 2\r\nD 2\r\nU 5\r\nD 3\r\nR 5\r\nD 3\r\nR 4\r\nU 2\r\nL 5\r\nR 2\r\nD 5\r\nR 1\r\nU 5\r\nR 6\r\nD 6\r\nU 2\r\nR 3\r\nL 2\r\nU 4\r\nR 1\r\nD 6\r\nL 3\r\nU 5\r\nR 2\r\nL 6\r\nU 1\r\nD 5\r\nL 3\r\nR 3\r\nU 5\r\nL 1\r\nR 3\r\nU 3\r\nL 3\r\nR 6\r\nD 6\r\nL 3\r\nU 2\r\nR 1\r\nL 4\r\nR 5\r\nL 6\r\nR 4\r\nD 6\r\nU 6\r\nL 6\r\nU 2\r\nL 4\r\nD 6\r\nR 2\r\nD 2\r\nR 3\r\nD 2\r\nL 1\r\nU 4\r\nR 4\r\nD 1\r\nR 2\r\nL 1\r\nD 5\r\nL 6\r\nU 6\r\nD 2\r\nL 2\r\nD 1\r\nU 3\r\nD 1\r\nL 4\r\nU 5\r\nR 6\r\nU 5\r\nL 2\r\nR 6\r\nD 5\r\nR 3\r\nL 4\r\nU 6\r\nL 3\r\nD 6\r\nL 4\r\nR 5\r\nL 5\r\nR 4\r\nD 4\r\nL 5\r\nR 3\r\nU 6\r\nD 6\r\nL 3\r\nD 6\r\nU 1\r\nD 5\r\nL 5\r\nR 3\r\nL 4\r\nR 1\r\nL 1\r\nU 3\r\nD 6\r\nU 6\r\nR 2\r\nD 1\r\nU 2\r\nL 1\r\nR 5\r\nU 1\r\nL 5\r\nU 3\r\nR 3\r\nD 3\r\nL 4\r\nD 6\r\nU 1\r\nR 5\r\nL 3\r\nU 5\r\nR 2\r\nU 5\r\nL 3\r\nD 6\r\nR 6\r\nD 2\r\nR 5\r\nU 3\r\nD 6\r\nU 7\r\nR 7\r\nL 7\r\nU 2\r\nL 6\r\nU 2\r\nR 5\r\nL 7\r\nU 2\r\nD 5\r\nU 2\r\nR 2\r\nU 2\r\nL 1\r\nD 5\r\nU 5\r\nR 2\r\nU 6\r\nR 2\r\nD 3\r\nR 1\r\nD 4\r\nL 3\r\nR 5\r\nU 7\r\nD 6\r\nU 5\r\nD 2\r\nL 5\r\nU 5\r\nL 5\r\nR 7\r\nU 3\r\nL 7\r\nU 7\r\nL 3\r\nU 5\r\nD 7\r\nL 4\r\nD 6\r\nL 2\r\nU 7\r\nD 1\r\nL 6\r\nR 6\r\nD 7\r\nU 5\r\nL 2\r\nD 7\r\nU 1\r\nD 5\r\nL 2\r\nU 2\r\nD 1\r\nU 7\r\nR 1\r\nD 3\r\nL 4\r\nD 5\r\nR 4\r\nL 6\r\nR 1\r\nL 1\r\nD 2\r\nR 5\r\nU 4\r\nL 2\r\nD 7\r\nR 1\r\nU 3\r\nL 2\r\nU 3\r\nL 2\r\nU 6\r\nD 1\r\nU 3\r\nL 2\r\nU 4\r\nR 3\r\nL 7\r\nD 7\r\nR 6\r\nL 1\r\nR 3\r\nU 1\r\nR 3\r\nD 5\r\nR 2\r\nU 4\r\nR 1\r\nU 1\r\nL 6\r\nD 7\r\nU 5\r\nD 1\r\nR 2\r\nU 1\r\nL 6\r\nR 6\r\nU 6\r\nD 1\r\nU 4\r\nD 4\r\nU 4\r\nL 2\r\nD 5\r\nU 4\r\nR 4\r\nU 7\r\nD 4\r\nU 5\r\nD 5\r\nU 8\r\nL 6\r\nU 5\r\nL 1\r\nD 5\r\nR 1\r\nD 7\r\nL 8\r\nU 4\r\nR 7\r\nU 7\r\nD 4\r\nL 4\r\nU 7\r\nD 1\r\nR 4\r\nL 2\r\nU 2\r\nR 7\r\nL 1\r\nR 2\r\nL 2\r\nR 1\r\nL 3\r\nD 7\r\nL 3\r\nD 7\r\nU 6\r\nL 1\r\nD 4\r\nU 2\r\nD 8\r\nR 4\r\nD 2\r\nR 7\r\nL 8\r\nU 5\r\nL 7\r\nU 5\r\nR 1\r\nD 4\r\nR 8\r\nL 2\r\nR 7\r\nL 4\r\nU 6\r\nR 3\r\nD 6\r\nL 8\r\nR 5\r\nU 5\r\nR 1\r\nD 3\r\nU 8\r\nR 3\r\nD 5\r\nL 1\r\nD 2\r\nR 8\r\nD 3\r\nR 6\r\nL 2\r\nR 1\r\nU 5\r\nR 5\r\nU 7\r\nL 3\r\nR 3\r\nL 8\r\nD 5\r\nL 2\r\nD 3\r\nL 5\r\nD 6\r\nL 5\r\nU 2\r\nR 3\r\nU 5\r\nR 7\r\nD 2\r\nU 5\r\nR 2\r\nD 3\r\nL 5\r\nR 1\r\nU 7\r\nL 5\r\nD 5\r\nR 4\r\nU 6\r\nD 8\r\nR 2\r\nD 4\r\nL 3\r\nR 4\r\nD 1\r\nL 7\r\nU 8\r\nL 3\r\nU 6\r\nD 6\r\nL 4\r\nD 1\r\nU 6\r\nL 4\r\nR 2\r\nL 5\r\nD 5\r\nL 5\r\nD 6\r\nR 2\r\nU 1\r\nL 7\r\nR 4\r\nD 9\r\nU 1\r\nL 3\r\nD 7\r\nL 9\r\nD 3\r\nU 9\r\nL 6\r\nD 6\r\nU 5\r\nD 5\r\nR 2\r\nD 8\r\nR 2\r\nD 1\r\nU 9\r\nD 7\r\nR 2\r\nD 3\r\nU 1\r\nL 3\r\nD 5\r\nR 3\r\nL 6\r\nD 7\r\nU 2\r\nR 8\r\nU 2\r\nL 6\r\nD 4\r\nL 5\r\nR 5\r\nL 6\r\nD 5\r\nL 1\r\nU 8\r\nD 1\r\nL 9\r\nD 6\r\nR 5\r\nD 4\r\nU 2\r\nR 9\r\nD 1\r\nU 4\r\nD 1\r\nU 7\r\nL 4\r\nR 4\r\nD 8\r\nU 3\r\nR 7\r\nL 1\r\nD 4\r\nL 9\r\nU 7\r\nL 6\r\nR 2\r\nL 6\r\nD 4\r\nL 8\r\nU 8\r\nL 2\r\nR 1\r\nL 9\r\nD 9\r\nL 2\r\nU 7\r\nL 5\r\nD 2\r\nU 1\r\nL 6\r\nD 6\r\nL 1\r\nR 8\r\nD 3\r\nR 8\r\nL 6\r\nU 7\r\nD 9\r\nU 7\r\nL 7\r\nD 4\r\nR 8\r\nD 3\r\nR 9\r\nL 1\r\nU 4\r\nL 2\r\nR 9\r\nL 3\r\nD 9\r\nR 7\r\nD 3\r\nU 4\r\nD 9\r\nR 4\r\nL 6\r\nU 9\r\nD 7\r\nU 8\r\nD 7\r\nL 1\r\nR 2\r\nU 3\r\nD 7\r\nU 5\r\nR 4\r\nL 8\r\nD 9\r\nL 1\r\nU 9\r\nL 1\r\nD 1\r\nL 2\r\nU 2\r\nR 8\r\nD 6\r\nL 4\r\nU 9\r\nL 3\r\nR 9\r\nU 4\r\nL 5\r\nR 6\r\nU 6\r\nD 6\r\nL 5\r\nD 4\r\nL 9\r\nR 1\r\nL 3\r\nD 8\r\nL 1\r\nR 2\r\nD 8\r\nU 10\r\nL 1\r\nD 8\r\nL 4\r\nU 7\r\nD 4\r\nR 10\r\nD 5\r\nL 5\r\nU 10\r\nR 3\r\nU 6\r\nL 10\r\nR 2\r\nU 5\r\nR 7\r\nL 5\r\nR 6\r\nU 4\r\nD 8\r\nU 8\r\nD 7\r\nR 8\r\nU 3\r\nD 7\r\nR 4\r\nD 4\r\nL 8\r\nR 2\r\nU 9\r\nR 1\r\nL 7\r\nR 6\r\nD 2\r\nU 9\r\nR 4\r\nD 9\r\nR 7\r\nD 6\r\nU 3\r\nL 4\r\nD 9\r\nL 9\r\nD 8\r\nL 4\r\nR 4\r\nU 6\r\nD 2\r\nU 3\r\nD 1\r\nL 1\r\nR 10\r\nL 1\r\nD 2\r\nR 4\r\nU 6\r\nL 3\r\nD 4\r\nL 4\r\nD 1\r\nL 9\r\nD 8\r\nR 5\r\nD 3\r\nU 2\r\nD 9\r\nR 10\r\nD 10\r\nR 10\r\nU 5\r\nD 4\r\nR 4\r\nD 4\r\nL 8\r\nD 4\r\nR 10\r\nD 9\r\nL 8\r\nD 1\r\nR 1\r\nD 8\r\nL 1\r\nD 8\r\nR 4\r\nU 8\r\nR 4\r\nU 4\r\nL 4\r\nU 8\r\nD 4\r\nL 8\r\nD 3\r\nU 3\r\nR 5\r\nD 9\r\nL 10\r\nR 8\r\nU 5\r\nL 4\r\nU 8\r\nR 6\r\nD 3\r\nL 8\r\nU 11\r\nD 4\r\nR 3\r\nL 5\r\nD 10\r\nU 11\r\nD 2\r\nL 5\r\nD 4\r\nR 4\r\nD 5\r\nR 11\r\nL 7\r\nU 9\r\nR 6\r\nL 7\r\nD 6\r\nR 4\r\nD 4\r\nU 9\r\nR 6\r\nD 2\r\nU 3\r\nD 8\r\nL 6\r\nU 6\r\nR 11\r\nU 10\r\nR 6\r\nL 5\r\nR 4\r\nD 1\r\nL 10\r\nR 5\r\nU 4\r\nR 3\r\nD 4\r\nU 9\r\nR 8\r\nD 4\r\nU 11\r\nL 2\r\nD 9\r\nU 5\r\nR 3\r\nD 4\r\nR 6\r\nU 11\r\nR 4\r\nD 2\r\nL 1\r\nR 1\r\nU 4\r\nL 5\r\nU 9\r\nL 8\r\nR 6\r\nD 11\r\nL 4\r\nD 5\r\nL 11\r\nD 7\r\nU 11\r\nD 3\r\nU 3\r\nL 5\r\nR 9\r\nD 2\r\nL 9\r\nR 7\r\nL 3\r\nD 7\r\nL 10\r\nD 1\r\nL 5\r\nU 8\r\nD 1\r\nL 5\r\nU 11\r\nD 8\r\nR 6\r\nD 9\r\nU 2\r\nD 11\r\nR 8\r\nU 5\r\nD 6\r\nR 1\r\nU 7\r\nD 10\r\nL 8\r\nD 2\r\nL 7\r\nD 9\r\nR 12\r\nU 11\r\nR 8\r\nD 9\r\nR 1\r\nD 10\r\nL 3\r\nR 10\r\nD 9\r\nL 2\r\nR 3\r\nD 6\r\nL 12\r\nU 3\r\nR 2\r\nU 11\r\nR 8\r\nL 12\r\nD 9\r\nR 10\r\nL 2\r\nD 6\r\nL 8\r\nU 4\r\nR 5\r\nU 8\r\nL 11\r\nR 7\r\nD 3\r\nL 2\r\nR 2\r\nU 4\r\nR 12\r\nL 8\r\nU 1\r\nR 5\r\nL 9\r\nD 7\r\nR 9\r\nD 8\r\nL 2\r\nR 12\r\nL 5\r\nD 6\r\nR 10\r\nU 11\r\nR 12\r\nL 9\r\nD 5\r\nL 7\r\nU 7\r\nR 9\r\nL 10\r\nR 11\r\nU 11\r\nD 8\r\nL 3\r\nU 10\r\nD 1\r\nR 11\r\nL 7\r\nR 5\r\nL 11\r\nD 6\r\nU 5\r\nD 5\r\nU 12\r\nD 7\r\nL 1\r\nR 3\r\nD 8\r\nL 10\r\nR 2\r\nD 10\r\nR 12\r\nU 10\r\nR 7\r\nU 12\r\nR 11\r\nU 5\r\nD 12\r\nR 6\r\nD 1\r\nU 2\r\nL 8\r\nR 7\r\nD 12\r\nU 5\r\nR 10\r\nL 2\r\nR 3\r\nD 10\r\nU 2\r\nL 8\r\nD 6\r\nR 12\r\nL 5\r\nR 7\r\nU 1\r\nR 2\r\nL 5\r\nD 1\r\nU 12\r\nL 2\r\nU 6\r\nD 8\r\nU 3\r\nD 11\r\nL 5\r\nR 6\r\nL 10\r\nU 9\r\nD 6\r\nR 5\r\nL 4\r\nR 6\r\nL 9\r\nD 12\r\nU 7\r\nL 2\r\nD 6\r\nL 1\r\nU 1\r\nR 7\r\nL 13\r\nD 8\r\nU 4\r\nL 5\r\nD 11\r\nU 12\r\nR 5\r\nU 7\r\nD 5\r\nL 4\r\nD 9\r\nL 9\r\nU 1\r\nL 9\r\nU 1\r\nL 2\r\nU 13\r\nL 2\r\nR 11\r\nL 7\r\nR 8\r\nU 11\r\nD 13\r\nU 10\r\nR 5\r\nU 5\r\nL 6\r\nR 7\r\nD 5\r\nL 1\r\nR 5\r\nU 6\r\nD 13\r\nU 4\r\nL 10\r\nU 6\r\nL 3\r\nU 7\r\nR 6\r\nU 4\r\nL 11\r\nU 7\r\nL 6\r\nR 13\r\nU 10\r\nR 11\r\nD 11\r\nU 9\r\nD 2\r\nU 4\r\nR 9\r\nL 11\r\nR 7\r\nU 1\r\nL 5\r\nU 8\r\nD 5\r\nL 12\r\nU 3\r\nD 7\r\nL 2\r\nR 6\r\nL 4\r\nD 12\r\nU 5\r\nR 12\r\nL 13\r\nD 6\r\nU 3\r\nL 11\r\nR 4\r\nL 3\r\nR 8\r\nU 12\r\nD 11\r\nU 3\r\nR 10\r\nU 12\r\nL 7\r\nD 10\r\nR 1\r\nU 5\r\nL 1\r\nU 13\r\nD 12\r\nU 1\r\nL 2\r\nR 12\r\nD 13\r\nR 2\r\nD 6\r\nL 12\r\nU 10\r\nR 14\r\nU 14\r\nR 2\r\nD 4\r\nL 10\r\nR 7\r\nU 14\r\nL 5\r\nD 7\r\nL 12\r\nR 2\r\nD 9\r\nR 8\r\nD 2\r\nR 4\r\nU 5\r\nL 9\r\nR 13\r\nL 14\r\nR 1\r\nU 8\r\nR 12\r\nU 10\r\nD 2\r\nR 5\r\nU 8\r\nD 4\r\nU 9\r\nD 3\r\nR 5\r\nD 7\r\nL 8\r\nR 11\r\nD 2\r\nU 11\r\nL 4\r\nR 2\r\nU 2\r\nD 10\r\nU 14\r\nL 3\r\nR 3\r\nD 3\r\nR 14\r\nL 2\r\nR 6\r\nD 9\r\nU 1\r\nL 14\r\nR 9\r\nL 7\r\nR 10\r\nU 7\r\nL 14\r\nR 11\r\nL 11\r\nD 10\r\nR 11\r\nU 13\r\nL 2\r\nD 7\r\nL 4\r\nD 10\r\nL 10\r\nR 12\r\nD 7\r\nR 14\r\nL 13\r\nD 8\r\nR 5\r\nL 12\r\nD 6\r\nR 5\r\nD 3\r\nU 6\r\nL 10\r\nD 6\r\nR 8\r\nU 9\r\nR 4\r\nD 7\r\nR 6\r\nD 12\r\nR 5\r\nD 6\r\nL 14\r\nU 12\r\nL 10\r\nU 14\r\nD 12\r\nL 12\r\nR 2\r\nU 14\r\nR 14\r\nD 11\r\nR 14\r\nU 12\r\nD 2\r\nU 10\r\nR 4\r\nU 7\r\nD 9\r\nU 10\r\nD 12\r\nU 8\r\nD 10\r\nL 3\r\nR 8\r\nL 5\r\nD 2\r\nR 6\r\nL 1\r\nD 8\r\nU 3\r\nL 4\r\nU 3\r\nR 5\r\nL 10\r\nD 10\r\nU 14\r\nD 2\r\nU 3\r\nR 13\r\nL 7\r\nR 12\r\nL 10\r\nR 14\r\nD 4\r\nL 10\r\nR 3\r\nU 14\r\nL 2\r\nD 15\r\nR 14\r\nD 2\r\nR 14\r\nL 12\r\nD 10\r\nR 3\r\nD 2\r\nL 3\r\nR 3\r\nD 5\r\nL 2\r\nR 1\r\nL 5\r\nD 14\r\nL 8\r\nR 10\r\nL 14\r\nD 8\r\nL 8\r\nD 8\r\nR 15\r\nD 12\r\nU 7\r\nD 13\r\nL 13\r\nU 4\r\nL 7\r\nU 13\r\nR 7\r\nU 12\r\nR 1\r\nD 7\r\nR 5\r\nL 10\r\nR 11\r\nL 15\r\nD 13\r\nL 8\r\nD 12\r\nU 15\r\nL 11\r\nR 10\r\nU 13\r\nR 12\r\nU 6\r\nR 11\r\nD 13\r\nR 8\r\nD 15\r\nL 2\r\nD 5\r\nU 11\r\nR 5\r\nL 13\r\nD 4\r\nR 15\r\nD 13\r\nR 10\r\nL 10\r\nU 1\r\nR 11\r\nU 3\r\nR 5\r\nD 11\r\nU 5\r\nR 6\r\nU 6\r\nD 14\r\nL 2\r\nR 14\r\nU 2\r\nR 1\r\nL 11\r\nU 15\r\nR 2\r\nD 10\r\nL 5\r\nD 3\r\nU 4\r\nD 9\r\nU 2\r\nL 13\r\nR 2\r\nD 7\r\nR 15\r\nD 1\r\nU 9\r\nR 15\r\nL 5\r\nD 4\r\nL 10\r\nD 16\r\nU 8\r\nR 11\r\nL 12\r\nU 5\r\nL 16\r\nR 1\r\nD 10\r\nR 11\r\nL 16\r\nD 4\r\nU 8\r\nD 7\r\nU 13\r\nD 3\r\nR 5\r\nU 9\r\nR 6\r\nU 12\r\nD 4\r\nU 15\r\nL 5\r\nU 15\r\nL 6\r\nU 12\r\nR 8\r\nL 3\r\nR 2\r\nU 3\r\nL 3\r\nR 10\r\nL 11\r\nU 6\r\nD 11\r\nL 4\r\nR 6\r\nD 8\r\nU 14\r\nL 5\r\nD 13\r\nR 13\r\nD 9\r\nL 10\r\nD 16\r\nR 14\r\nL 6\r\nD 7\r\nU 2\r\nL 11\r\nD 14\r\nR 4\r\nU 6\r\nR 7\r\nL 13\r\nU 6\r\nL 8\r\nD 13\r\nR 4\r\nU 13\r\nL 15\r\nU 16\r\nL 8\r\nD 14\r\nL 3\r\nR 7\r\nD 3\r\nU 9\r\nD 7\r\nU 12\r\nR 4\r\nD 3\r\nU 11\r\nD 7\r\nL 9\r\nU 6\r\nL 5\r\nU 12\r\nD 6\r\nR 5\r\nD 9\r\nU 14\r\nD 9\r\nR 6\r\nU 16\r\nR 11\r\nU 16\r\nL 15\r\nR 15\r\nU 10\r\nL 13\r\nD 12\r\nR 4\r\nD 5\r\nL 5\r\nU 1\r\nD 11\r\nR 10\r\nU 7\r\nR 13\r\nU 6\r\nL 6\r\nD 5\r\nR 13\r\nU 13\r\nD 3\r\nU 11\r\nL 4\r\nR 5\r\nU 4\r\nD 5\r\nL 17\r\nR 2\r\nL 12\r\nR 10\r\nL 17\r\nU 1\r\nR 11\r\nD 12\r\nL 10\r\nU 8\r\nL 15\r\nR 8\r\nU 9\r\nL 17\r\nD 13\r\nL 5\r\nR 7\r\nL 1\r\nD 8\r\nR 6\r\nD 1\r\nU 3\r\nD 10\r\nR 6\r\nL 6\r\nU 15\r\nR 1\r\nU 17\r\nL 17\r\nR 4\r\nU 4\r\nR 10\r\nU 12\r\nL 5\r\nD 12\r\nR 14\r\nD 17\r\nR 1\r\nU 1\r\nR 9\r\nU 2\r\nD 4\r\nR 17\r\nL 9\r\nD 5\r\nU 2\r\nL 7\r\nD 8\r\nR 11\r\nU 12\r\nD 13\r\nR 16\r\nL 15\r\nD 15\r\nL 2\r\nR 10\r\nD 16\r\nR 13\r\nD 2\r\nR 6\r\nD 16\r\nL 8\r\nD 2\r\nL 10\r\nU 7\r\nL 14\r\nR 16\r\nL 5\r\nD 5\r\nR 10\r\nL 2\r\nU 13\r\nR 10\r\nL 9\r\nU 1\r\nL 10\r\nR 10\r\nU 14\r\nD 6\r\nR 11\r\nD 4\r\nR 12\r\nD 4\r\nL 1\r\nD 14\r\nL 2\r\nU 3\r\nL 15\r\nU 9\r\nD 12\r\nR 13\r\nD 14\r\nR 5\r\nL 6\r\nD 14\r\nR 14\r\nL 16\r\nR 7\r\nU 7\r\nL 14\r\nR 11\r\nU 9\r\nD 11\r\nU 9\r\nL 10\r\nR 13\r\nL 4\r\nR 12\r\nU 15\r\nR 9\r\nD 10\r\nU 3\r\nR 7\r\nU 1\r\nR 6\r\nD 17\r\nU 16\r\nD 4\r\nR 12\r\nU 3\r\nR 18\r\nD 17\r\nL 8\r\nU 11\r\nD 6\r\nL 9\r\nR 17\r\nL 14\r\nD 1\r\nL 2\r\nD 6\r\nU 13\r\nL 3\r\nR 18\r\nD 4\r\nL 13\r\nU 7\r\nD 6\r\nU 11\r\nL 11\r\nU 8\r\nR 10\r\nL 15\r\nU 4\r\nD 6\r\nR 18\r\nU 17\r\nR 16\r\nD 11\r\nU 5\r\nR 16\r\nL 5\r\nD 16\r\nU 1\r\nR 9\r\nL 10\r\nU 7\r\nR 17\r\nU 8\r\nL 7\r\nR 14\r\nL 11\r\nR 9\r\nD 8\r\nR 9\r\nU 1\r\nR 14\r\nL 15\r\nU 6\r\nL 4\r\nR 3\r\nL 15\r\nU 15\r\nD 17\r\nU 12\r\nD 14\r\nR 13\r\nU 11\r\nD 10\r\nU 16\r\nL 8\r\nR 11\r\nU 6\r\nD 11\r\nU 9\r\nR 15\r\nL 12\r\nU 6\r\nL 13\r\nU 12\r\nR 3\r\nU 16\r\nL 2\r\nU 15\r\nL 15\r\nR 4\r\nD 5\r\nR 8\r\nD 9\r\nL 8\r\nU 7\r\nR 2\r\nD 10\r\nL 12\r\nR 1\r\nU 11\r\nR 17\r\nU 18\r\nD 6\r\nL 12\r\nU 2\r\nR 2\r\nU 14\r\nD 17\r\nL 7\r\nR 12\r\nU 13\r\nD 18\r\nL 8\r\nR 4\r\nU 10\r\nR 10\r\nL 8\r\nU 4\r\nL 1\r\nU 15\r\nL 6\r\nD 6\r\nL 10\r\nR 12\r\nD 2\r\nR 10\r\nU 16\r\nL 12\r\nD 1\r\nR 11\r\nD 10\r\nU 19\r\nR 7\r\nD 18\r\nU 1\r\nD 7\r\nR 3\r\nU 19\r\nR 12\r\nU 5\r\nL 11\r\nU 8\r\nD 12\r\nR 2\r\nD 16\r\nU 14\r\nR 14\r\nD 1\r\nU 17\r\nL 15\r\nD 8\r\nL 18\r\nD 2\r\nL 14\r\nU 10\r\nL 17\r\nD 2\r\nU 14\r\nL 17\r\nU 15\r\nR 18\r\nL 11\r\nR 15\r\nU 4\r\nL 8\r\nD 10\r\nL 17\r\nU 13\r\nR 1\r\nL 10\r\nU 16\r\nR 9\r\nL 4\r\nD 13\r\nR 13\r\nU 10\r\nR 12\r\nL 14\r\nU 10\r\nD 5\r\nR 18\r\nL 8\r\nD 8\r\nR 5\r\nD 19\r\nU 10\r\nR 8\r\nU 12\r\nR 12\r\nD 6\r\nU 7\r\nL 2\r\nU 5\r\nL 6\r\nR 1\r\nD 16\r\nR 16\r\nU 15\r\nR 2\r\nD 15\r\nR 2\r\nD 10\r\nL 4\r\nD 8\r\nR 17\r\nD 6\r\nR 7\r\nU 10\r\nR 8\r\nD 16\r\nR 3\r\nD 17\r\nR 11\r\nD 18\r\nL 3\r\nR 11\r\nD 8\r\nR 14\r\nD 7\r\nU 14\r\nR 12\r\nL 2\r\nR 18\r\nL 6\r\nR 2\r\nD 3\r\nR 18";
            List<String> inputPerLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            Board board = new Board();
            //RopeSegment tail = new RopeSegment(0, 0, board, 'T', true); //tail first so the head is first on the list of segments, thus rendering it on top
            //RopeSegment head = new RopeSegment(0, 0, board, 'H', false, tail);
            int ropeLength = 10;
            Dictionary<int, RopeSegment> segments = new Dictionary<int, RopeSegment>();
            for(int i = ropeLength - 1; i >= 0; i--)
            {
                if(i == ropeLength - 1)
                {
                    segments[i] = new RopeSegment(0, 0, board, char.Parse(i.ToString()), true); //Marker segment with no child
                }
                else
                {
                    segments[i] = new RopeSegment(0, 0, board, char.Parse(i.ToString()), false, segments[i + 1]); //Nonmarker segment with last segment as child
                }

            }
            RopeSegment head = segments[0];
            head.sprite = 'H';

            Console.WriteLine(" == START ==");
            Console.WriteLine(board.Draw());

            bool verbose = false;
            foreach (String line in inputPerLine)
            {
                String[] lineSplit = line.Split(' ');
                string direction = lineSplit[0];
                int steps = int.Parse(lineSplit[1]);
                for (int i = 0; i < steps; i++)
                {
                    (int xoffset, int yoffset) = board.dirToOffsets(direction);
                    head.Move(xoffset, yoffset);
                }
                if (verbose)
                {
                    Console.WriteLine($"== {direction} {steps} ==");
                    Console.WriteLine(board.Draw());
                }
            }

            Console.WriteLine(" == END ==");
            Console.WriteLine(board.Draw());

            Console.WriteLine($"Marked squares: {board.markedCoords.Count}!");
            Console.WriteLine(board.Draw(true));
        }
    }
}
