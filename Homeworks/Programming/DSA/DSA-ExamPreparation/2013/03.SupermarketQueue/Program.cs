using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wintellect.PowerCollections;

namespace _03.SupermarketQueue
{
    class Program
    {

        static BigList<string> list = new BigList<string>();
        static Dictionary<string, int> bla = new Dictionary<string, int>();

        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] command = line.Split(' ');
                string commandName = command[0];
                switch (commandName)
                {
                    case "Append": Append(command);
                        break;
                    case "Serve": Serve(command);
                        break;
                    case "Find": Find(command);
                        break;
                    case "Insert": Insert(command);
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(sb.ToString());
        }

        private static void Insert(string[] command)
        {
            int position = int.Parse(command[1]);
            string name = command[2];

            if (position == 0)
            {
                list.AddToFront(name);
                if (!bla.ContainsKey(name))
                {
                    bla.Add(name, 0);
                }

                bla[name]++;

                sb.AppendLine("OK");
            }
            else if (position == list.Count)
            {
                list.Add(name);
                if (!bla.ContainsKey(name))
                {
                    bla.Add(name, 0);
                }

                bla[name]++;

                sb.AppendLine("OK");
            }
            else if (position > list.Count)
            {
                sb.AppendLine("Error");
            }
            else
            {
                list.Insert(position, name);

                sb.AppendLine("OK");
                if (!bla.ContainsKey(name))
                {
                    bla.Add(name, 0);
                }

                bla[name]++;
            }
        }

        private static void Find(string[] command)
        {
            string name = command[1];

            if (!bla.ContainsKey(name))
            {
                sb.AppendLine("0");
                return;
            }

            int count = bla[name];

            sb.AppendLine(count.ToString());
        }

        private static void Serve(string[] command)
        {
            int count = int.Parse(command[1]);

            if (count > list.Count)
            {
                sb.AppendLine("Error");
            }
            else
            {
                var served = list.GetRange(0, count);
                foreach (var chuek in served)
                {
                    bla[chuek]--;
                }

                list.RemoveRange(0, count);

                sb.AppendLine(string.Join(" ", served));
            }
        }

        private static void Append(string[] command)
        {
            var name = command[1];
            list.Add(name);
            if (!bla.ContainsKey(name))
            {
                bla.Add(name, 0);
            }

            bla[name]++;

            sb.AppendLine("OK");
        }
    }
}
