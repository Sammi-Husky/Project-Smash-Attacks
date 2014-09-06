
namespace SmashAttacks.Nodes
{
    public class ParamNode : BaseNode
    {
        public long ParamCount;

        public ParamNode(string name, long offset, long Count)
            : base(name, offset, Type.ValueList)
        {
            this.ParamCount = Count;
        }
    }
}
