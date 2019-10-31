using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_test_auto_it
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public string Name { get; set;}

        public int CompareTo(GroupData other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public GroupData(string name)
        {
            Name = name;
        }

        public GroupData()
        {
           
        }

        public bool Equals(GroupData other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
