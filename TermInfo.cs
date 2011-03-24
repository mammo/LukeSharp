using Lucene.Net.Index;

namespace Lucene.Net.LukeNet
{
	public class TermInfo 
	{
        public int DocFreq
        {
            get;
            private set;
        }

        public Term Term
        {
            get;
            private set;
        }
        
        public TermInfo(Term term, int docFrequency) 
		{
			Term = term;
			DocFreq = docFrequency;
		}
	}
}