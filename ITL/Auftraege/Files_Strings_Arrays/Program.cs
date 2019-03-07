using System;

namespace Files_Strings_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            InitConsole();

            Console.Write(@"Please input the File that you want to check:\n > C:\Tmp\");
            string filePath = @"C:\Tmp\" + Console.ReadLine();
            if(!System.IO.File.Exists(filePath))
            {
                Console.WriteLine("Die Datei existiert nicht!");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }

            RunNormal(filePath);

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey(true);
        }

        static void RunNormal(string path)
        {
            Console.WriteLine("Anzahl der Zeilen: {0}", StringUtils.CountLines(path));
            Console.WriteLine("Anzahl der Wörter: {0}", StringUtils.CountWords(path));
            Console.WriteLine("Anzahl der Buchstaben: {0}", StringUtils.CountLetters(path));
            int[] punctuationMarks = StringUtils.CountPunctuationMarks(path);
            Console.WriteLine("Anzahl der Punkte: {0}", punctuationMarks[0]);
            Console.WriteLine("Anzahl der Beistriche: {0}", punctuationMarks[1]);
            Console.WriteLine();
        }

        static void InitConsole()
        {
            Console.SetWindowSize(80, 10);
            Console.SetBufferSize(80, 10);
            Console.SetWindowSize(80, 10);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
}
