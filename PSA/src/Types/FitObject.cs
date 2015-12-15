using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashAttacks.Types
{
    public class FitObject
    {
        public long pData;

        public long Animations
        {
            get { return _pAnimations; }
        }
        protected long _pAnimations;
        public long ActionFlags { get { return _pActionFlags; } }
        protected long _pActionFlags;
        public long SubactionMain
        {
            get { return _pSubactionMain; }
        }
        protected long _pSubactionMain;
        public long SubactionGFX
        {
            get { return _pSubactionGFX; }
        }
        protected long _pSubactionGFX;
        public long SubactionSFX
        {
            get { return _pSubactionSFX; }
        }
        protected long _pSubactionSFX;
        public long SubactionOther { get { return _pSubactionOther; } }
        protected long _pSubactionOther;
        public long Actions
        {
            get { return _pActions; }
        }
        protected long _pActions;
        public int SubactionCount
        {
            get { return _subCount; }
            set { _subCount = value; }
        }
        protected int _subCount;
        protected int _actionCount;
        public int ActionCount
        {
            get { return _actionCount; }
            set { _actionCount = value; }
        }
    }
}
