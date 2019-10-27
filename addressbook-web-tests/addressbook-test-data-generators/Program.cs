using System;
using System.IO;// для того чтобы использовать метод StreamWriter нужно добавить этот using 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;///этот юзинг нужен для того чтобы работать с xml
using System.Xml.Serialization; ///этот юзинг нужен для того чтобы работать с xml
using System.Threading.Tasks;
using addressbook_web_tests; //для того чтобы методы из другого проекта необходимо добавить reference к этому +
//проекту и потом обращаться к namespace через using

namespace addressbook_test_data_generators
{
    class Program
    {                     
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }
            if (format == "csv")
            {
                writeGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                writeGroupsToXmlFile(groups, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format " + format);
            }
           
            writer.Close();
        }
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

    }
}
