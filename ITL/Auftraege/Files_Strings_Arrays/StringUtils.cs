using System;

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
            text = text.Replace(',', ' ');
            text = text.Replace('.', ' ');

            while(text.Contains("  "))
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
    }
}
