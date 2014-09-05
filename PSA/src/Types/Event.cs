using System;

namespace SmashAttacks.Types
{
    public class Event
    {
        public void SetEventWord(long v) { eventWord = v; ResolveEventWord(); }
        public long GetEventWord() { return eventWord; }

        //  Resolve for the string-hex version of the event word and adjust the number
        //  of parameters to the amount indicated by the event word.
        public void ResolveEventWord()
        {
            eventId = eventWord.ToString("X");
            eventId = eventId.PadLeft(8, '0');
            if (eventId.Length > 8)
                eventId = eventId.Substring(eventId.Length - 8);

            lParameters = (eventWord & 0xFF00) / 0x100;

            Array.Resize<Block>(ref parameters, (int)lParameters);
            for (int i = 0; i < lParameters; i++) parameters[i] = new Block();
        }

        public string eventId;
        public long pParameters;
        public long lParameters;
        public Block[] parameters;
        public long pThis;
        long eventWord;
    }
}
