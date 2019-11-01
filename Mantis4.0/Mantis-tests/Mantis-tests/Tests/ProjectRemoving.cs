using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
    public class ProjectRemoving : AuthTestBase
    {
        [Test]
        public void ProjectRemoveTest()
        {
            AccountData account = new AccountData("Administrator", "Root") { };
           
            app.Project.CheckProjects();

            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            ProjectData toBeRemoved = oldProjects[0];
            string id = toBeRemoved.Id;
            app.API.DeleteProject(account, id);

            Assert.AreEqual(oldProjects.Count - 1, app.API.GetProjectList(account).Count());

            List<ProjectData> newProjects = app.API.GetProjectList(account);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
        //[Test]
        //public void ProjectRemoveTest()
        //{
        //    app.Project.CheckProjects();

        //    List<ProjectData> oldProjects = app.Project.GetProjectList();
        //    app.Project.Remove(0);

        //    Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());

        //    List<ProjectData> newProjects = app.Project.GetProjectList();
        //    oldProjects.RemoveAt(0);
        //    oldProjects.Sort();
        //    newProjects.Sort();

        //    Assert.AreEqual(oldProjects, newProjects);
        //}

    }
}
