
namespace SmashAttacks.Types
{
    public class InfoParameter
    {
        public InfoParameter()
        {
            name = new string[0];
            description = new string[0];
        }

        ~InfoParameter() { }

        public string GetName(long i)
        {
            if (i >= name.Length) return "Parameter " + i;
            return name[i];
        }

        public string GetDescription(long i)
        {
            if (i >= description.Length) return "No Description Available.";
            return description[i];
        }

        public string idNumber;
        public string[] name;
        public string[] description;
    }
}
