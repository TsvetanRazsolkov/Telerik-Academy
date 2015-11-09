using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stools
{
    class Stool
    {
        public Stool(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }
    }

    class Program
    {
        static Stool[] stools;
        static int n;
        static int[, ,] memo;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            stools = new Stool[n];
            memo = new int[1 << n, n, 3];
            //memo = new int[1 << n, 16, 4];

            // read input
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                stools[i] = new Stool(
                    int.Parse(line[0]),
                    int.Parse(line[1]),
                    int.Parse(line[2])
                    );
            }

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result = Math.Max(result, MaxHeight((1 << n) - 1, i, j));
                }
            }

            Console.WriteLine(result);
        }

        static int MaxHeight(int usedMask, int topIndex, int side)
        {
            if (usedMask == (1 << topIndex))
            {
                if (side == 0) // say that this is when X is the height
                {
                    return stools[topIndex].X;
                }
                if (side == 1) // say that this is when Y is the height
                {
                    return stools[topIndex].Y;
                }
                // say that this is when Z is the height
                return stools[topIndex].Z;
            }

            if (memo[usedMask, topIndex, side] != 0)
            {
                return memo[usedMask, topIndex, side];
            }

            // This gives s mask wuth all stools indices accept the top one
            int fromStools = usedMask ^ (1 << topIndex);

            //int baseSideOne, baseSideTwo, height;

            //if (side == 0)
            //{
            //    baseSideOne = stools[topIndex].X;
            //    baseSideTwo = stools[topIndex].Y;
            //    height = stools[topIndex].Z;
            //}

            //if (side == 1)
            //{
            //    baseSideOne = stools[topIndex].Y;
            //    baseSideTwo = stools[topIndex].X;
            //    height = stools[topIndex].Z;
            //}
            //else
            //{
            //    baseSideOne = stools[topIndex].Z;
            //    baseSideTwo = stools[topIndex].X;
            //    height = stools[topIndex].Y;
            //}

            int baseSideOne = (side == 0) ? stools[topIndex].Y : stools[topIndex].X;
            int baseSideTwo = (side == 2) ? stools[topIndex].Y : stools[topIndex].Z;
            int height = stools[topIndex].X + stools[topIndex].Y + stools[topIndex].Z - baseSideOne - baseSideTwo;

            int result = height;

            for (int i = 0; i < n; i++)
            {
                if (((fromStools >> i) & 1) == 1)
                {
                    // side of stools[i] == 0
                    if ((stools[i].Y >= baseSideOne && stools[i].Z >= baseSideTwo)
                        || (stools[i].Y >= baseSideTwo && stools[i].Z >= baseSideOne))
                    {
                        result = Math.Max(result, MaxHeight(fromStools, i, 0) + height);
                    }

                    if (stools[i].X == stools[i].Y && stools[i].X == stools[i].Z)
                    {
                        continue;
                    }

                    // side of stools[i] == 1
                    if ((stools[i].X >= baseSideOne && stools[i].Z >= baseSideTwo)
                        || (stools[i].X >= baseSideTwo && stools[i].Z >= baseSideOne))
                    {
                        result = Math.Max(result, MaxHeight(fromStools, i, 1) + height);
                    }

                    // side of stools[i] == 2
                    if ((stools[i].X >= baseSideOne && stools[i].Y >= baseSideTwo)
                        || (stools[i].X >= baseSideTwo && stools[i].Y >= baseSideOne))
                    {
                        result = Math.Max(result, MaxHeight(fromStools, i, 2) + height);
                    }
                }
            }

            memo[usedMask, topIndex, side] = result;
            return result;
        }
    }
}
