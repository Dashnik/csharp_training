﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    class RemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navi.Gotothegrouppage();
            app.Groups.GroupLine(2);
            app.Groups.RemoveGroup();
        }
    }
}
