using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreySentimentAnalysis.ConsoleApp;

namespace GreySentimentAnalysis.Web.Models
{
	public class AnalysisViewModel
	{
		public string Tweet { get; set; }

		public GreyTweetAnalysisResult AnalysisResult { get; set; }
	}
}
