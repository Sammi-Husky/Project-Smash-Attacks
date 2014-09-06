using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmashAttacks.Nodes
{
    public class ArticleNode : BaseNode
    {
        public ArticleNode(string name, long address)
            : base(name, address, Type.EventData)
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
