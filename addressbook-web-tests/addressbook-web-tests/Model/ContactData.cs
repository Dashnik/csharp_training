using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
     
        private string allPhones;
        private string allMails;
        private string superfields;

        public ContactData()
        {
        }


        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
           Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname;

        }


        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + "\nlastname" + Lastname;

        }

        public int CompareTo(ContactData other)
        {

            if (Lastname.CompareTo(other.Lastname) == 0 && Firstname.CompareTo(other.Firstname) == 0)
            {
                {
                    return 0;
                }
            }
            return Lastname.CompareTo(other.Lastname);
        }
        
        //Объявление автоматические свойства  (они обеспечивают простой доступ к полям классов)
        public string Firstname {get; set;}
        public string Lastname {get; set;}
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Mail { get; set; }
        public string Mail2 { get; set; }
        public string Mail3 { get; set; }


        //обычное свойство
        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string SuperFields
        {
            get
            {
                if (superfields != null)
                {
                    return superfields;
                }
                else
                {                   
                    return Firstname +" "+ PasteIn(Lastname) + PasteIn(Address) + "\r\n" + PasteIn(HomePhone).Insert(0, "H: ") + 
                        PasteIn(MobilePhone).Insert(0, "M: ") + PasteIn(WorkPhone).Insert(0,"W: ")+ "\r\n" + PasteIn(Mail) + PasteIn(Mail2) + Mail3.Trim();
                }
            }
            set
            {
                superfields = value;
            }
        }

        private string PasteIn(string symbols)
        {
            if (symbols == null || symbols == "")
            {
                return "";
            }
            return symbols + "\r\n";
        }


        public string AllMails
        {
            get
            {
                if (allMails != null)
                {
                    return allMails;
                }
                else
                {
                    return CleanUp(Mail) + CleanUp(Mail2) + CleanUp(Mail3).Trim();
                }
            }
            set
            {
                allMails = value;
            }
        }

       

        private string CleanUp(string phone)
        {
            if (WorkPhone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}
