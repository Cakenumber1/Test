using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp4
{
    class ParserReader
    {
        //ParsedFile dd = new ParsedFile();
        public void ParseAndStore(string file, ParsedFile dd)
        {
            try
            {
                FileFormatCheck(file, dd);
                OpenableFileCheck(file, dd);
                Parse(file, dd);
                Console.ForegroundColor = ConsoleColor.DarkGreen; // устанавливаем цвет
                Console.WriteLine("Successfully parsed");
                Console.ResetColor(); // сбрасываем в стандартный
                
            }
            catch (Exception2 a)
            {
                Console.WriteLine("Incorrect format", a);
            }
            catch (Exception1 d)
            {
                Console.WriteLine("File does not exist", d);
            }

        }

        public string FileFormatCheck(string a, ParsedFile dd)
        {
            int d = a.IndexOf('.')+1;
            string q = a.Substring(d);
            if (q.Equals("INI"))
            {
                return a;
            }
            throw new Exception2();
        }
        public string OpenableFileCheck(string a, ParsedFile dd)
        {
            if (File.Exists(a).Equals(true))
            {
                return a;
            }
            throw new Exception1();
        }

        public void Parse(string file, ParsedFile dd)
        {
            List<string> Test = new List<string>();
            var fileStream = new StreamReader(file);
            string line;
            string line1;
            string line2;
            int StackInd = -1;

            // Read the file line by line
            while ((line = fileStream.ReadLine()) != null)
            {
                // Split the line by the deliminator
                var splitLine = line.Split(new[] { '\n' });
                foreach (string value in splitLine)
                {
                    Test.Add(value);
                }
            }
            foreach (string temp in Test)
            {
                if (temp[0].Equals('['))
                {
                    int sep1 = temp.IndexOf(']');
                    line1 = temp.Substring(1, sep1-1);
                    dd.AddSection(line1);
                    dd.AddCounter();
                    StackInd++;
                }
                else
                {
                    int sep = temp.IndexOf('=');
                    int sep2 = temp.IndexOf(';');

                    line1 = temp.Substring(0, sep);
                    if (sep2 == -1)
                    {
                        line2 = temp.Substring(sep + 1);
                    }
                    else
                    {
                        line2 = temp.Substring(sep + 1, sep2-1 - sep);
                    }
                    
                    dd.AddName(line1);
                    dd.AddValue(line2);
                    dd.UpdateCounter(StackInd);
                }
            }
            
        }
    }
}
