
/*Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file).
Print how many times each word occurs in the text.
Hint: you may find a C# trie in Internet.*/
namespace _03.FindWordsInLargeText
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var trie = new Trie();

            // File is smaller than 100MB due to uploading restrictions, but you can make it bigger by doing 10-15 copy/pastes of its content :)
            var words = new StreamReader("..\\..\\someText.txt").ReadToEnd().Split(new char[] { '.', '!', '?', ';', ' ', ':', ',', '-', '<', '>', '/', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                trie.AddWord(word);
            }

            var result = new StringBuilder();

            var searchedWords = new StreamReader("..\\..\\searchedWords.txt").ReadToEnd().Split(new char[] { '.', '!', '?', ';', ' ', ':', ',', '-', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int occurs = 0;
            foreach (var word in searchedWords)
            {
                result.Append(word);
                result.Append(" -> ");
                trie.TryFindWord(word, out occurs);
                result.Append(occurs);
                result.AppendLine(" times");
            }

            Console.Write(result.ToString());
        }
    }
}
