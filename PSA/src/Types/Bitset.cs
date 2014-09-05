using System;

namespace SmashAttacks.Types
{
    public class Bitset
    {
        public Bitset() { bitVal = new bool[8]; }
        ~Bitset() { }

        public void SetByte(byte v) { byteVal = v; ResolveBits(); }
        public void SetBit(int b, bool v) { bitVal[b] = v; ResolveByte(); }

        public byte GetByte() { return byteVal; }
        public bool GetBit(int b) { return bitVal[b]; }

        //  Set each bit according to the bitset's current byte value.
        public void ResolveBits()
        {
            for (int i = 0; i < 8; i++)
                bitVal[i] = (((long)Math.Pow(0x2, i) & byteVal) != 0 ? true : false);
        }

        //  Set the byte value according to the bitset's bits.
        public void ResolveByte()
        {
            byteVal = 0;
            for (int i = 0; i < 8; i++)
                if (bitVal[i] == true)
                    byteVal += (byte)Math.Pow(0x2, i);
        }

        byte byteVal;
        bool[] bitVal;
    }
}
