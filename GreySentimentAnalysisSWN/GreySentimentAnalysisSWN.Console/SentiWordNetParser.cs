using System;
using System.Collections.Generic;
using System.IO;
using GreySentimentAnalysisSWN.SWN;

namespace GreySentimentLexiconSWN.ConsoleApp
{
	internal class SentiWordNetParser
    {
        private SortedDictionary<string, SentiWordNetTerm> SentiWordNetTerms { get; set; }

        public void Load()
        {
            SentiWordNetTerms = new SortedDictionary<string, SentiWordNetTerm>();

            //1. Load from SentiWordNet
            using (var reader = new StreamReader(File.OpenRead(@"Data\SentiWordNet_3.0.0_20130122.txt")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    //skip commented lines
                    if (line[0] != '#' && line[0] != '\t')
                    {
                        ProcessLine(line);
                        Console.WriteLine(line);
                    }
                }
            }

            //2. Write to file
            using (var writer = File.CreateText("lexicon-swn-grey.csv"))
            {
                foreach (var wordDictionaryEntry in SentiWordNetTerms)
                {
                    var word = wordDictionaryEntry.Value.Term;

                    var line = word;

	                var greyPolarity = wordDictionaryEntry.Value.GetGreyPolarity();
                    line += "," + greyPolarity.Low + "";
                    line += "," + greyPolarity.High + "";

                    writer.WriteLine(line);
                    writer.Flush();
                }
            }

			using (var writer = File.CreateText("lexicon-swn-mostFrequent.csv"))
			{
				foreach (var wordDictionaryEntry in SentiWordNetTerms)
				{
					var word = wordDictionaryEntry.Value.Term;

					var line = word;

					var greyPolarity = wordDictionaryEntry.Value.GetMostFrequentPolarity();
					line += "," + greyPolarity + "";
					line += "," + greyPolarity + "";

					writer.WriteLine(line);
					writer.Flush();
				}
			}

			using (var writer = File.CreateText("lexicon-swn-average.csv"))
			{
				foreach (var wordDictionaryEntry in SentiWordNetTerms)
				{
					var word = wordDictionaryEntry.Value.Term;

					var line = word;

					var greyPolarity = wordDictionaryEntry.Value.GetAveragePolarity();
					line += "," + greyPolarity + "";
					line += "," + greyPolarity + "";

					writer.WriteLine(line);
					writer.Flush();
				}
			}
		}

        public void ProcessLine(string line)
        {
            var values = line.Split('\t');

            var pos = values[0];
            var id = values[1];
            var posScore = double.Parse(values[2]);
            var negScore = -double.Parse(values[3]);
            var synsetTerms = values[4];
            var gloss = values[5];

            var terms = synsetTerms.Split(' ');

            foreach (var term in terms)
            {
                var wordAndSense = term.Split('#');
                var word = wordAndSense[0];
                var senseNumber = int.Parse(wordAndSense[1]);

				//add the word
	            if (!SentiWordNetTerms.ContainsKey(word))
					SentiWordNetTerms.Add(word, new SentiWordNetTerm(word));

	            var greyLexiconWord = SentiWordNetTerms[word];
				greyLexiconWord.Senses.Add(new SentiWordNetTermSense(senseNumber, posScore, negScore));
			}
        }
    }
}
