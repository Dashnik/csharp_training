using System;
using System.Collections.Generic;
using System.Linq;//позволяет работать с таблицами в  БД
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;// позволяет работать с аттрибутом [Table]

namespace addressbook_web_tests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public GroupData()
        {            
        }

        public GroupData(string name)
        {
             Name = name;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nheader= " + Header + "\nfooter=" + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        [Column(Name = "group_name")]
        public string Name{ get; set;}

        [Column(Name = "group_header")]
        public string Header { get; set;}

        [Column(Name = "group_footer")]
        public string Footer { get; set;}

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set;}

        public static List<GroupData> GetAll()
        {
            using (//в этой конструкции юзинга db.close вызывается автоматически, т.о. мы уменьшаем количество кода
              AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

    }
}
