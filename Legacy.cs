using System;
using Lucene.Net.Documents;

namespace Lucene.Net.LukeNet
{
    public class Legacy
    {
        public static Field CreateField(String name, String string_Renamed, bool store, bool index, bool token, bool storeTermVector)
        {
            Field.Index fieldIndex;
            if (index)
            {
                fieldIndex = token ? Field.Index.ANALYZED : Field.Index.NOT_ANALYZED;
            }
            else
            {
                fieldIndex = Field.Index.NO;
            }

            return new Field(name, string_Renamed, store ? Field.Store.YES : Field.Store.NO, fieldIndex, storeTermVector ? Field.TermVector.YES : Field.TermVector.NO);

        }

    }
}
