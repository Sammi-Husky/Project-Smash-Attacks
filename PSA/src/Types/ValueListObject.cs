using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashAttacks.Types
{
    public class ValueListObject
    {
        public ValueListObject(long start, long size)
        {
            offset = start;
            Length = size;
        }
        public long offset;
        public long Length;

        public InfoAttribute[] iAttributes;
        public string Name;
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name))
                return offset.ToString("X");
            else
                return Name;
        }
    }
}
