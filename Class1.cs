using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp4
{
    class ParsedFile
    {
        List<string> Sections = new List<string>();
        List<string> Names = new List<string>();
        List<string> Values = new List<string>();
        List<int> Counters = new List<int>();
        public void AddSection(string a)
        {
            Sections.Add(a);
        }
        public void AddName(string a)
        {
            Names.Add(a);
        }
        public void AddValue(string a)
        {
            Values.Add(a);
        }
        public void AddCounter()
        {
            Counters.Add(0);
        }
        public void UpdateCounter(int b)
        {
            Counters[b]++;
        }
        public int SearchForSection(string a)
        {
            int out1 = -1;
            foreach (string dd in Sections)
            {
                out1++;
                if (dd.Equals(a))
                {
                    return out1;
                }
            }
            throw new ArgumentException1();

        }
        public int SearchForName(string b, int sum, int out1)
        {
            int out2 = sum;

            for (int t = sum; t < (sum + Counters[out1]); t++)
            {

                if (Names[t].Equals(b))
                {
                    return out2;
                }
                out2++;
            }
            
            throw new ArgumentException2();

        }
        public string ValueChange(string c, int out2)
        {
            int test1;
            double test2;
            bool ChangeTry = false;
            if (c.Equals("int"))
            {
                
                ChangeTry = int.TryParse(Values[out2], out test1);
                if (ChangeTry == true)
                {
                    return Values[out2];
                }
            }
            if (c.Equals("double"))
            {
                
                ChangeTry = double.TryParse(Values[out2], out test2);
                
                if (ChangeTry == true)
                {
                    return Values[out2];
                }
            }
            if (c.Equals("string"))
            {
                return Values[out2];
            }
            throw new InvalidCastException();

        }

        public void Search(string a, string b, string c)
        {
            try
            {
                int out1 = SearchForSection(a);
                int sum = 0;

                for (int i = 0; i < out1; i++)
                {
                    
                    sum =sum+ Counters[i];
                }

                int out2 = SearchForName(b, sum, out1);
                string answ = ValueChange(c, out2);
                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine(answ);
                Console.ResetColor(); // сбрасываем в стандартный
                


            }
            catch (InvalidCastException d)
            {
                Console.WriteLine("Incorrect type", d);
            }
            catch (ArgumentException2 e)
            {
                Console.WriteLine("Name in Section does not exist", e);

            }
            catch (ArgumentException1 n)
            {
                Console.WriteLine("Section does not exist", n);
            }

        }
    }

}

