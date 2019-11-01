using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis_tests;
using NUnit.Framework;

namespace Mantis_tests
{
    public class ProjectCreationTests : AuthTestBase
    {
        public static IEnumerable<ProjectData> RandomProjectDataProvider()
        {
            List<ProjectData> contacts = new List<ProjectData>();
            for (int i = 0; i < 1; i++)
            {
                contacts.Add(new ProjectData(GenerateRandomString(30))
                {
                    Description = GenerateRandomString(100)
                });
            }

            return contacts;
        }
        [Test, TestCaseSource("RandomProjectDataProvider")]

        public void ProjectCreationTest(ProjectData project)
        {
            List<ProjectData> oldProjects = app.Project.GetProjectList();
            app.Project.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = app.Project.GetProjectList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}
