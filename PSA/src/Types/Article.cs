#pragma warning disable 649
using System;

namespace SmashAttacks.Types
{
    public unsafe class Article
    {
        /*Alot of this was copied from Tabuu's source code, so credits to Dantarion and company for this work.*/

        private Data _data;
        struct Data
        {
            public const int Size = 56;

            public bint id;
            public bint ArcGroup;
            public bint BoneID;
            public bint ActionFlagsStart;

            public bint SubactionFlagsStart;
            public bint ActionsStart;
            public bint SubactionMainStart;
            public bint SubactionGFXStart;

            public bint SubactionSFXStart;
            public bint ModelVisibility;
            public bint CollisionData;
            public bint UnknownD2;

            public bint UnknownD3;
        }

        public int ID
        {
            get { return _data.id; }
            set { _data.id = value; }
        }
        public int SubactionMain
        {
            get { return _data.SubactionMainStart; }
        }
        public int SubactionGFX
        {
            get { return _data.SubactionGFXStart; }
        }
        public int SubactionSFX
        {
            get { return _data.SubactionSFXStart; }
        }
        public int Actions
        {
            get { return _data.ActionsStart; }
        }
        public int ArcGroup
        {
            get { return _data.ArcGroup; }
            set { _data.ArcGroup = value; }
        }
        public int BoneID
        {
            get { return _data.BoneID; }
            set { _data.BoneID = value; }
        }
        public int CollisionData
        {
            get { return _data.CollisionData; }
            set { _data.CollisionData = value; }
        }
        public int UnknownD2
        {
            get { return _data.UnknownD2; }
            set { _data.UnknownD2 = value; }
        }
        public int UnknownD3
        {
            get { return _data.UnknownD3; }
            set { _data.UnknownD3 = value; }
        }

        private int _subCount;
        public int SubactionCount
        {
            get { return _subCount; }
            set { _subCount = value; }
        }

        private int _actionCount;
        public int ActionCount
        {
            get { return _actionCount; }
            set { _actionCount = value; }
        }

        public unsafe Article(long FileLength, long pData, byte* ptr)
        {
            _data = *(Data*)(ptr + pData);
            if (
                _data.SubactionFlagsStart < 1 ||
                _data.ActionsStart > FileLength || _data.ActionsStart % 4 != 0 ||
                _data.SubactionFlagsStart > FileLength || _data.SubactionFlagsStart % 4 != 0 ||
                _data.SubactionGFXStart > FileLength || _data.SubactionGFXStart % 4 != 0 ||
                _data.SubactionSFXStart > FileLength || _data.SubactionSFXStart % 4 != 0 ||
                _data.ModelVisibility > FileLength || _data.ModelVisibility % 4 != 0
                )
                throw new Exception("Not actually an Article, lol");
            var actionCount = 0;
            var subactions = (pData - _data.SubactionFlagsStart) / 8;
            if (_data.ActionFlagsStart > 0 && _data.ActionsStart > 0)
                actionCount = (_data.ActionsStart - _data.ActionFlagsStart) / 0x10;
            if (_data.SubactionFlagsStart > 0 && _data.SubactionMainStart > 0)
                subactions = (_data.SubactionMainStart - _data.SubactionFlagsStart) / 0x8;
            if (subactions > 0x1000 || actionCount > 0x1000 || subactions < 0 || actionCount < 0)
                throw new Exception("Not actually a Article, lol");

            _subCount = (int)subactions;
            _actionCount = (int)actionCount;
        }
    }
}
