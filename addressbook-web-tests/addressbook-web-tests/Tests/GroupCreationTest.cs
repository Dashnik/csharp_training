﻿using System;
using System.IO; // этот юзинг позволяет работать с файлами и вызывать метод File
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;//юзинг для того чтобы можно было использовать json
using System.Linq;

namespace addressbook_web_tests

{

    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                    {
                         Header = parts[1],
                         Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
            
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            app.Navi.Gotothegrouppage();
            List<GroupData> oldgroups = GroupData.GetAll();

            app.Groups.NewGroupCreation();
            app.Groups.FillnewGroup(group);
            app.Groups.Submitgroupcreation();

            //ниже реализуется быстрая проверка на то, есть ли смысл тратить время на более сложную проверку
            //это медленная проверка, чтобы в случае ошибки не выполнять быструю
            Assert.AreEqual(oldgroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newgroups = GroupData.GetAll();
            oldgroups.Add(group);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            //DateTime start = DateTime.Now;
            //List<GroupData> fromUI = app.Groups.GetGroupList();
            //DateTime end = DateTime.Now;
            //System.Console.Out.WriteLine(end.Subtract(start));

            // start = DateTime.Now;
            //List<GroupData> fromDb = GroupData.GetAll();
            //    //AddressBookDB db = new AddressBookDB();
            //    //List<GroupData> fromDb = (from g in db.Groups select g).ToList();
            //    //db.Close();
            //    end = DateTime.Now;
            //System.Console.Out.WriteLine(end.Subtract(start));
            foreach (ContactData contact in  GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contact);
            }
        }

    }
}
