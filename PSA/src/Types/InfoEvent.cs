using System;

namespace SmashAttacks.Types
{
    public class InfoEvent
    {
        public InfoEvent() { dfltParameters = new long[0]; }
        public InfoEvent(string nId, string nName, string nDescription)
        {
            idNumber = nId; name = nName; description = nDescription;
            dfltParameters = new long[0];
        }
        ~InfoEvent() { }

        //  Translate a string of numbers into a set of default parameter types for the event.
        public void SetDfltParameters(string s)
        {
            if (s == null) return;
            Array.Resize<long>(ref dfltParameters, s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                try { dfltParameters[i] = long.Parse(s.Substring(i, 1)); }
                catch { dfltParameters[i] = 0; }
            }
        }

        //  Return the default type for the parameter number passed.
        public long GetDfltParameter(int i)
        {
            if (i >= dfltParameters.Length) return 0;
            if (dfltParameters[i] > 6) return 0;
            return dfltParameters[i];
        }

        public string idNumber;
        public string name;
        public string description;

        private long[] dfltParameters;
    }
}
