using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmashAttacks.Nodes
{
    public class DataNode : BaseNode
    {
        public DataNode(string name, Type type, long address)
            : base(name, address, type)
        {
            this.Text = name;
            this.address = address;
        }
        public long pAnimations;
        public long pActions;
        public long lActions;
        public long[] pSubactions;
        public long lSubactions;
    }
}
