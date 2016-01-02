using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashAttacks.Types
{
    public unsafe class Item : FitObject
    {
        public sAnimParam _data;
        public Item(long pData, byte* ptr)
        {
            _data = *(sAnimParam*)(ptr + pData);
            base.pData = pData;

            _pActionFlags = _data.ActionFlags;
            _pSubactionMain = _data.SubactionMain;
            _pSubactionGFX = _data.SubactionGFX;
            _pSubactionSFX = _data.SubactionSFX;
            _pActions = _data.EntryActionsStart;
            _pAnimations = _data.SubactionFlags;
            _subCount = _data.SubactionFlagsCount;
            _actionCount = _data.ActionFlagsCount;
        }
        public override string ToString()
        {
            return "Item";
        }
    }
    public struct sAnimParam
    {
        public bint SubactionFlags;
        public bint SubactionFlagsCount;
        public bint ActionFlags;
        public bint ActionFlagsCount;
        public bint Unknown4;
        public bint Unknown5;
        public bint Unknown6;
        public bint SubactionMain;
        public bint SubactionGFX;
        public bint SubactionSFX;
        public bint EntryActionsStart;
        public bint ExitActionsStart;
        public bint Hurtboxes;
        public bint Unknown13;
        public bint CollisionData;
        public bint Unknown15;
    }
}
