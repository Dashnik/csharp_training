using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";
        private string group_name;
        private string group_header;
        private string group_footer;

        public GroupData(string name)
        {
            this.name = name;
           
        }
        public GroupData(string group_name, string group_header, string group_footer)
        {
            this.group_name = group_name;
            this.group_header = group_header;
            this.group_footer = group_footer;
        }
        public string Name
        {
            get {
                return name;
                    }
            set
            {
                name = value;

            }
        }
        public string Header
        {
            get
            {
                return header;
                    }
            set
            {
                header = value;
            }
        }
        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;

            }
        }
        public string EditName
        {
            get
            {
                return group_name;
            }
            set
            {
                group_name = value;
            }
        }
        public string EditHeader
        {
            get
            {
                return group_header;
            }
            set
            {
                group_header = value;
            }
        }
        public string EditFooter
        {
            get
            {
                return group_footer;
            }
            set
            {
                group_footer = value;
            }
        }

    }
}
