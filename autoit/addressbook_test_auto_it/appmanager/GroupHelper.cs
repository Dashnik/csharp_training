using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;// юзинг для List<>
using NUnit.Framework;


namespace addressbook_test_auto_it
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView("GROUPWINTITLE", "", "WindowsForms10.SysTreeView32.app.0.2c908d51","GetItemCount","#0","");

            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                    GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        public void RemoveGroup(int numberGroup)
        {
            OpenGroupsDialogue();
            ChooseGroup(numberGroup);
            PressDeleteButton();
            PressOkButton();
            CloseGroupsDialogue();
        }

        private void PressOkButton()
        {
            aux.ControlClick(DELETEWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
        }

        private void PressDeleteButton()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
        }
       
        private void ChooseGroup(int numberGroup)
        {
            aux.ControlClick(GROUPWINTITLE, "", aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#" + numberGroup,""));
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");

            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();

        }
        

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54 ");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
                                        

            aux.WinWait(GROUPWINTITLE);
        }

        public void CheckThatGroupExist(string value)
        {
            OpenGroupsDialogue();
            
            string count = aux.ControlTreeView(WINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            if (int.Parse(count) < 1)
            {
                Add(new GroupData(value));
            }          
          
        }
    }
}