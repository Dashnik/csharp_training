﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
//using Windows.Forms;

namespace addressbook_web_tests
{
    [TestFixture]
    class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navi.Gotothegrouppage();
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.CheckEmptyGroup();
            app.Groups.GroupLine(0)
            .RemoveGroup();
            //ниже реализуется быстрая проверка на то, есть ли смысл тратить время на более сложную проверку
            //это медленная проверка, чтобы в случае ошибки не выполнять быструю
            Assert.AreEqual(oldgroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newgroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldgroups[0];
            oldgroups.RemoveAt(0);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);

            //делаем  проверку что идентификатор удаленного элемента на равен идентификатору существующего элемента

            foreach (GroupData group in newgroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}