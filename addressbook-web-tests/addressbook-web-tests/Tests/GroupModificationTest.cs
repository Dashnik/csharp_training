﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ModificationTests : AuthTestBase
    {

        [Test]

        public void GroupModificationTest()
        {
            app.Navi.Gotothegrouppage();
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            GroupData newData = new GroupData("name");
            app.Groups.CheckEmptyGroup();
            app.Groups.GroupLine(0);
            app.Groups.EditGroup(newData);
            //ниже реализуется быстрая проверка на то, есть ли смысл тратить время на более сложную проверку
            //это медленная проверка, чтобы в случае ошибки не выполнять быструю
            Assert.AreEqual(oldgroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newgroups = app.Groups.GetGroupList();
            oldgroups[0].Name = newData.Name;
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
          
        }
    }
}
