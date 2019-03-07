using System;
using System.Linq;

namespace Flexible_Datenstrukturen
{
    class Program
    {

        static void Main(string[] args)
        {

            Run(@"C:\Tmp\students1.dat");
            Console.WriteLine();
            Run(@"C:\Tmp\students2.dat");
            Console.WriteLine();
            Run(@"C:\Tmp\students3.dat");
            Console.WriteLine();
            Run(@"C:\Tmp\students4.dat");
            Console.ReadKey(true);

        }

        static void Run(string filepath)
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            foreach (string line in lines)
            {
                string name;
                float avg;
                AverageCalc(line, out name, out avg);
                Console.WriteLine("{0} = {1}", name, avg);
            }
        }

        static void AverageCalc(string line, out string name, out float average)
        {
            if (!line.Contains(':'))
            {
                name = null;
                average = -1;
                return;
            }
            average = 0;

            name = line.Substring(0, line.IndexOf(':'));
            string[] grades = line.Substring(line.IndexOf(':')).Split(',');
            int correctGrades = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                string grade = grades[i].Trim();
                if (!grade.Contains('='))
                {
                    continue;
                }

                string[] splittedGrade = grade.Split('=');
                if (splittedGrade.Length < 2)
                {
                    continue;
                }

                float num = 0;
                if (!float.TryParse(splittedGrade[1], out num))
                {
                    Console.WriteLine("Warning: Invalid Grade '{0}' at student '{1}' in class '{2}'", splittedGrade[1], name, splittedGrade[0]);
                    correctGrades--;
                }

                correctGrades++;
                average += num;
            }

            if (correctGrades != 0)
            {
                average /= correctGrades;
            }
            else
            {
                average = 0;
            }
            average = (float)Math.Round(average, 2);
        }

    }
}
