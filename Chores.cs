using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoresApp
{
    public class Chores
    {
        public int ID { get; set; }
        public string ChoreName { get; set; }
        public virtual User ChoreAssignment { get; set; }

        public override string ToString()
        {
            return "Chore [id=" + this.ID + ", Chore Name=" + this.ChoreName + "]";
        }
    }
}
