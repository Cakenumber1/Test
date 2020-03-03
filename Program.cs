using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserReader task3 = new ParserReader();
            ParsedFile task3parsed = new ParsedFile();
            task3.ParseAndStore("qq.txt", task3parsed);//incorrect format
            task3.ParseAndStore("dd.INI", task3parsed);//file dnt ex
            Console.WriteLine();
            task3.ParseAndStore("qq.INI",task3parsed);//start (added notification "su par")
            task3parsed.Search("COMMON", "DiskCachePath", "string");//correct+ comment
            task3parsed.Search("COMMON", "qwe", "string");// no qwe in COMMON
            task3parsed.Search("COMMON", "DiskCachePath", "double");//not double type
            task3parsed.Search("qwe", "DiskCachePath", "double");//no qwe section
            task3parsed.Search("ADC_DEV", "BufferLenSeconds", "double");//0.65 is not double
            task3parsed.Search("ADC_DEV", "Var", "double");// 0,65 is double + commnet
            task3parsed.Search("ADC_DEV", "Var", "int");//not int
            task3parsed.Search("COMMON", "LogNCMD", "int");//done


        }
    }
}
