using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Frames
{
    class Program
    {
        static SortedSet<string> results = new SortedSet<string>();
        static List<Frame> frames = new List<Frame>();

        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < k; i++)
            {
                var frame = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                frames.Add(new Frame(frame[0], frame[1]));
            }

            GenerateFramePermutations(0);

            Console.WriteLine(results.Count);

            if (results.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, results));
            }
        }

        private static void GenerateFramePermutations(int k)
        {
            if (k >= frames.Count)
            {
                string permutation = string.Join(" | ", frames);
                results.Add(permutation);
                return;
            }
            else
            {
                for (int i = k; i < frames.Count; i++)
                {
                    SwapFrames(k, i);
                    GenerateFramePermutations(k + 1);
                    SwapNumbers(frames[k]);
                    GenerateFramePermutations(k + 1);
                    SwapNumbers(frames[k]);
                    SwapFrames(k, i);
                }
            }
        }

        private static void SwapFrames(int k, int i)
        {
            Frame temp = frames[k];
            frames[k] = frames[i];
            frames[i] = temp;
        }

        private static void SwapNumbers(Frame frame)
        {
            int temp = frame.X;
            frame.X = frame.Y;
            frame.Y = temp;
        }
    }

    class Frame
    {
        public Frame(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
    }
}
