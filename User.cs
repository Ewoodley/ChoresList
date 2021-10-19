using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoresApp
{
    public class User
    {
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public virtual IList<Chores> ChoreName { get; set; }

        public String GetName()
        {
            return this.FirstName;
        }
        public override string ToString()
        {
            return "User [id=" + this.UserId + ", name=" + this.GetName() + "]";
        }
    }
}
