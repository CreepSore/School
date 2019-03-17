using System;
using System.Collections.Generic;

namespace Files_Strings_Arrays
{
    public static class StringUtils
    {
        /*
         * Made Functions public so I can access it from Program.cs
         */

        public static int CountLines(string path)
        {
            if(!System.IO.File.Exists(path)) return -1;
            string text = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8).Trim();
           
            return text.Split('\n').Length;
        }

        public static int CountWords(string path)
        {
            if (!System.IO.File.Exists(path)) return -1;
            string text = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8);
            string toReplace = ",.\n\r";
            foreach (char c in toReplace)
            {
                text = text.Replace(c, ' ');
            }

            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }

            return text.Split(' ').Length;
        }

        public static int CountLetters(string path)
        {
            if (!System.IO.File.Exists(path)) return -1;
            string text = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8).Trim();

            int count = 0;
            foreach (char c in text)
            {
                if ((char.IsLetter(c)))
                    count++;
            }

            return count;
        }

        public static int[] CountPunctuationMarks(string path)
        {
            if (!System.IO.File.Exists(path)) return new int[] { -1, -1 };
            string text = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8).Trim();

            int[] count = { 0, 0 };
            foreach (char c in text)
            {
                if(c == '.')
                {
                    count[0]++;
                }
                else if(c == ',')
                {
                    count[1]++;
                }
            }

            return count;
        }

        public static Dictionary<string, int> CountSameWords(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            string toReplace = ",.\n\r";
            foreach(char c in toReplace)
            {
                text = text.Replace(c, ' ');
            }

            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }

            Dictionary<string, int> result = new Dictionary<string, int>();

            string[] words = text.Split(' ');
            for(int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
            
            foreach (string word in words)
            {
                if (result.ContainsKey(word))
                {
                    result[word]++;
                }
                else
                {
                    result.Add(word, 1);
                }
            }

            return result;
        }

        public static Dictionary<string, List<int>> CreateIndex(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            Dictionary<string, List<int>> result = new Dictionary<string, List<int>>();


            string toReplace = ",.\n\r";
            for (int i = 0; i < lines.Length; i++)
            {
                foreach (char c in toReplace)
                {
                    lines[i] = lines[i].Replace(c, ' ').Trim();
                }

                string[] words = lines[i].Split(' ');
                foreach(string word in words)
                {
                    if(!result.ContainsKey(word))
                    {
                        result.Add(word, new List<int>());
                    }
                    if (!result[word].Contains(i + 1))
                    {
                        result[word].Add(i + 1);
                    }
                }
            }

            return result;
        }
    }
}
