using Advent_of_Code_2022.libs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Advent_of_Code_2022
{
    internal class Day17
    {
        //https://adventofcode.com/2022/day/17

        //static string input = "<<>>>";
        //static string input = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";
        static string input = ">>><>>>><<<>>>><<>><>>><<<<>>>><<<<>>><<<>><>>>><>>><><<<><<<>>><>>><<<><<<>>><<>>>><<<><<<<><<<<>>><>>><<<>>>><>><<<>>><<<<>><>>>><<<><<>><><<<><<>>><<<>><<>>><>>>><<<>>>><<<>><<<<>>><>>><<<<>><<<><<<<>>><>>><>>>><<<<><<<<>>><<>><<<<>>>><><<>><<<<>>>><<<<>>><<>>><>><>><>><<<<>>>><<>><<<>>>><>>><<>>><<><<<>><<<<>>><<<<>>>><<<<>>>><<<<>>><<>><<<<>><<<><>><><<>>>><>>>><>><<<<>>>><<<>>><>><<>><<<<>><<<<>>><<<<>><<<<>>><<<>><<><<<<><<>><>>><<<<><>>><<><<>><<>>>><<<<>>>><>>><<<<>>>><<<>><>>>><<<<><>>><<<><<<<>>><>>>><<>>><<>><<<<>><<<>>>><<<<>>><>>><<<<>>><<>><<<<>>><<<>><<>>><<<<><<<>><<>><>>>><<>>><><>>><>>>><<>><<>><<><><<<<>>>><<>><<<><<<>>>><<<>>><<<>>><>><<<<><<>><<<<>><><<>><>><>><<<>><><<>><<<<>>><>><<<>>>><><>>>><<<<>>><<<><<<>>>><<<>>><<<<>><<<>>>><<<>>><>>>><><<<>>><<>><><<<<>>>><<><<>>>><><>><<>>><<>>><<<>><<<>>><<<>>>><<<<>><<<>>><<<<>>><<<<>>><<<<>>><<<<>>><<<>><<>>><>>>><<<>>><<<<><<<<>>>><<<<><<<>>><<><<>>>><>>>><<<<>><><<<>><<<><<<<>><<<>>>><<>>>><<>>>><>>><<>><<<>><<>>><<<><<<<>><<>>>><<>>>><<>>>><<<<>>>><<>>>><<<><<>><<>><<>>><<<>>>><>>>><<<>>>><<<<>>><>>><<<>>>><<<<><>><>>><<>>>><<<<>><<<<>><<<<>>><<<<>>><><<>><<>>>><>>>><<>><<<>>>><<<><>><<<<>>><<<<>>><>>>><<<<>>><>><<><<>>>><<><<><>>><<<<>><>>>><<<<>><<>>><<>>><<>>>><>>><<><><>>>><>>><<<<>><<<<>>><>><<<<>>><>>><>><<<<>>>><<><<<>>>><<<<>>>><<>><<>>><<<<>>><<>>><<<>><<><<<<>><<<>>>><<<<>>><<<>><<<>>>><<<>>><<<<><<<>><>>>><<<><<<<>>><<<<><<<<>><>>>><<<>>><<<>>>><<<<>>>><<<<>>><<<>><<>><<<><<<<><<>>>><<<<>>>><>><>><<<>>><>><<><<<<>><<<>>><>>><<><<<<>>>><>><<<<><<<<><<<<>>><<><<>>>><>><<<><<>>>><>><<<<>>><<<<>>>><<>>><<<<>><<<<>>>><<<<>>>><<<<>><>><>><<<<>>>><<<>>><<>>><><<>>><<<>>>><<<>>>><<>>><<<<>>><<<><<<<>>>><<>>><<<<>><<<>>>><<<>>><<>>><<<<><>><<<>><><<>>>><<>><<><>><><>>>><>>><<<<>><<<<>><><<<<>>>><><<<<>>><<<<>>>><<<<>>><<<>><<>>><<<<>><<<<>><<>>>><<>>>><<<>><<<>>><<<<>><<>>>><<<<><<<<>>>><>>><<<<>>>><<<><<><>><<>>><<<<><>>>><>>>><<<>><<<<>><<>><<<<>>><<>>><>><<<>>><<<>><>>>><<>>><<<>>><<>>>><<>>>><><<<>>><<<<><>>>><<><<<<>>>><<<>><<>><<<<>>>><>>><<<>><<<>>><>>><<>>>><<<><<>>><<<>>>><>>><<<<>><<<<><<<>>>><<>>><<<<>><>>>><>><<<<>><<<>>><>><<>>>><<<><<<><<<<>>>><<>><><<<<>>>><<>>>><<<<>>><><<<<>>>><<>><>><<>>>><<>>>><<<>>>><<<<><<<>>>><>>><<<><<<<><<<<><>>><<<>><<<>><<>>><<<<><<<>>>><>><<><<>><<>>>><<<>>><<<<>><>>><<<><<<<>>>><<>><<><>>>><<<<>>><>><<>>>><<<>>>><<<<>>><<<>>>><<<>><<<<>><<<<>><<<><<<>>>><<<><<>>>><<<<><<<>>><><<<>><<><<<<><<<><<>><<<><><<><<<<>><<>><<>>><<<<><<<>>>><<<>>>><<<<>>><<>>>><<<<><<<<><<<<>>>><<>>>><<<><<<>>>><<><<>>>><<<<>>><><<>>>><<>><>>>><<<<><>>><<<>>>><<<>><>><>><<<<>>><<<>>><><>><>>><>>>><>>><>>><>>>><>>><<>>><<<<>>>><<<><<<<>><<<<>><<<>>><<<<>>><<>>><<<>>>><<<>><<<><<<<>><<<<>>>><<><>>><<<<><>>>><>><<>><<>>><<><<<<>><<><<<<>>>><<>>><<<>>><>>>><<<>>>><>>><<<>>><<<<>>><<<<>><<<>>>><<<<>><<<>><<<<>>><>>>><<>>><<<<>>><<<><>>>><><>><<><>>>><<<>><<>><<<>><<<>>>><<<>>><<<>><<<<>><>>><<<<>>>><<>>>><>>>><>><<<>>><<<<>>><<<>>><<<>>><<<<><>>>><<<>>><<>>>><><<<>>>><<<<>><<<<><<<>>>><<>>><>>>><<<<>>>><<<>>>><<>><>>>><<>>>><<<<>>>><<><<<<><<<<><<<>>>><>>>><<>><<><<>><>><<>>><<<<>><><<<>>>><>><<<<><>><<>>><>><<<>>><<>>>><><><<>><><>><<<>>><<>><<<<>><>>>><<>>><<<>>><<>>><<<<>>><<<><<<>>>><<<><>><<>><<<<>><<>>>><<<<>><<<<>>>><<<<>><>>>><<<>>>><<<<>>>><>>>><>>><<<<>>><><>>><<<>><>>>><<>><<>><<<><<<<>><<>>><><<>><<>><<<>><<<>>>><<<<>>>><<<<>>>><<>>><>>>><<>><><<<<>><<><>>><<<<>>><>>>><><<<>>><<>><<<<>>>><>>><>>>><<<<>><><<<<>>>><<<><><<<<><<<<>>>><<<<>><>>><<<>><<<>>>><<>>><<<><<<>><<<>>><<<><>><>>>><>>>><<<<>>>><><<<>>>><<<<><<<<>>><>>><>><<<>>>><<<>>>><><<<<><<<>>>><<<>><>>><<<<>>>><<>><<>>>><>>>><>>><>><<<>>><<<>>>><>><>>>><>><<<><<>>><<>>>><>><><>>>><<<<>><<<>><<<>><<><<<>>><<<>>>><<<<>><<<>>><>><<<><<<><<>>>><<><<<<>>><<<<>>>><<><><<>><<>>><>>>><><<<<>>><<><>>>><<>><<<>>><<<>>><<<<>><<>>><>><<<><<<>>>><<<<>>><><><><>>>><<<<><<<>>>><<>>>><<<>><<<<>>><>><<<<>><<<<><<<>><<><<<<>><>><>><<<><<><<<<>>><<<>><<<<>>>><<<<>><<<<>><<<<>>>><<<><<<<>>><<<><<<<>><<<<>><<<>>>><<>>><<<<><<>><<<>>>><<>>><<<<>>>><<<<><<<<>><<>>><>>>><>><<<<>>><<><<<<><<<>>>><<<<><<<<>><<<<><<>><>><<>>>><<><<<<>><><<<><>>><<<>>><<><><<<>>>><>><>>><<>>>><<<>>><<<<>>><>>><<<<>>><<<>>>><<<>>><>>>><>><><<<<>><<<<><>>>><<><>>><<>><<<<>><<<<>><<<<>><<<>><>>>><<<<>><<><>>><<>>>><<>>><<<>>>><<<<><<<<>>>><><<<<>>>><<><<<<>>>><<<<><<>><>>><<>>>><<<><<<<>>>><<<>>><<>>><<<<>>>><<<>><><<<<>>>><<>><<<<><<<>><<>><>>><<<>>><<<<>>>><><<<>>>><<<>><<><<<>><<><>>>><<>><>><>>>><<>><<<>>>><<<<>>><>>>><<<>><<<><<>><>>>><<>>>><<<><>>><<<>>>><><<<<>><<<<>><<>><<<>>><<<>>>><<<<>>>><<>>>><>><>>>><<<<>>><<>><<<<>>>><<<<>><<>>>><>>><><>>>><<>><<<<>>><>>><>><><><<<>><<<>>>><<<<><<<>><>><<<<>>><<<>>><<<<><><<>>><<<<>>><<<>>>><<><<>>><><<<<>><><<<<>>><<<>>><>><<<<>><<<<>>>><<<<>>><<>>>><<<<>>><<<>><<<<>>>><<<<>><<<>><<<<>>><<<<>>><<<>>><<<<>>>><<<>>>><<<>><>>>><<><>>>><<>>>><<<<>>><<><<<<>>>><<<<>><<<>><>>><<<<>>><>>>><<<><>>><<<><<<>>>><>>>><<<<>>>><<<<><<<>><>><<><<>>><<>><<>>><<<>>>><<<<>>><<>><<<>>><<>>><<><<<<>>>><<<>>><<>>><<<<>><>>><<>>><<><<>>><<>>><<>>><<<<><<<>>>><<>><<<<>>><<>>>><<<>>><<<<><<<<><<>><<<><<<<>>>><<<>>><<>><<><<<>>><<<>><<<>>>><<<<>>><<>>><<<><>><<<><<>><<<><<<<>><<<<>>>><<<<>><<<<>>>><<><>>><<<>>>><<<<><><><<<><<<<><<<>>><<<>>><<<<>>><<<>>>><<<>><<<>>><<<<>><<<><<<<>>><<>><><>><<<>><<><><<<<>>><<>>>><<>><<>>><<><<>>>><<<<><<>><<>>><<>><<<>>><<<<>>><<>>>><>><<<><<<>><<<<>>>><<<>>><<<<>>><<><<<<><<><>>><<<>><<<<><<<<><><<>><>>><>>>><<<<><<<>><<<><>><<>>>><<>>><<<<><<>>><>>>><<<<>>><>>><<>>><<<>>>><<<>>><<>>><<<<>>>><>><<<<>><<>>><<>>><<<<>>><>><<<<>>>><<<>>>><>>>><<>><<<>>><>><<<<>>><<<>>>><<<<>>>><<<>>><>>><<<<>>><>>><<>><<<<>><<>><<<>><<>><>><<<<>>>><<<><<><<<<>><<>><><>>><>><>>><>>><<<>>>><<>><<<><<>>>><<>>>><>><>>>><><<><<><>>><<<<>><><<<>>><<<<>>><>>><<>><<<>>><<<<>>><<<>><<><<>><><<<<><<<<>><<>>>><<>><<>>>><<<<>>><<<>>>><<><<>>>><<<>><<>>><<>>><<<<>>>><<<>>><><<>><<>><<<<>><<<<>><<>>>><<<>><<<>><<<>><<<<>>><<>>><<<>>>><>><<><><>><><<<>><>>>><>><>><<>>>><<<>>>><>>><<<>><>>>><<><><<><<<><<>>>><>>><<<<>>><<><>>><<<<><>>>><<>><<<><<<>><<>><<<>>>><><<>>><<<>>>><<<<>>><<<>>><<<<>>>><<>>><>>><<<<>>><<><<<>><<<<>>><><<>>>><<>><<>>>><<<<>>>><>>>><<<<>><<<<>>><<>><<<>><<<<><<<>><<><<<<><><<<<><<<><<>>><<<>>><<<<>>><>>>><>>>><<<<>>>><>>>><<<>>>><<<<>>>><<<<>><<<>><><<<<>>>><<<>>><>>><<<>>>><<>>><<<>>><>>>><<<>>><>>>><><<>>>><<<>><<<<>>>><<<<>><>>><<>><<><<><<>><<<>><<>>><<>>>><<<>>>><<<>>><>><<<<>>><<<><<>>>><<>><>>><<>>><<<><<<<><<<><<<<><<<<>>>><<>><<<<>><<<>>><<<>>>><>>>><<<><<<>><<<<>>><<>><<<<>>><<<>>>><<><><<>>>><>><>><<<>>>><>>><<<<><<>>><<>>>><<<>>><><>><<>><<<>>>><<<<>><<<<>>>><<><<<><<<<>><>>>><<<<>><<>>><>>><<<>><<>><<<<>>>><><<>><<<>>>><<>><<<<><>>>><<>>><<><<<>><<>>>><<>>>><>><<<>>><<>><>>>><<<<>><<<><<>>><<<<><<<<>>>><<><>><<<>>><<<>>><<>>>><<<><<<><<<<>>>><<><<<>>>><>><<<>>>><>>><<<<>><<><>><<<><<>><<>><<<><>>>><<<<>>><>>><<<>>><<><<>>>><<>><<<<>>><<<<>><<<><<<<>>>><<<><<<><<<>>><>>><<<<>>>><<<<>>>><<<<><>>>><<<<>><<>><<<<>>><>><<<>>><<><<>>><>><<<>>><<<<>><>>>><<><<<>>><<<>>><<>>>><<><<<<>>>><>>>><>><<<<>><<<><<><<>>>><<<><<<<><<>>><<<<>>>><>>>><<<>>><<<>>><>>>><<<<>>><<<<><<<>>><<<>><>>><>>><>>>><>><<>><<<>>><<<<><<<<>>>><<<<><<<>>>><<<>><<<><<<>>>><<<>><<>><<<<>><<<>>>><>>>><<>>>><<<>>><><<<>>><<<>><<<>>><<>><<<<>>><>>><<>>>><>>>><>>><><<<<>>><<<><<<<>>>><>>>><<<<><<<>>><<<>>>><<<<>>>><<<<>>><<>>><<>>>><<>>>><<<<><<<<>><<<<><<>>><>>><<>>>><>>>><<<<>>><<<<>>>><<<><<<>>><<<>><<<<>>><><<<<>>><>><<>>>><<<>><<>>>><<<<>><<><<<>><<<<><<<<><<<<>><>>><<<><<<><<>>><<<<>><<>>><>>>><<<<>>><<<<>>>><<<>>>><<<>>>><<>><<>>><<<>>><<<>>><<>>>><<<<><<<>>>><<<><<<<>>><<<>><<>>>><<>><<<>>>><<<<><<<>>><<>><<<<>><<<<>><<>>>><>>><<><<>>><<><<<>><><>>>><>><>><<>>>><>>>><<<<><<><<<<>>>><<><<<>>><><<<>>><>>><<<<>><<<<>><<<<><<>>>><<<<>><<<>>><>><<>><<<>><<>>><<<<><<<>>><<>>>><<>>><<<<>>>><<><<<<>><<<>><<<>><<><>>><<>><<<>>>><<>>>><<>><<<>><<<<>>>><<>><<<<>>><<<>>>><<<<><<<><<<>>><<<><<<<>>>><<<<><<<<>>><<><<<><<>>><<>><<<<>>><<<>>><>><<<<><<>>><>>>><<<<>>>><<>>><><<<<>>>><<<>>>><<<>><<<>>><<<<>><>><<><<<<>><<<>>><<<<>><>>><<<<>>>><<<<>>><>>>><<<<>><<><><<<><<>>>><<>>><<<><><<>>><<<<>>><<>><<<><>>>><<<<>>><<><><<<<><<>>><<>>>><<<<>>><<><>>>><><>>>><<>><<<<><<>>><<><<<<><><<>>><<<<>><<<>><><<<><<<<><<<<><<><>>>><<>><<><<>>>><>>><<<><>><>>>><<><<<<>>><<<<><><><><<<<>>><<<><<<<>>><<<<><<<<><<<<>><<<<><<<<><<<<>>>><<>>>><><<>>>><>>>><<>><<<>>>><><<>>><<<<><>>>><<>>>><<<>>>><<<>><<<<>><<<>><><><<>>>><<>><<><><<><<>><<<<><><<><>>><<<>>><<<<>>>><<>>>><<<><<<<><<>><<<<><>><<<<><<><<<>><<<<>>><<<>><<><<<<>>>><>>><<<<><<<<>><<<>>>><<><><>>>><<<><<<<><<<<><<>><<><<<><<>>>><<<>><>><<>><<<>><<<<>><>><<>>><>>>><>>><>>><<<<>>><<<<><<<<>><<<<>><<>>><>>><<<<>><<>><>>>><<<>>>><<><<<><<<>>>><>>><>><<>>>><<<>><<>>><<>>>><<<>>>><<>>><<<<>><>>><<>>>><>><<>><<<<>>><<>>>><<<<>>><<<<>><<<>>>><<<<>>>><<<><<<>><<><<<<><<<>><<<>>>><>>><<<<>>><><<<><<<<>><<><<<<>>>><>>>><<<<>>>><<<<>>><<<><<<>><>><<<<>>><<<><>>><<>>>><>>><<<>>><<<>>>><>><<<>>><<<><>>><<<>>><<<>>><<><<<<>><>>>><<<<>>><>>><>><>><<<<><<<<>>>><<<<>>>><>>>><<>>>><<<>>><>><<<>>>><<>><><<>><>><<<>><><<>>>><<>>><<<<><<>><<<>>>><><>>>><<><<<>>>><><<<>>>><<>><<<>>>><<<>>><<<<><>>>><<>><<><>>>><<<>>>><><<<<>>><<<<>><<>>>><>>>><>><<<>><<<<>>><<>>>><<>><<<<><<<>>>><>><<><>>><<<<>><<<<><>><><<><<<>>><<<<>>>><<>>><>>><<<>>><<<<>><<>><<><<<><<<<>>><<<<>>>><>><<<<>>><<<<>>><<<<><<>>>><<<>><<>><<>><>><>><<<>>>><<>><<>>>><>>><<<>>><>>>><<<>><<<<>>>><<<<><<<<>>><<>><<<<><<<>>><<>>><<<<>>>><<<>>><<><<<><>>><<>>>><<<>>>><<<>>><<<<>><<<>><>>>><<<>>><<<>>><<<>>><<<>><<<<>>><<<><>>><<<<>>>><<><<>><><><<>><<>><<<><<<<>>>><<>><>><<><<<<>>><><<>>><<<>><<<><<<>><<>><<><>>>><<<>>>><<>>>><<<<>><>>>><<>>><<><<<>>>><>><<<>>><<>>><<<<><<>>>><<<>>>><<>><>>>><<<<>><<<>>><><<><<>>>><<>>><<<>><<<>>><<<<><<>>>><<>>>><<><<<>><<<<>>>><>><<<>>>><<<<>>><>>><<<<><<><<>>><><<<><<<>><<<<>><<>>><>><<<>>>><<<<>>><<<<>><<<<><<<>>><<<>>><<<<>>>><<<><>>>><<<<>>><<>><<<>>><<<>><<<<>>><<><<<<>>><<<><<<><<<>><<>>>><<<<>>>><<<>><<<>>>><<<<><>>>><>>>><<<>>><<<<>>><<>><><<<>><<<><<<>>><<";

        static readonly List<Type> pieceOrder = new List<Type>() { typeof(Minus), typeof(Cross), typeof(Corner), typeof(Line), typeof(Block) };

        public static void Run()
        {
            Board board = new(0, 0, 6, 3, '.', '#');

            long piecesAtRest = 0;
            long rockPushes = 0;

            while (true)
            {
                Piece piece = SpawnPiece(board, pieceOrder, piecesAtRest);

                bool pieceIsActive = true;
                while (pieceIsActive)
                {
                    RockPush(piece, input, rockPushes);
                    rockPushes++;

                    if (!FallPiece(piece))
                    {
                        pieceIsActive = false;
                        
                    }
                }

                piecesAtRest++;
                board.UpdateMaxY(piece);

                if (piecesAtRest % 50 == 0)
                {
                    board.TrimTheFat();
                }

                if (piecesAtRest == 2022)
                {
                    GridRenderer.Render(5, 10, board.MakeGrid());
                    Console.WriteLine(board.highestRockY);
                    return;
                }
            }
        }

        /// <summary>
        /// Attempts to push a rock piece according to the jet pattern of the cave.
        /// </summary>
        /// <param name="piece">The piece to push.</param>
        /// <param name="pattern">Pattern of rock pushes e.g. "<>><>>>><<".</param>
        /// <param name="rockPushes">How many times has a push happened so far?</param>
        /// <returns>true if the piece was successfully moved, false if the piece was not moved (due to colliding with the walls or another piece).</returns>
        public static bool RockPush(Piece piece, string pattern, long rockPushes)
        {
            int index = (int)rockPushes % pattern.Length;
            char direction = pattern[index];

            int xOffset = direction == '>' ? 1 : -1;

            if (piece.loc.X + xOffset < 0 || piece.loc.X + piece.width + xOffset > piece.board.maxx + 1)
            {
                return false;
            }
            // To check if pushing us would make us collide with another piece, we actually get pushed,
            // then we check if we're colliding, and if so, we undo the push.
            piece.Shift(xOffset, 0);
            if (piece.board.IsPieceColliding(piece))
            {
                piece.Shift(-xOffset, 0);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Attempts to apply gravity on a piece to make it fall.
        /// </summary>
        /// <param name="piece">The piece to make fall.</param>
        /// <returns>True if the piece was successfully moved, false if the piece is firmly at rest (due to landing on the floor or on another piece).</returns>
        public static bool FallPiece(Piece piece)
        {
            if (piece.loc.Y - 1 < 0)
            {
                return false;
            }
            // To check if falling would make us collide with another piece, we actually fall 1 tile,
            // then we check if we're colliding, and if so, we undo the fall.
            piece.Shift(0, -1);
            if (piece.board.IsPieceColliding(piece))
            {
                piece.Shift(0, 1);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Spawns a piece on the board. The type of piece to spawn is determined from the piece order and how many pieces are already at rest.
        /// </summary>
        /// <param name="board">The board to spawn in.</param>
        /// <param name="pieceOrder">A list of Types of piece, specifying the order of pieces to cycle through.</param>
        /// <param name="piecesAtRest">How many pieces have been spawned so far?</param>
        /// <returns></returns>
        public static Piece SpawnPiece(Board board, List<Type> pieceOrder, long piecesAtRest)
        {
            int index = (int)piecesAtRest % pieceOrder.Count;
            Type pieceType = pieceOrder[index];
            Point loc = new(2, board.highestRockY + 3);
            Piece? piece = (Piece?)Activator.CreateInstance(pieceType, loc, board);
            if (piece == null)
            {
                throw new Exception("Piece is somehow null!");
            }
            board.AddPiece(piece);
            return piece;
        }

        public class Board
        {
            public int minx, miny, maxx, maxy;
            public char defaultChar;
            public char pieceChar;

            public int highestRockY = 0;

            public HashSet<Piece> pieces = new();

            public Board(int minx, int miny, int maxx, int maxy, char defaultChar, char pieceChar)
            {
                this.minx = minx;
                this.miny = miny;
                this.maxx = maxx;
                this.maxy = maxy;
                this.defaultChar = defaultChar;
                this.pieceChar = pieceChar;
            }

            /// <summary>
            /// Tries to clean up the board by removing pieces that no longer matter.
            /// It does this by finding a row of solid blocks (or 2 rows that, when combined, make a solid row) and defining that as the new bottom,
            /// deleting all pieces under that row.
            /// </summary>
            public void TrimTheFat()
            {
                for (int y = highestRockY; y > miny; y--)
                {
                    if (RowIsSolid(y))
                    {
                        foreach (Piece piece in pieces)
                        {
                            if (piece.loc.Y + piece.height < y)
                            {
                                pieces.Remove(piece);
                            }
                        }
                        miny = y - 2;
                        return;
                    }
                }
            }

            public bool RowIsSolid(int y)
            {
                for (int x = 0; x <= maxx; x++)
                {
                    bool top = IsPointColliding(new Point(x, y));
                    bool bottom = IsPointColliding(new Point(x, y - 1));
                    if (!top && !bottom)
                    {
                        return false;
                    }
                }
                return true;
            }

            public void AddPiece(Piece piece)
            {
                pieces.Add(piece);
                //UpdateMaxes(piece);
            }

            public void UpdateMaxY(Piece piece)
            {
                highestRockY = Math.Max(highestRockY, piece.loc.Y + piece.height);
                maxy = highestRockY + 2;
            }

            /// <summary>
            /// Returns true if this piece is colliding with the other pieces on the board.
            /// </summary>
            public bool IsPieceColliding(Piece piece)
            {
                foreach (Piece otherPiece in pieces)
                {
                    if (otherPiece == piece)
                    {
                        continue;
                    }
                    if (piece.CollidesWith(otherPiece))
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Returns true if any piece in this board is colliding with this point.
            /// </summary>
            public bool IsPointColliding(Point point)
            {
                foreach (Piece piece in pieces)
                {
                    if (piece.CollidesWith(point))
                    {
                        return true;
                    }
                }
                return false;
            }

            public char DrawPoint(Point point)
            {
                if (IsPointColliding(point))
                {
                    return pieceChar;
                }
                return defaultChar;
            }

            public char[,] MakeGrid()
            {
                int height = maxy - miny + 1;
                int width = maxx - minx + 1;

                char[,] grid = new char[width, height];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        grid[x, y] = DrawPoint(new Point(x + minx, y + miny));
                    }
                }
                return grid;
            }
        }

        public class Piece
        {
            public Point loc; //Bottomleftmost corner of our bounding box
            public List<Point> points = new(); //Collection of points that make us up

            public Board board;

            public int width;
            public int height;

            public void Shift(int x, int y)
            {
                loc.Offset(x, y);
                for (int i = 0; i < points.Count; i++)
                {
                    Point point = points[i];
                    point.Offset(x, y);
                    points[i] = point;
                }
            }

            public bool CollidesWith(Point point)
            {
                if (point.Y < loc.Y || point.Y > loc.Y + height || point.X < loc.X || point.X > loc.X + width)
                {
                    return false;
                }
                foreach (Point p in points)
                {
                    if (point.Equals(p))
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool CollidesWith(Piece otherPiece)
            {
                if (otherPiece.loc.X > loc.X + width || otherPiece.loc.X + otherPiece.width < loc.X
                    || otherPiece.loc.Y > loc.Y + height || otherPiece.loc.Y + otherPiece.height < loc.Y)
                {
                    return false;
                }
                foreach (Point point in points)
                {
                    if (otherPiece.CollidesWith(point))
                    {
                        return true;
                    }
                }
                return false;
            }

            public Piece(Point loc, Board board, List<(int, int)> pointCoords)
            {
                this.loc = loc;
                this.board = board;

                foreach ((int, int) offset in pointCoords)
                {
                    points.Add(new Point(loc.X + offset.Item1, loc.Y + offset.Item2));
                }
                width = pointCoords.Max(coord => coord.Item1) + 1;
                height = pointCoords.Max(coord => coord.Item2) + 1;
            }
        }
        public class Cross : Piece
        {
            readonly static List<(int, int)> pointCoords = new() { (1, 0), (0, 1), (1, 1), (2, 1), (1, 2) };

            public Cross(Point loc, Board board) : base(loc, board, pointCoords)
            {
            }
        }
        public class Minus : Piece
        {
            readonly static List<(int, int)> pointCoords = new() { (0, 0), (1, 0), (2, 0), (3, 0) };
            public Minus(Point loc, Board board) : base(loc, board, pointCoords)
            {
            }
        }
        public class Corner : Piece
        {
            readonly static List<(int, int)> pointCoords = new() { (0, 0), (1, 0), (2, 0), (2, 1), (2, 2) };

            public Corner(Point loc, Board board) : base(loc, board, pointCoords)
            {
            }
        }
        public class Line : Piece
        {
            readonly static List<(int, int)> pointCoords = new() { (0, 0), (0, 1), (0, 2), (0, 3) };

            public Line(Point loc, Board board) : base(loc, board, pointCoords)
            {
            }
        }
        public class Block : Piece
        {
            readonly static List<(int, int)> pointCoords = new() { (0, 0), (1, 0), (0, 1), (1, 1) };

            public Block(Point loc, Board board) : base(loc, board, pointCoords)
            {
            }
        }
    }
}
