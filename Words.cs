using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Heming
{
    class Words 
    {
        byte[] bit;
        public Words(int lenght)
        {
            bit = new byte[lenght];
        }
        public IEnumerator GetEnumerator()
        {
            return bit.GetEnumerator();
        }

        public int Lenght
        {
            get{ return bit.Length; }
        }
        public byte this[int index]
        {
            get { return bit[index]; }
            set
            {
                if (value == 0 || value == 1)
                    bit[index] = value;
                else
                    throw new Exception("Word must containce byte code.");
            }
        }

    }
}
