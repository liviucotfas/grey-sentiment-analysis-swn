using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreySentimentAnalysis.ConsoleApp;
using GreySentimentAnalysis.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreySentimentAnalysis.Web.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(AnalysisViewModel viewModel)
		{
			if (viewModel.Tweet != null)
			{
				var greyTweetAnalyser = new GreyTweetAnalyser("Data/lexicon-swn-grey.csv");
				var analysisResult = greyTweetAnalyser.CalculateTweetPerception(viewModel.Tweet);
				viewModel.AnalysisResult = analysisResult;
			}

			return View(viewModel);
		}
	}
}
