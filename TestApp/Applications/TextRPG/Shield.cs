using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Applications.TextRPG
{
    public class Shield : Item
    {
        public int MinimumDefense { get; set; }
        public int MaximumDefense { get; set; }

        public Shield(int id, string name, string namePlural, int minimumDefense,
            int maximumDefense) : base(id, name, namePlural)
        {
            MinimumDefense = minimumDefense;
            MaximumDefense = maximumDefense;
        }
    }
}
