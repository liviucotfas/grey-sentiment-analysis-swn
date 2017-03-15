namespace GreySentimentAnalysisSWN.SWN
{
    internal class SentiWordNetTermSense
    {
	   public int SenseNumber { get; set; }
		public double PosScore { get; set; }
		public double NegScore { get; set; }

		public SentiWordNetTermSense(int senseNumber, double posScore, double negScore)
		{
			SenseNumber = senseNumber;
			PosScore = posScore;
			NegScore = negScore;
		}
	}
}
