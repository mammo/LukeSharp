using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucene.Net.LukeNet
{
    public class GrowableStringArray
    {
        public int INITIAL_SIZE = 20;
        private int size = 0;
        private String[] array = null;

        public int Size()
        {
            return size;
        }

        public void Set(int index, String val)
        {
            if (array == null) array = new String[INITIAL_SIZE];
            if (array.Length < index + 1)
            {
                String[] newArray = new String[index + INITIAL_SIZE];
                array.CopyTo(newArray, 0);
                array = newArray;
            }
            if (index > size - 1) size = index + 1;
            array[index] = val;
        }

        public String Get(int index)
        {
            return array[index];
        }
    }
}
