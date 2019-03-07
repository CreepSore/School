using System;

namespace Uebung6
{
    class Program
    {
        const string SCHUELER_START_TAG = "<schueler>";
        const string SCHUELER_END_TAG = "</schueler>";


        static void Main(string[] args)
        {

            string tmpXML =
                @"<bs2>
                    <2aITI>
                        <schueler> Mayr Peter</schueler>
                        <schueler> Schuster Jürgen</schueler>
                        <schueler> Schuster </schueler>
                        <schueler> </schueler>
                    </2aITI>
                 </bs2>";


            string startTag = SCHUELER_START_TAG;
            string endTag = SCHUELER_END_TAG;
            int startPos = 0;
            int endPos = 0;
            do
            {
                startPos = tmpXML.IndexOf(startTag, startPos);
                if (startPos == -1) break;
                endPos = tmpXML.IndexOf(endTag, endPos);
                if (endPos == -1) break;

                string fullname = tmpXML.Substring(startPos + startTag.Length, endPos - startPos - startTag.Length).Trim();
                if (!string.IsNullOrEmpty(fullname))
                {
                    string[] name = fullname.Split(' ');
                    Console.WriteLine($"Vorname: {(name.Length >= 1 ? name[0] : "KEINER")}\tNachname: {(name.Length >= 2 ? name[1] : "KEINER")}");
                }

                startPos += startTag.Length;
                endPos += endTag.Length;
            } while (true);

            Console.ReadKey(true);
        }
    }
}
