using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashAttacks.Types
{
    public unsafe class Fighter : FitObject
    {
        public unsafe Fighter(long pData, byte* ptr)
        {
            _data = *(sFighter*)(ptr + pData);
            base.pData = pData;

            _pActionFlags = _data.ActionFlagsStart;
            _pSubactionMain = _data.SubactionMainStart;
            _pSubactionGFX = _data.SubactionGFXStart;
            _pSubactionSFX = _data.SubactionSFXStart;
            _pSubactionOther = _data.SubactionOtherStart;
            _pActions = _data.EntryActionsStart;
            _pAnimations = _data.SubactionFlagsStart;
        }
        private sFighter _data;
        public sFighter Data { get { return _data; } }
        public override string ToString()
        {
            return "Fighter";
        }
    }

    public struct sFighter
    {
        public bint SubactionFlagsStart;
        public bint ModelVisibilityStart;
        public bint AttributeStart;
        public bint SSEAttributeStart;

        public bint MiscSectionOffset;
        public bint CommonActionFlagsStart;
        public bint ActionFlagsStart;
        public bint Unknown7;

        public bint ActionInterrupts;
        public bint EntryActionsStart;
        public bint ExitActionsStart;
        public bint ActionPreStart;

        public bint SubactionMainStart;
        public bint SubactionGFXStart;
        public bint SubactionSFXStart;
        public bint SubactionOtherStart;

        public bint AnchoredItemPositions;
        public bint GooeyBombPositions;
        public bint BoneRef1;
        public bint BoneRef2;

        public bint EntryActionOverrides;
        public bint ExitActionOverrides;
        public bint Unknown22;
        public bint SamusArmCannonPositions;

        public bint Unknown24;
        public bint StaticArticlesStart;
        public bint EntryArticleStart;

        public bint Unknown27;
        public bint Unknown28;
        public buint Flags1;
        public bint Flags2; //Sometimes -1
    }
}
