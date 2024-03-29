﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ModificationTests : GroupTestBase
    {

        [Test]

        public void GroupModificationTest()
        {
            app.Navi.Gotothegrouppage();
            List<GroupData> oldgroups = GroupData.GetAll();
            GroupData oldData = oldgroups[0];
            GroupData newData = new GroupData("abracadabra-test");
            app.Groups.CheckEmptyGroup();

            //app.Groups.EditGroup(0, newData);//original row
            app.Groups.EditGroup(oldData, newData);
            //ниже реализуется быстрая проверка на то, есть ли смысл тратить время на более сложную проверку
            //это медленная проверка, чтобы в случае ошибки не выполнять быструю
            Assert.AreEqual(oldgroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newgroups = GroupData.GetAll();
            oldgroups[0].Name = newData.Name;
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);

            foreach (GroupData group in newgroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
          
        }
    }
}
