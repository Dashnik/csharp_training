using System;
using System.IO;// для того чтобы использовать метод StreamWriter нужно добавить этот using 
using System.Collections.Generic;
using Newtonsoft.Json;//юзинг для того чтобы можно было использовать json
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


            string typeData = args[0];
            int count = Convert.ToInt32(args[1]);
            string fileName = args[2];
            string format = args[3];
           
            List<GroupData> groups = new List<GroupData>();
          
            for (int i = 0; i < count; i++)
            {
                //GroupData gt1 = new GroupData(TestBase.GenerateRandomString(10));
                //gt1.Header = TestBase.GenerateRandomString(100);
                //gt1.Footer = TestBase.GenerateRandomString(100);
                //groups.Add(gt1); эта запись эквивалента записи ниже

                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }

             List<ContactData> contacts = new List<ContactData>();
          
            for (int i = 0; i < count; i++)
            {                               
               contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
               {
                    Address = TestBase.GenerateRandomString(10)                   
               });

            }
            if (typeData == "groups")
            {
                StreamWriter writer = new StreamWriter(args[2]);

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupToJsonFile(groups, writer);
                }
                else
                {
                    Console.Out.Write("Unrecognized format " + format);
                }
                writer.Close();
            }
          

            if ( typeData == "contacts" )
            {
                StreamWriter writer = new StreamWriter(args[2]);
                {
                    if (format == "xml")
                    {
                        writeContactsToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        writeContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        Console.Out.Write("Unrecognized format: " + format);
                    }
                    writer.Close();
                }
            }
            
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

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeGroupToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups,Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
