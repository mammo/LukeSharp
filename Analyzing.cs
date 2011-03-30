using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net.Analysis;
using System.Reflection;
using System.Collections;

namespace Lucene.Net.LukeNet
{
    public class Analyzing
    {
        private static object _syncRoot = new object();

        private static Type[] _defaultAnalyzers = 
			{
//				typeof(Lucene.Net.Analysis.De.GermanAnalyzer),
//				typeof(Lucene.Net.Analysis.Ru.RussianAnalyzer),
				typeof(Lucene.Net.Analysis.SimpleAnalyzer),
				typeof(Lucene.Net.Analysis.Standard.StandardAnalyzer),
				typeof(Lucene.Net.Analysis.StopAnalyzer),
				typeof(Lucene.Net.Analysis.WhitespaceAnalyzer)
			};

        private static Dictionary<string, Type> _analyzers;
        private static Dictionary<string, Type> Analyzers
        {
            get
            {
                if (_analyzers == null)
                {
                    lock (_syncRoot)
                    {
                        if (_analyzers == null)
                        {
                            try
                            {
                                _analyzers = new Dictionary<string, Type>();
                                Type[] analyzerTypes = null;
                                try
                                {
                                    analyzerTypes = Lucene.Net.LukeNet.ClassFinder.ClassFinder.GetInstantiableSubtypes(typeof(Lucene.Net.Analysis.Analyzer));
                                }
                                catch (Exception) { }

                                if (analyzerTypes == null || analyzerTypes.Length == 0)
                                {
                                    foreach (Type t in _defaultAnalyzers)
                                        _analyzers[t.FullName] = t;
                                }
                                else
                                {
                                    foreach (Type aType in analyzerTypes)
                                        _analyzers[aType.FullName] = aType;
                                }
                            }
                            catch 
                            {
                            }
                        }
                    }
                }
                return _analyzers;
            }
        }

        public static List<string> GetAnalyzerNames()
        {
            return Analyzers.Keys.OrderBy(k => k).ToList();
        }

        public static string GetAnalyzerName(string analyzerName)
        {
            if (null == analyzerName || analyzerName == string.Empty)
            {
                analyzerName = "Lucene.Net.Analysis.Standard.StandardAnalyzer";
            }
            return analyzerName;
        }

        public static Analyzer GetAnalyzerForName(string analyzerName)
        {
            try
            {
                Type analyzerType;
                if (!Analyzers.TryGetValue(analyzerName, out analyzerType))
                {
                    Assembly a = Assembly.GetAssembly(typeof(Lucene.Net.Analysis.Analyzer));
                    analyzerType = a.GetType(analyzerName);
                }

                return (Analyzer)Activator.CreateInstance(analyzerType);
            }
            catch (Exception)
            { return null; }
        }

    }
}
