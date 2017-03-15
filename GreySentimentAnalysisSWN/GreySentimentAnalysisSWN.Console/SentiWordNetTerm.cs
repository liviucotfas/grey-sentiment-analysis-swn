using System.Collections.Generic;
using System.Linq;
using GreyNumbers;

namespace GreySentimentAnalysisSWN.SWN
{
	internal class SentiWordNetTerm
    {
		public string Term { get; set; }
	    public List<SentiWordNetTermSense> Senses { get; set; }

	    public SentiWordNetTerm(string term)
	    {
			Senses = new List<SentiWordNetTermSense>();

		    Term = term;
	    }

	    public double GetAveragePolarity()
	    {
			    var allScores = Senses.Select(x => x.PosScore).ToList();
				allScores.AddRange(Senses.Select(x => x.NegScore).ToList());

			    return allScores.Sum(x => x) / Senses.Count;
	    }

	    public double GetMostFrequentPolarity()
	    {
				var sense = Senses.First(x=>x.SenseNumber == 1);
			    return sense.NegScore + sense.PosScore;
	    }

	    public GreyNumber GetGreyPolarity()
	    {
				var allScores = Senses.Select(x => x.PosScore).ToList();
				allScores.AddRange(Senses.Select(x => x.NegScore).ToList());

				return new GreyNumber(allScores.Min(), allScores.Max());
	    }
	}
}
