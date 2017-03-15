using System;

namespace GreySentimentLexiconSWN.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
           var sentiWordNetParser = new SentiWordNetParser();
            sentiWordNetParser.Load();

            Console.ReadKey(true);
        }

        
    }
}