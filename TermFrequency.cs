using System;
using System.Collections;

namespace Lucene.Net.LukeNet
{
    public class TermFrequency
    {
        public string Term { get; private set; }
        public int Frequency{ get; private set; }

        public TermFrequency(string term, int frequency)
        {
            Term = term;
            Frequency = frequency;
        }
    }
}
