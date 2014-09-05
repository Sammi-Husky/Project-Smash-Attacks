using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmashAttacks.Nodes
{
    public class BaseNode : TreeNode
    {
        public BaseNode(string Name) { address = 0; this.Text = Name; type = Type.None; }
        public BaseNode(string Name, Type Type, long Address)
        {
            address = Address;
            this.Text = Name;
            type = Type;
        }

        public Type type;
        public long address;
        public enum Type
        {
            None = -1,
            EventData = 0,
            ValueList = 1,
        }
    }
}
